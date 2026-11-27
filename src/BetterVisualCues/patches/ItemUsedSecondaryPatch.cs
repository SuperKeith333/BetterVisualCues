using System;
using System.Linq;
using System.Reflection;
using BetterVisualCues;
using HarmonyLib;
using UnityEngine;

[HarmonyPatch(typeof(Item), "ContinueUseSecondary")]
static class ItemSecondaryBeingUsedPatch
{
    static void Prefix(Item __instance)
    {
        if (!__instance.holderCharacter.IsLocal)
            return;

        

        if (__instance.isUsingSecondary && __instance.usingTimePrimary > 0.01f) {
            if (AnimationHandler.IsItemSupported(__instance.name))
                AnimationHandler.PlaySecondaryUsingAnimation(__instance.name, __instance, __instance.castProgress);
        }
    }
}