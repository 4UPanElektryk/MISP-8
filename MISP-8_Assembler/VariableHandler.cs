using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MISP_8.Assembler
{
	public class VarInst : Instruction
	{
		public VarInst(string prefix) : base(prefix, 0, 0x00) { }
		public override byte[] Process(string[] args)
		{
			VariableHandler.asmvars.Add(args[0].Substring(1), VariableHandler.GetVariable(args[1]));
			return null;
		}
	}
	public class VariableHandler
	{
		public static Dictionary<string, byte> asmvars;
		public VariableHandler() 
		{
			asmvars = new Dictionary<string, byte>();
		}
		public static byte GetVariable(string name)
		{
			if (name.StartsWith("0x"))
			{
				int d = int.Parse(name.ToCharArray()[2].ToString()) * 16;
				int j = int.Parse(name.ToCharArray()[3].ToString()) * 1;
				d += j;
				return byte.Parse(d.ToString());
			}
			else if (name.StartsWith("&"))
			{
				return Convert.ToByte(name.Substring(1),2);
			}
			else if (name.StartsWith("$"))
			{
				return asmvars[name.Substring(1)];
			}
			else
			{
				throw new NotImplementedException("Icorrect Input");
			}
		}
	}
}
