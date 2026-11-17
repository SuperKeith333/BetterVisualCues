using UnityEngine;

public class ButtonShroom : ItemPatch
{
    public override string ItemName => "Mushroom Normie(";

    public override void Created(Item __instance)
    {
        if (MeshRegistry.GetOriginal("Button Shroom") == null)
            MeshRegistry.SetOriginal("Button Shroom", __instance.transform.Find("Mushroom Normie (1)").GetComponent<MeshFilter>().sharedMesh);
    }

    public override void AnimationUpdated(string emoteName, CharacterAnimations __instance)
    {
        if (emoteName == "A_Scout_Land")
        {
            PlayRemoveAnimationPatch.item?.transform.Find("Mushroom Normie (1)").GetComponent<MeshFilter>().sharedMesh = MeshRegistry.GetOriginal("Button Shroom");
        }
    }

    public override void AnimationTick()
    {
        if (PlayRemoveAnimationPatch.anim == "A_Scout_Use_Item")
        {
            float progress = 1f / (1.2f / PlayRemoveAnimationPatch.animTime);
            if (progress > 0.25f &&  PlayRemoveAnimationPatch.item?.transform.Find("Mushroom Normie (1)").GetComponent<MeshFilter>().sharedMesh != MeshRegistry.Get("Button_Shroom_Eat_2"))
            {
                PlayRemoveAnimationPatch.item?.transform.Find("Mushroom Normie (1)").GetComponent<MeshFilter>().sharedMesh = MeshRegistry.Get("Button_Shroom_Eat_2");
            }              
            if (progress > 0.50f &&  PlayRemoveAnimationPatch.item?.transform.Find("Mushroom Normie (1)").GetComponent<MeshFilter>().sharedMesh != MeshRegistry.Get("Button_Shroom_Eat_3"))
            {
                PlayRemoveAnimationPatch.item?.transform.Find("Mushroom Normie (1)").GetComponent<MeshFilter>().sharedMesh = MeshRegistry.Get("Button_Shroom_Eat_3");
            }           
            if (progress > 0.75f &&  PlayRemoveAnimationPatch.item?.transform.Find("Mushroom Normie (1)").GetComponent<MeshFilter>().sharedMesh != MeshRegistry.Get("Button_Shroom_Eat_4"))
            {
                PlayRemoveAnimationPatch.item?.transform.Find("Mushroom Normie (1)").GetComponent<MeshFilter>().sharedMesh = MeshRegistry.Get("Button_Shroom_Eat_4");
            }
        }
    }
}