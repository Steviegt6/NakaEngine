using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using NVorbis;
using System;

namespace NakaEngine.Audio
{
    public sealed class Music : IDisposable
    {
        private readonly DynamicSoundEffectInstance instance;

        private readonly VorbisReader reader;

        public Music(string path)
        {
            reader = new VorbisReader(path);
            
            instance = new DynamicSoundEffectInstance(reader.SampleRate, (AudioChannels)reader.Channels);
        }

        public void Play()
        {
            SubmitBuffer();

            instance.Play();
        }

        private void SubmitBuffer()
        {
            const int bufferSize = 4096;
            float[] buffer = new float[bufferSize];

            int samples = reader.ReadSamples(buffer, 0, buffer.Length);

            reader.ReadSamples(buffer, samples, buffer.Length - samples);

            instance.SubmitFloatBufferEXT(buffer);
        }

        public DynamicSoundEffectInstance SetVolume(float volume)
        {
            instance.Volume = MathHelper.Clamp(volume, 0f, 1f);

            return instance;
        }

        public DynamicSoundEffectInstance SetPan(float pan)
        {
            instance.Pan = MathHelper.Clamp(pan, -1f, 1f);

            return instance;
        }

        public DynamicSoundEffectInstance SetPitch(float pitch)
        {
            instance.Pitch = pitch;

            return instance;
        }

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing = false)
        {
            if (disposing)
            {
                reader?.Dispose();
                instance?.Dispose();
            }
        }

        ~Music() => Dispose();
    }
}
