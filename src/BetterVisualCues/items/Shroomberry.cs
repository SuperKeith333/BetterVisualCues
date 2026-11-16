using UnityEngine;

public class ShroomberryPatch : ItemPatch
{
    public override string ItemName => "Shroomberry";

    public override void Created(Item __instance)
    {
        if (MeshRegistry.GetOriginal("Shroomberry") == null) {
            MeshRegistry.SetOriginal("Shroomberry", __instance.transform.Find("shroomberry").GetComponent<MeshFilter>().sharedMesh);
        }
    }

    public override void BeingUsed(Item __instance)
    {
        if (__instance.castProgress > 0.25f && __instance.transform.Find("shroomberry").GetComponent<MeshFilter>().sharedMesh != MeshRegistry.Get("Shroomberry_Eat_2"))
        {
            __instance.transform.Find("shroomberry").GetComponent<MeshFilter>().sharedMesh = MeshRegistry.Get("Shroomberry_Eat_2");
            __instance.transform.Find("shroomberry/Leaves.001 (1)").gameObject.SetActive(false);
        } 
        if (__instance.castProgress > 0.75f && __instance.transform.Find("shroomberry").GetComponent<MeshFilter>().sharedMesh != MeshRegistry.Get("Shroomberry_Eat_3"))
        {
            __instance.transform.Find("shroomberry").GetComponent<MeshFilter>().sharedMesh = MeshRegistry.Get("Shroomberry_Eat_3");
        } 
    }

    public override void CancelUsed(Item __instance)
    {
        __instance.transform.Find("shroomberry").GetComponent<MeshFilter>().sharedMesh = MeshRegistry.GetOriginal("Shroomberry");
        __instance.transform.Find("shroomberry/Leaves.001 (1)").gameObject.SetActive(true);
    }
}