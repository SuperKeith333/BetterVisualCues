using UnityEngine;

public class Prickleberry : ItemPatch
{
    public override string ItemName => "Prickleberry";

    public override void Created(Item __instance)
    {
        if (MeshRegistry.GetOriginal("Prickleberry") == null)
            MeshRegistry.SetOriginal("Prickleberry", __instance.transform.Find("Prickleberry (3)").GetComponent<MeshFilter>().sharedMesh);
    }

    public override void BeingUsed(Item __instance)
    {
        if (__instance.castProgress > 0.25f &&  __instance.transform.Find("Prickleberry (3)").GetComponent<MeshFilter>().sharedMesh != MeshRegistry.Get("Prickleberry_Eat_2"))
        {
            __instance.transform.Find("Prickleberry (3)").GetComponent<MeshFilter>().sharedMesh = MeshRegistry.Get("Prickleberry_Eat_2");
        }       
        if (__instance.castProgress > 0.75f &&  __instance.transform.Find("Prickleberry (3)").GetComponent<MeshFilter>().sharedMesh != MeshRegistry.Get("Prickleberry_Eat_3"))
        {
            __instance.transform.Find("Prickleberry (3)").GetComponent<MeshFilter>().sharedMesh = MeshRegistry.Get("Prickleberry_Eat_3");
        }
    }

    public override void CancelUsed(Item __instance)
    {
        __instance.transform.Find("Prickleberry (3)").GetComponent<MeshFilter>().sharedMesh = MeshRegistry.GetOriginal("Prickleberry");
    }
}