using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISP_8.Insturctions
{
	public class InsLdA : Instruction
	{
		public InsLdA(byte react) : base(react) { }
		public override void RunStep(byte current)
		{
			if (CPUEmu.RegExeStep == 1)
			{
				Main(current);
			}
			else
			{
				Ready();
			}
		}
		private void Ready()
		{
			CPUEmu.RegExeStep = 0x01;
		}
		private void Main(byte current)
		{
			CPUEmu.RegExeStep = 0x00;
			CPUEmu.RegA = current;
		}
	}
}
