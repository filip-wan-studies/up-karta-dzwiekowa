using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsAppKM.Interfaces;
using SharpDX;
using SharpDX.DirectSound;
using SharpDX.IO;
using SharpDX.Multimedia;

namespace WindowsFormsAppKM
{
    class DirectXPlayer : iPlayer
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
        /// Konstruktor
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="handle"></param>
        public DirectXPlayer(string fileName, IntPtr handle)
        {
            FileName = fileName;
            _secondaryBuffer = initializeSecondaryBuffer(fileName, handle);
        }

        private readonly SecondarySoundBuffer _secondaryBuffer;

        private SecondarySoundBuffer initializeSecondaryBuffer(string fileName, IntPtr handle)
        {
            var directSound = new DirectSound();
            directSound.SetCooperativeLevel(handle, CooperativeLevel.Exclusive);

            // Otwórz plik binarnie
            var reader = new BinaryReader(File.OpenRead(FileName));

            // Wczytaj header pliku
            var chunkId = new string(reader.ReadChars(4));
            var chunkSize = reader.ReadInt32();
            var format = new string(reader.ReadChars(4));
            var subChunkId = new string(reader.ReadChars(4));
            var subChunkSize = reader.ReadInt32();
            var audioFormat = (WaveFormatEncoding)reader.ReadInt16();
            var numChannels = reader.ReadInt16();
            var sampleRate = reader.ReadInt32();
            var bytesPerSecond = reader.ReadInt32();
            var blockAlign = reader.ReadInt16();
            var bitsPerSample = reader.ReadInt16();
            var dataChunkId = new string(reader.ReadChars(4));
            var dataSize = reader.ReadInt32();

            // Ustaw format wave
            var buffer = new SoundBufferDescription
            {
                Flags = BufferFlags.ControlVolume,
                BufferBytes = dataSize,
                Format = new WaveFormat(44100, 16, 2),
                AlgorithmFor3D = Guid.Empty
            };

            // Create a temporary sound buffer with the specific buffer settings.
            var secondaryBuffer = new SecondarySoundBuffer(directSound, buffer);

            // Wczytaj dane do tymczasowego bufora
            var waveData = reader.ReadBytes(dataSize);

            reader.Close();

            // Załaduj dane do bufora
            var waveBufferData1 = secondaryBuffer.Lock(0, dataSize, LockFlags.None, out var waveBufferData2);
            waveBufferData1.Write(waveData, 0, dataSize);
            secondaryBuffer.Unlock(waveBufferData1, waveBufferData2);

            return secondaryBuffer;
        }

        /// <summary>
        /// Odtwarzanie pliku
        /// </summary>
        public void Play()
        {
            _secondaryBuffer.Play(0, PlayFlags.Looping);
        }

        /// <summary>
        /// Pauzowanie odtwarzania
        /// </summary>
        public void Pause()
        {
            _secondaryBuffer.Stop();
        }

        /// <summary>
        /// Zatrzymanie odtwarzania
        /// </summary>
        public void Stop()
        {
            _secondaryBuffer.Stop();
            _secondaryBuffer.CurrentPosition = 0;
        }
    }
}
