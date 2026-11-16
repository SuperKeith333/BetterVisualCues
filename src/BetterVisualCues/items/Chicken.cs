using UnityEngine;

public class ChickenPatch : ItemPatch
{
    public override string ItemName => "EggTurkey";

    public override void Created(Item __instance)
    {
        if (MeshRegistry.GetOriginal("Chicken") == null) {
            MeshRegistry.SetOriginal("Chicken", __instance.transform.Find("Chicken").GetComponent<MeshFilter>().sharedMesh);
        }
    }

    public override void BeingUsed(Item __instance)
    {
        if (__instance.castProgress > 0.25f && __instance.transform.Find("Chicken").GetComponent<MeshFilter>().sharedMesh != MeshRegistry.Get("Chicken_Eat_2"))
        {
            __instance.transform.Find("Chicken").GetComponent<MeshFilter>().sharedMesh = MeshRegistry.Get("Chicken_Eat_2");
        } 
        if (__instance.castProgress > 0.75f && __instance.transform.Find("Chicken").GetComponent<MeshFilter>().sharedMesh != MeshRegistry.Get("Chicken_Eat_3"))
        {
            __instance.transform.Find("Chicken").GetComponent<MeshFilter>().sharedMesh = MeshRegistry.Get("Chicken_Eat_3");
        } 
    }

    public override void CancelUsed(Item __instance)
    {
        __instance.transform.Find("Chicken").GetComponent<MeshFilter>().sharedMesh = MeshRegistry.GetOriginal("Chicken");
    }
}