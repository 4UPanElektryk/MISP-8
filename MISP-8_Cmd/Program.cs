using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISP_8
{
	internal class Program
	{
		public static bool MemOutputEnabled = false;
		public static bool CpuOutputEnabled = false;
		static void Main(string[] args)
		{
			string pathramin = "";
			string pathramout = "";
			if (args.Length == 2)
			{
				pathramin = args[0];
				pathramout = args[1];
			}
			else if (args.Length == 4)
			{
				pathramin = args[0];
				pathramout = args[1];
				MemOutputEnabled = args[2] == "-Vm";
				CpuOutputEnabled = args[3] == "-Vc";
			}
			new RAMEmulator(pathramin);
			new CPUEmu();
			CPUEmu.RunAllInstructions();
			RAMEmulator.Export(pathramout);
		}
	}
}
