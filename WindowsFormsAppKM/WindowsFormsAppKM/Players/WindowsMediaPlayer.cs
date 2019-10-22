using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsAppKM.Interfaces;

namespace WindowsFormsAppKM.Players
{
    class WindowsMediaPlayer : iPlayer
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
        /// Odtwarzacz windows media player
        /// </summary>
        private readonly WMPLib.WindowsMediaPlayer _wmPlayer;

        /// <summary>
        /// Kontruktor i inicjalizacja windows media playera
        /// </summary>
        /// <param name="fileName"></param>
        public WindowsMediaPlayer(string fileName)
        {
            FileName = fileName;
            _wmPlayer = new WMPLib.WindowsMediaPlayer();
            _wmPlayer.settings.autoStart = false;
            _wmPlayer.URL = FileName;
        }

        /// <summary>
        /// Odtwarzanie wybranego pliku
        /// </summary>
        public void Play()
        {
            _wmPlayer.controls.play();
        }

        /// <summary>
        /// Pauzowanie odtwarzania wybranego pliku
        /// </summary>
        public void Pause()
        {
            _wmPlayer.controls.pause();
        }

        /// <summary>
        /// Zatrzymanie odtwarzania wybranego pliku
        /// </summary>
        public void Stop()
        {
            _wmPlayer.controls.stop();
        }
    }
}
