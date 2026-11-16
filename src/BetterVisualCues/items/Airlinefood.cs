using UnityEngine;

public class AirlinefoodPatch : ItemPatch
{
    public override string ItemName => "Airplane Food";

    public override void Created(Item __instance)
    {
        if (MeshRegistry.GetOriginal("Airline Food") == null)
            MeshRegistry.SetOriginal("Airline Food", __instance.transform.Find("airplane food (1)").GetComponent<MeshFilter>().sharedMesh);
    }

    public override void BeingUsed(Item __instance)
    {
        if (__instance.castProgress > 0.25f && __instance.transform.Find("airplane food (1)/plastic").gameObject.activeInHierarchy)
        {
            __instance.transform.Find("airplane food (1)/plastic").gameObject.SetActive(false);
        }                
        if (__instance.castProgress > 0.50f && __instance.transform.Find("airplane food (1)").GetComponent<MeshFilter>().sharedMesh != MeshRegistry.Get("Airlinefood_Eat_2"))
        {
            __instance.transform.Find("airplane food (1)").GetComponent<MeshFilter>().sharedMesh = MeshRegistry.Get("Airlinefood_Eat_2");
            __instance.transform.Find("airplane food (1)").localRotation = Quaternion.Euler(270.41f, 0, 0);
        }              
        if (__instance.castProgress > 0.75f && __instance.transform.Find("airplane food (1)").GetComponent<MeshFilter>().sharedMesh != MeshRegistry.Get("Airlinefood_Eat_3"))
        {
            __instance.transform.Find("airplane food (1)").GetComponent<MeshFilter>().sharedMesh = MeshRegistry.Get("Airlinefood_Eat_3");
            __instance.transform.Find("airplane food (1)").localRotation = Quaternion.Euler(270.41f, 0, 0);
        }
    }

    public override void CancelUsed(Item __instance)
    {
        __instance.transform.Find("airplane food (1)/plastic").gameObject.SetActive(true);
        __instance.transform.Find("airplane food (1)").GetComponent<MeshFilter>().sharedMesh = MeshRegistry.GetOriginal("Airline Food");
        __instance.transform.Find("airplane food (1)").localRotation = Quaternion.Euler(323.41f, 180, 90);
    }
}