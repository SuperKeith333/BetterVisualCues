using UnityEngine;

public class GranolaBar : ItemPatch
{
    public override string ItemName => "Granola Bar";

    public override void Created(Item __instance)
    {
        if (MeshRegistry.GetOriginal("Granola Bar") == null)
            MeshRegistry.SetOriginal("Granola Bar", __instance.transform.Find("GranolaBar").GetComponent<MeshFilter>().sharedMesh);
    }

    public override void BeingUsed(Item __instance)
    {
        if (__instance.castProgress > 0.25f &&  __instance.transform.Find("GranolaBar").GetComponent<MeshFilter>().sharedMesh != MeshRegistry.Get("Granola_Bar_Eat_2"))
        {
            __instance.transform.Find("GranolaBar").GetComponent<MeshFilter>().sharedMesh = MeshRegistry.Get("Granola_Bar_Eat_2");
        }       
        if (__instance.castProgress > 0.75f &&  __instance.transform.Find("GranolaBar").GetComponent<MeshFilter>().sharedMesh != MeshRegistry.Get("Granola_Bar_Eat_3"))
        {
            __instance.transform.Find("GranolaBar").GetComponent<MeshFilter>().sharedMesh = MeshRegistry.Get("Granola_Bar_Eat_3");
        }
    }

    public override void CancelUsed(Item __instance)
    {
        __instance.transform.Find("GranolaBar").GetComponent<MeshFilter>().sharedMesh = MeshRegistry.GetOriginal("Granola Bar");
    }
}