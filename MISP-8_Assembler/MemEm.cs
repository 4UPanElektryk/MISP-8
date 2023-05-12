using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISP_8.Assembler
{
	public class MemEm
	{
		public static byte[] data;
		public MemEm()
		{
			data = new byte[0x10000];
		}
		public static void setMem(UInt16 address, byte[] indata)
		{
			for (int i = 0; i < indata.Length; i++)
			{
				Console.WriteLine("Eprom: 0x" + ((UInt16)(address+i)).ToString("X4") + " = " + indata[i]);
				data[address + i] = indata[i];
			}
		}
	}
}
