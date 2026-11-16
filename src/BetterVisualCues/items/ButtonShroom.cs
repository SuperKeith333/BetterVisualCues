using UnityEngine;

public class ButtonShroom : ItemPatch
{
    public override string ItemName => "Mushroom Normie(";

    public override void Created(Item __instance)
    {
        if (MeshRegistry.GetOriginal("Button Shroom") == null)
            MeshRegistry.SetOriginal("Button Shroom", __instance.transform.Find("Mushroom Normie (1)").GetComponent<MeshFilter>().sharedMesh);
    }

    public override void BeingUsed(Item __instance)
    {
        if (__instance.castProgress > 0.25f &&  __instance.transform.Find("Mushroom Normie (1)").GetComponent<MeshFilter>().sharedMesh != MeshRegistry.Get("Button_Shroom_Eat_2"))
        {
            __instance.transform.Find("Mushroom Normie (1)").GetComponent<MeshFilter>().sharedMesh = MeshRegistry.Get("Button_Shroom_Eat_2");
        }              
        if (__instance.castProgress > 0.50f &&  __instance.transform.Find("Mushroom Normie (1)").GetComponent<MeshFilter>().sharedMesh != MeshRegistry.Get("Button_Shroom_Eat_3"))
        {
            __instance.transform.Find("Mushroom Normie (1)").GetComponent<MeshFilter>().sharedMesh = MeshRegistry.Get("Button_Shroom_Eat_3");
        }           
        if (__instance.castProgress > 0.75f &&  __instance.transform.Find("Mushroom Normie (1)").GetComponent<MeshFilter>().sharedMesh != MeshRegistry.Get("Button_Shroom_Eat_4"))
        {
            __instance.transform.Find("Mushroom Normie (1)").GetComponent<MeshFilter>().sharedMesh = MeshRegistry.Get("Button_Shroom_Eat_4");
        }
    }

    public override void CancelUsed(Item __instance)
    {
        __instance.transform.Find("Mushroom Normie (1)").GetComponent<MeshFilter>().sharedMesh = MeshRegistry.GetOriginal("Button Shroom");
    }
}