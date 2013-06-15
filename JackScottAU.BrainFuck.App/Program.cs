using JackScottAU.BrainFuck.Library;
using JackScottAU.BrainFuck.Library.Types;
using System.Collections.Generic;

namespace JackScottAU.BrainFuck.App
{
	class Program
	{
		static void Main(string[] args)
		{
			Parser parser = new Parser();
			Interpreter interpreter = new Interpreter(30000, System.Console.In, System.Console.Out);

			parser.GenerateASTFromString(args[1]);
			List<IInstruction> program = parser.AbstractSyntaxTree;

			interpreter.Interpret(program);
		}
	}
}
