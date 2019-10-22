using System;
using System.Windows.Forms;
using WindowsFormsAppKM.Interfaces;
using WindowsFormsAppKM.Players;

namespace WindowsFormsAppKM
{
    public partial class FormMain : Form
    {
        /// <summary>
        /// Pole z klasą odtwarzającą podany plik
        /// </summary>
        private iPlayer Player { get; set; }

        /// <summary>
        /// Inicjalizacja okna
        /// </summary>
        public FormMain()
        {
            InitializeComponent();
            comboBoxPlayMethod.SelectedIndex = 0;
        }

        /// <summary>
        /// Ustawienie pola tekstowego FileName
        /// na nazwę wybranego pliku
        /// </summary>
        /// <param name="text"></param>
        private void SetText(string text)
        {
            textBoxSelectedFile.Text = text;
        }

        /// <summary>
        /// Stworzenie nowego obiektu Player o podanej nazwie
        /// </summary>
        /// <param name="fileName"></param>
        private void ChangeFileName(string fileName)
        {
            Player = CreatePlayer(fileName);
            if(Player == null) return;
            SetText(fileName);
            buttonPause.Enabled = Player.IsPausable;
        }

        /// <summary>
        /// Stworzenie nowego odtwarzacza w zależności
        /// od wybranego sposobu odtwarzania
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private iPlayer CreatePlayer(string fileName)
        {
            switch (comboBoxPlayMethod.Text)
            {
                case "Play Sound":
                    return new PlaySoundPlayer(fileName);
                case "Windows Media Player (WMP)":
                    return new WindowsMediaPlayer(fileName);
                case "MCI":
                    return new MCIPlayer(fileName);
                case "Direct Sound":
                    return new DirectXPlayer(fileName, this.Handle);
                default:
                    return null;
            }
        }

        // Event handlery

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
            buttonPause.Enabled = Player?.IsPausable ?? false;
        }
    }
}
