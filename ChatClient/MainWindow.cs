using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ImageMagick;
using ImageMagick.Formats;
using OutilsChat;
using SkiaSharp;
using static System.Net.Mime.MediaTypeNames;

namespace ChatClient
{
    public partial class MainWindow : Form
    {
        private GestionChat comm;
        private IniFile configFile;
        private Dictionary<int, Color> clients;
        private Color couleurChoisie = Color.Black;
        private byte[] imageData;
        private string fileName;
        private string outputPathCompressed;

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
            this.imageRecuLabel.Visible = false;
            this.imageRecuPB.Visible = false;
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
            
            if (message.imageData != null)
            {
                try
                {
                    String imageRecuChemin = $"image{Guid.NewGuid()}.png";
                    File.WriteAllBytes(imageRecuChemin, message.imageData);
                    imageRecuLabel.Visible = true;
                    imageRecuPB.Visible = true;

                    imageRecuPB.Image = System.Drawing.Image.FromFile(imageRecuChemin);
                    imageRecuPB.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erreur lors de la réception de l'image : {ex.Message}");
                }
            }

            this.AjoutMessage(message, couleurChoisie);
        }

        private void AjoutMessage(OutilsChat.Message msg, Color clr)
        {
            int beforeAppend = this.afficher_dans_richMessages.TextLength;
            this.afficher_dans_richMessages.AppendText(msg.Param1 + " - " + DateTime.Now.ToString() + Environment.NewLine);
            int afterAppend = this.afficher_dans_richMessages.TextLength;
            this.afficher_dans_richMessages.Select(beforeAppend, afterAppend - beforeAppend);
            this.afficher_dans_richMessages.SelectionColor = clr;
            this.afficher_dans_richMessages.SelectionFont = new System.Drawing.Font(this.afficher_dans_richMessages.SelectionFont, FontStyle.Bold);

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
            newMessage.Envoi(this.textAlias.Text);
            this.AjoutMessage(newMessage, couleurChoisie);
            this.textMessage.Clear();
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
                fileName = openFileDialog.SafeFileName;
               
                outputPathCompressed = CompressImage(filePath, 200, 200, 50);

                byte[] fileData = File.ReadAllBytes(outputPathCompressed);
                string fileType = obtenirTypeFichier(outputPathCompressed);

                
                if (fileType == "image")
                {
                    DisplayImage(fileData);

                }
                else
                {
                    MessageBox.Show("Seul les fichiers image peuvent être sélectionnés.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
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


        private void DisplayImage(byte[] imageData)
        {
            using (MemoryStream ms = new MemoryStream(imageData))
            {
                System.Drawing.Image img = System.Drawing.Image.FromStream(ms);
                imageEnvoiPB.Image = img;
                imageEnvoiPB.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void button3_Clear_Click(object sender, EventArgs e)
        {
            if (imageEnvoiPB.Image != null)
            {
                imageEnvoiPB.Image = null;
                MessageBox.Show("L'image a été supprimée.");
            }
            else
            {
                MessageBox.Show("Aucune image à supprimer.");
            }
        }

        private void button3_EnvoyerImg_Click(object sender, EventArgs e)
        {
            if (imageEnvoiPB.Image != null)
            {
                try
                {
                    imageData = ConvertImageToBytes(imageEnvoiPB.Image);
                    
                    this.textMessage.Text = this.textAlias.Text + " send " + "an image: " + fileName;
                    string messageText = this.textMessage.Text;
                        
                    if (string.IsNullOrWhiteSpace(messageText))
                    {

                        messageText = "J'envoie une image";
                    }

                    string colorRGB = $"{couleurChoisie.R},{couleurChoisie.G},{couleurChoisie.B}";
                    this.comm.Ecrire(messageText, imageData);
                        

                    OutilsChat.Message newMessage = new OutilsChat.Message(0, messageText);
                    newMessage.Envoi(this.textAlias.Text);
                    this.AjoutMessage(newMessage, couleurChoisie);
                    this.textMessage.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erreur lors de l'envoi de l'image : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Veuillez charger une image avant d'envoyer.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public static byte[] ConvertImageToBytes(System.Drawing.Image image)
        {
            if (image == null)
                throw new ArgumentNullException(nameof(image));

            using (MemoryStream memoryStream = new MemoryStream())
            {
                image.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);
                return memoryStream.ToArray();
            }
        }

        public string CompressImage(string inputPath, int newWidth, int newHeight, long quality)
        {
            using (System.Drawing.Image originalImage = System.Drawing.Image.FromFile(inputPath))
            {
                
                using (Bitmap resizedImage = new Bitmap(newWidth, newHeight))
                {
                    using (Graphics graphics = Graphics.FromImage(resizedImage))
                    {
                        graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                        graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                        graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

                        
                        graphics.DrawImage(originalImage, 0, 0, newWidth, newHeight);
                    }

                    
                    ImageCodecInfo pngEncoder = GetEncoder(ImageFormat.Png);
                    EncoderParameters encoderParameters = new EncoderParameters(1);
                    encoderParameters.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);
                    string output = $"compressed{Guid.NewGuid()}.png";
                    
                    resizedImage.Save(output, pngEncoder, encoderParameters);

                    return output;
                }
            }
        }

        public ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }
    }
}