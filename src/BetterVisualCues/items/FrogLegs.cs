using UnityEngine;

public class FrogLegs : ItemPatch
{
    public override string ItemName => "FrogLegs";

    public override void Created(Item __instance)
    {
        if (MeshRegistry.GetOriginal("Frog Legs") == null)
            MeshRegistry.SetOriginal("Frog Legs", __instance.transform.Find("FrogLegs (1)/FrogLegsGreen").GetComponent<MeshFilter>().sharedMesh);
    }

    public override void AnimationUpdated(string emoteName, CharacterAnimations __instance)
    {
        if (emoteName == "A_Scout_Land")
        {
            PlayRemoveAnimationPatch.item?.transform.Find("FrogLegs (1)/FrogLegsGreen").GetComponent<MeshFilter>().sharedMesh = MeshRegistry.GetOriginal("Frog Legs");
        }
    }

    public override void AnimationTick()
    {
        if (PlayRemoveAnimationPatch.anim == "A_Scout_Use_Item")
        {
            float progress = 1f / (1.2f / PlayRemoveAnimationPatch.animTime);
            if (progress > 0.5f && PlayRemoveAnimationPatch.item?.transform.Find("FrogLegs (1)/FrogLegsGreen").GetComponent<MeshFilter>().sharedMesh != MeshRegistry.Get("Frog_Legs_Eat_2"))
            {
                PlayRemoveAnimationPatch.item?.transform.Find("FrogLegs (1)/FrogLegsGreen").GetComponent<MeshFilter>().sharedMesh = MeshRegistry.Get("Frog_Legs_Eat_2");
            }
        }
    }
}