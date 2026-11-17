using UnityEngine;

public class ChubbyShroom : ItemPatch
{
    public override string ItemName => "Mushroom Chubby";

    public override void Created(Item __instance)
    {
        if (MeshRegistry.GetOriginal("Chubby Shroom") == null)
            MeshRegistry.SetOriginal("Chubby Shroom", __instance.transform.Find("Mushroom Chubby").GetComponent<MeshFilter>().sharedMesh);
    }

    public override void AnimationUpdated(string emoteName, CharacterAnimations __instance)
    {
        if (emoteName == "A_Scout_Land")
        {
            PlayRemoveAnimationPatch.item?.transform.Find("Mushroom Chubby").GetComponent<MeshFilter>().sharedMesh = MeshRegistry.GetOriginal("Chubby Shroom");
        }
    }

    public override void AnimationTick()
    {
        if (PlayRemoveAnimationPatch.anim == "A_Scout_Use_Item")
        {
            float progress = 1f / (1.2f / PlayRemoveAnimationPatch.animTime);
            if (progress > 0.5f &&  PlayRemoveAnimationPatch.item?.transform.Find("Mushroom Chubby").GetComponent<MeshFilter>().sharedMesh != MeshRegistry.Get("Chubby_Shroom_Eat_2"))
            {
                PlayRemoveAnimationPatch.item?.transform.Find("Mushroom Chubby").GetComponent<MeshFilter>().sharedMesh = MeshRegistry.Get("Chubby_Shroom_Eat_2");
            }
        }
    }
}