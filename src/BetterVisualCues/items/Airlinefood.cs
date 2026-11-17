using BetterVisualCues;
using UnityEngine;

public class AirlinefoodPatch : ItemPatch
{
    public override string ItemName => "Airplane Food";

    public override void Created(Item __instance)
    {
        if (MeshRegistry.GetOriginal("Airline Food") == null)
            MeshRegistry.SetOriginal("Airline Food", __instance.transform.Find("airplane food (1)").GetComponent<MeshFilter>().sharedMesh);
    }

    public override void AnimationUpdated(string emoteName, CharacterAnimations __instance)
    {
        if (emoteName == "A_Scout_Land")
        {
            PlayRemoveAnimationPatch.item?.transform.Find("airplane food (1)/plastic").gameObject.SetActive(true);
            PlayRemoveAnimationPatch.item?.transform.Find("airplane food (1)").GetComponent<MeshFilter>().sharedMesh = MeshRegistry.GetOriginal("Airline Food");
            PlayRemoveAnimationPatch.item?.transform.Find("airplane food (1)").localRotation = Quaternion.Euler(323.41f, 180, 90);
        }
    }

    public override void AnimationTick()
    {
        if (PlayRemoveAnimationPatch.anim == "A_Scout_Use_Item")
        {
            float progress = 1f / (1.2f / PlayRemoveAnimationPatch.animTime);
            if (progress > 0.25f && PlayRemoveAnimationPatch.item?.transform.Find("airplane food (1)/plastic").gameObject.activeInHierarchy == true)
            {
                PlayRemoveAnimationPatch.item.transform.Find("airplane food (1)/plastic").gameObject.SetActive(false);
            }                
            if (progress > 0.50f && PlayRemoveAnimationPatch.item?.transform.Find("airplane food (1)").GetComponent<MeshFilter>().sharedMesh != MeshRegistry.Get("Airlinefood_Eat_2"))
            {
                PlayRemoveAnimationPatch.item?.transform.Find("airplane food (1)").GetComponent<MeshFilter>().sharedMesh = MeshRegistry.Get("Airlinefood_Eat_2");
                PlayRemoveAnimationPatch.item?.transform.Find("airplane food (1)").localRotation = Quaternion.Euler(270.41f, 0, 0);
            }              
            if (progress > 0.75f && PlayRemoveAnimationPatch.item?.transform.Find("airplane food (1)").GetComponent<MeshFilter>().sharedMesh != MeshRegistry.Get("Airlinefood_Eat_3"))
            {
                PlayRemoveAnimationPatch.item?.transform.Find("airplane food (1)").GetComponent<MeshFilter>().sharedMesh = MeshRegistry.Get("Airlinefood_Eat_3");
                PlayRemoveAnimationPatch.item?.transform.Find("airplane food (1)").localRotation = Quaternion.Euler(270.41f, 0, 0);
            }
        }
    }
}