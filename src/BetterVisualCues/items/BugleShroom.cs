using UnityEngine;

public class BugleShroom : ItemPatch
{
    public override string ItemName => "Mushroom Lace(";

    public override void Created(Item __instance)
    {
        if (MeshRegistry.GetOriginal("Bugle Shroom") == null)
            MeshRegistry.SetOriginal("Bugle Shroom", __instance.transform.Find("Mushroom Chubby").GetComponent<MeshFilter>().sharedMesh);
    }

    public override void AnimationUpdated(string emoteName, CharacterAnimations __instance)
    {
        if (emoteName == "A_Scout_Land")
        {
            PlayRemoveAnimationPatch.item?.transform.Find("Mushroom Chubby").GetComponent<MeshFilter>().sharedMesh = MeshRegistry.GetOriginal("Bugle Shroom");
        }
    }

    public override void AnimationTick()
    {
        if (PlayRemoveAnimationPatch.anim == "A_Scout_Use_Item")
        {
            float progress = 1f / (1.2f / PlayRemoveAnimationPatch.animTime);
            if (progress > 0.25f &&  PlayRemoveAnimationPatch.item?.transform.Find("Mushroom Chubby").GetComponent<MeshFilter>().sharedMesh != MeshRegistry.Get("Bugle_Shroom_Eat_2"))
            {
                PlayRemoveAnimationPatch.item?.transform.Find("Mushroom Chubby").GetComponent<MeshFilter>().sharedMesh = MeshRegistry.Get("Bugle_Shroom_Eat_2");
            }              
            if (progress > 0.50f &&  PlayRemoveAnimationPatch.item?.transform.Find("Mushroom Chubby").GetComponent<MeshFilter>().sharedMesh != MeshRegistry.Get("Bugle_Shroom_Eat_3"))
            {
                PlayRemoveAnimationPatch.item?.transform.Find("Mushroom Chubby").GetComponent<MeshFilter>().sharedMesh = MeshRegistry.Get("Bugle_Shroom_Eat_3");
            }           
            if (progress > 0.75f &&  PlayRemoveAnimationPatch.item?.transform.Find("Mushroom Chubby").GetComponent<MeshFilter>().sharedMesh != MeshRegistry.Get("Bugle_Shroom_Eat_4"))
            {
                PlayRemoveAnimationPatch.item?.transform.Find("Mushroom Chubby").GetComponent<MeshFilter>().sharedMesh = MeshRegistry.Get("Bugle_Shroom_Eat_4");
            }
        }
    }
}