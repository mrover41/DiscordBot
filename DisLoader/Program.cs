using System.Reflection;
using DisLoader.Base;
using DisLoader.Core.ModuleSystem;

public class Program {
	public static void Main(string[] args) {
		Console.WriteLine("________  .__       .____                     .___            \n\\______ \\ |__| _____|    |    _________     __| _/___________ \n |    |  \\|  |/  ___/    |   /  _ \\__  \\   / __ |/ __ \\_  __ \\\n |    `   \\  |\\___ \\|    |__(  <_> ) __ \\_/ /_/ \\  ___/|  | \\/\n/_______  /__/____  >_______ \\____(____  /\\____ |\\___  >__|   \n        \\/        \\/        \\/         \\/      \\/    \\/       \n  _________                                                   \n /   _____/ ______________  __ ___________                    \n \\_____  \\_/ __ \\_  __ \\  \\/ // __ \\_  __ \\                   \n /        \\  ___/|  | \\/\\   /\\  ___/|  | \\/                   \n/_______  /\\___  >__|    \\_/  \\___  >__|                      \n        \\/     \\/                 \\/                          ");

		if (args.Length <= 0) {
			Console.WriteLine("Usage: DisLoader <dll path>");
			return;
		}
		
		string dllPath = args[0];
		Console.WriteLine(dllPath);

		if (!Directory.Exists(dllPath)) return;
		
		List<string> dllFiles = Directory.GetFiles(dllPath, "*.dll").ToList();

		foreach (string dllFile in dllFiles) {
			Console.WriteLine("load: " + dllFile);
			
			Assembly assembly = Assembly.LoadFrom(dllFile);

			Type mainClass = assembly.GetTypes().First(x => x.IsSubclassOf(typeof(ServerModule)) && !x.IsAbstract);

			if (mainClass == null) {
				Console.WriteLine("[ERROR] File " + dllFile + " already exists and can't be loaded");
				return;
			}
			
			ServerModule instance = (ServerModule)Activator.CreateInstance(mainClass);
			
			ModuleManager.RegModule(instance);
			
			Console.WriteLine("[INFO] Loaded " + dllFile);
			/*Console.WriteLine($"[INFO] Author: {instance.Author}\n" +
			                  $"Version: {instance.Version}\n" +
			                  $"Name: {instance.Name}\n" +
			                  $"Description: {instance.Description}");*/
			instance.OnLoad();
			
			Console.WriteLine("[INFO] Registered " + dllFile);
		}
		
		Console.WriteLine("Loading...");
		
		ModuleManager.LoadModules();
		
		Console.WriteLine("Press any key to exit...");
		Console.ReadKey();

		ModuleManager.UnloadAllModules();
		ModuleManager.UnReg();
	}
}