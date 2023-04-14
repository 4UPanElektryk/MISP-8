using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISP_8
{
	public class Instruction
	{
		public byte Reactto;
		public Instruction(byte react) 
		{
			Reactto = react;
		}
		public virtual void RunStep(byte current)
		{

		}
	}
}
