using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using BetterVisualCues;
using HarmonyLib;
using UnityEngine;

[HarmonyPatch(typeof(Item), "CancelUseSecondary")]
static class ItemStopUsedSecondaryPatch
{
    static void Prefix(Item __instance)
    {
        if (!__instance.holderCharacter.IsLocal)
            return;

        if (__instance.isUsingSecondary && AnimationHandler.IsItemSupported(__instance.name))
            AnimationHandler.CancelSecondaryAnimation(__instance.name, __instance);
    }
}