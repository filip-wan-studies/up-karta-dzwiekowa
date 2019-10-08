using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsAppKM.Interfaces;

namespace WindowsFormsAppKM
{
    public partial class FormMain : Form
    {
        private iPlayer Player { get; set; }

        public FormMain()
        {
            InitializeComponent();
            comboBoxPlayMethod.SelectedIndex = 0;
        }

        private void SetText(string text)
        {
            textBoxSelectedFile.Text = text;
        }

        private void ChangeFileName(string fileName)
        {
            Player = CreatePlayer(fileName);
            if(Player == null) return;
            SetText(fileName);
            buttonPause.Enabled = Player.IsPausable;
        }

        private iPlayer CreatePlayer(string fileName)
        {
            switch (comboBoxPlayMethod.Text)
            {
                case "Play Sound":
                    return new PlaySoundPlayer(fileName);
                default:
                    return null;
            }
        }

        private void buttonFile_Click(object sender, EventArgs e)
        {
            Player?.Stop();
            openFileDialog.ShowDialog();
            if (!openFileDialog.CheckFileExists) return;
            ChangeFileName(openFileDialog.FileName);
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            Player?.Play();
        }

        private void ButtonPause_Click(object sender, EventArgs e)
        {
            Player?.Pause();
        }

        private void ButtonStop_Click(object sender, EventArgs e)
        {
            Player?.Stop();
        }

        private void ComboBoxPlayMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            Player?.Stop();
            if (openFileDialog.FileName == "" || !openFileDialog.CheckFileExists) return;
            Player = CreatePlayer(openFileDialog.FileName);
        }
    }
}
