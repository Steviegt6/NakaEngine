using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Xml.Linq;

namespace NakaEngine.Core
{
    internal static class DllManager
	{
		internal static void AttachResolver(Assembly assembly)
		{
			string osString;

			if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) 
			{
				osString = "windows";
			} 
			else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX)) 
			{
				osString = "osx";
			} 
			else if (RuntimeInformation.IsOSPlatform(OSPlatform.FreeBSD)) 
			{
				osString = "freebsd";
			} 
			else 
			{
				osString = "linux";
			}

			string cpuString = RuntimeInformation.OSArchitecture switch 
			{
				Architecture.Arm => "arm",
				Architecture.Arm64 => "armv8",
				Architecture.X86 => "x86",
				_ => "x86-64",
			};

			string wordSizeString = RuntimeInformation.OSArchitecture switch 
			{
				Architecture.X86 => "32",
				Architecture.Arm => "32",
				_ => "64",
			};

			StringComparer stringComparer = StringComparer.InvariantCultureIgnoreCase;

			bool StringNullOrEqual(string a, string b) => a == null || stringComparer.Equals(a, b);

			NativeLibrary.SetDllImportResolver(assembly, (name, theAssembly, path) =>
			{ 
				string configPath = theAssembly.Location + ".config";

                if (!File.Exists(configPath))
				{
					return IntPtr.Zero;
				}

				XElement root = XElement.Load(configPath);

				IEnumerable<XElement> maps = root
					.Elements("dllmap")
					.Where(element => stringComparer.Equals(element.Attribute("dll")?.Value, name))
					.Where(element => StringNullOrEqual(element.Attribute("os")?.Value, osString))
					.Where(element => StringNullOrEqual(element.Attribute("cpu")?.Value, cpuString))
					.Where(element => StringNullOrEqual(element.Attribute("wordsize")?.Value, wordSizeString));

				XElement map = maps.SingleOrDefault();

				if (map == null) 
				{
					throw new ArgumentException($"'{Path.GetFileName(configPath)}' - Found {maps.Count()} possible mapping candidates for dll '{name}'.");
				}

				return NativeLibrary.Load(map.Attribute("target").Value);
			});
		}
	}
}
