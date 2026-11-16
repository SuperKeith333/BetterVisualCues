using UnityEngine;

public class ClusterShroomPoison : ItemPatch
{
    public override string ItemName => "Mushroom Cluster Poison";

    public override void Created(Item __instance)
    {
        if (MeshRegistry.GetOriginal("Cluster Shroom Poison") == null)
            MeshRegistry.SetOriginal("Cluster Shroom Poison", __instance.transform.Find("Mushroom Cluster").GetComponent<MeshFilter>().sharedMesh);
    }

    public override void BeingUsed(Item __instance)
    {
        if (__instance.castProgress > 0.25f &&  __instance.transform.Find("Mushroom Cluster").GetComponent<MeshFilter>().sharedMesh != MeshRegistry.Get("Cluster_Shroom_Poison_Eat_2"))
        {
            __instance.transform.Find("Mushroom Cluster").GetComponent<MeshFilter>().sharedMesh = MeshRegistry.Get("Cluster_Shroom_Poison_Eat_2");
        }       
        if (__instance.castProgress > 0.75f &&  __instance.transform.Find("Mushroom Cluster").GetComponent<MeshFilter>().sharedMesh != MeshRegistry.Get("Cluster_Shroom_Poison_Eat_3"))
        {
            __instance.transform.Find("Mushroom Cluster").GetComponent<MeshFilter>().sharedMesh = MeshRegistry.Get("Cluster_Shroom_Poison_Eat_3");
        }
    }

    public override void CancelUsed(Item __instance)
    {
        __instance.transform.Find("Mushroom Cluster").GetComponent<MeshFilter>().sharedMesh = MeshRegistry.GetOriginal("Cluster Shroom Poison");
    }
}