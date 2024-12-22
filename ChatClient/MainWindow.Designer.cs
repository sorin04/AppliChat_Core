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
            label3 = new Label();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericPort).BeginInit();
            statusBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)imageEnvoiPB).BeginInit();
            ((System.ComponentModel.ISupportInitialize)imageRecuPB).BeginInit();
            SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(562, 622);
            label3.Margin = new Padding(5, 0, 5, 0);
            label3.Name = "label3";
            label3.Size = new Size(67, 20);
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
            groupBox1.Location = new Point(16, 18);
            groupBox1.Margin = new Padding(5, 6, 5, 6);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(5, 6, 5, 6);
            groupBox1.Size = new Size(613, 126);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Configuration";
            // 
            // button1
            // 
            button1.Location = new Point(8, 86);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(86, 30);
            button1.TabIndex = 6;
            button1.Text = "Couleurs";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(249, 78);
            label4.Margin = new Padding(5, 0, 5, 0);
            label4.Name = "label4";
            label4.Size = new Size(48, 20);
            label4.TabIndex = 5;
            label4.Text = "Alias :";
            // 
            // textAlias
            // 
            textAlias.Location = new Point(328, 74);
            textAlias.Margin = new Padding(5, 6, 5, 6);
            textAlias.Name = "textAlias";
            textAlias.Size = new Size(132, 27);
            textAlias.TabIndex = 4;
            // 
            // buttonStop
            // 
            buttonStop.Location = new Point(473, 32);
            buttonStop.Margin = new Padding(5, 6, 5, 6);
            buttonStop.Name = "buttonStop";
            buttonStop.Size = new Size(101, 34);
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
            ipAddressControl1.Location = new Point(75, 32);
            ipAddressControl1.Margin = new Padding(5, 6, 5, 6);
            ipAddressControl1.Name = "ipAddressControl1";
            ipAddressControl1.Size = new Size(203, 30);
            ipAddressControl1.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(8, 38);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(58, 20);
            label2.TabIndex = 2;
            label2.Text = "Serveur";
            // 
            // numericPort
            // 
            numericPort.Location = new Point(357, 34);
            numericPort.Margin = new Padding(5, 6, 5, 6);
            numericPort.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            numericPort.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericPort.Name = "numericPort";
            numericPort.Size = new Size(104, 27);
            numericPort.TabIndex = 1;
            numericPort.TextAlign = HorizontalAlignment.Right;
            numericPort.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(303, 38);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(46, 20);
            label1.TabIndex = 1;
            label1.Text = "Port : ";
            // 
            // buttonStart
            // 
            buttonStart.Location = new Point(473, 32);
            buttonStart.Margin = new Padding(5, 6, 5, 6);
            buttonStart.Name = "buttonStart";
            buttonStart.Size = new Size(101, 34);
            buttonStart.TabIndex = 2;
            buttonStart.Text = "Start";
            buttonStart.UseVisualStyleBackColor = true;
            buttonStart.Click += buttonStart_Click;
            // 
            // afficher_dans_richMessages
            // 
            afficher_dans_richMessages.BackColor = SystemColors.ActiveCaption;
            afficher_dans_richMessages.Location = new Point(16, 152);
            afficher_dans_richMessages.Margin = new Padding(5, 6, 5, 6);
            afficher_dans_richMessages.Name = "afficher_dans_richMessages";
            afficher_dans_richMessages.ReadOnly = true;
            afficher_dans_richMessages.Size = new Size(613, 390);
            afficher_dans_richMessages.TabIndex = 1;
            afficher_dans_richMessages.Text = "";
            
            // 
            // textMessage
            // 
            textMessage.Enabled = false;
            textMessage.Location = new Point(0, 536);
            textMessage.Margin = new Padding(5, 6, 5, 6);
            textMessage.Multiline = true;
            textMessage.Name = "textMessage";
            textMessage.ScrollBars = ScrollBars.Both;
            textMessage.Size = new Size(529, 138);
            textMessage.TabIndex = 2;
            // 
            // buttonEnvoi
            // 
            buttonEnvoi.Enabled = false;
            buttonEnvoi.Location = new Point(554, 642);
            buttonEnvoi.Margin = new Padding(5, 6, 5, 6);
            buttonEnvoi.Name = "buttonEnvoi";
            buttonEnvoi.Size = new Size(75, 114);
            buttonEnvoi.TabIndex = 3;
            buttonEnvoi.Text = "Envoyer";
            buttonEnvoi.UseVisualStyleBackColor = true;
            buttonEnvoi.Click += buttonEnvoi_Click;
            // 
            // statusBar
            // 
            statusBar.ImageScalingSize = new Size(20, 20);
            statusBar.Items.AddRange(new ToolStripItem[] { statusBarInfo });
            statusBar.Location = new Point(0, 842);
            statusBar.Name = "statusBar";
            statusBar.Padding = new Padding(1, 0, 19, 0);
            statusBar.Size = new Size(996, 22);
            statusBar.TabIndex = 5;
            statusBar.Text = "statusStrip1";
            // 
            // statusBarInfo
            // 
            statusBarInfo.Name = "statusBarInfo";
            statusBarInfo.Size = new Size(0, 16);
            // 
            // button2
            // 
            button2.BackgroundImage = (Image)resources.GetObject("button2.BackgroundImage");
            button2.Location = new Point(539, 536);
            button2.Margin = new Padding(3, 4, 3, 4);
            button2.Name = "button2";
            button2.Size = new Size(90, 82);
            button2.TabIndex = 6;
            button2.Text = "Pièces_J";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // imageEnvoiPB
            // 
            imageEnvoiPB.Location = new Point(678, 30);
            imageEnvoiPB.Margin = new Padding(2);
            imageEnvoiPB.Name = "imageEnvoiPB";
            imageEnvoiPB.Size = new Size(308, 200);
            imageEnvoiPB.TabIndex = 7;
            imageEnvoiPB.TabStop = false;
            // 
            // groupBox2
            // 
            groupBox2.Location = new Point(678, 607);
            groupBox2.Margin = new Padding(2);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(2);
            groupBox2.Size = new Size(298, 214);
            groupBox2.TabIndex = 8;
            groupBox2.TabStop = false;
            groupBox2.Text = "Fichier_MP3_recu";
            
            // 
            // button3_Clear
            // 
            button3_Clear.Location = new Point(810, 234);
            button3_Clear.Margin = new Padding(2);
            button3_Clear.Name = "button3_Clear";
            button3_Clear.Size = new Size(90, 27);
            button3_Clear.TabIndex = 10;
            button3_Clear.Text = "Clear";
            button3_Clear.UseVisualStyleBackColor = true;
            button3_Clear.Click += button3_Clear_Click;
            // 
            // button3_EnvoyerImg
            // 
            button3_EnvoyerImg.Location = new Point(686, 234);
            button3_EnvoyerImg.Margin = new Padding(2);
            button3_EnvoyerImg.Name = "button3_EnvoyerImg";
            button3_EnvoyerImg.Size = new Size(90, 27);
            button3_EnvoyerImg.TabIndex = 11;
            button3_EnvoyerImg.Text = "Envoyer";
            button3_EnvoyerImg.UseVisualStyleBackColor = true;
            button3_EnvoyerImg.Click += button3_EnvoyerImg_Click;
            // 
            // imageRecuLabel
            // 
            imageRecuLabel.AutoSize = true;
            imageRecuLabel.Location = new Point(678, 301);
            imageRecuLabel.Name = "imageRecuLabel";
            imageRecuLabel.Size = new Size(111, 20);
            imageRecuLabel.TabIndex = 12;
            imageRecuLabel.Text = "Image received";
            // 
            // imageRecuPB
            // 
            imageRecuPB.Location = new Point(678, 333);
            imageRecuPB.Margin = new Padding(2);
            imageRecuPB.Name = "imageRecuPB";
            imageRecuPB.Size = new Size(308, 200);
            imageRecuPB.TabIndex = 13;
            imageRecuPB.TabStop = false;
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(996, 864);
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
            Margin = new Padding(5, 6, 5, 6);
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
    }
}

