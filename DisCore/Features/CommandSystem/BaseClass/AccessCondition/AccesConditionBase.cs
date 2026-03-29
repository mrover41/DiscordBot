using DSharpPlus.Entities;

namespace DisCore.Features.CommandSystem.BaseClass.AccessCondition;

public abstract class AccessConditionBase {
    public AccessConditionBase() {
        
    }
    
    public virtual bool CheckAccess(DiscordMember member, string[] args) {
        return true;
    }
}