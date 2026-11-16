public class ItemPatch
{
    public virtual string ItemName => "";

    public virtual void Created(Item __instance) {}
    public virtual void BeingUsed(Item __instance) {}
    public virtual void UsedFinished(Item __instance) {}
    public virtual void CancelUsed(Item __instance) {}
    public virtual void ItemDataUpdate(ItemInstanceData instanceData, Item __instance) {}
}