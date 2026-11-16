using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BerrynanaPatch : ItemPatch
{
    public override string ItemName => "Berrynana";

    public override void Created(Item __instance)
    {
        if (MeshRegistry.GetOriginal("Berrynana") == null)
            MeshRegistry.SetOriginal("Berrynana", __instance.transform.Find("Bananna Berry (1)").GetComponent<MeshFilter>().sharedMesh);
    }

    public override void BeingUsed(Item __instance)
    {
        if (__instance.castProgress > 0.50f && __instance.transform.Find("Bananna Berry (1)").GetComponent<MeshRenderer>().materials.Length == 1)
        {
            __instance.transform.Find("Bananna Berry (1)").GetComponent<MeshFilter>().sharedMesh = MeshRegistry.Get("Berrynana_Eat_2");
            var mats = __instance.transform.Find("Bananna Berry (1)").GetComponent<MeshRenderer>().materials.ToList();
            Material matToAdd = null;
            if (__instance.name.StartsWith("Berrynana Blue"))
            {
                matToAdd = MaterialRegistry.GetMaterial("M_BananaBlue_Inside");
            }
            else if (__instance.name.StartsWith("Berrynana Yellow"))
            {
                matToAdd = MaterialRegistry.GetMaterial("M_Banana_Inside");
            }
            else if (__instance.name.StartsWith("Berrynana Brown"))
            {
                matToAdd = MaterialRegistry.GetMaterial("M_BananaBrown_Inside");
            }
            else if (__instance.name.StartsWith("Berrynana Pink"))
            {
                matToAdd = MaterialRegistry.GetMaterial("M_BananaPink_Inside");
            }
            mats.Add(matToAdd);
            mats.Add(__instance.transform.Find("Bananna Berry (1)").GetComponent<MeshRenderer>().materials[0]);
            mats[0] = mats[1];
            __instance.transform.Find("Bananna Berry (1)").GetComponent<MeshRenderer>().sharedMaterials = mats.ToArray();
            __instance.transform.Find("Bananna Berry (1)").GetComponent<MeshRenderer>().materials = mats.ToArray();
            __instance.transform.Find("Bananna Berry (1)").localPosition = new Vector3(-0.046f, -0.149f, -0.022f);
            __instance.transform.Find("Bananna Berry (1)/Leaves.002").localPosition = new Vector3(-0.0265f, -0.0117f, 0.1f);
        }
    }

    public override void CancelUsed(Item __instance)
    {
        if (!__instance.name.Contains("Peel") && __instance.transform.Find("Bananna Berry (1)").GetComponent<MeshRenderer>().materials.Length >= 3)
        {
            __instance.transform.Find("Bananna Berry (1)/Leaves.002").localPosition = new Vector3(-0.0265f, -0.0117f, 0f);
            __instance.transform.Find("Bananna Berry (1)").GetComponent<MeshFilter>().sharedMesh = MeshRegistry.GetOriginal("Berrynana");
            List<Material> mats = new List<Material>();
            mats.Add(__instance.transform.Find("Bananna Berry (1)").GetComponent<MeshRenderer>().materials[2]);
            __instance.transform.Find("Bananna Berry (1)").GetComponent<MeshRenderer>().materials = mats.ToArray();
            __instance.transform.Find("Bananna Berry (1)").GetComponent<MeshRenderer>().sharedMaterials = mats.ToArray();
            __instance.transform.Find("Bananna Berry (1)").localPosition = new Vector3(-0.046f, -0.049f, -0.022f);
        }
    }
}