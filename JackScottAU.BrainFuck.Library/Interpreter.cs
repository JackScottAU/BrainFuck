using System;
using System.Collections.Generic;
using System.IO;
using JackScottAU.BrainFuck.Library.Types;

namespace JackScottAU.BrainFuck.Library
{
	public class Interpreter
	{
		/// <summary>
		/// Holds the working memory for the program.
		/// </summary>
		private Byte[] _memory;

		/// <summary>
		/// The index to the current cell in memory.
		/// </summary>
		private int _currentCell;

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

			_currentCell = 0;
		}

		/// <summary>
		/// Interprets a piece of code.
		/// </summary>
		/// <param name="syntaxTree">The AST representation of the code.</param>
		public void Interpret(List<IInstruction> syntaxTree)
		{
			foreach (IInstruction instruction in syntaxTree)
			{
				if (instruction is Decrement)
					_memory[_currentCell]--;

				if (instruction is Increment)
					_memory[_currentCell]++;

				if (instruction is PreviousCell)
					_currentCell--;

				if (instruction is NextCell)
					_currentCell++;

				if (instruction is InputByte)
					_memory[_currentCell] = Convert.ToByte(_inputStream.Read());

				if (instruction is OutputByte)
					_outputStream.Write((char)_memory[_currentCell]);

				if (instruction is Loop)
				{
					while(_memory[_currentCell] != 0)
					{
						Loop temp = (Loop)instruction;

						Interpret(temp.Statements);
					}
				}
			}
		}
	}
}
