using System.Reflection;
using DisCore.Features.CommandSystem.BaseClass.Managers;
using DisCore.Features.ModuleSystem.Managers;
using DisLoader.Base;

namespace DisCore;

public class Loader : ServerModule {
    public override string Name => "Core";
    public override string Version => "1.0.0";

    public override void OnLoad() {
        ModuleManager.RegisterModules(Assembly.GetExecutingAssembly());
        CommandManager.RegisterAllCommands(Assembly.GetExecutingAssembly());
        base.OnLoad();
    }

    public override void OnUnload() {
        ModuleManager.UnregisterAllModuels();
        base.OnUnload();
    }
}