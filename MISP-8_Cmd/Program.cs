using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISP_8
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string pathramin = args[0];
			string pathramout = args[1];
			new RAMEmulator(pathramin);
			new CPUEmu();
			CPUEmu.RunAllInstructions();
			RAMEmulator.Export(pathramout);
		}
	}
}
