using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Reflection.Emit;
using JackScottAU.BrainFuck.Library.Types;

namespace JackScottAU.BrainFuck.Library
{
	public class Compiler
	{
		public static void Compile(List<IInstruction> syntaxTree, string outputFileName, string outputName)
		{
			AssemblyBuilder asm = AppDomain.CurrentDomain.DefineDynamicAssembly(new AssemblyName(outputName),AssemblyBuilderAccess.RunAndSave);

			ModuleBuilder mod = asm.DefineDynamicModule(outputName, outputFileName);
			TypeBuilder type = mod.DefineType("Program", TypeAttributes.Class);

			MethodBuilder main = type.DefineMethod("Main", MethodAttributes.Public | MethodAttributes.Static);
			
			ILGenerator il = main.GetILGenerator();
			il.Emit(OpCodes.Ldstr, "Hello world!");
			il.Emit(OpCodes.Call, typeof(Console).GetMethod("WriteLine",
				BindingFlags.Public | BindingFlags.Static,
				null, new Type[] { typeof(String) }, null));
			il.Emit(OpCodes.Ret);

			
			type.CreateType();
			asm.SetEntryPoint(main);
			asm.Save(outputFileName);
		}
	}
}
