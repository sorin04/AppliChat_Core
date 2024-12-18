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
            richMessages = new RichTextBox();
            textMessage = new TextBox();
            buttonEnvoi = new Button();
            statusBar = new StatusStrip();
            statusBarInfo = new ToolStripStatusLabel();
            button2 = new Button();
            pictureBox1 = new PictureBox();
            groupBox2 = new GroupBox();
            button3_Envoyer = new Button();
            button3_Clear = new Button();
            label3 = new Label();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericPort).BeginInit();
            statusBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(704, 757);
            label3.Margin = new Padding(6, 0, 6, 0);
            label3.Name = "label3";
            label3.Size = new Size(82, 25);
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
            groupBox1.Location = new Point(20, 23);
            groupBox1.Margin = new Padding(6, 7, 6, 7);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(6, 7, 6, 7);
            groupBox1.Size = new Size(766, 157);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Configuration";
            // 
            // button1
            // 
            button1.Location = new Point(10, 107);
            button1.Margin = new Padding(4, 5, 4, 5);
            button1.Name = "button1";
            button1.Size = new Size(107, 38);
            button1.TabIndex = 6;
            button1.Text = "Couleurs";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(311, 98);
            label4.Margin = new Padding(6, 0, 6, 0);
            label4.Name = "label4";
            label4.Size = new Size(58, 25);
            label4.TabIndex = 5;
            label4.Text = "Alias :";
            // 
            // textAlias
            // 
            textAlias.Location = new Point(410, 92);
            textAlias.Margin = new Padding(6, 7, 6, 7);
            textAlias.Name = "textAlias";
            textAlias.Size = new Size(164, 31);
            textAlias.TabIndex = 4;
            // 
            // buttonStop
            // 
            buttonStop.Location = new Point(591, 40);
            buttonStop.Margin = new Padding(6, 7, 6, 7);
            buttonStop.Name = "buttonStop";
            buttonStop.Size = new Size(126, 43);
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
            ipAddressControl1.Location = new Point(94, 40);
            ipAddressControl1.Margin = new Padding(6, 8, 6, 8);
            ipAddressControl1.Name = "ipAddressControl1";
            ipAddressControl1.Size = new Size(254, 38);
            ipAddressControl1.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(10, 47);
            label2.Margin = new Padding(6, 0, 6, 0);
            label2.Name = "label2";
            label2.Size = new Size(71, 25);
            label2.TabIndex = 2;
            label2.Text = "Serveur";
            // 
            // numericPort
            // 
            numericPort.Location = new Point(446, 42);
            numericPort.Margin = new Padding(6, 7, 6, 7);
            numericPort.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            numericPort.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericPort.Name = "numericPort";
            numericPort.Size = new Size(130, 31);
            numericPort.TabIndex = 1;
            numericPort.TextAlign = HorizontalAlignment.Right;
            numericPort.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(379, 47);
            label1.Margin = new Padding(6, 0, 6, 0);
            label1.Name = "label1";
            label1.Size = new Size(58, 25);
            label1.TabIndex = 1;
            label1.Text = "Port : ";
            // 
            // buttonStart
            // 
            buttonStart.Location = new Point(591, 40);
            buttonStart.Margin = new Padding(6, 7, 6, 7);
            buttonStart.Name = "buttonStart";
            buttonStart.Size = new Size(126, 43);
            buttonStart.TabIndex = 2;
            buttonStart.Text = "Start";
            buttonStart.UseVisualStyleBackColor = true;
            buttonStart.Click += buttonStart_Click;
            // 
            // richMessages
            // 
            richMessages.BackColor = SystemColors.ActiveCaption;
            richMessages.Location = new Point(20, 190);
            richMessages.Margin = new Padding(6, 7, 6, 7);
            richMessages.Name = "richMessages";
            richMessages.ReadOnly = true;
            richMessages.Size = new Size(765, 487);
            richMessages.TabIndex = 1;
            richMessages.Text = "";
            richMessages.TextChanged += richMessages_TextChanged;
            // 
            // textMessage
            // 
            textMessage.Enabled = false;
            textMessage.Location = new Point(20, 757);
            textMessage.Margin = new Padding(6, 7, 6, 7);
            textMessage.Multiline = true;
            textMessage.Name = "textMessage";
            textMessage.ScrollBars = ScrollBars.Both;
            textMessage.Size = new Size(660, 171);
            textMessage.TabIndex = 2;
            // 
            // buttonEnvoi
            // 
            buttonEnvoi.Enabled = false;
            buttonEnvoi.Location = new Point(694, 787);
            buttonEnvoi.Margin = new Padding(6, 7, 6, 7);
            buttonEnvoi.Name = "buttonEnvoi";
            buttonEnvoi.Size = new Size(94, 143);
            buttonEnvoi.TabIndex = 3;
            buttonEnvoi.Text = "Envoyer";
            buttonEnvoi.UseVisualStyleBackColor = true;
            buttonEnvoi.Click += buttonEnvoi_Click;
            // 
            // statusBar
            // 
            statusBar.ImageScalingSize = new Size(20, 20);
            statusBar.Items.AddRange(new ToolStripItem[] { statusBarInfo });
            statusBar.Location = new Point(0, 971);
            statusBar.Name = "statusBar";
            statusBar.Padding = new Padding(1, 0, 24, 0);
            statusBar.Size = new Size(1245, 22);
            statusBar.TabIndex = 5;
            statusBar.Text = "statusStrip1";
            // 
            // statusBarInfo
            // 
            statusBarInfo.Name = "statusBarInfo";
            statusBarInfo.Size = new Size(0, 15);
            // 
            // button2
            // 
            button2.BackgroundImage = (Image)resources.GetObject("button2.BackgroundImage");
            button2.Location = new Point(704, 679);
            button2.Margin = new Padding(4, 5, 4, 5);
            button2.Name = "button2";
            button2.Size = new Size(89, 79);
            button2.TabIndex = 6;
            button2.Text = "Pièces_J";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(848, 37);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(385, 250);
            pictureBox1.TabIndex = 7;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // groupBox2
            // 
            groupBox2.Location = new Point(839, 505);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(372, 268);
            groupBox2.TabIndex = 8;
            groupBox2.TabStop = false;
            groupBox2.Text = "Fichier_MP3_recu";
            groupBox2.Enter += groupBox2_Enter;
            // 
            // button3_Envoyer
            // 
            button3_Envoyer.Location = new Point(848, 293);
            button3_Envoyer.Name = "button3_Envoyer";
            button3_Envoyer.Size = new Size(112, 34);
            button3_Envoyer.TabIndex = 9;
            button3_Envoyer.Text = "Envoyer";
            button3_Envoyer.UseVisualStyleBackColor = true;
            button3_Envoyer.Click += button3_Envoyer_Click;
            // 
            // button3_Clear
            // 
            button3_Clear.Location = new Point(1012, 293);
            button3_Clear.Name = "button3_Clear";
            button3_Clear.Size = new Size(112, 34);
            button3_Clear.TabIndex = 10;
            button3_Clear.Text = "Clear";
            button3_Clear.UseVisualStyleBackColor = true;
            button3_Clear.Click += button3_Click;
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1245, 993);
            Controls.Add(button3_Clear);
            Controls.Add(button3_Envoyer);
            Controls.Add(groupBox2);
            Controls.Add(pictureBox1);
            Controls.Add(button2);
            Controls.Add(statusBar);
            Controls.Add(buttonEnvoi);
            Controls.Add(label3);
            Controls.Add(textMessage);
            Controls.Add(richMessages);
            Controls.Add(groupBox1);
            Margin = new Padding(6, 7, 6, 7);
            MaximizeBox = false;
            Name = "MainWindow";
            Text = "Client de Tchatche";
            FormClosing += MainWindow_FormClosing;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericPort).EndInit();
            statusBar.ResumeLayout(false);
            statusBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
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
        private System.Windows.Forms.RichTextBox richMessages;
        private System.Windows.Forms.TextBox textMessage;
        private System.Windows.Forms.Button buttonEnvoi;
        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.ToolStripStatusLabel statusBarInfo;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textAlias;
        private Button button1;
        private Button button2;
        private PictureBox pictureBox1;
        private GroupBox groupBox2;
        private Button button3_Envoyer;
        private Button button3_Clear;
    }
}

