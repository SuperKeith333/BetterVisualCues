using UnityEngine;

public class ShroomberryPatch : ItemPatch
{
    public override string ItemName => "Shroomberry";

    public override void Created(Item __instance)
    {
        if (MeshRegistry.GetOriginal("Shroomberry") == null) {
            MeshRegistry.SetOriginal("Shroomberry", __instance.transform.Find("shroomberry").GetComponent<MeshFilter>().sharedMesh);
        }
    }

    public override void AnimationUpdated(string emoteName, CharacterAnimations __instance)
    {
        if (emoteName == "A_Scout_Land")
        {
            PlayRemoveAnimationPatch.item?.transform.Find("shroomberry").GetComponent<MeshFilter>().sharedMesh = MeshRegistry.GetOriginal("Shroomberry");
            PlayRemoveAnimationPatch.item?.transform.Find("shroomberry/Leaves.001 (1)").gameObject.SetActive(true);
        }
    }

    public override void AnimationTick()
    {
        if (PlayRemoveAnimationPatch.anim == "A_Scout_Use_Item")
        {
            float progress = 1f / (1.2f / PlayRemoveAnimationPatch.animTime);
            if (progress > 0.25f && PlayRemoveAnimationPatch.item?.transform.Find("shroomberry").GetComponent<MeshFilter>().sharedMesh != MeshRegistry.Get("Shroomberry_Eat_2"))
            {
                PlayRemoveAnimationPatch.item?.transform.Find("shroomberry").GetComponent<MeshFilter>().sharedMesh = MeshRegistry.Get("Shroomberry_Eat_2");
                PlayRemoveAnimationPatch.item?.transform.Find("shroomberry/Leaves.001 (1)").gameObject.SetActive(false);
            } 
            if (progress > 0.75f && PlayRemoveAnimationPatch.item?.transform.Find("shroomberry").GetComponent<MeshFilter>().sharedMesh != MeshRegistry.Get("Shroomberry_Eat_3"))
            {
                PlayRemoveAnimationPatch.item?.transform.Find("shroomberry").GetComponent<MeshFilter>().sharedMesh = MeshRegistry.Get("Shroomberry_Eat_3");
            } 
        }
    }
}