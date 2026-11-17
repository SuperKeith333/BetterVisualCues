using UnityEngine;

public class ChickenPatch : ItemPatch
{
    public override string ItemName => "EggTurkey";

    public override void Created(Item __instance)
    {
        if (MeshRegistry.GetOriginal("Chicken") == null) {
            MeshRegistry.SetOriginal("Chicken", __instance.transform.Find("Chicken").GetComponent<MeshFilter>().sharedMesh);
        }
    }

    public override void AnimationUpdated(string emoteName, CharacterAnimations __instance)
    {
        if (emoteName == "A_Scout_Land")
        {
            PlayRemoveAnimationPatch.item?.transform.Find("Chicken").GetComponent<MeshFilter>().sharedMesh = MeshRegistry.GetOriginal("Chicken");
        }
    }

    public override void AnimationTick()
    {
        if (PlayRemoveAnimationPatch.anim == "A_Scout_Use_Item")
        {
            float progress = 1f / (1.2f / PlayRemoveAnimationPatch.animTime);
            if (progress > 0.25f && PlayRemoveAnimationPatch.item?.transform.Find("Chicken").GetComponent<MeshFilter>().sharedMesh != MeshRegistry.Get("Chicken_Eat_2"))
            {
                PlayRemoveAnimationPatch.item?.transform.Find("Chicken").GetComponent<MeshFilter>().sharedMesh = MeshRegistry.Get("Chicken_Eat_2");
            } 
            if (progress > 0.75f && PlayRemoveAnimationPatch.item?.transform.Find("Chicken").GetComponent<MeshFilter>().sharedMesh != MeshRegistry.Get("Chicken_Eat_3"))
            {
                PlayRemoveAnimationPatch.item?.transform.Find("Chicken").GetComponent<MeshFilter>().sharedMesh = MeshRegistry.Get("Chicken_Eat_3");
            } 
        }
    }
}