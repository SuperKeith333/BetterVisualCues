using UnityEngine;

public class EggPatch : ItemPatch
{
    public override string ItemName => "Egg(";

    public override void Created(Item __instance)
    {
        if (MeshRegistry.GetOriginal("Egg") == null) {
            MeshRegistry.SetOriginal("Egg", __instance.transform.Find("Egg_SunnySideUp").GetComponent<MeshFilter>().sharedMesh);
        }
    }

    public override void BeingUsed(Item __instance)
    {
        if (__instance.castProgress > 0.25f && __instance.transform.Find("Egg_SunnySideUp").GetComponent<MeshFilter>().sharedMesh != MeshRegistry.Get("Egg_Eat_2"))
        {
            __instance.transform.Find("Egg_SunnySideUp").GetComponent<MeshFilter>().sharedMesh = MeshRegistry.Get("Egg_Eat_2");
        } 
        if (__instance.castProgress > 0.75f && __instance.transform.Find("Egg_SunnySideUp").GetComponent<MeshFilter>().sharedMesh != MeshRegistry.Get("Egg_Eat_3"))
        {
            __instance.transform.Find("Egg_SunnySideUp").GetComponent<MeshFilter>().sharedMesh = MeshRegistry.Get("Egg_Eat_3");
        } 
    }

    public override void CancelUsed(Item __instance)
    {
        __instance.transform.Find("Egg_SunnySideUp").GetComponent<MeshFilter>().sharedMesh = MeshRegistry.GetOriginal("Egg");
    }
}