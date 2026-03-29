using System.Collections.Generic;
using DisLoader.Base;

namespace DisLoader.Core.ModuleSystem;

public static class ModuleManager {
    public static readonly System.Collections.Generic.Dictionary<int, ServerModule> Modules = new();

    public static int RegModule(ServerModule module) {
        int id = Modules.Count + 1;
        Modules.Add(id, module);
        return id;
    }
    
    public static ServerModule GetModule(int id) {
        return Modules[id];
    }

    public static void LoadModules() {
        foreach (ServerModule module in Modules.Values) {
            module.OnLoad();
        }
    }

    public static void LoadModule(int id) {
        Modules[id].OnLoad();
    }

    public static void UnloadModule(int id) {
        Modules[id].OnUnload();
    }

    public static void UnloadAllModules() {
        foreach (ServerModule module in Modules.Values) {
            module.OnUnload();
        }
    }

    public static void UnReg() {
        Modules.Clear();
    }
}