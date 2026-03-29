namespace DisCore.Features.ModuleSystem.BaseClass;

public abstract class ModuleBase {
    public virtual string Name { get; }
    public virtual int Id { get; internal set; } = -1;
    public virtual string Description { get; } = "No description provided.";
    public bool IsEnabled { get; internal set; } = false;

    protected ModuleBase() {
        if(Name == null || Name == string.Empty)
            Name = GetType().Name;
    }
        
    public virtual void OnEnable() {}
    public virtual void OnDisable() {}
}