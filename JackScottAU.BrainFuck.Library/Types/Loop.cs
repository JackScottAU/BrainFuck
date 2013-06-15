using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JackScottAU.BrainFuck.Library.Types
{
	class Loop : IInstruction
	{
		public List<IInstruction> Statements { get; set; }
	}
}
