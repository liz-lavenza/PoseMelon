using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using MelonLoader;

namespace PoseMelon
{
	public class PoseMelonPlugin : MelonPlugin
	{
		public override void OnApplicationStarted()
		{
			try
			{
				string text = File.ReadAllText("./PoseMod/Modules/DetectedVersion.ini");
				Assembly assembly = Assembly.LoadFile("./PoseMod/Modules/" + text);
				Type[] types = assembly.GetTypes();
				foreach (Type type in types)
				{
					if (type.IsClass && type.Namespace == "pmcaller" && type.Name == "pmcaller")
					{
						MethodInfo method = type.GetMethod("Call");
						method.Invoke(null, null);
						break;
					}
				}
			}
			catch (Exception ex)
			{
				File.AppendAllText("pm_SideInjector error.txt", ex.Message + "\n" + ex.StackTrace);
			}
		}
	}
}
