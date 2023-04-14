using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISP_8.Insturctions
{
	public class InsRtBwithC : Instruction
	{
		public InsRtBwithC(byte react) : base(react) { }
		public override void RunStep(byte current)
		{
			byte mv = CPUEmu.RegB;
			CPUEmu.RegB = CPUEmu.RegC;
			CPUEmu.RegC = mv;
		}
	}
}
