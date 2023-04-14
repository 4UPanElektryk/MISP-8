﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MISP_8.Assembler
{
	public class Instruction
	{
		public string Prefix;
		public int Args;
		public byte Bytename;

		public Instruction(string prefix, int args, byte bytename)
		{
			Prefix = prefix;
			Args = args;
			Bytename = bytename;
		}
		public virtual byte[] Process(string[] args)
		{
			List<byte> output = new List<byte> 
			{
				Bytename
			};
			args = args.Skip(1).ToArray();
			foreach (string item in args)
			{
				output.Add(VariableHandler.GetVariable(item));
			}
			return output.ToArray();
		}
	}
	public class Replacer
	{
		public static List<Instruction> Insts;
		public Replacer() 
		{
			Insts = new List<Instruction> 
			{
				new Instruction("lda",1,0x10),
				new Instruction("sta",2,0x11),
				new Instruction("rtab",0,0x20),
				new Instruction("rtbc",0,0x21),
				new Instruction("rtcd",0,0x22),
				new Instruction("add",0,0x01),
				new Instruction("sub",0,0x02),
				new VarInst("$"),
			};
		}
		public static byte[] ProcessLine(string line)
		{
			line = line.Split(';')[0];
			string[] args = line.Split(' ');
			foreach (Instruction item in Insts)
			{
				if (line.StartsWith(item.Prefix))
				{
					return item.Process(args);
				}
			}
			return null;
		}
	}
}
