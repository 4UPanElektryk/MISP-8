using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISP_8.Insturctions
{
	public class InsAdd : Instruction
	{
		public InsAdd(byte react) : base(react) { }
		public override void RunStep(byte current)
		{
			int ou = CPUEmu.RegA + CPUEmu.RegB;
			if (ou > 0xff)
			{
				ou -= 0xff;
				CPUEmu.carry = true;
			}
			CPUEmu.RegC = (byte)ou;
		}
	}
}
