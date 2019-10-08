using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDX;
using SharpDX.DirectSound;
using SharpDX.IO;
using SharpDX.Multimedia;

namespace WindowsFormsAppKM
{
    class DirectXPlayer
    {
        public void Play(string fileName)
        {
            DirectSound directSound = new DirectSound();

            var primaryBufferDesc = new SoundBufferDescription();
            primaryBufferDesc.Flags = BufferFlags.PrimaryBuffer;

            var primarySoundBuffer = new PrimarySoundBuffer(directSound, primaryBufferDesc);

            primarySoundBuffer.Play(0, PlayFlags.Looping);
            
            WaveFormat waveFormat = new WaveFormat();

            var secondaryBufferDesc = new SoundBufferDescription();
            secondaryBufferDesc.BufferBytes = waveFormat.ConvertLatencyToByteSize(60000);
            secondaryBufferDesc.Format = waveFormat;
            secondaryBufferDesc.Flags = BufferFlags.GetCurrentPosition2 | BufferFlags.ControlPositionNotify | BufferFlags.GlobalFocus |
                                        BufferFlags.ControlVolume | BufferFlags.StickyFocus;
            secondaryBufferDesc.AlgorithmFor3D = Guid.Empty;
            var secondarySoundBuffer = new SecondarySoundBuffer(directSound, secondaryBufferDesc);

            // Get Capabilties from secondary sound buffer
            var capabilities = secondarySoundBuffer.Capabilities;
            // Lock the buffer

            //byte[] bytes1 = new byte[desc2.SizeInBytes / 2];
            //byte[] bytes2 = new byte[desc2.SizeInBytes];

            //Stream stream = File.Open(audioFile, FileMode.Open);

            DataStream dataPart2;
            //dataPart2.Write()
            var dataPart1 = secondarySoundBuffer.Lock(0, capabilities.BufferBytes, LockFlags.EntireBuffer, out dataPart2);

            // Fill the buffer with some sound
            int numberOfSamples = capabilities.BufferBytes / waveFormat.BlockAlign;
            for (int i = 0; i < numberOfSamples; i++)
            {
                double vibrato = Math.Cos(2 * Math.PI * 10.0 * i / waveFormat.SampleRate);
                short value = (short)(Math.Cos(2 * Math.PI * (220.0 + 4.0 * vibrato) * i / waveFormat.SampleRate) * 16384); // Not too loud
                dataPart1.Write(value);
                dataPart1.Write(value);
            }

            // Unlock the buffer
            secondarySoundBuffer.Unlock(dataPart1, dataPart2);

            // Play the song
            secondarySoundBuffer.Play(0, PlayFlags.Looping);
        }
    }
}
