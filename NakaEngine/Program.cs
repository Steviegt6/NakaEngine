using System;

namespace NakaEngine
{
    public static class Program
    {
        [STAThread] 
        public static void Main()
        {
            Bootstrap.Initialize_FNA();

            NakaEngine engine = new();
            engine.Run();
        }
    }
}
