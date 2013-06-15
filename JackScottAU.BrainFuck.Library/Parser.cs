using JackScottAU.BrainFuck.Library.Types;
using System;
using System.Collections.Generic;

namespace JackScottAU.BrainFuck.Library
{
	class Parser
	{
		/// <summary>
		/// Holds the intermediate representation of the program as an Abstract Syntax Tree.
		/// </summary>
		public List<IInstruction>AbstractSyntaxTree { get; set; }

		/// <summary>
		/// Holds the portion of the program that has not yet been converted.
		/// </summary>
		private String _inputString;

		/// <summary>
		/// Creates a new empty program.
		/// </summary>
		public Parser()
		{
			AbstractSyntaxTree = new List<IInstruction>();
		}

		/// <summary>
		/// Parses a given string into a BrainFuck AST.
		/// </summary>
		/// <param name="inputString">The string to parse.</param>
		public void GenerateASTFromString(String inputString)
		{
			this._inputString = inputString;

			AbstractSyntaxTree = HandleInstructions();
		}

		/// <summary>
		/// Iterates over all the instructions.
		/// </summary>
		/// <returns></returns>
		private List<IInstruction> HandleInstructions()
		{
			///A list of instructions in this scope.
			List<IInstruction> result = new List<IInstruction>();

			///The character we are currently dealing with.
			String current;

			//Try and get another character. If there isn't one, don't try and parse it.
			while((current = GetCharacterFromInputString()) != null)
			{
				switch (current)
				{
					//Add 1 to current cell.
					case "+":
						result.Add(new Increment());
						break;

					//Subtract 1 from current cell.
					case "-":
						result.Add(new Decrement());
						break;

					//Move to next cell.
					case ">":
						result.Add(new NextCell());
						break;

					//Move to previous cell.
					case "<":
						result.Add(new PreviousCell());
						break;

					//Input byte.
					case ",":
						result.Add(new InputByte());
						break;

					//Output byte.
					case ".":
						result.Add(new OutputByte());
						break;

					//A loop. The other end of the loop is matched by the HandleLoop() function so we don't need to do that here.
					case "[":
						result.Add(HandleLoop());
						break;

					//We ignore all other characters.
					default:
						//Do nothing.
						break;
				}
			}

			//Return our syntax tree.
			return result;
		}

		/// <summary>
		/// Handles a loop in the code.
		/// </summary>
		/// <returns>A loop filled with many glorious instructions.</returns>
		private Loop HandleLoop()
		{
			//An empty loop.
			Loop result = new Loop();

			//Match the end of the loop.
			int i = FindMatchingEndOfLoop();

			//Divide this into bits within this loop, and bits outside.
			string firstpart = i == -1 ? this._inputString : this._inputString.Substring(0, i);
			this._inputString = this._inputString.Substring(i);

			//A new parsing context.
			Parser subprogram = new Parser();

			//Our loop needs to contains a list of instructions.
			subprogram.GenerateASTFromString(firstpart);
			result.Statements = subprogram.AbstractSyntaxTree;

			return result;
		}

		/// <summary>
		/// Find the matching ] to the one that has just been removed from the start of the string.
		/// </summary>
		/// <returns>The position offset from zero of the ] that matches.</returns>
		private int FindMatchingEndOfLoop()
		{
			//For nested loops, we only want to match if this is the matching ].
			int depth = 0;

			//Whether we have found the ] we are looking for.
			bool found = false;

			//The position in the string.
			int currentPosition = 0;

			//Loop through until we find it.
			while (!found)
			{
				//Grab a new character off the list. We don't want to alter the list at all.
				String currentChararacter = this._inputString.Substring(currentPosition, 1);

				switch (currentChararacter)
				{
					case "[":
						//Another sub-loop.
						depth++;
						break;

					case "]":
						if (depth == 0)
						{
							//We found it!
							found = true;
							break;
						}
						else
						{
							//This is not the ] you are looking for.
							depth--;
						}
						break;
				}

				currentPosition++;
			}

			return currentPosition;
		}

		/// <summary>
		/// Removes a character from the object's input string and returns it.
		/// </summary>
		/// <returns>The first character from the input string.</returns>
		private String GetCharacterFromInputString()
		{
			///Holds the character (there will only be one) we are going to return.
			String result;

			try
			{
				//Remove the first character and use it.
				result = this._inputString.Substring(0, 1);

				//Remove the first character from the string.
				this._inputString = this._inputString.Substring(1);

				//Return the only character in our character array.
				return result;
			}
			catch (ArgumentOutOfRangeException)
			{
				//We have been given a string with no more characters.
				return null;
			}
		}
	}
}
