using UnityEngine;

public class GranolaBar : ItemPatch
{
    public override string ItemName => "Granola Bar";

    public override void Created(Item __instance)
    {
        if (MeshRegistry.GetOriginal("Granola Bar") == null)
            MeshRegistry.SetOriginal("Granola Bar", __instance.transform.Find("GranolaBar").GetComponent<MeshFilter>().sharedMesh);
    }

    public override void AnimationUpdated(string emoteName, CharacterAnimations __instance)
    {
        if (emoteName == "A_Scout_Land")
        {
            PlayRemoveAnimationPatch.item?.transform.Find("GranolaBar").GetComponent<MeshFilter>().sharedMesh = MeshRegistry.GetOriginal("Granola Bar");
        }
    }

    public override void AnimationTick()
    {
        if (PlayRemoveAnimationPatch.anim == "A_Scout_Use_Item")
        {
            float progress = 1f / (1.2f / PlayRemoveAnimationPatch.animTime);
            if (progress > 0.25f &&  PlayRemoveAnimationPatch.item?.transform.Find("GranolaBar").GetComponent<MeshFilter>().sharedMesh != MeshRegistry.Get("Granola_Bar_Eat_2"))
            {
                PlayRemoveAnimationPatch.item?.transform.Find("GranolaBar").GetComponent<MeshFilter>().sharedMesh = MeshRegistry.Get("Granola_Bar_Eat_2");
            }       
            if (progress > 0.75f &&  PlayRemoveAnimationPatch.item?.transform.Find("GranolaBar").GetComponent<MeshFilter>().sharedMesh != MeshRegistry.Get("Granola_Bar_Eat_3"))
            {
                PlayRemoveAnimationPatch.item?.transform.Find("GranolaBar").GetComponent<MeshFilter>().sharedMesh = MeshRegistry.Get("Granola_Bar_Eat_3");
            }
        }
    }
}