using System.Collections.Generic;
using System.Linq;
using BetterVisualCues;
using UnityEngine;

public class BerrynanaPatch : ItemPatch
{
    public override string ItemName => "Berrynana";

    public override void Created(Item __instance)
    {
        if (MeshRegistry.GetOriginal("Berrynana") == null)
            MeshRegistry.SetOriginal("Berrynana", __instance.transform.Find("Bananna Berry (1)").GetComponent<MeshFilter>().sharedMesh);
    }

    public override void AnimationUpdated(string emoteName, CharacterAnimations __instance)
    {
        if (emoteName == "A_Scout_Land")
        {
            if (PlayRemoveAnimationPatch.item?.name.Contains("Peel") != null && PlayRemoveAnimationPatch.item.transform.Find("Bananna Berry (1)").GetComponent<MeshRenderer>().materials.Length >= 3)
            {
                PlayRemoveAnimationPatch.item.transform.Find("Bananna Berry (1)/Leaves.002").localPosition = new Vector3(-0.0265f, -0.0117f, 0f);
                PlayRemoveAnimationPatch.item.transform.Find("Bananna Berry (1)").GetComponent<MeshFilter>().sharedMesh = MeshRegistry.GetOriginal("Berrynana");
                List<Material> mats = new List<Material>();
                mats.Add(PlayRemoveAnimationPatch.item.transform.Find("Bananna Berry (1)").GetComponent<MeshRenderer>().materials[2]);
                PlayRemoveAnimationPatch.item.transform.Find("Bananna Berry (1)").GetComponent<MeshRenderer>().materials = mats.ToArray();
                PlayRemoveAnimationPatch.item.transform.Find("Bananna Berry (1)").GetComponent<MeshRenderer>().sharedMaterials = mats.ToArray();
                PlayRemoveAnimationPatch.item.transform.Find("Bananna Berry (1)").localPosition = new Vector3(-0.046f, -0.049f, -0.022f);
            }
        }
    }

    public override void AnimationTick()
    {
        if (PlayRemoveAnimationPatch.anim == "A_Scout_Use_Item") {
            float progress = 1f / (1.2f / PlayRemoveAnimationPatch.animTime);
            if (progress > 0.50f && PlayRemoveAnimationPatch.item?.transform.Find("Bananna Berry (1)").GetComponent<MeshRenderer>().materials.Length == 1)
            {
                PlayRemoveAnimationPatch.item.transform.Find("Bananna Berry (1)").GetComponent<MeshFilter>().sharedMesh = MeshRegistry.Get("Berrynana_Eat_2");
                var mats = PlayRemoveAnimationPatch.item.transform.Find("Bananna Berry (1)").GetComponent<MeshRenderer>().materials.ToList();
                Material? matToAdd = null;
                if (PlayRemoveAnimationPatch.item.name.StartsWith("Berrynana Blue"))
                {
                    matToAdd = MaterialRegistry.GetMaterial("M_BananaBlue_Inside");
                }
                else if (PlayRemoveAnimationPatch.item.name.StartsWith("Berrynana Yellow"))
                {
                    matToAdd = MaterialRegistry.GetMaterial("M_Banana_Inside");
                }
                else if (PlayRemoveAnimationPatch.item.name.StartsWith("Berrynana Brown"))
                {
                    matToAdd = MaterialRegistry.GetMaterial("M_BananaBrown_Inside");
                }
                else if (PlayRemoveAnimationPatch.item.name.StartsWith("Berrynana Pink"))
                {
                    matToAdd = MaterialRegistry.GetMaterial("M_BananaPink_Inside");
                }
                mats.Add(matToAdd);
                mats.Add(PlayRemoveAnimationPatch.item.transform.Find("Bananna Berry (1)").GetComponent<MeshRenderer>().materials[0]);
                mats[0] = mats[1];
                PlayRemoveAnimationPatch.item.transform.Find("Bananna Berry (1)").GetComponent<MeshRenderer>().sharedMaterials = mats.ToArray();
                PlayRemoveAnimationPatch.item.transform.Find("Bananna Berry (1)").GetComponent<MeshRenderer>().materials = mats.ToArray();
                PlayRemoveAnimationPatch.item.transform.Find("Bananna Berry (1)").localPosition = new Vector3(-0.046f, -0.149f, -0.022f);
                PlayRemoveAnimationPatch.item.transform.Find("Bananna Berry (1)/Leaves.002").localPosition = new Vector3(-0.0265f, -0.0117f, 0.1f);
            }
        }
    }
}