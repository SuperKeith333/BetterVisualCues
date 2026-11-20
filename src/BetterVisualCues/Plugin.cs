using System.IO;
using System.Reflection;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using UnityEngine;

namespace BetterVisualCues;

// Here are some basic resources on code style and naming conventions to help
// you in your first CSharp plugin!
// https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions
// https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/identifier-names
// https://learn.microsoft.com/en-us/dotnet/standard/design-guidelines/names-of-namespaces

// The BepInAutoPlugin attribute comes from the Hamunii.BepInEx.AutoPlugin
// NuGet package, and it will generate the BepInPlugin attribute for you!
// For more info, see https://github.com/Hamunii/BepInEx.AutoPlugin

/// <summary>
/// The BepInEx plugin class of BetterVisualCues.
/// </summary>
[BepInAutoPlugin]
public partial class Plugin : BaseUnityPlugin
{
    internal static ManualLogSource Log { get; private set; } = null!;
    private readonly Harmony _harmony = new (Id);

    private void Awake()
    {
        // BepInEx gives us a logger which we can use to log information.
        // See https://lethal.wiki/dev/fundamentals/logging
        Log = Logger;

        MeshRegistry.Init();
        MaterialRegistry.loadMaterialFromItem("Berrynana Peel Blue Variant", "M_BananaBlue_Inside");
        MaterialRegistry.loadMaterialFromItem("Berrynana Peel Yellow", "M_Banana_Inside");
        MaterialRegistry.loadMaterialFromItem("Berrynana Peel Pink Variant", "M_BananaPink_Inside");
        MaterialRegistry.loadMaterialFromItem("Berrynana Peel Brown Variant", "M_BananaBrown_Inside");

        _harmony.PatchAll(Assembly.GetExecutingAssembly());
        Log.LogInfo($"Plugin {Name} is loaded!");
    }

    void Update()
    {

    }
    

    void OnDestroy()
    {
        _harmony.UnpatchSelf();
        MeshRegistry.Unload();
        AnimationHandler.Unload();
        MaterialRegistry.Unload();
        Log.LogInfo($"Plugin {Name} unloaded!");
    }
}
