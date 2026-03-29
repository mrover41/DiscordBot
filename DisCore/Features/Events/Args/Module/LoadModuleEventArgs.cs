using DisCore.Features.ModuleSystem.BaseClass;

namespace DisCore.Features.Events.Args.Module;

public class LoadModuleEventArgs {
    public LoadModuleEventArgs(ModuleBase module) {
        ModuleName = module;
    }
    
    public ModuleBase ModuleName { get; }
}