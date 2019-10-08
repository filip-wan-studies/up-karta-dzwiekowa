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

namespace WindowsFormsAppKM
{
    public partial class FormMain : Form
    {

        public FormMain()
        {
            InitializeComponent();
        }

        private void SetText(string text)
        {
            textBoxSelectedFile.Text = text;
        }

        private void buttonFile_Click(object sender, EventArgs e)
        {
            SetText(openFileDialog.FileName);
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            PlaySoundPlayer.Play(openFileDialog.FileName);
        }
    }
}
