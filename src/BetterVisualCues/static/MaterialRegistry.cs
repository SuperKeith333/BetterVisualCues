using System.Collections.Generic;
using UnityEngine;

public static class MaterialRegistry
{
    static readonly Dictionary<string, Material> materials = [];

    public static void loadMaterialFromItem(string itemName, string materialName)
    {
        var prefab = Resources.Load<GameObject>("0_Items/" + itemName);
        if (prefab == null) { Debug.LogWarning("[Telltale] prefab not found: " + itemName); return; }

        Material? src = null;
        foreach (var r in prefab.GetComponentsInChildren<Renderer>(true))
            foreach (var m in r.sharedMaterials)
                if (m != null && m.name == materialName) src = m;

        materials[materialName] = new Material(src)
        {
            hideFlags = HideFlags.DontUnloadUnusedAsset
        };
    }

    public static Material? GetMaterial(string name)
    {
        if (materials.TryGetValue(name, out var m) && m != null) return m;
        BetterVisualCues.Plugin.Log.LogWarning("Material not found: " + name);
        return null;
    }
}