using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsAppKM.Interfaces
{
    interface iPlayer
    {
        string FileName { get; }
        bool IsPausable { get; }

        void Play();
        void Pause();
        void Stop();
    }
}
