using UnityEngine;

public class LollipopPatch : ItemPatch
{
    public override string ItemName => "Lollipop";

    public override void Created(Item __instance)
    {
        if (MeshRegistry.GetOriginal("Lollipop") == null)
            MeshRegistry.SetOriginal("Lollipop", __instance.transform.Find("Lollipop/Cube").GetComponent<MeshFilter>().sharedMesh);
    }

    public override void BeingUsed(Item __instance)
    {
        if (__instance.castProgress > 0.25f &&  __instance.transform.Find("Lollipop/Cube").GetComponent<MeshFilter>().sharedMesh != MeshRegistry.Get("Lollipop_Eat_2"))
        {
            __instance.transform.Find("Lollipop/Cube").GetComponent<MeshFilter>().sharedMesh = MeshRegistry.Get("Lollipop_Eat_2");
        }              
        if (__instance.castProgress > 0.75f &&  __instance.transform.Find("Lollipop/Cube").GetComponent<MeshFilter>().sharedMesh != MeshRegistry.Get("Lollipop_Eat_3"))
        {
            __instance.transform.Find("Lollipop/Cube").GetComponent<MeshFilter>().sharedMesh = MeshRegistry.Get("Lollipop_Eat_3");
        }
    }

    public override void CancelUsed(Item __instance)
    {
        __instance.transform.Find("Lollipop/Cube").GetComponent<MeshFilter>().sharedMesh = MeshRegistry.GetOriginal("Lollipop");
    }
}