using System.Reflection;
using DisCore.Features.CommandSystem.BaseClass.Managers;
using DisLoader.Base;

namespace DisCommands;

public class Loader : ServerModule {
    public override string Name => "Commands";
    public override string Version => "1.0.0";

    public override void OnLoad() {
        CommandManager.RegisterAllCommands(Assembly.GetExecutingAssembly());
        base.OnLoad();
    }

    public override void OnUnload() {
        base.OnUnload();
    }
}