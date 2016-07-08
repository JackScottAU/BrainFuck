using JackScottAU.BrainFuck.Library;
using JackScottAU.BrainFuck.Library.Types;
using System;
using System.Collections.Generic;

namespace JackScottAU.BrainFuck.App
{
    /// <summary>
    /// Command-line program to interface with the Brainfuck tools.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Entry point of the program. Processes command-line arguments.
        /// </summary>
        /// <param name="args">The command-line arguments.</param>
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

        /// <summary>
        /// Prints help and usage information to the console.
        /// </summary>
        private static void PrintHelp()
        {
            Console.WriteLine("JackScottAU's BrainFuck Tools");
            Console.WriteLine("Released under the terms of the ISC license.");
            Console.WriteLine("Usage: " + Environment.GetCommandLineArgs()[0] + " <inputfile>");
        }
    }
}
