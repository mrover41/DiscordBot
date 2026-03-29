namespace DisLoader.Base;

public abstract class ServerModule {
    public virtual string Name { get; } = "NoName";
    public virtual string Description { get; } = "NoDescription";
    public virtual string Author { get; } = "-";
    public abstract string Version { get; }
    
    public virtual void OnLoad() { }
    public virtual void OnUnload() { }
}