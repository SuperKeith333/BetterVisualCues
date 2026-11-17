using UnityEngine;

public class ClusterberryPatch : ItemPatch
{
    public override string ItemName => "Clusterberry";

    public override void Created(Item __instance)
    {
        if (MeshRegistry.GetOriginal("Clusterberry") == null) {
            if (!__instance.name.Contains("Red")) {
                MeshRegistry.SetOriginal("Clusterberry", __instance.transform.Find("Cluster Berry (1)").GetComponent<MeshFilter>().sharedMesh);
            } else
            {
                MeshRegistry.SetOriginal("Clusterberry", __instance.transform.Find("Raspberry").GetComponent<MeshFilter>().sharedMesh);
            }
        }
    }

    public override void AnimationUpdated(string emoteName, CharacterAnimations __instance)
    {
        if (emoteName == "A_Scout_Land")
        {
            if (PlayRemoveAnimationPatch.item?.name.Contains("Red") == false) {
                PlayRemoveAnimationPatch.item?.transform.Find("Cluster Berry (1)").GetComponent<MeshFilter>().sharedMesh = MeshRegistry.GetOriginal("Clusterberry");
            } else
            {
                PlayRemoveAnimationPatch.item?.transform.Find("Raspberry").GetComponent<MeshFilter>().sharedMesh = MeshRegistry.GetOriginal("Clusterberry");  
            }
        }
    }

    public override void AnimationTick()
    {
        if (PlayRemoveAnimationPatch.anim == "A_Scout_Use_Item")
        {
            float progress = 1f / (1.2f / PlayRemoveAnimationPatch.animTime);
            if (PlayRemoveAnimationPatch.item?.name.Contains("Red") == false) {
                if (progress > 0.50f && PlayRemoveAnimationPatch.item?.transform.Find("Cluster Berry (1)").GetComponent<MeshFilter>().sharedMesh != MeshRegistry.Get("ClusterBerry_Eat_2"))
                {
                    PlayRemoveAnimationPatch.item?.transform.Find("Cluster Berry (1)").GetComponent<MeshFilter>().sharedMesh = MeshRegistry.Get("ClusterBerry_Eat_2");
                } 
            } else
            {
                if (progress > 0.50f && PlayRemoveAnimationPatch.item?.transform.Find("Raspberry").GetComponent<MeshFilter>().sharedMesh != MeshRegistry.Get("ClusterBerry_Eat_2"))
                {
                    PlayRemoveAnimationPatch.item?.transform.Find("Raspberry").GetComponent<MeshFilter>().sharedMesh = MeshRegistry.Get("ClusterBerry_Eat_2");
                } 
            }
        }
    }
}