using UnityEngine;

public class ChubbyShroom : ItemPatch
{
    public override string ItemName => "Mushroom Chubby";

    public override void Created(Item __instance)
    {
        if (MeshRegistry.GetOriginal("Chubby Shroom") == null)
            MeshRegistry.SetOriginal("Chubby Shroom", __instance.transform.Find("Mushroom Chubby").GetComponent<MeshFilter>().sharedMesh);
    }

    public override void BeingUsed(Item __instance)
    {
        if (__instance.castProgress > 0.5f &&  __instance.transform.Find("Mushroom Chubby").GetComponent<MeshFilter>().sharedMesh != MeshRegistry.Get("Chubby_Shroom_Eat_2"))
        {
            __instance.transform.Find("Mushroom Chubby").GetComponent<MeshFilter>().sharedMesh = MeshRegistry.Get("Chubby_Shroom_Eat_2");
        }
    }

    public override void CancelUsed(Item __instance)
    {
        __instance.transform.Find("Mushroom Chubby").GetComponent<MeshFilter>().sharedMesh = MeshRegistry.GetOriginal("Chubby Shroom");
    }
}