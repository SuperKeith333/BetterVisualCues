public class ItemPatch
{
    public virtual string ItemName => "";
    public virtual string startAnimName => "A_Scout_Use_Item";
    public virtual string stopAnimName => "A_Scout_Land";

    public virtual void Created(Item __instance) {}
    public virtual void BeingUsed(Item __instance)
    {
        if (__instance.castProgress < 0.15f)
        {
            __instance.holderCharacter.view.RPC("RPCA_PlayRemove", Photon.Pun.RpcTarget.All, startAnimName, false);
        }
    }
    public virtual void UsedFinished(Item __instance) {}
    public virtual void CancelUsed(Item __instance)
    {
        __instance.holderCharacter.view.RPC("RPCA_PlayRemove", Photon.Pun.RpcTarget.All, stopAnimName, false);
    }
    public virtual void SecondaryBeingUsed(Item __instance) {}
    public virtual void SecondaryCancelUsed(Item __instance) {}
    public virtual void ItemDataUpdate(ItemInstanceData instanceData, Item __instance) {}
    public virtual void AnimationUpdated(string emoteName, CharacterAnimations __instance) {}
    public virtual void AnimationTick() {}
}