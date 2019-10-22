namespace WindowsFormsAppKM
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.buttonStart = new System.Windows.Forms.Button();
            this.comboBoxPlayMethod = new System.Windows.Forms.ComboBox();
            this.buttonPause = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonFile = new System.Windows.Forms.Button();
            this.labelSelectedFile = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.textBoxSelectedFile = new System.Windows.Forms.TextBox();
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(16, 146);
            this.buttonStart.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(257, 80);
            this.buttonStart.TabIndex = 0;
            this.buttonStart.Text = "START";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // comboBoxPlayMethod
            // 
            this.comboBoxPlayMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPlayMethod.FormattingEnabled = true;
            this.comboBoxPlayMethod.Items.AddRange(new object[] {
            "Play Sound",
            "Windows Media Player (WMP)",
            "MCI",
            "Direct Sound"});
            this.comboBoxPlayMethod.Location = new System.Drawing.Point(16, 105);
            this.comboBoxPlayMethod.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBoxPlayMethod.Name = "comboBoxPlayMethod";
            this.comboBoxPlayMethod.Size = new System.Drawing.Size(787, 33);
            this.comboBoxPlayMethod.TabIndex = 1;
            this.comboBoxPlayMethod.SelectedIndexChanged += new System.EventHandler(this.ComboBoxPlayMethod_SelectedIndexChanged);
            // 
            // buttonPause
            // 
            this.buttonPause.Location = new System.Drawing.Point(281, 146);
            this.buttonPause.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonPause.Name = "buttonPause";
            this.buttonPause.Size = new System.Drawing.Size(257, 80);
            this.buttonPause.TabIndex = 2;
            this.buttonPause.Text = "PAUSE";
            this.buttonPause.UseVisualStyleBackColor = true;
            this.buttonPause.Click += new System.EventHandler(this.ButtonPause_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(546, 146);
            this.buttonStop.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(257, 80);
            this.buttonStop.TabIndex = 3;
            this.buttonStop.Text = "STOP";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.ButtonStop_Click);
            // 
            // buttonFile
            // 
            this.buttonFile.Location = new System.Drawing.Point(13, 13);
            this.buttonFile.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonFile.Name = "buttonFile";
            this.buttonFile.Size = new System.Drawing.Size(788, 40);
            this.buttonFile.TabIndex = 4;
            this.buttonFile.Text = "Select File";
            this.buttonFile.UseVisualStyleBackColor = true;
            this.buttonFile.Click += new System.EventHandler(this.buttonFile_Click);
            // 
            // labelSelectedFile
            // 
            this.labelSelectedFile.AutoSize = true;
            this.labelSelectedFile.Location = new System.Drawing.Point(11, 68);
            this.labelSelectedFile.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelSelectedFile.Name = "labelSelectedFile";
            this.labelSelectedFile.Size = new System.Drawing.Size(144, 26);
            this.labelSelectedFile.TabIndex = 5;
            this.labelSelectedFile.Text = "Selected File:";
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "wav";
            this.openFileDialog.Filter = "Audio file (*.wav)|*.wav";
            // 
            // textBoxSelectedFile
            // 
            this.textBoxSelectedFile.Enabled = false;
            this.textBoxSelectedFile.Location = new System.Drawing.Point(153, 65);
            this.textBoxSelectedFile.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxSelectedFile.Name = "textBoxSelectedFile";
            this.textBoxSelectedFile.Size = new System.Drawing.Size(649, 32);
            this.textBoxSelectedFile.TabIndex = 6;
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(531, 348);
            this.axWindowsMediaPlayer1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(143, 35);
            this.axWindowsMediaPlayer1.TabIndex = 7;
            this.axWindowsMediaPlayer1.Visible = false;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(814, 258);
            this.Controls.Add(this.axWindowsMediaPlayer1);
            this.Controls.Add(this.textBoxSelectedFile);
            this.Controls.Add(this.labelSelectedFile);
            this.Controls.Add(this.buttonFile);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.buttonPause);
            this.Controls.Add(this.comboBoxPlayMethod);
            this.Controls.Add(this.buttonStart);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormMain";
            this.Text = "Karta Muzyczna";
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.ComboBox comboBoxPlayMethod;
        private System.Windows.Forms.Button buttonPause;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Button buttonFile;
        private System.Windows.Forms.Label labelSelectedFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.TextBox textBoxSelectedFile;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
    }
}

