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
        public DirectXPlayer(string fileName, IntPtr handle)
        {
            FileName = fileName;
            _secondaryBuffer = initializeSecondaryBuffer(fileName, handle);
        }

        public string FileName { get; }

        public bool IsPausable { get; } = true;

        private SecondarySoundBuffer _secondaryBuffer;

        private SecondarySoundBuffer initializeSecondaryBuffer(string fileName, IntPtr handle)
        {
            var directSound = new DirectSound();
            directSound.SetCooperativeLevel(handle, CooperativeLevel.Exclusive);

            // Open the wave file in binary.
            var reader = new BinaryReader(File.OpenRead(FileName));

            // Read in the wave file header.
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

            // Check that the chunk ID is the RIFF format
            // and the file format is the WAVE format
            // and sub chunk ID is the fmt format
            // and the audio format is PCM
            // and the wave file was recorded in stereo format
            // and at a sample rate of 44.1 KHz
            // and at 16 bit format
            // and there is the data chunk header.
            // Otherwise return false.
            if (chunkId != "RIFF" || format != "WAVE" || subChunkId.Trim() != "fmt" ||
                audioFormat != WaveFormatEncoding.Pcm || numChannels != 2 || sampleRate != 44100 ||
                bitsPerSample != 16 || dataChunkId != "data")
                return null;

            // Set the buffer description of the secondary sound buffer that the wave file will be loaded onto and the wave format.
            var buffer = new SoundBufferDescription
            {
                Flags = BufferFlags.ControlVolume,
                BufferBytes = dataSize,
                Format = new WaveFormat(44100, 16, 2),
                AlgorithmFor3D = Guid.Empty
            };

            // Create a temporary sound buffer with the specific buffer settings.
            var secondaryBuffer = new SecondarySoundBuffer(directSound, buffer);

            // Read in the wave file data into the temporary buffer.
            var waveData = reader.ReadBytes(dataSize);

            // Close the reader
            reader.Close();

            // Lock the secondary buffer to write wave data into it.
            var waveBufferData1 = secondaryBuffer.Lock(0, dataSize, LockFlags.None, out var waveBufferData2);

            // Copy the wave data into the buffer.
            waveBufferData1.Write(waveData, 0, dataSize);

            // Unlock the secondary buffer after the data has been written to it.
            secondaryBuffer.Unlock(waveBufferData1, waveBufferData2);

            return secondaryBuffer;
        }

        public void Play()
        {
            _secondaryBuffer.Play(0, PlayFlags.Looping);
        }

        public void Pause()
        {
            _secondaryBuffer.Stop();
        }

        public void Stop()
        {
            _secondaryBuffer.Stop();
            _secondaryBuffer.CurrentPosition = 0;
        }
    }
}
