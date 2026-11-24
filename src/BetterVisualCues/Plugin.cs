using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using Newtonsoft.Json;
using Photon.Pun;
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
    private Dictionary<Item, float> ItemAnimationsToPlay = [];
    private Dictionary<Item, float> SecondaryItemAnimationsToPlay = [];

    private void Awake()
    {
        // BepInEx gives us a logger which we can use to log information.
        // See https://lethal.wiki/dev/fundamentals/logging
        Log = Logger;

        MeshRegistry.Init();

        // MaterialRegistry.loadMaterialFromItem("Berrynana Peel Pink Variant", "M_BananaPink_Inside");
        // MaterialRegistry.loadMaterialFromItem("Berrynana Peel Brown Variant", "M_BananaBrown_Inside");

        AnimationHandler.Init();
        AnimationHandler.registerCodeOverride("Anti-Zooka", new AntiZookaCodeOverride());
        AnimationHandler.registerCodeOverride("Cure-All", new CureAllCodeOverride());

        SteamComms.Init(OnEvent);

        _harmony.PatchAll(Assembly.GetExecutingAssembly());
        Log.LogInfo($"Plugin {Name} is loaded!");
    }

    void Update()
    {
        foreach (var item in ItemAnimationsToPlay.Keys.ToList())
        {
            if (item != null)
                ItemAnimationsToPlay[item] += 1f / item.usingTimePrimary * Time.deltaTime;
        }
        foreach (var item in SecondaryItemAnimationsToPlay.Keys.ToList())
        {
            if (item != null)
                SecondaryItemAnimationsToPlay[item] += 1f / item.totalSecondaryUsingTime * Time.deltaTime;
        }


        foreach (var (item, progress) in ItemAnimationsToPlay)
        {
            if (item != null) {
                AnimationHandler.PlayUsingAnimation(item.name, item, progress);
            }
        }

        foreach (var (item, progress) in SecondaryItemAnimationsToPlay)
        {
            if (item != null) {
                AnimationHandler.PlaySecondaryUsingAnimation(item.name, item, progress);
            }
        }

        if (Input.GetKeyDown(KeyCode.End))
        {
            MeshRegistry.Unload();
            AnimationHandler.Unload();
            MaterialRegistry.Unload();

            MeshRegistry.Init();
            // MaterialRegistry.loadMaterialFromItem("Berrynana Peel Pink Variant", "M_BananaPink_Inside");
            // MaterialRegistry.loadMaterialFromItem("Berrynana Peel Brown Variant", "M_BananaBrown_Inside");
            AnimationHandler.Init();
        }
    }

    private void OnEvent(string sender, VisualCueEventType eventType, string json)
    {
        Plugin.Log.LogInfo("Event Recived: " + eventType + " from sender: " + sender + " with payload: " + json);
        var player = PlayerHandler.GetPlayerCharacter(PhotonNetwork.PlayerList.FirstOrDefault(p => p.NickName == sender));
        AnimationData? animData = JsonConvert.DeserializeObject<AnimationData>(json);

        

        switch (eventType)
        {
            case VisualCueEventType.PLAY_USE_ANIM:
                if (player.data.currentItem == null)
                    break;
                ItemAnimationsToPlay[player.data.currentItem] = 0;

                if (animData != null)
                    player.refs.animator.Play(animData.ThirdPersonUseAnim, 0, 0);
                break;
            case VisualCueEventType.CANCEL_USE_ANIM:
                if (player.data.currentItem == null)
                    break;
                ItemAnimationsToPlay.Remove(player.data.currentItem);

                if (animData != null)
                    player.refs.animator.Play("A_Scout_Land", 0, 0);
                
                AnimationHandler.CancelAnimation(player.data.currentItem.name, player.data.currentItem);
                break;
            case VisualCueEventType.PLAY_SECONDARY_USE_ANIM:
                if (player.data.currentItem == null)
                    break;
                SecondaryItemAnimationsToPlay[player.data.currentItem] = 0;

                if (animData != null)
                    player.refs.animator.Play(animData.ThirdPersonUseAnim, 0, 0);
                break;
            case VisualCueEventType.CANCEL_SECONDARY_USE_ANIM:
                if (player.data.currentItem == null)
                    break;
                SecondaryItemAnimationsToPlay.Remove(player.data.currentItem);

                if (animData != null)
                    player.refs.animator.Play("A_Scout_Land", 0, 0);
                
                AnimationHandler.CancelSecondaryAnimation(player.data.currentItem.name, player.data.currentItem);
                break;
        }
    }
    

    void OnDestroy()
    {
        _harmony.UnpatchSelf();
        MeshRegistry.Unload();
        AnimationHandler.Unload();
        MaterialRegistry.Unload();
        SteamComms.Unload();
        Log.LogInfo($"Plugin {Name} unloaded!");
    }
}
