using UnityEngine;

public class FrogLegs : ItemPatch
{
    public override string ItemName => "FrogLegs";

    public override void Created(Item __instance)
    {
        if (MeshRegistry.GetOriginal("Frog Legs") == null)
            MeshRegistry.SetOriginal("Frog Legs", __instance.transform.Find("FrogLegs (1)/FrogLegsGreen").GetComponent<MeshFilter>().sharedMesh);
    }

    public override void BeingUsed(Item __instance)
    {
        if (__instance.castProgress > 0.5f &&  __instance.transform.Find("FrogLegs (1)/FrogLegsGreen").GetComponent<MeshFilter>().sharedMesh != MeshRegistry.Get("Frog_Legs_Eat_2"))
        {
            __instance.transform.Find("FrogLegs (1)/FrogLegsGreen").GetComponent<MeshFilter>().sharedMesh = MeshRegistry.Get("Frog_Legs_Eat_2");
        }
    }

    public override void CancelUsed(Item __instance)
    {
        __instance.transform.Find("FrogLegs (1)/FrogLegsGreen").GetComponent<MeshFilter>().sharedMesh = MeshRegistry.GetOriginal("Frog Legs");
    }
}