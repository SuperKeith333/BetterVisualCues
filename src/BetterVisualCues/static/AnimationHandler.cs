using System.Collections.Generic;
using BetterVisualCues;
using Newtonsoft.Json;
using UnityEngine;

public static class AnimationHandler
{
    static readonly List<Animation> animations = [];
    static readonly List<string> supportedItemNames = [];
    static readonly Dictionary<string, BaseCodeOverride> codeOverrides = [];
    static bool playingAnimation;

    public static void Init()
    {
        var anims = jsonLoader.LoadAllAnimationFiles();

        foreach (Animation animation in anims)
        {
            animations.Add(animation);
            supportedItemNames.Add(animation.ItemName);

            if (animation.LoadMaterials != null)
            {
                foreach (AnimationStep step in animation.LoadMaterials)
                {
                    if (step.LoadMaterial != null)
                        MaterialRegistry.loadMaterialFromItem(step.LoadMaterial.Item, step.LoadMaterial.Material);
                }
            }
        }

        playingAnimation = false;
    }

    public static void registerCodeOverride(string name, BaseCodeOverride Override)
    {
        codeOverrides[name] = Override;
    }

    public static bool IsItemSupported(string name)
    {
        foreach (string SupportedItem in supportedItemNames)
        {
            if (name.Contains(SupportedItem))
                return true;
        }

        return false;
    }

    public static void ItemCreated(string ItemName, Item item)
    {
        Animation? animation = null;     
        foreach (Animation anim in animations)
        {
            if (ItemName.Contains(anim.ItemName))
                animation = anim;
        }

        if (animation == null)
        {
            Plugin.Log.LogError("Failed to Find Animation for " + ItemName);
            return;
        }

        if (animation.Created != null) {
            foreach (AnimationStep step in animation.Created) {
                if (step.SetOriginalMesh != null) {
                    string name = animation.ItemName;
                    if (step.SetOriginalMesh.Tag != null)
                        name = step.SetOriginalMesh.Tag;
                    if (MeshRegistry.GetOriginal(name) == null) {
                        MeshRegistry.SetOriginal(name, item.transform.Find(animation.Objects[step.SetOriginalMesh.Object]).GetComponent<MeshFilter>().sharedMesh);
                        
                    }
                }

                if (step.SetOriginalSkinnedMesh != null) {
                    string name = animation.ItemName;
                    if (step.SetOriginalSkinnedMesh.Tag != null)
                        name = step.SetOriginalSkinnedMesh.Tag;
                    if (MeshRegistry.GetOriginal(name) == null) {
                        MeshRegistry.SetOriginal(name, item.transform.Find(animation.Objects[step.SetOriginalSkinnedMesh.Object]).GetComponent<SkinnedMeshRenderer>().sharedMesh);
                        
                    }
                }

                if (step.SetMesh != null)
                    item.transform.Find(animation.Objects[step.SetMesh.Object]).GetComponent<MeshFilter>().sharedMesh = MeshRegistry.Get(step.SetMesh.Mesh);
            
                if (step.SetMaterialSlot != null)
                {
                    List<Material?> materials = [];

                    foreach (Material mat in item.transform.Find(animation.Objects[step.SetMaterialSlot.Object]).GetComponent<MeshRenderer>().sharedMaterials)
                    {
                        materials.Add(mat);
                    }

                    while (materials.Count - 1 < step.SetMaterialSlot.Slot)
                    {
                        materials.Add(null);
                    }

                    materials[step.SetMaterialSlot.Slot] = MaterialRegistry.GetMaterial(step.SetMaterialSlot.Material);

                    item.transform.Find(animation.Objects[step.SetMaterialSlot.Object]).GetComponent<MeshRenderer>().sharedMaterials = materials.ToArray();
                }
            }
        }

        if (animation.CodeOverride != null)
        {
            if (codeOverrides.ContainsKey(animation.CodeOverride))
                codeOverrides[animation.CodeOverride].Created(ItemName, item);
        }
    }

    public static void FinishedUse(string ItemName, Item item)
    {
        Animation? animation = null;     
        foreach (Animation anim in animations)
        {
            if (ItemName.Contains(anim.ItemName))
                animation = anim;
        }

        if (animation == null)
        {
            Plugin.Log.LogError("Failed to Find Animation for " + ItemName);
            return;
        }

        if (animation.CodeOverride != null)
        {
            if (codeOverrides.ContainsKey(animation.CodeOverride))
                codeOverrides[animation.CodeOverride].UsedFinished(ItemName, item);
        }

        SteamComms.SendEvent(VisualCueEventType.CANCEL_USE_ANIM, "{}", Photon.Realtime.ReceiverGroup.Others);
        playingAnimation = false;
    }


    public static void FinishedSecondaryUse(string ItemName, Item item)
    {
        Animation? animation = null;     
        foreach (Animation anim in animations)
        {
            if (ItemName.Contains(anim.ItemName))
                animation = anim;
        }

        if (animation == null)
        {
            Plugin.Log.LogError("Failed to Find Animation for " + ItemName);
            return;
        }

        if (animation.CodeOverride != null)
        {
            if (codeOverrides.ContainsKey(animation.CodeOverride))
                codeOverrides[animation.CodeOverride].SecondaryUsedFinished(ItemName, item);
        }

        SteamComms.SendEvent(VisualCueEventType.CANCEL_SECONDARY_USE_ANIM, "{}", Photon.Realtime.ReceiverGroup.Others);
        playingAnimation = false;
    }

    public static void PlayUsingAnimation(string ItemName, Item item, float progress)
    {
        Animation? animation = null;     
        foreach (Animation anim in animations)
        {
            if (ItemName.Contains(anim.ItemName))
                animation = anim;
        }

        if (animation == null)
        {
            Plugin.Log.LogError("Failed to Find Animation for " + ItemName);
            return;
        }

        if (animation.UseAnimation != null) {
            foreach (AnimationStep step in animation.UseAnimation)
            {
                if (progress < step.Time - 0.05f || progress > step.Time + 0.05f)
                    continue;
                if (step.SetMesh != null)
                    item.transform.Find(animation.Objects[step.SetMesh.Object]).GetComponent<MeshFilter>().sharedMesh = MeshRegistry.Get(step.SetMesh.Mesh);

                if (step.SetSkinnedMesh != null)
                    item.transform.Find(animation.Objects[step.SetSkinnedMesh.Object]).GetComponent<SkinnedMeshRenderer>().sharedMesh = MeshRegistry.Get(step.SetSkinnedMesh.Mesh);

                if (step.SetObjectActive != null)
                    item.transform.Find(animation.Objects[step.SetObjectActive.Object]).gameObject.SetActive(step.SetObjectActive.Enabled);
                
                if (step.SetObjectRotation != null)
                    item.transform.Find(animation.Objects[step.SetObjectRotation.Object]).localRotation = Quaternion.Euler(step.SetObjectRotation.X, step.SetObjectRotation.Y, step.SetObjectRotation.Z);

                if (step.SetObjectPosition != null)
                    item.transform.Find(animation.Objects[step.SetObjectPosition.Object]).localPosition = new Vector3(step.SetObjectPosition.X, step.SetObjectPosition.Y, step.SetObjectPosition.Z);
            
                if (step.SetRandomPosition != null)
                    item.transform.Find(animation.Objects[step.SetRandomPosition.Object]).localPosition = new Vector3(
                        item.transform.Find(animation.Objects[step.SetRandomPosition.Object]).localPosition.x + Random.Range(-step.SetRandomPosition.MaxOffset, step.SetRandomPosition.MaxOffset), 
                        item.transform.Find(animation.Objects[step.SetRandomPosition.Object]).localPosition.y + Random.Range(-step.SetRandomPosition.MaxOffset, step.SetRandomPosition.MaxOffset), 
                        item.transform.Find(animation.Objects[step.SetRandomPosition.Object]).localPosition.z + Random.Range(-step.SetRandomPosition.MaxOffset, step.SetRandomPosition.MaxOffset));
            
                if (step.SetMaterialSlot != null)
                {
                    List<Material?> materials = [];

                    foreach (Material mat in item.transform.Find(animation.Objects[step.SetMaterialSlot.Object]).GetComponent<MeshRenderer>().sharedMaterials)
                    {
                        materials.Add(mat);
                    }

                    while (materials.Count - 1 < step.SetMaterialSlot.Slot)
                    {
                        materials.Add(null);
                    }

                    materials[step.SetMaterialSlot.Slot] = MaterialRegistry.GetMaterial(step.SetMaterialSlot.Material);

                    item.transform.Find(animation.Objects[step.SetMaterialSlot.Object]).GetComponent<MeshRenderer>().sharedMaterials = materials.ToArray();
                }
            }
        }

        if (!playingAnimation) {
            var animData = new AnimationData
            {
                ThirdPersonUseAnim = animation.ThirdPersonUseAnim
            };
            SteamComms.SendEvent(VisualCueEventType.PLAY_USE_ANIM, JsonConvert.SerializeObject(animData), Photon.Realtime.ReceiverGroup.Others);
        }

        if (animation.CodeOverride != null)
        {
            if (codeOverrides.ContainsKey(animation.CodeOverride))
                codeOverrides[animation.CodeOverride].BeingUsed(ItemName, item, progress);
        }

        playingAnimation = true;
    }

    public static void PlaySecondaryUsingAnimation(string ItemName, Item item, float progress)
    {
        Animation? animation = null;     
        foreach (Animation anim in animations)
        {
            if (ItemName.Contains(anim.ItemName))
                animation = anim;
        }

        if (animation == null)
        {
            Plugin.Log.LogError("Failed to Find Animation for " + ItemName);
            return;
        }

        if (animation.SecondaryUseAnimation != null) {
            foreach (AnimationStep step in animation.SecondaryUseAnimation)
            {
                if (progress < step.Time - 0.05f || progress > step.Time + 0.05f)
                    continue;
                if (step.SetMesh != null)
                    item.transform.Find(animation.Objects[step.SetMesh.Object]).GetComponent<MeshFilter>().sharedMesh = MeshRegistry.Get(step.SetMesh.Mesh);

                if (step.SetSkinnedMesh != null)
                    item.transform.Find(animation.Objects[step.SetSkinnedMesh.Object]).GetComponent<SkinnedMeshRenderer>().sharedMesh = MeshRegistry.Get(step.SetSkinnedMesh.Mesh);

                if (step.SetObjectActive != null)
                    item.transform.Find(animation.Objects[step.SetObjectActive.Object]).gameObject.SetActive(step.SetObjectActive.Enabled);
                
                if (step.SetObjectRotation != null)
                    item.transform.Find(animation.Objects[step.SetObjectRotation.Object]).localRotation = Quaternion.Euler(step.SetObjectRotation.X, step.SetObjectRotation.Y, step.SetObjectRotation.Z);
            
                if (step.SetObjectPosition != null)
                    item.transform.Find(animation.Objects[step.SetObjectPosition.Object]).localPosition = new Vector3(step.SetObjectPosition.X, step.SetObjectPosition.Y, step.SetObjectPosition.Z);
            
                if (step.SetMaterialSlot != null)
                {
                    List<Material?> materials = [];

                    foreach (Material mat in item.transform.Find(animation.Objects[step.SetMaterialSlot.Object]).GetComponent<MeshRenderer>().sharedMaterials)
                    {
                        materials.Add(mat);
                    }

                    while (materials.Count - 1 < step.SetMaterialSlot.Slot)
                    {
                        materials.Add(null);
                    }

                    materials[step.SetMaterialSlot.Slot] = MaterialRegistry.GetMaterial(step.SetMaterialSlot.Material);

                    item.transform.Find(animation.Objects[step.SetMaterialSlot.Object]).GetComponent<MeshRenderer>().sharedMaterials = materials.ToArray();
                }
            }
        }

        if (!playingAnimation) {
            var animData = new AnimationData
            {
                ThirdPersonUseAnim = animation.ThirdPersonUseAnim
            };
            SteamComms.SendEvent(VisualCueEventType.PLAY_SECONDARY_USE_ANIM, JsonConvert.SerializeObject(animData), Photon.Realtime.ReceiverGroup.Others);
        }

        playingAnimation = true;
    }


    public static void CancelAnimation(string ItemName, Item item)
    {
        Animation? animation = null;     
        foreach (Animation anim in animations)
        {
            if (ItemName.Contains(anim.ItemName))
                animation = anim;
        }

        if (animation == null)
        {
            Plugin.Log.LogError("Failed to Find Animation for " + ItemName);
            return;
        }

        if (animation.CancelUseAnimation != null) {
            foreach (AnimationStep step in animation.CancelUseAnimation)
            {
                if (step.SetOriginalMesh != null) {
                    string name = animation.ItemName;
                    if (step.SetOriginalMesh.Tag != null)
                        name = step.SetOriginalMesh.Tag;

                    item.transform.Find(animation.Objects[step.SetOriginalMesh.Object]).GetComponent<MeshFilter>().sharedMesh = MeshRegistry.GetOriginal(name);
                }

                if (step.SetOriginalSkinnedMesh != null) {
                    string name = animation.ItemName;
                    if (step.SetOriginalSkinnedMesh.Tag != null)
                        name = step.SetOriginalSkinnedMesh.Tag;

                    item.transform.Find(animation.Objects[step.SetOriginalSkinnedMesh.Object]).GetComponent<SkinnedMeshRenderer>().sharedMesh = MeshRegistry.GetOriginal(name);
                }
                
                if (step.SetObjectActive != null)
                    item.transform.Find(animation.Objects[step.SetObjectActive.Object]).gameObject.SetActive(step.SetObjectActive.Enabled);
                
                if (step.SetObjectRotation != null)
                    item.transform.Find(animation.Objects[step.SetObjectRotation.Object]).localRotation = Quaternion.Euler(step.SetObjectRotation.X, step.SetObjectRotation.Y, step.SetObjectRotation.Z);
            
                if (step.SetObjectPosition != null)
                    item.transform.Find(animation.Objects[step.SetObjectPosition.Object]).localPosition = new Vector3(step.SetObjectPosition.X, step.SetObjectPosition.Y, step.SetObjectPosition.Z);
            
                if (step.SetMaterialSlot != null)
                {
                    List<Material?> materials = [];

                    foreach (Material mat in item.transform.Find(animation.Objects[step.SetMaterialSlot.Object]).GetComponent<MeshRenderer>().sharedMaterials)
                    {
                        materials.Add(mat);
                    }

                    while (materials.Count - 1 < step.SetMaterialSlot.Slot)
                    {
                        materials.Add(null);
                    }

                    materials[step.SetMaterialSlot.Slot] = MaterialRegistry.GetMaterial(step.SetMaterialSlot.Material);

                    item.transform.Find(animation.Objects[step.SetMaterialSlot.Object]).GetComponent<MeshRenderer>().sharedMaterials = materials.ToArray();
                }

                if (step.ClearMaterials != null)
                    item.transform.Find(animation.Objects[step.ClearMaterials.Object]).GetComponent<MeshRenderer>().sharedMaterials = [];
            }
        }

        if (animation.CodeOverride != null)
        {
            if (codeOverrides.ContainsKey(animation.CodeOverride))
                codeOverrides[animation.CodeOverride].UseCanceled(ItemName, item);
        }

        SteamComms.SendEvent(VisualCueEventType.CANCEL_USE_ANIM, "{}", Photon.Realtime.ReceiverGroup.Others);
        playingAnimation = false;
    }


    public static void CancelSecondaryAnimation(string ItemName, Item item)
    {
        Animation? animation = null;     
        foreach (Animation anim in animations)
        {
            if (ItemName.Contains(anim.ItemName))
                animation = anim;
        }

        if (animation == null)
        {
            Plugin.Log.LogError("Failed to Find Animation for " + ItemName);
            return;
        }

        if (animation.CancelSecondaryUseAnimation != null) {
            foreach (AnimationStep step in animation.CancelSecondaryUseAnimation)
            {
                if (step.SetOriginalMesh != null) {
                    string name = animation.ItemName;
                    if (step.SetOriginalMesh.Tag != null)
                        name = step.SetOriginalMesh.Tag;

                    item.transform.Find(animation.Objects[step.SetOriginalMesh.Object]).GetComponent<MeshFilter>().sharedMesh = MeshRegistry.GetOriginal(name);
                }

                if (step.SetOriginalSkinnedMesh != null) {
                    string name = animation.ItemName;
                    if (step.SetOriginalSkinnedMesh.Tag != null)
                        name = step.SetOriginalSkinnedMesh.Tag;

                    item.transform.Find(animation.Objects[step.SetOriginalSkinnedMesh.Object]).GetComponent<SkinnedMeshRenderer>().sharedMesh = MeshRegistry.GetOriginal(name);
                }
                
                if (step.SetObjectActive != null)
                    item.transform.Find(animation.Objects[step.SetObjectActive.Object]).gameObject.SetActive(step.SetObjectActive.Enabled);
                
                if (step.SetObjectRotation != null)
                    item.transform.Find(animation.Objects[step.SetObjectRotation.Object]).localRotation = Quaternion.Euler(step.SetObjectRotation.X, step.SetObjectRotation.Y, step.SetObjectRotation.Z);
            
                if (step.SetObjectPosition != null)
                    item.transform.Find(animation.Objects[step.SetObjectPosition.Object]).localPosition = new Vector3(step.SetObjectPosition.X, step.SetObjectPosition.Y, step.SetObjectPosition.Z);
            
                if (step.SetMaterialSlot != null)
                {
                    List<Material?> materials = [];

                    foreach (Material mat in item.transform.Find(animation.Objects[step.SetMaterialSlot.Object]).GetComponent<MeshRenderer>().sharedMaterials)
                    {
                        materials.Add(mat);
                    }

                    while (materials.Count - 1 < step.SetMaterialSlot.Slot)
                    {
                        materials.Add(null);
                    }

                    materials[step.SetMaterialSlot.Slot] = MaterialRegistry.GetMaterial(step.SetMaterialSlot.Material);

                    item.transform.Find(animation.Objects[step.SetMaterialSlot.Object]).GetComponent<MeshRenderer>().sharedMaterials = materials.ToArray();
                }

                if (step.ClearMaterials != null)
                    item.transform.Find(animation.Objects[step.ClearMaterials.Object]).GetComponent<MeshRenderer>().sharedMaterials = [];
            }
        }

        SteamComms.SendEvent(VisualCueEventType.CANCEL_SECONDARY_USE_ANIM, "{}", Photon.Realtime.ReceiverGroup.Others);
        playingAnimation = false;
    }

    public static void ItemDataUpdated(string ItemName, ItemInstanceData instanceData, Item item)
    {
        Animation? animation = null;     
        foreach (Animation anim in animations)
        {
            if (ItemName.Contains(anim.ItemName))
                animation = anim;
        }

        if (animation == null)
        {
            Plugin.Log.LogError("Failed to Find Animation for " + ItemName);
            return;
        }

        if (animation.CodeOverride != null)
        {
            if (codeOverrides.ContainsKey(animation.CodeOverride))
                codeOverrides[animation.CodeOverride].ItemDataUpdated(ItemName, instanceData, item);
        }
    }


    public static void Unload()
    {
        animations.Clear();
        supportedItemNames.Clear();
    }
}