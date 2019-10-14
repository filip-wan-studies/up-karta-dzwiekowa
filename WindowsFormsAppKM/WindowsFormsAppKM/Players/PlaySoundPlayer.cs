using System;
using System.Runtime.InteropServices;
using WindowsFormsAppKM.Interfaces;

namespace WindowsFormsAppKM
{
    public class PlaySoundPlayer : iPlayer
    {
        public PlaySoundPlayer(string fileName)
        {
            FileName = fileName;

        }

        public string FileName { get; }

        public bool IsPausable { get; } = false;

        [DllImport("winmm.dll", SetLastError = true)]
        private static extern bool PlaySound(string pszSound, UIntPtr hmod, uint fdwSound);

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

        public void Play()
        {
            PlaySound(FileName, UIntPtr.Zero, (uint)(SoundFlags.SND_FILENAME | SoundFlags.SND_ASYNC | SoundFlags.SND_LOOP));
        }

        public void Pause()
        {
        }

        public void Stop()
        {
            PlaySound(null, UIntPtr.Zero, 0);
        }
    }
}
