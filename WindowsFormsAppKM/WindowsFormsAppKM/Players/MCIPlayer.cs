using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsAppKM.Interfaces;

namespace WindowsFormsAppKM.Players
{
    class MCIPlayer : iPlayer
    {
        /// <summary>
        /// Nazwa wybranego pliku
        /// </summary>
        public string FileName { get; }

        /// <summary>
        /// Wybrana metoda nie obsługuje pauzowania odtwarzania
        /// </summary>
        public bool IsPausable { get; } = true;

        /// <summary>
        /// Zmienna wskazująca, czy dany plik jest załadowany
        /// </summary>
        private bool _isOpened = false;

        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="fileName"></param>
        public MCIPlayer(string fileName)
        {
            FileName = fileName;
        }

        /// <summary>
        /// Import metody mciSendString
        /// </summary>
        /// <param name="strCommand"></param>
        /// <param name="strReturn"></param>
        /// <param name="iReturnLength"></param>
        /// <param name="hwndCallback"></param>
        /// <returns></returns>
        [DllImport("winmm.dll")]
        private static extern int mciSendString(string strCommand,
            StringBuilder strReturn, int iReturnLength, IntPtr hwndCallback);

        /// <summary>
        /// Odtwarzanie wybranego pliku
        /// </summary>
        public void Play()
        {
            string command;

            if (!_isOpened)
            {
                command = "open \"" + FileName + "\" alias MediaFile";
                mciSendString(command, null, 0, IntPtr.Zero);
            }

            command = "play MediaFile";
            mciSendString(command, null, 0, IntPtr.Zero);
        }

        /// <summary>
        /// Zapauzowanie odtwarzania
        /// </summary>
        public void Pause()
        {
            if (!_isOpened) return;

            string command = "pause MediaFile";
            mciSendString(command, null, 0, IntPtr.Zero);
        }

        /// <summary>
        /// Zatrzymanie odtwarzania
        /// </summary>
        public void Stop()
        {
            if (!_isOpened) return;

            string command = "close MediaFile";
            mciSendString(command, null, 0, IntPtr.Zero);
            _isOpened = false;
        }
    }
}
