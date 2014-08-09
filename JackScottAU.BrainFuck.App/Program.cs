using JackScottAU.BrainFuck.Library;
using JackScottAU.BrainFuck.Library.Types;
using System;
using System.Collections.Generic;
using System.Text;

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

			parser.GenerateASTFromString(System.IO.File.ReadAllText(args[1]));
			List<IInstruction> program = parser.AbstractSyntaxTree;

            if(args[0] == "-i")
            {
                Interpreter interpreter = new Interpreter(30000, System.Console.In, System.Console.Out);
                interpreter.Interpret(program);
            }
            else
            {
                // compile to C code.
                CCompiler compiler = new CCompiler();
                StringBuilder builder = compiler.Compile(program);
                System.IO.File.WriteAllText(args[2], builder.ToString());
            }
		}

		static void PrintHelp()
		{
			System.Console.WriteLine("BrainFuck Tools");
			System.Console.WriteLine("Usage: " + Environment.GetCommandLineArgs()[0] + "[-i/-c] <inputfile>");
            System.Console.WriteLine("C: Compile to C code, I: interpret");
		}
	}
}
