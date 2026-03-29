using DisCore.Features.Events.Args.Module;

namespace DisCore.Features.Events.Handles;

public class ModuleHandler {
    public static event Action<LoadingModuleEventArgs> LoadingModule;
    public static event Action<LoadModuleEventArgs> LoadModule;

    public static LoadingModuleEventArgs OnLoadingModule(LoadingModuleEventArgs args) {
        LoadingModule?.Invoke(args);
        return args;
    }

    public static LoadModuleEventArgs OnLoadModule(LoadModuleEventArgs args) {
        LoadModule?.Invoke(args);
        return args;
    }
}