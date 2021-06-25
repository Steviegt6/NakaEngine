using Microsoft.Xna.Framework;

namespace NakaEngine.Utilities
{
    public static class MathUtils
    {
        public static bool InRange(this byte value, byte min, byte max) => value >= min && value <= max;

        public static bool InRange(this sbyte value, sbyte min, sbyte max) => value >= min && value <= max;
        
        public static bool InRange(this short value, short min, short max) => value >= min && value <= max;

        public static bool InRange(this ushort value, ushort min, ushort max) => value >= min && value <= max;

        public static bool InRange(this int value, int min, int max) => value >= min && value <= max;

        public static bool InRange(this uint value, uint min, uint max) => value >= min && value <= max;

        public static bool InRange(this long value, long min, long max) => value >= min && value <= max;

        public static bool InRange(this ulong value, ulong min, ulong max) => value >= min && value <= max;

        public static bool InRange(this float value, float min, float max) => value >= min && value <= max;

        public static bool InRange(this double value, double min, double max) => value >= min && value <= max;

        public static bool InRange(this decimal value, decimal min, decimal max) => value >= min && value <= max;

        public static float DeltaTime(this GameTime gametime) => (float)(gametime.ElapsedGameTime.TotalSeconds * 60);
    }
}
