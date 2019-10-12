﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
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
        static extern bool PlaySound(string pszSound, UIntPtr hmod, uint fdwSound);

        [System.Flags]
        public enum SoundFlags : int
        {
            /// <summary>play synchronously (default)</summary>
            SND_SYNC = 0x0000,
            /// <summary>play asynchronously</summary>
            SND_ASYNC = 0x0001,
            /// <summary>silence (!default) if sound not found</summary>
            SND_NODEFAULT = 0x0002,
            /// <summary>pszSound points to a memory file</summary>
            SND_MEMORY = 0x0004,
            /// <summary>loop the sound until next sndPlaySound</summary>
            SND_LOOP = 0x0008,
            /// <summary>don’t stop any currently playing sound</summary>
            SND_NOSTOP = 0x0010,
            /// <summary>Stop Playing Wave</summary>
            SND_PURGE = 0x40,
            /// <summary>don’t wait if the driver is busy</summary>
            SND_NOWAIT = 0x00002000,
            /// <summary>name is a registry alias</summary>
            SND_ALIAS = 0x00010000,
            /// <summary>alias is a predefined id</summary>
            SND_ALIAS_ID = 0x00110000,
            /// <summary>name is file name</summary>
            SND_FILENAME = 0x00020000,
            /// <summary>name is resource name or atom</summary>
            SND_RESOURCE = 0x00040004
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
