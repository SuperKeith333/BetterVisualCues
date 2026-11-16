using UnityEngine;

public class ClusterberryPatch : ItemPatch
{
    public override string ItemName => "Clusterberry";

    public override void Created(Item __instance)
    {
        if (MeshRegistry.GetOriginal("Clusterberry") == null) {
            if (!__instance.name.Contains("Red")) {
                MeshRegistry.SetOriginal("Clusterberry", __instance.transform.Find("Cluster Berry (1)").GetComponent<MeshFilter>().sharedMesh);
            } else
            {
                MeshRegistry.SetOriginal("Clusterberry", __instance.transform.Find("Raspberry)").GetComponent<MeshFilter>().sharedMesh);
            }
        }
    }

    public override void BeingUsed(Item __instance)
    {
        if (!__instance.name.Contains("Red")) {
            if (__instance.castProgress > 0.50f && __instance.transform.Find("Cluster Berry (1)").GetComponent<MeshFilter>().sharedMesh != MeshRegistry.Get("ClusterBerry_Eat_2"))
            {
                 __instance.transform.Find("Cluster Berry (1)").GetComponent<MeshFilter>().sharedMesh = MeshRegistry.Get("ClusterBerry_Eat_2");
            } 
        } else
        {
            if (__instance.castProgress > 0.50f && __instance.transform.Find("Raspberry").GetComponent<MeshFilter>().sharedMesh != MeshRegistry.Get("ClusterBerry_Eat_2"))
            {
                __instance.transform.Find("Raspberry").GetComponent<MeshFilter>().sharedMesh = MeshRegistry.Get("ClusterBerry_Eat_2");
            } 
        }
    }

    public override void CancelUsed(Item __instance)
    {
        if (!__instance.name.Contains("Red")) {
            __instance.transform.Find("Cluster Berry (1)").GetComponent<MeshFilter>().sharedMesh = MeshRegistry.GetOriginal("Clusterberry");
        } else
        {
            __instance.transform.Find("Raspberry").GetComponent<MeshFilter>().sharedMesh = MeshRegistry.GetOriginal("Clusterberry");  
        }
    }
}