public class BaseCodeOverride
{
    public virtual void Created(string ItemName, Item item) {}
    public virtual void UsedFinished(string ItemName, Item item) {}
    public virtual void SecondaryUsedFinished(string ItemName, Item item) {}
    public virtual void ItemDataUpdated(string ItemName, ItemInstanceData instanceData, Item item) {}
}