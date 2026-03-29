using DisCore.Features.ModuleSystem.BaseClass;

namespace DisCore.Features.Events.Args.Module;

public class LoadingModuleEventArgs {
    public LoadingModuleEventArgs(ModuleBase module) {
        Module = module;
    }
    public ModuleBase Module { get; }
    public bool IsAllowed { get; set; }
}