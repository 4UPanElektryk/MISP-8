using System;
using System.CodeDom.Compiler;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace MISP_8
{
	public class RAMEmulator
	{
		public static byte[] ram;
		public RAMEmulator(int amount) 
		{
			byte noop = 0x00;
			ram = new byte[amount];
			for (int i = 0; i < amount; i++)
			{
				ram[i] = noop;
			}
		}
		public RAMEmulator(string path) 
		{
			ram = File.ReadAllBytes(path);
		}
		public static byte GetByte(byte p1, byte p2)
		{
			int address = 256 * p1 + p2;
			if (Program.MemOutputEnabled)
			{
				Console.WriteLine("Got: 0x" + BitConverter.ToString(new byte[] { ram[address] })+" From: 0x"+BitConverter.ToString(new byte[] { p1, p2 }).Replace("-", ""));
			}
			return ram[address];
		}
		public static void SetByte(byte p1, byte p2, byte data)
		{
			int address = 256 * p1 + p2;
			ram[address] = data;
			if (Program.MemOutputEnabled)
			{
				Console.WriteLine("Set: 0x" + BitConverter.ToString(new byte[] { p1, p2 }).Replace("-", "") + " to: 0x" + BitConverter.ToString(new byte[] { data }));
			}
		}
		public static void Export(string path)
		{
			File.WriteAllBytes(path, ram);
		}
	}
}
