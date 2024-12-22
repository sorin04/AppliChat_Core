namespace ChatClient
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Label label3;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            groupBox1 = new GroupBox();
            button1 = new Button();
            label4 = new Label();
            textAlias = new TextBox();
            buttonStop = new Button();
            ipAddressControl1 = new OutilsChat.IPAddressControl();
            label2 = new Label();
            numericPort = new NumericUpDown();
            label1 = new Label();
            buttonStart = new Button();
            afficher_dans_richMessages = new RichTextBox();
            textMessage = new TextBox();
            buttonEnvoi = new Button();
            statusBar = new StatusStrip();
            statusBarInfo = new ToolStripStatusLabel();
            button2 = new Button();
            imageEnvoiPB = new PictureBox();
            groupBox2 = new GroupBox();
            button3_Clear = new Button();
            button3_EnvoyerImg = new Button();
            imageRecuLabel = new Label();
            imageRecuPB = new PictureBox();
            button_Play = new Button();
            button_Stop = new Button();
            button_EnvoyerMP3 = new Button();
            label3 = new Label();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericPort).BeginInit();
            statusBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)imageEnvoiPB).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)imageRecuPB).BeginInit();
            SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(492, 466);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(53, 15);
            label3.TabIndex = 4;
            label3.Text = "Message";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(textAlias);
            groupBox1.Controls.Add(buttonStop);
            groupBox1.Controls.Add(ipAddressControl1);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(numericPort);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(buttonStart);
            groupBox1.Location = new Point(14, 14);
            groupBox1.Margin = new Padding(4, 4, 4, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4, 4, 4, 4);
            groupBox1.Size = new Size(536, 94);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Configuration";
            // 
            // button1
            // 
            button1.Location = new Point(7, 64);
            button1.Name = "button1";
            button1.Size = new Size(75, 22);
            button1.TabIndex = 6;
            button1.Text = "Couleurs";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(218, 58);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(38, 15);
            label4.TabIndex = 5;
            label4.Text = "Alias :";
            // 
            // textAlias
            // 
            textAlias.Location = new Point(287, 56);
            textAlias.Margin = new Padding(4, 4, 4, 4);
            textAlias.Name = "textAlias";
            textAlias.Size = new Size(116, 23);
            textAlias.TabIndex = 4;
            // 
            // buttonStop
            // 
            buttonStop.Location = new Point(414, 24);
            buttonStop.Margin = new Padding(4, 4, 4, 4);
            buttonStop.Name = "buttonStop";
            buttonStop.Size = new Size(88, 26);
            buttonStop.TabIndex = 3;
            buttonStop.Text = "Stop";
            buttonStop.UseVisualStyleBackColor = true;
            buttonStop.Visible = false;
            buttonStop.Click += buttonStop_Click;
            // 
            // ipAddressControl1
            // 
            ipAddressControl1.BackColor = SystemColors.Control;
            ipAddressControl1.IPAddress = "0.0.0.0";
            ipAddressControl1.IsSubnetMask = false;
            ipAddressControl1.Location = new Point(66, 24);
            ipAddressControl1.Margin = new Padding(4, 4, 4, 4);
            ipAddressControl1.Name = "ipAddressControl1";
            ipAddressControl1.Size = new Size(178, 22);
            ipAddressControl1.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(7, 28);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(46, 15);
            label2.TabIndex = 2;
            label2.Text = "Serveur";
            // 
            // numericPort
            // 
            numericPort.Location = new Point(312, 26);
            numericPort.Margin = new Padding(4, 4, 4, 4);
            numericPort.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            numericPort.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericPort.Name = "numericPort";
            numericPort.Size = new Size(91, 23);
            numericPort.TabIndex = 1;
            numericPort.TextAlign = HorizontalAlignment.Right;
            numericPort.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(265, 28);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 1;
            label1.Text = "Port : ";
            // 
            // buttonStart
            // 
            buttonStart.Location = new Point(414, 24);
            buttonStart.Margin = new Padding(4, 4, 4, 4);
            buttonStart.Name = "buttonStart";
            buttonStart.Size = new Size(88, 26);
            buttonStart.TabIndex = 2;
            buttonStart.Text = "Start";
            buttonStart.UseVisualStyleBackColor = true;
            buttonStart.Click += buttonStart_Click;
            // 
            // afficher_dans_richMessages
            // 
            afficher_dans_richMessages.BackColor = SystemColors.ActiveCaption;
            afficher_dans_richMessages.Location = new Point(14, 114);
            afficher_dans_richMessages.Margin = new Padding(4, 4, 4, 4);
            afficher_dans_richMessages.Name = "afficher_dans_richMessages";
            afficher_dans_richMessages.ReadOnly = true;
            afficher_dans_richMessages.Size = new Size(537, 294);
            afficher_dans_richMessages.TabIndex = 1;
            afficher_dans_richMessages.Text = "";
            // 
            // textMessage
            // 
            textMessage.Enabled = false;
            textMessage.Location = new Point(0, 482);
            textMessage.Margin = new Padding(4, 4, 4, 4);
            textMessage.Multiline = true;
            textMessage.Name = "textMessage";
            textMessage.ScrollBars = ScrollBars.Both;
            textMessage.Size = new Size(463, 104);
            textMessage.TabIndex = 2;
            // 
            // buttonEnvoi
            // 
            buttonEnvoi.Enabled = false;
            buttonEnvoi.Location = new Point(479, 500);
            buttonEnvoi.Margin = new Padding(4, 4, 4, 4);
            buttonEnvoi.Name = "buttonEnvoi";
            buttonEnvoi.Size = new Size(66, 86);
            buttonEnvoi.TabIndex = 3;
            buttonEnvoi.Text = "Envoyer";
            buttonEnvoi.UseVisualStyleBackColor = true;
            buttonEnvoi.Click += buttonEnvoi_Click;
            // 
            // statusBar
            // 
            statusBar.ImageScalingSize = new Size(20, 20);
            statusBar.Items.AddRange(new ToolStripItem[] { statusBarInfo });
            statusBar.Location = new Point(0, 626);
            statusBar.Name = "statusBar";
            statusBar.Padding = new Padding(1, 0, 17, 0);
            statusBar.Size = new Size(872, 22);
            statusBar.TabIndex = 5;
            statusBar.Text = "statusStrip1";
            // 
            // statusBarInfo
            // 
            statusBarInfo.Name = "statusBarInfo";
            statusBarInfo.Size = new Size(0, 17);
            // 
            // button2
            // 
            button2.BackgroundImage = (Image)resources.GetObject("button2.BackgroundImage");
            button2.Location = new Point(471, 415);
            button2.Name = "button2";
            button2.Size = new Size(79, 62);
            button2.TabIndex = 6;
            button2.Text = "Pièces_J";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // imageEnvoiPB
            // 
            imageEnvoiPB.Location = new Point(593, 22);
            imageEnvoiPB.Margin = new Padding(2);
            imageEnvoiPB.Name = "imageEnvoiPB";
            imageEnvoiPB.Size = new Size(270, 150);
            imageEnvoiPB.TabIndex = 7;
            imageEnvoiPB.TabStop = false;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(button_EnvoyerMP3);
            groupBox2.Controls.Add(button_Stop);
            groupBox2.Controls.Add(button_Play);
            groupBox2.Location = new Point(593, 455);
            groupBox2.Margin = new Padding(2);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(2);
            groupBox2.Size = new Size(261, 160);
            groupBox2.TabIndex = 8;
            groupBox2.TabStop = false;
            groupBox2.Text = "Fichier_MP3_recu";
            groupBox2.Enter += groupBox2_Enter;
            // 
            // button3_Clear
            // 
            button3_Clear.Location = new Point(709, 176);
            button3_Clear.Margin = new Padding(2);
            button3_Clear.Name = "button3_Clear";
            button3_Clear.Size = new Size(79, 20);
            button3_Clear.TabIndex = 10;
            button3_Clear.Text = "Clear";
            button3_Clear.UseVisualStyleBackColor = true;
            button3_Clear.Click += button3_Clear_Click;
            // 
            // button3_EnvoyerImg
            // 
            button3_EnvoyerImg.Location = new Point(600, 176);
            button3_EnvoyerImg.Margin = new Padding(2);
            button3_EnvoyerImg.Name = "button3_EnvoyerImg";
            button3_EnvoyerImg.Size = new Size(79, 20);
            button3_EnvoyerImg.TabIndex = 11;
            button3_EnvoyerImg.Text = "Envoyer";
            button3_EnvoyerImg.UseVisualStyleBackColor = true;
            button3_EnvoyerImg.Click += button3_EnvoyerImg_Click;
            // 
            // imageRecuLabel
            // 
            imageRecuLabel.AutoSize = true;
            imageRecuLabel.Location = new Point(593, 226);
            imageRecuLabel.Name = "imageRecuLabel";
            imageRecuLabel.Size = new Size(87, 15);
            imageRecuLabel.TabIndex = 12;
            imageRecuLabel.Text = "Image received";
            // 
            // imageRecuPB
            // 
            imageRecuPB.Location = new Point(593, 250);
            imageRecuPB.Margin = new Padding(2);
            imageRecuPB.Name = "imageRecuPB";
            imageRecuPB.Size = new Size(270, 150);
            imageRecuPB.TabIndex = 13;
            imageRecuPB.TabStop = false;
            // 
            // button_Play
            // 
            button_Play.Location = new Point(12, 103);
            button_Play.Name = "button_Play";
            button_Play.Size = new Size(75, 23);
            button_Play.TabIndex = 0;
            button_Play.Text = "Play";
            button_Play.UseVisualStyleBackColor = true;
            // 
            // button_Stop
            // 
            button_Stop.Location = new Point(93, 103);
            button_Stop.Name = "button_Stop";
            button_Stop.Size = new Size(75, 23);
            button_Stop.TabIndex = 1;
            button_Stop.Text = "Stop";
            button_Stop.UseVisualStyleBackColor = true;
            // 
            // button_EnvoyerMP3
            // 
            button_EnvoyerMP3.Location = new Point(12, 132);
            button_EnvoyerMP3.Name = "button_EnvoyerMP3";
            button_EnvoyerMP3.Size = new Size(75, 23);
            button_EnvoyerMP3.TabIndex = 2;
            button_EnvoyerMP3.Text = "EnvoyerMP3      ";
            button_EnvoyerMP3.UseVisualStyleBackColor = true;
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(872, 648);
            Controls.Add(imageRecuPB);
            Controls.Add(imageRecuLabel);
            Controls.Add(button3_EnvoyerImg);
            Controls.Add(button3_Clear);
            Controls.Add(groupBox2);
            Controls.Add(imageEnvoiPB);
            Controls.Add(button2);
            Controls.Add(statusBar);
            Controls.Add(buttonEnvoi);
            Controls.Add(label3);
            Controls.Add(textMessage);
            Controls.Add(afficher_dans_richMessages);
            Controls.Add(groupBox1);
            Margin = new Padding(4, 4, 4, 4);
            MaximizeBox = false;
            Name = "MainWindow";
            Text = "Client de Tchatche";
            FormClosing += MainWindow_FormClosing;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericPort).EndInit();
            statusBar.ResumeLayout(false);
            statusBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)imageEnvoiPB).EndInit();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)imageRecuPB).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown numericPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Label label2;
        private OutilsChat.IPAddressControl ipAddressControl1;
        private System.Windows.Forms.RichTextBox afficher_dans_richMessages;
        private System.Windows.Forms.TextBox textMessage;
        private System.Windows.Forms.Button buttonEnvoi;
        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.ToolStripStatusLabel statusBarInfo;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textAlias;
        private Button button1;
        private Button button2;
        private PictureBox imageEnvoiPB;
        private GroupBox groupBox2;
        private Button button3_Clear;
        private Button button3_EnvoyerImg;
        private Label imageRecuLabel;
        private PictureBox imageRecuPB;
        private Button button_Stop;
        private Button button_Play;
        private Button button_EnvoyerMP3;
    }
}

