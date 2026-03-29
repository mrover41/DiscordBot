namespace DisCore.Features.CommandSystem.Attributies;

[AttributeUsage(AttributeTargets.Class)]
public sealed class LoadCommandAttribute : Attribute {
    public Type ComponentType { get; }
    
    public LoadCommandAttribute(Type componentType) {
        ComponentType = componentType;
    }
}