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
        public MCIPlayer(string fileName)
        {
            FileName = fileName;
        }
        private string Command;
        private bool isPaused = false;
        public string FileName { get; }

        public bool IsPausable { get; } = true;

        [DllImport("winmm.dll")]
        private static extern int mciSendString(string strCommand,
        StringBuilder strReturn, int iReturnLength, IntPtr hwndCallback);
        //[DllImport("winmm.dll")]
        //public static extern int mciGetErrorString(int errCode,
        //              StringBuilder errMsg, int buflen);

        void iPlayer.Play()
        {
            if (!isPaused)
            {
                Command = "open \"" + FileName + "\" alias MediaFile";
                mciSendString(Command, null, 0, IntPtr.Zero);

            }
            Command = "play MediaFile";
            mciSendString(Command, null, 0, IntPtr.Zero);
            isPaused = false;
        }

        void iPlayer.Pause()
        {
            isPaused = true;
            Command = "pause MediaFile";
            mciSendString(Command, null, 0, IntPtr.Zero);
        }
        
        void iPlayer.Stop()
        {
            Command = "close MediaFile";
            mciSendString(Command, null, 0, IntPtr.Zero);
        }
    }
}
