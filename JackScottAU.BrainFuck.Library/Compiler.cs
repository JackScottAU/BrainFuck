using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Reflection.Emit;

namespace JackScottAU.BrainFuck.Library
{
	public class Compiler
	{
		public Compiler()
		{

		}

		public void Compile()
		{
			AssemblyBuilder asm = AppDomain.CurrentDomain.DefineDynamicAssembly(
				new AssemblyName("TestOutput"),
				AssemblyBuilderAccess.RunAndSave);

			ModuleBuilder mod = asm.DefineDynamicModule("TestOutput.exe",
				"TestOutput.exe");
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
			asm.Save("TestOutput.exe");
		}
	}
}
