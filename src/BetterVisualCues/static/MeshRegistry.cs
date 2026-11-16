using System.Collections.Generic;
using System.IO;
using System.Reflection;
using BepInEx;
using BetterVisualCues;
using UnityEngine;

public static class MeshRegistry
{
    static readonly Dictionary<string, Mesh> meshes = new Dictionary<string, Mesh>();
    static readonly Dictionary<string, Mesh> originals = new Dictionary<string, Mesh>();
    public static readonly Dictionary<string, Material> materials = new Dictionary<string, Material>();
    static AssetBundle bundle;

    public static bool loaded => bundle != null;

    public static void Init()
    {
        if (loaded) return;

        string path = FindBundle("meshes");
        if (path == null) { Plugin.Log.LogError("Bundle not found: meshes"); return; }

        foreach (var b in AssetBundle.GetAllLoadedAssetBundles())
            if (b.name == "meshes") b.Unload(true);

        bundle = AssetBundle.LoadFromFile(path);
        if (bundle == null)
        {
            Plugin.Log.LogError("Failed to load mesh bundle at " + path);
            return;
        }

        foreach (var mesh in bundle.LoadAllAssets<Mesh>())
        {
            mesh.hideFlags = HideFlags.DontUnloadUnusedAsset;
            meshes[mesh.name] = mesh;
            Plugin.Log.LogInfo("Registered mesh: " + mesh.name);
        }
    }

    static string FindBundle(string fileName)
    {
        // 1) Where BepInEx loads plugins from (survives reload tools)
        foreach (var dir in Directory.GetDirectories(Paths.PluginPath, "*", SearchOption.AllDirectories))
        {
            string p = Path.Combine(dir, fileName);
            if (File.Exists(p)) return p;
        }
        string direct = Path.Combine(Paths.PluginPath, fileName);
        if (File.Exists(direct)) return direct;

        // 2) Next to the executing assembly (normal, non-reloaded case)
        string asmDir = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        string local = Path.Combine(asmDir, fileName);
        return File.Exists(local) ? local : null;
    }

    public static Mesh Get(string name)
    {
        if (meshes.TryGetValue(name, out var m) && m != null) return m;
        Plugin.Log.LogWarning("Mesh not found: " + name);
        return null;
    }

    public static Mesh GetOriginal(string key)
    {
        if (originals.TryGetValue(key, out var m) && m != null) return m;
        Plugin.Log.LogWarning("Original Mesh not found: " + key);
        return null;
    }

    public static void SetOriginal(string key, Mesh mesh)
    {
        originals[key] = mesh;
    }
    public static void Unload()
    {
        foreach (var m in meshes.Values)
            if (m != null) m.hideFlags = HideFlags.None;
        meshes.Clear();

        if (bundle != null)
        {
            bundle.Unload(true);
            bundle = null;
        }
    }
}