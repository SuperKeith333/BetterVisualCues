using UnityEngine;

public class ClusterShroomPoison : ItemPatch
{
    public override string ItemName => "Mushroom Cluster Poison";

    public override void Created(Item __instance)
    {
        if (MeshRegistry.GetOriginal("Cluster Shroom Poison") == null)
            MeshRegistry.SetOriginal("Cluster Shroom Poison", __instance.transform.Find("Mushroom Cluster").GetComponent<MeshFilter>().sharedMesh);
    }

    public override void AnimationUpdated(string emoteName, CharacterAnimations __instance)
    {
        if (emoteName == "A_Scout_Land")
        {
            PlayRemoveAnimationPatch.item?.transform.Find("Mushroom Cluster").GetComponent<MeshFilter>().sharedMesh = MeshRegistry.GetOriginal("Cluster Shroom Poison");
        }
    }

    public override void AnimationTick()
    {
        if (PlayRemoveAnimationPatch.anim == "A_Scout_Use_Item")
        {
            float progress = 1f / (1.2f / PlayRemoveAnimationPatch.animTime);
            if (progress > 0.25f &&  PlayRemoveAnimationPatch.item?.transform.Find("Mushroom Cluster").GetComponent<MeshFilter>().sharedMesh != MeshRegistry.Get("Cluster_Shroom_Poison_Eat_2"))
            {
                PlayRemoveAnimationPatch.item?.transform.Find("Mushroom Cluster").GetComponent<MeshFilter>().sharedMesh = MeshRegistry.Get("Cluster_Shroom_Poison_Eat_2");
            }       
            if (progress > 0.75f &&  PlayRemoveAnimationPatch.item?.transform.Find("Mushroom Cluster").GetComponent<MeshFilter>().sharedMesh != MeshRegistry.Get("Cluster_Shroom_Poison_Eat_3"))
            {
                PlayRemoveAnimationPatch.item?.transform.Find("Mushroom Cluster").GetComponent<MeshFilter>().sharedMesh = MeshRegistry.Get("Cluster_Shroom_Poison_Eat_3");
            }
        }
    }
}