using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using BetterVisualCues;
using HarmonyLib;
using UnityEngine;

[HarmonyPatch(typeof(Item), "CancelUsePrimary")]
static class ItemStopUsedPatch
{
    static void Prefix(Item __instance)
    {
        if (GUIManager.InPauseMenu)
            return;

        if (!__instance.holderCharacter.IsLocal)
            return;

        if (AnimationHandler.IsItemSupported(__instance.name) && __instance.castProgress > 0.01f) {
            AnimationHandler.CancelAnimation(__instance.name, __instance);
        }
        
    }
}