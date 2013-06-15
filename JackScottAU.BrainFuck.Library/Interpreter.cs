using JackScottAU.BrainFuck.Library.Types;
using System;
using System.Collections.Generic;
using System.IO;

namespace JackScottAU.BrainFuck.Library
{
	public class Interpreter
	{
		/// <summary>
		/// Holds the working memory for the program.
		/// </summary>
		private Byte[] _memory;

		/// <summary>
		/// Where to get our input.
		/// </summary>
		private TextReader _inputStream;

		/// <summary>
		/// Where to put our output.
		/// </summary>
		private TextWriter _outputStream;

		/// <summary>
		/// Creates a new context for interpreting programs within.
		/// </summary>
		/// <param name="memorySize">How large our memory should be.</param>
		/// <param name="inputStream">Where to get input.</param>
		/// <param name="outputStream">Where to put output.</param>
		public Interpreter(int memorySize, TextReader inputStream, TextWriter outputStream)
		{
			_memory = new Byte[memorySize];

			_inputStream = inputStream;

			_outputStream = outputStream;
		}

		/// <summary>
		/// Interprets a piece of code.
		/// </summary>
		/// <param name="syntaxTree">The AST representation of the code.</param>
		public void Interpret(List<IInstruction> syntaxTree)
		{
			throw new NotImplementedException();
		}
	}
}
