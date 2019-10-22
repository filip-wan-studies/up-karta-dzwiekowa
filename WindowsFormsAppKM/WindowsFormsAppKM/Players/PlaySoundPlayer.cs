using System;
using System.Runtime.InteropServices;
using WindowsFormsAppKM.Interfaces;

namespace WindowsFormsAppKM
{
    public class PlaySoundPlayer : iPlayer
    {
        /// <summary>
        /// Nazwa wybranego pliku
        /// </summary>
        public string FileName { get; }

        /// <summary>
        /// Wybrana metoda nie obsługuje pauzowania odtwarzania
        /// </summary>
        public bool IsPausable { get; } = false;

        /// <summary>
        /// Konstruktor - przypisanie nazwy pliku
        /// </summary>
        /// <param name="fileName"></param>
        public PlaySoundPlayer(string fileName)
        {
            FileName = fileName;

        }

        /// <summary>
        /// Import metody PlaySound
        /// </summary>
        /// <param name="pszSound"></param>
        /// <param name="hmod"></param>
        /// <param name="fdwSound"></param>
        /// <returns></returns>
        [DllImport("winmm.dll", SetLastError = true)]
        private static extern bool PlaySound(string pszSound, UIntPtr hmod, uint fdwSound);

        /// <summary>
        /// Używane flagi
        /// </summary>
        [System.Flags]
        private enum SoundFlags : int
        {
            /// <summary>play asynchronously</summary>
            SND_ASYNC = 0x0001,
            /// <summary>loop the sound until next sndPlaySound</summary>
            SND_LOOP = 0x0008,
            /// <summary>name is file name</summary>
            SND_FILENAME = 0x00020000
        }

        /// <summary>
        /// Odtwarzanie wybranego pliku
        /// </summary>
        public void Play()
        {
            PlaySound(FileName, UIntPtr.Zero, (uint)(SoundFlags.SND_FILENAME | SoundFlags.SND_ASYNC | SoundFlags.SND_LOOP));
        }

        public void Pause()
        {
        }

        /// <summary>
        /// Zatrzymanie wybranego pliku
        /// </summary>
        public void Stop()
        {
            PlaySound(null, UIntPtr.Zero, 0);
        }
    }
}
