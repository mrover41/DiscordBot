using System.Reflection;
using DisCore.Features.Events.Args.Module;
using DisCore.Features.ModuleSystem.Attributies;
using DisCore.Features.ModuleSystem.BaseClass;

namespace DisCore.Features.ModuleSystem.Managers;
//Сорри за копипаст методов, мне в падлу это сейчас исправлять, как-нибудь потом
public static class ModuleManager {
        public static List<ModuleBase> Modules { get; private set; } = new List<ModuleBase>();

        [Obsolete("Pleas use attributes")]
        internal static void RegisterModule(ModuleBase module, bool isEnabled = true) {
            if (module != null && !Modules.Contains(module)) {
                Modules.Add(module);
                if (module.Id == -1)
                    module.Id = Modules.Count + 1;
                //Corwarx_Project.Events.Handles.Module.OnRegModuleEvent(new Events.Args.Modules.RegModuleEventArg(module));
                if (isEnabled) {
                    //if (!Corwarx_Project.Events.Handles.Module.OnEnableModuleEvent(new Events.Args.Modules.EnableModuleEventArg(module)).IsAllowed)
                      //  return;
                    module.OnEnable();
                    //Corwarx_Project.Events.Handles.Module.OnEnabledModuleEventArg(new Events.Args.Modules.EnabledModuleEventArg(module));
                }
            } else {
                Console.WriteLine($"Module {module.Name} with ID {module.Id} is null or already registered.");
            }
        }

        public static void RegisterModules(Assembly asm, bool enable_modules = true) {
            foreach (Type type in asm.GetTypes()) {
                if (type.GetCustomAttribute<LoadModuleAttribute>() != null) {
                    if (!typeof(ModuleBase).IsAssignableFrom(type))
                        throw new Exception($"Error in class: {type.FullName}\n Can`t load module");
                    ModuleBase instance = (ModuleBase)Activator.CreateInstance(type);
                    RegisterModule(instance, false);
                    if (enable_modules)
                        instance.OnEnable();
                }
            }

            //Events.Handles.Module.OnRegisterAssembly();
        }

        internal static void EnableAllModules() {
            foreach (ModuleBase module in Modules) {
                if (module.IsEnabled)
                    continue;

                if (!Features.Events.Handles.ModuleHandler.OnLoadingModule(new LoadingModuleEventArgs(module)).IsAllowed)
                    continue;

                module.OnEnable();
                module.IsEnabled = true;

                Features.Events.Handles.ModuleHandler.OnLoadModule(new LoadModuleEventArgs(module));
            }
        }

        internal static void DisableAllModules() {
            foreach (ModuleBase module in Modules) {
                if (!module.IsEnabled)
                    return;

                module.OnDisable();
                module.IsEnabled = false;
                //Corwarx_Project.Events.Handles.Module.OnDisableModuleEventArg(new Events.Args.Modules.DisableModuleEventArg(module));
            }
        }

       public static bool UnregisterAllModuels() {
           foreach (ModuleBase module in Modules) {
               if (module.IsEnabled) return false;
           }
           Modules.Clear();
           return true;
       }
    }