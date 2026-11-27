using System;
using System.Linq;
using System.Reflection;
using BetterVisualCues;
using HarmonyLib;
using UnityEngine;

[HarmonyPatch(typeof(Item), "FinishCastSecondary")]
static class ItemSecondaryUsedFinishPatch
{
    static void Postfix(Item __instance)
    {
        if (!__instance.holderCharacter.IsLocal)
            return;

        

        if (AnimationHandler.IsItemSupported(__instance.name))
            AnimationHandler.FinishedSecondaryUse(__instance.name, __instance);
    }
}