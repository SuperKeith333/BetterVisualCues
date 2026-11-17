using BetterVisualCues;
using UnityEngine;

public class LollipopPatch : ItemPatch
{
    public override string ItemName => "Lollipop";

    public override void Created(Item __instance)
    {
        if (MeshRegistry.GetOriginal("Lollipop") == null)
            MeshRegistry.SetOriginal("Lollipop", __instance.transform.Find("Lollipop/Cube").GetComponent<MeshFilter>().sharedMesh);
    }

    // public override void SecondaryBeingUsed(Item __instance)
    // {
    //     if (__instance.castProgress > 0.25f &&  __instance.transform.Find("Lollipop/Cube").GetComponent<MeshFilter>().sharedMesh != MeshRegistry.Get("Lollipop_Eat_2"))
    //     {
    //         __instance.transform.Find("Lollipop/Cube").GetComponent<MeshFilter>().sharedMesh = MeshRegistry.Get("Lollipop_Eat_2");
    //     }              
    //     if (__instance.castProgress > 0.75f &&  __instance.transform.Find("Lollipop/Cube").GetComponent<MeshFilter>().sharedMesh != MeshRegistry.Get("Lollipop_Eat_3"))
    //     {
    //         __instance.transform.Find("Lollipop/Cube").GetComponent<MeshFilter>().sharedMesh = MeshRegistry.Get("Lollipop_Eat_3");
    //     }
    // }

    // public override void SecondaryCancelUsed(Item __instance)
    // {
    //     __instance.transform.Find("Lollipop/Cube").GetComponent<MeshFilter>().sharedMesh = MeshRegistry.GetOriginal("Lollipop");
    // }

    public override void AnimationUpdated(string emoteName, CharacterAnimations __instance)
    {
        if (emoteName == "A_Scout_Land")
        {
            PlayRemoveAnimationPatch.item?.transform.Find("Lollipop/Cube").GetComponent<MeshFilter>().sharedMesh = MeshRegistry.GetOriginal("Lollipop");
        }
    }

    public override void AnimationTick()
    {
        if (PlayRemoveAnimationPatch.anim == "A_Scout_Use_Item")
        {
            float progress = 1f / (1.2f / PlayRemoveAnimationPatch.animTime);
            if (progress > 0.25f && PlayRemoveAnimationPatch.item?.transform.Find("Lollipop/Cube").GetComponent<MeshFilter>().sharedMesh != MeshRegistry.Get("Lollipop_Eat_2"))
            {
                PlayRemoveAnimationPatch.item?.transform.Find("Lollipop/Cube").GetComponent<MeshFilter>().sharedMesh = MeshRegistry.Get("Lollipop_Eat_2");
            }              
            if (progress > 0.75f &&  PlayRemoveAnimationPatch.item?.transform.Find("Lollipop/Cube").GetComponent<MeshFilter>().sharedMesh != MeshRegistry.Get("Lollipop_Eat_3"))
            {
                PlayRemoveAnimationPatch.item?.transform.Find("Lollipop/Cube").GetComponent<MeshFilter>().sharedMesh = MeshRegistry.Get("Lollipop_Eat_3");
            }
        }
    }
}