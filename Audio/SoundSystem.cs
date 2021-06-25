using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;

namespace NakaEngine.Audio
{
    public class SoundSystem 
    {
        public static SoundEffectInstance PlaySound(SoundEffect effect, float volume = 1f, float pitch = 0f, float pan = 0f)
        {
            SoundEffectInstance instance = effect.CreateInstance();

            instance.Volume = volume;
            instance.Pitch = pitch;
            instance.Pan = MathHelper.Clamp(pan, -1f, 1f);

            instance.Play();

            return instance;
        }
    }
}
