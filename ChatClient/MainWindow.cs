using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OutilsChat;

namespace ChatClient
{
    public partial class MainWindow : Form
    {
        private GestionChat comm;
        private IniFile configFile;
        private Dictionary<int, Color> clients;
        private Color couleurChoisie = Color.Black;
        private byte[] imageData;

        public MainWindow()
        {
            InitializeComponent();
            comm = null;
            configFile = new IniFile(AppDomain.CurrentDomain.BaseDirectory + "config.ini");
            int port = configFile.ReadValue("Server", "Port", 18);
            String ipAddress = configFile.ReadValue("Server", "IPAddress", "127.0.0.1");
            String alias = configFile.ReadValue("User", "Alias", "JohnDoe");
            this.numericPort.Value = port;
            this.ipAddressControl1.IPAddress = ipAddress;
            this.textAlias.Text = alias;
            this.Text += " " + Constants.APP_VERSION;
            this.clients = new Dictionary<int, Color>();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (comm == null)
            {
                configFile = new IniFile(AppDomain.CurrentDomain.BaseDirectory + "config.ini");
                configFile.WriteValue("Server", "Port", (int)this.numericPort.Value);
                configFile.WriteValue("Server", "IPAddress", this.ipAddressControl1.IPAddress);
                configFile.WriteValue("User", "Alias", this.textAlias.Text);

                this.comm = new GestionChat(this.ipAddressControl1.IPAddress, (int)this.numericPort.Value, this.textAlias.Text);
                this.comm.OnMessageReceived += new OnMessageReceived(this.OnMessageReceived);
                this.comm.OnClientDisconnected += new OnClientDisconnected(this.OnClientDisconnected);
                this.comm.Start();

                if (this.comm.Connected)
                {
                    this.ipAddressControl1.Enabled = false;
                    this.numericPort.Enabled = false;
                    this.textAlias.Enabled = false;
                    this.buttonStart.Visible = false;
                    this.buttonStop.Visible = true;
                    this.textMessage.Enabled = true;
                    this.buttonEnvoi.Enabled = true;
                    this.AfficherInfo("Connection sur " + this.ipAddressControl1.IPAddress + ":" + this.numericPort.Value + ".");
                }
                else
                {
                    this.AfficherErreur("Erreur de connection sur " + this.ipAddressControl1.IPAddress + ":" + this.numericPort.Value + ".");
                    this.comm = null;
                }
            }
        }

        private void OnClientDisconnected(GestionChat sender)
        {
            this.Invoke((OnClientDisconnected)this.DoClientDisconnected, new object[] { sender });
        }

        private void DoClientDisconnected(GestionChat sender)
        {
            this.ipAddressControl1.Enabled = true;
            this.numericPort.Enabled = true;
            this.textAlias.Enabled = true;
            this.buttonStart.Visible = true;
            this.buttonStop.Visible = false;
            this.textMessage.Enabled = false;
            this.buttonEnvoi.Enabled = false;
            this.comm.Stop();
            this.comm = null;
        }

        private void OnMessageReceived(GestionChat sender, OutilsChat.Message message)
        {
            this.Invoke((OnMessageReceived)this.DoMessageReceived, new object[] { sender, message });
        }

        private void DoMessageReceived(GestionChat sender, OutilsChat.Message message)
        {
            if (!this.clients.ContainsKey(message.Id))
            {
                this.clients[message.Id] = RandomColor();
            }
            if (message.Texte.StartsWith("FILE|image|"))
            {
                try
                {
                    string base64Data = message.Texte.Split('|')[2];
                    byte[] imageData = Convert.FromBase64String(base64Data);
                    

                }
                catch (Exception ex)
                {
                    AfficherErreur($"Erreur lors de la réception de l'image : {ex.Message}");
                }
            }
            else
            {
                AjoutMessage(message, this.clients[message.Id]);

            }
        }

        private void AjoutMessage(OutilsChat.Message msg, Color clr)
        {
            int beforeAppend = this.afficher_dans_richMessages.TextLength;
            this.afficher_dans_richMessages.AppendText(msg.Param1 + " - " + DateTime.Now.ToString() + Environment.NewLine);
            int afterAppend = this.afficher_dans_richMessages.TextLength;
            this.afficher_dans_richMessages.Select(beforeAppend, afterAppend - beforeAppend);
            this.afficher_dans_richMessages.SelectionColor = clr;
            this.afficher_dans_richMessages.SelectionFont = new Font(this.afficher_dans_richMessages.SelectionFont, FontStyle.Bold);

            beforeAppend = this.afficher_dans_richMessages.TextLength;
            this.afficher_dans_richMessages.AppendText(msg.Texte + Environment.NewLine);
            afterAppend = this.afficher_dans_richMessages.TextLength;
            this.afficher_dans_richMessages.Select(beforeAppend, afterAppend - beforeAppend);
            this.afficher_dans_richMessages.SelectionColor = clr;
        }

        private Color RandomColor()
        {
            Random randomGen = new Random((int)DateTime.Now.Ticks);
            KnownColor[] names = (KnownColor[])Enum.GetValues(typeof(KnownColor));
            KnownColor randomColorName = names[randomGen.Next(names.Length)];
            return Color.FromKnownColor(randomColorName);
        }

        private void AfficherErreur(string msg)
        {
            this.statusBarInfo.ForeColor = Color.Red;
            this.statusBarInfo.Text = msg;
        }

        private void AfficherInfo(string info)
        {
            this.statusBarInfo.ForeColor = Color.Black;
            this.statusBarInfo.Text = info;
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (comm != null)
            {
                this.comm.OnClientDisconnected = null;
                this.comm.Stop();
            }
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            if (comm != null)
            {
                this.comm.Stop();
            }
        }

        private void buttonEnvoi_Click(object sender, EventArgs e)
        {
            string messageText = this.textMessage.Text;
            if (string.IsNullOrWhiteSpace(messageText)) return;
            string colorRGB = $"{couleurChoisie.R},{couleurChoisie.G},{couleurChoisie.B}";
            string fullMessage = messageText;
            this.comm.Ecrire(fullMessage);
            OutilsChat.Message newMessage = new OutilsChat.Message(0, messageText);
            this.AjoutMessage(newMessage, couleurChoisie);
            this.textMessage.Clear();

            /*string messageText = this.textMessage.Text;
            if (string.IsNullOrWhiteSpace(messageText)) return;

            string colorRGB = $"{couleurChoisie.R},{couleurChoisie.G},{couleurChoisie.B}";
            string fullMessage = messageText;
            this.comm.Ecrire(fullMessage);

            OutilsChat.Message newMessage = new OutilsChat.Message(0, this.textMessage.Text);
            newMessage.Envoi(this.textAlias.Text);
            this.AjoutMessage(newMessage, couleurChoisie);
            this.textMessage.Clear();*/

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                couleurChoisie = colorDialog.Color;
                button1.BackColor = couleurChoisie;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Images (*.jpg; *.jpeg; *.png; *.gif)|*.jpg;*.jpeg;*.png;*.gif|MP3 Files (*.mp3)|*.mp3|All Files (*.*)|*.*";
            openFileDialog.Title = "Sélectionner un fichier";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                byte[] fileData = File.ReadAllBytes(filePath);
                string fileType = obtenirTypeFichier(filePath);

                if (fileType == "image")
                {
                    DisplayImage(fileData);

                }
                else
                {
                    AfficherErreur("Seul les fichiers image peuvent être sélectionnés.");
                }
            }
        }

        private string obtenirTypeFichier(string filePath)
        {
            string extension = Path.GetExtension(filePath).ToLower();

            if (extension == ".jpg" || extension == ".jpeg" || extension == ".png" || extension == ".gif")
                return "image";
            else if (extension == ".mp3")
                return "mp3";
            else
                return "inconnu";
        }

        private string EnvoyerFichierAuServeur(byte[] fileData, string fileType)
        {
            if (comm != null)
            {
                try
                {
                    string base64File = Convert.ToBase64String(fileData);
                    string fileMessage = $"FILE|{fileType}|{base64File}";
                    this.comm.Ecrire(fileMessage);

                    OutilsChat.Message msg = new OutilsChat.Message(0, "Fichier envoyé : " + fileType);
                    this.AjoutMessage(msg, couleurChoisie);

                    return "Fichier envoyé avec succès.";
                }
                catch (Exception ex)
                {
                    return $"Erreur lors de l'envoi du fichier : {ex.Message}";
                }
            }
            else
            {
                return "Vous n'êtes pas connecté au serveur !";
            }
        }

        private void DisplayImage(byte[] imageData)
        {
            using (MemoryStream ms = new MemoryStream(imageData))
            {
                Image img = Image.FromStream(ms);
                pictureBox1.Image = img;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void button3_Envoyer_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
                    byte[] imageData = ms.ToArray();
                    EnvoyerFichierAuServeur(imageData, "image");

                    OutilsChat.Message newMessage = new OutilsChat.Message(0, "Image envoyée");
                    this.AjoutMessage(newMessage, couleurChoisie);
                    pictureBox1.Image = null;
                }
            }
            else
            {
                AfficherErreur("Aucune image à envoyer.");
            }
        }

        private void button3_Clear_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                pictureBox1.Image = null;
                AfficherInfo("L'image a été supprimée.");
            }
            else
            {
                AfficherErreur("Aucune image à supprimer.");
            }
        }



        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void richMessages_TextChanged(object sender, EventArgs e)
        {
            if (imageData == null || imageData.Length == 0)
            {
                AfficherErreur("Les données de l'image sont invalides !");
                return;
            }
            try
            {
                using (MemoryStream ms = new MemoryStream(imageData))
                {
                    Image image = Image.FromStream(ms);
                    int width = 100;
                    int height = 100;
                    Image resizedImage = new Bitmap(image, new Size(width, height));
                    Clipboard.SetImage(resizedImage);
                    if (Clipboard.ContainsImage())
                    {
                        afficher_dans_richMessages.Paste();
                    }
                    else
                    {
                        AfficherErreur("Impossible d'insérer l'image dans la boîte de messages.");
                    }

                }




            }
            catch (Exception ex)
            {
                AfficherErreur($"Erreur lors de l'ajout de l'image : {ex.Message}");
            }
        }

        private void button3_EnvoyerImg_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image!=null)
            {
                try
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
                        byte[] imageData = ms.ToArray();
                        string messageReponse = EnvoyerFichierAuServeur(imageData, "image");
                        MessageBox.Show($"Réponse du serveur : {messageReponse}", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        EnvoyerFichierAuServeur(imageData, "image");


                    }

                }
                catch(Exception ex) 
                {
                    MessageBox.Show($"Erreur lors de l'envoi de l'image : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);


                }
            }
            else
                {
                    MessageBox.Show("Veuillez charger une image avant d'envoyer.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

        /*private void DessinerImageDansRichTextBox(Image image)
        {
            
            using (Graphics g = afficher_dans_richMessages.CreateGraphics())
            {
                
                Point location = new Point(0, afficher_dans_richMessages.TextLength);

                
                g.DrawImage(image, location);
            }
        }*/

    }
    }



