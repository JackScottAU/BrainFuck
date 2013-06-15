using JackScottAU.BrainFuck.Library;
using JackScottAU.BrainFuck.Library.Types;
using System;
using System.Collections.Generic;

namespace JackScottAU.BrainFuck.App
{
	class Program
	{
		public static void Main(string[] args)
		{
			if (args.Length < 1)
			{
				PrintHelp();
				return;
			}

			Parser parser = new Parser();
			Interpreter interpreter = new Interpreter(30000, System.Console.In, System.Console.Out);

			parser.GenerateASTFromString(System.IO.File.ReadAllText(args[0]));
			List<IInstruction> program = parser.AbstractSyntaxTree;

			interpreter.Interpret(program);
		}

		static void PrintHelp()
		{
			System.Console.WriteLine("BrainFuck Tools");
			System.Console.WriteLine("Usage: " + Environment.GetCommandLineArgs()[0] + " <inputfile>");
		}
	}
}
