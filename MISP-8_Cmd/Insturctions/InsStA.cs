using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISP_8.Insturctions
{
	public class InsStA : Instruction
	{
		public InsStA(byte react) : base(react) { }
		public override void RunStep(byte current)
		{
			if (CPUEmu.RegExeStep == 0x02)
			{
				Step1(current);
			}
			else if (CPUEmu.RegExeStep == 0x01)
			{
				Step2(current);
			}
			else
			{
				Ready();
			}
		}
		private void Step1(byte current)
		{
			CPUEmu.RegExeStep = 0x01;
			CPUEmu.RegC = current;
		}
		private void Step2(byte current)
		{
			CPUEmu.RegExeStep = 0x00;
			RAMEmulator.SetByte(CPUEmu.RegC, current, CPUEmu.RegA);
		}
		private void Ready()
		{
			CPUEmu.RegExeStep = 0x02;
		}
	}
}
