using JackScottAU.BrainFuck.Library.Types;
using JackScottAU.BrainFuck.Library.Interpreter;
using JackScottAU.BrainFuck.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JackScottAU.BrainFuck.App
{
	class Program
	{
		static void Main(string[] args)
		{
			Parser parser = new Parser();
			Interpreter interpreter = new Interpreter(30000, System.Console.In, System.Console.Out);
			
			//List<IInstruction> program = 
		}
	}
}
