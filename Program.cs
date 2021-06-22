using Microsoft.Xna.Framework;
using System;
using System.Reflection;

namespace NakaEngine
{
    internal static class Program
	{
		[STAThread] 
		internal static void Main(string[] args)
		{
			DllManager.AttachResolver(Assembly.GetExecutingAssembly());
			DllManager.AttachResolver(Assembly.GetAssembly(typeof(Game)));

            using var engine = new NakaEngine();
            engine.Run();
        }
	}
}
