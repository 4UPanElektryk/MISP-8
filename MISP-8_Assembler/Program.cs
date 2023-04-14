using MISP_8.Assembler;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISP_.Assembler
{
	public class Program
	{
		static void Main(string[] args)
		{
			string inputasm = args[0];
			string outputbin = args[1];
			List<byte> output = new List<byte>();
			new Replacer();
			new VariableHandler();
			foreach (string item in File.ReadAllLines(inputasm))
			{
				if (Replacer.ProcessLine(item) != null)
				{
					output.AddRange(Replacer.ProcessLine(item));
				}
			}
			File.WriteAllBytes(outputbin, output.ToArray());
		}
	}
}
