using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsAppKM.Interfaces;
using SharpDX.Multimedia;

namespace WindowsFormsAppKM.Players
{
    class WaveOutWrite : iPlayer
    {
        public WaveOutWrite(string fileName)
        {
            FileName = fileName;
        }

        #region WaveOut

        

        [StructLayout(LayoutKind.Sequential)]
        public struct WAVEFORMAT
        {
            public short wFormatTag;
            public short nChannels;
            public int nSamplesPerSec;
            public int nAvgBytesPerSec;
            public short nBlockAlign;
            public short wBitsPerSample;
            //public short cbSize;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct WAVEHDR
        {
            public IntPtr lpData;
            public int dwBufferLength;
            public int dwBytesRecorded;
            public IntPtr dwUser;
            public int dwFlags;
            public int dwLoops;
            public IntPtr lpNext;
            public IntPtr Reserved;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MMTIME
        {
            public int wType;
            public int u;
            public int x;
        }

    public delegate void WaveDelegate(IntPtr hwo, int uMsg, int dwInstance,
            ref WaveOutWrite.WAVEHDR wavhdr, int dwParam2);

    private void WaveCallBack(IntPtr hwo, int uMsg, int dwInstance,
        ref WAVEHDR wavhdr, int dwParam2){}

        [DllImport("winmm.dll")]
        public static extern int waveOutPause(IntPtr hWaveOut);
        [DllImport("winmm.dll")]
        public static extern int waveOutRestart(IntPtr hWaveOut);

        [DllImport("winmm.dll")]
        public static extern int waveOutReset(IntPtr hWaveIn);
        [DllImport("winmm.dll")]
        public static extern int waveOutUnprepareHeader(IntPtr hWaveIn, ref WAVEHDR lpWaveInHdr, int uSize);
        [DllImport("winmm.dll")]
        public static extern int waveOutClose(IntPtr hWaveIn);
        [DllImport("winmm.dll")]
        public static extern int waveOutWrite(IntPtr hWaveOut, ref WAVEHDR lpWaveOutHdr, int uSize);
        [DllImport("winmm.dll")]
        public static extern int waveOutOpen(out IntPtr hWaveOut, int uDeviceID,
            ref WAVEFORMAT format, WaveDelegate dwCallback, int fPlaying, int dwFlags);
        [DllImport("winmm.dll")]
        public static extern int waveOutPrepareHeader(IntPtr hWaveIn, ref WAVEHDR lpWaveInHdr, int uSize);
        [DllImport("winmm.dll")]
        public static extern int waveOutGetPosition(IntPtr hWaveOut, ref MMTIME lpInfo, int uSize);

        public const int WHDR_BEGINLOOP = 0x4;
        public const int WHDR_ENDLOOP = 0x8;
        public const int MMSYSERR_NOERROR = 0;
        //public const int CALLBACK_WINDOW = 0x10000;
        public const int CALLBACK_FUNCTION = 0x30000;
        public const int MM_WOM_DONE = 0x3BD;
        #endregion
        private IntPtr _hWaveOut;

        public string FileName { get; }

        public bool IsPausable { get; } = true;


        void iPlayer.Play()
        {
            WAVEFORMAT fmt = new WAVEFORMAT();

            // these are the format settings for sample.wav in this project:
            fmt.wBitsPerSample = 16;
            fmt.nChannels = 1;
            fmt.wFormatTag = 1; // PCM
            fmt.nSamplesPerSec = 44100;
            fmt.nBlockAlign = 2;
            fmt.nAvgBytesPerSec = 44100 * 1 * 2;
            var _WaveDelegate = new WaveDelegate(WaveCallBack);

            if (waveOutOpen(out _hWaveOut, 0, ref fmt,
                    _WaveDelegate, 0, CALLBACK_FUNCTION)
                != MMSYSERR_NOERROR)
            {
                throw new Exception("error opening WAVE device");
            }
        }

        void iPlayer.Pause()
        {

        }
        
        void iPlayer.Stop()
        {

        }
    }
}
