using UnityEngine;

public class ClusterShroom : ItemPatch
{
    public override string ItemName => "Mushroom Cluster(";

    public override void Created(Item __instance)
    {
        if (MeshRegistry.GetOriginal("Cluster Shroom") == null)
            MeshRegistry.SetOriginal("Cluster Shroom", __instance.transform.Find("Mushroom Cluster").GetComponent<MeshFilter>().sharedMesh);
    }

    public override void AnimationUpdated(string emoteName, CharacterAnimations __instance)
    {
        if (emoteName == "A_Scout_Land")
        {
            PlayRemoveAnimationPatch.item?.transform.Find("Mushroom Cluster").GetComponent<MeshFilter>().sharedMesh = MeshRegistry.GetOriginal("Cluster Shroom");
        }
    }

    public override void AnimationTick()
    {
        if (PlayRemoveAnimationPatch.anim == "A_Scout_Use_Item")
        {
            float progress = 1f / (1.2f / PlayRemoveAnimationPatch.animTime);
            if (progress > 0.25f &&  PlayRemoveAnimationPatch.item?.transform.Find("Mushroom Cluster").GetComponent<MeshFilter>().sharedMesh != MeshRegistry.Get("Cluster_Shroom_Eat_2"))
            {
                PlayRemoveAnimationPatch.item?.transform.Find("Mushroom Cluster").GetComponent<MeshFilter>().sharedMesh = MeshRegistry.Get("Cluster_Shroom_Eat_2");
            }       
            if (progress > 0.75f &&  PlayRemoveAnimationPatch.item?.transform.Find("Mushroom Cluster").GetComponent<MeshFilter>().sharedMesh != MeshRegistry.Get("Cluster_Shroom_Eat_3"))
            {
                PlayRemoveAnimationPatch.item?.transform.Find("Mushroom Cluster").GetComponent<MeshFilter>().sharedMesh = MeshRegistry.Get("Cluster_Shroom_Eat_3");
            }
        }
    }
}