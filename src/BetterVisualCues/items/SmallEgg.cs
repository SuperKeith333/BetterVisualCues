using UnityEngine;

public class SmallEggPatch : ItemPatch
{
    public override string ItemName => "EggRaven";

    public override void Created(Item __instance)
    {
        if (MeshRegistry.GetOriginal("Egg") == null) {
            MeshRegistry.SetOriginal("Egg", __instance.transform.Find("Egg_SunnySideUp/Mesh").GetComponent<MeshFilter>().sharedMesh);
        }
    }

    public override void AnimationUpdated(string emoteName, CharacterAnimations __instance)
    {
        if (emoteName == "A_Scout_Land")
        {
            PlayRemoveAnimationPatch.item?.transform.Find("Egg_SunnySideUp/Mesh").GetComponent<MeshFilter>().sharedMesh = MeshRegistry.GetOriginal("Egg");
        }
    }

    public override void AnimationTick()
    {
        if (PlayRemoveAnimationPatch.anim == "A_Scout_Use_Item")
        {
            float progress = 1f / (1.2f / PlayRemoveAnimationPatch.animTime);
            if (progress > 0.25f && PlayRemoveAnimationPatch.item?.transform.Find("Egg_SunnySideUp/Mesh").GetComponent<MeshFilter>().sharedMesh != MeshRegistry.Get("Egg_Eat_2"))
            {
                PlayRemoveAnimationPatch.item?.transform.Find("Egg_SunnySideUp/Mesh").GetComponent<MeshFilter>().sharedMesh = MeshRegistry.Get("Egg_Eat_2");
            } 
            if (progress > 0.75f && PlayRemoveAnimationPatch.item?.transform.Find("Egg_SunnySideUp/Mesh").GetComponent<MeshFilter>().sharedMesh != MeshRegistry.Get("Egg_Eat_3"))
            {
                PlayRemoveAnimationPatch.item?.transform.Find("Egg_SunnySideUp/Mesh").GetComponent<MeshFilter>().sharedMesh = MeshRegistry.Get("Egg_Eat_3");
            } 
        }
    }
}