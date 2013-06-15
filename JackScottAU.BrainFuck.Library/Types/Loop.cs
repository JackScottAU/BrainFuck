using System.Collections.Generic;

namespace JackScottAU.BrainFuck.Library.Types
{
	/// <summary>
	/// Represents the two operators which make up BrainFuck's loops (equivalent of C's while) and the instructions which are between them.
	/// </summary>
	public class Loop : IInstruction
	{
		/// <summary>
		/// The list of instructions within the loop. Can contain more loops.
		/// </summary>
		public List<IInstruction> Statements { get; set; }
	}
}
