namespace NakaEngine.Utilities
{
    public static class MathUtils
    {
        public static bool InRange(this byte value, byte min, byte max) => value >= min && value <= max;

        public static bool InRange(this int value, int min, int max) => value >= min && value <= max;

        public static bool InRange(this float value, int min, int max) => value >= min && value <= max;

        public static bool InRange(this double value, double min, double max) => value >= min && value <= max;

        public static bool InRange(this decimal value, decimal min, decimal max) => value >= min && value <= max;
    }
}
