using System;
using System.Linq;
using System.Reflection;
using BetterVisualCues;
using HarmonyLib;
using UnityEngine;

[HarmonyPatch(typeof(Item), "ContinueUsePrimary")]
static class ItemBeingUsedPatch
{
    static bool Prefix(Item __instance)
    {
        if (GUIManager.InPauseMenu)
            return true;
        if (!__instance.holderCharacter.IsLocal)
            return true;


        if (__instance.isUsingPrimary && __instance.castProgress > 0.01f && !__instance.finishedCast) {
            if (AnimationHandler.IsItemSupported(__instance.name)) {
                AnimationHandler.PlayUsingAnimation(__instance.name, __instance, __instance.castProgress);
            }
        }

        return true;
    }
}