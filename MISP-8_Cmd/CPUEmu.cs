using System;
using System.Collections.Generic;
using MISP_8.Insturctions;

namespace MISP_8
{
	public class CPUEmu
	{
		// Address
		public static byte RegAP1, RegAP2;
		// Currently Executing Instruction
		public static byte RegExe, RegExeStep;
		// GPR (Generel Purpouse Registry)
		public static byte RegA, RegB, RegC, RegD;
		public static bool carry;
		public static List<Instruction> CPUInstructons;
		public CPUEmu()
		{
			CPUInstructons = new List<Instruction> 
			{
				new InsLdA(0x10),
				new InsStA(0x11),
				new InsRtAwithB(0x20),
				new InsRtBwithC(0x21),
				new InsRtCwithD(0x22),
				new InsAdd(0x01),
				new InsSub(0x02)
			};
		}
		public static void IncrementAddress()
		{
			int i = RegAP1 * 256 + RegAP2;
			i++;
			if (i > 256 * 256)
			{
				i = 0;
			}
			RegAP1 = (byte)(i / 256);
			RegAP2 = (byte)(i % 256);
		}
		public static void ExecuteInstructionSingleStep()
		{
			byte input = RAMEmulator.GetByte(RegAP1, RegAP2);
			if (RegExeStep != 0)
			{
				foreach (Instruction instr in CPUInstructons)
				{
					if (instr.Reactto == RegExe)
					{
						if (Program.CpuOutputEnabled)
						{
							Console.WriteLine("Executed Instruction: 0x" +BitConverter.ToString(new byte[] { input }));
							Console.WriteLine("("+instr+")");
						}
						instr.RunStep(input);
					}
				}
			}
			else
			{
				foreach (Instruction instr in CPUInstructons)
				{
					if (instr.Reactto == input)
					{
						if (Program.CpuOutputEnabled)
						{
							Console.WriteLine("Executed Instruction: 0x" + BitConverter.ToString(new byte[] { input }));
							Console.WriteLine("(" + instr + ")");
						}
						instr.RunStep(input);
						if (RegExeStep != 0)
						{
							RegExe = input;
						}
					}
				}
			}
		}
		public static void RunAllInstructions()
		{
			int i = 0;
			while (i < RAMEmulator.ram.Length - 1)
			{
				i = RegAP1 * 256 + RegAP2;
				ExecuteInstructionSingleStep();
				IncrementAddress();
			}
		}
	}
}
