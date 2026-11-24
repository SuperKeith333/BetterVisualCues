using System;
using System.Linq;
using System.Reflection;
using BetterVisualCues;
using HarmonyLib;
using UnityEngine;

[HarmonyPatch(typeof(Item), "ContinueUsePrimary")]
static class ItemBeingUsedPatch
{
    static void Prefix(Item __instance)
    {
        if (GUIManager.InPauseMenu)
            return;
        if (!__instance.holderCharacter.IsLocal)
            return;
        

        if (__instance.isUsingPrimary && __instance.castProgress > 0.01f) {
            if (AnimationHandler.IsItemSupported(__instance.name)) {
                AnimationHandler.PlayUsingAnimation(__instance.name, __instance, __instance.castProgress);
            }
        }
    }
}