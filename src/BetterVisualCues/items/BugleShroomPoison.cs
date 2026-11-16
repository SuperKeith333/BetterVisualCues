using UnityEngine;

public class BugleShroomPoison : ItemPatch
{
    public override string ItemName => "Mushroom Lace Poison";

    public override void Created(Item __instance)
    {
        if (MeshRegistry.GetOriginal("Bugle Shroom Poison") == null)
            MeshRegistry.SetOriginal("Bugle Shroom Poison", __instance.transform.Find("Mushroom Chubby").GetComponent<MeshFilter>().sharedMesh);
    }

    public override void BeingUsed(Item __instance)
    {
        if (__instance.castProgress > 0.25f &&  __instance.transform.Find("Mushroom Chubby").GetComponent<MeshFilter>().sharedMesh != MeshRegistry.Get("Bugle_Shroom_Poison_Eat_2"))
        {
            __instance.transform.Find("Mushroom Chubby").GetComponent<MeshFilter>().sharedMesh = MeshRegistry.Get("Bugle_Shroom_Poison_Eat_2");
        }              
        if (__instance.castProgress > 0.50f &&  __instance.transform.Find("Mushroom Chubby").GetComponent<MeshFilter>().sharedMesh != MeshRegistry.Get("Bugle_Shroom_Poison_Eat_3"))
        {
            __instance.transform.Find("Mushroom Chubby").GetComponent<MeshFilter>().sharedMesh = MeshRegistry.Get("Bugle_Shroom_Poison_Eat_3");
        }           
        if (__instance.castProgress > 0.75f &&  __instance.transform.Find("Mushroom Chubby").GetComponent<MeshFilter>().sharedMesh != MeshRegistry.Get("Bugle_Shroom_Poison_Eat_4"))
        {
            __instance.transform.Find("Mushroom Chubby").GetComponent<MeshFilter>().sharedMesh = MeshRegistry.Get("Bugle_Shroom_Poison_Eat_4");
        }
    }

    public override void CancelUsed(Item __instance)
    {
        __instance.transform.Find("Mushroom Chubby").GetComponent<MeshFilter>().sharedMesh = MeshRegistry.GetOriginal("Bugle Shroom Poison");
    }
}