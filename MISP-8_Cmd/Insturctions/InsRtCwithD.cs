using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISP_8.Insturctions
{
	public class InsRtCwithD : Instruction
	{
		public InsRtCwithD(byte react) : base(react) { }
		public override void RunStep(byte current)
		{
			byte mv = CPUEmu.RegC;
			CPUEmu.RegC = CPUEmu.RegD;
			CPUEmu.RegD = mv;
		}
	}
}
