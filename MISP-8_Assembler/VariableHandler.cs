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
			VariableHandler.asmvars.Add(new VarDat() { name = args[0].Substring(1),data = VariableHandler.GetVariable(args[1]), Loc = Replacer.Index});
			return new byte[] 
			{
				VariableHandler.GetVariable(args[1])
			};
		}
	}
	public struct VarDat
	{
		public string name;
		public UInt16 Loc;
		public byte data;
	}
	public class VariableHandler
	{
		public static List<VarDat> asmvars;
		public VariableHandler() 
		{
			asmvars = new List<VarDat>();
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
				return Convert.ToByte(name.Substring(1), 2);
			}
			else if (name.StartsWith("$"))
			{
				return asmvars.Find(x => x.name.Equals(name.Substring(1))).data;
			}
			else if (name.StartsWith("*H$"))
			{
				return (byte)(asmvars.Find(x => x.name.Equals(name.Substring(3))).Loc / 0xFF);
			}
			else if (name.StartsWith("*L$"))
			{
				return (byte)asmvars.Find(x => x.name.Equals(name.Substring(3))).Loc;
			}
			else
			{
				throw new NotImplementedException("Icorrect Input");
			}
		}
	}
}
