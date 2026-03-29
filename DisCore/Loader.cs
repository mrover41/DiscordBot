using DisLoader.Base;

namespace DisCore;

public class Loader : ServerModule {
    public override string Name => "Loader";
    public override string Version => "1.0.0";

    public override void OnLoad() {
        Console.WriteLine("Hello World!");
        base.OnLoad();
    }

    public override void OnUnload() {
        Console.WriteLine("НЕЕЕЕЕТ, Я НЕ ХОЧУ УМИРАТЬ!!!!");
        base.OnUnload();
    }
}