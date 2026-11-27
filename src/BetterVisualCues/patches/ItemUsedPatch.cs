using System;
using System.Linq;
using System.Reflection;
using BetterVisualCues;
using HarmonyLib;
using UnityEngine;

[HarmonyPatch(typeof(Item), "FinishCastPrimary")]
static class ItemUsedPatch
{
    static void Postfix(Item __instance)
    {
        if (!__instance.holderCharacter.IsLocal)
            return;

        if (AnimationHandler.IsItemSupported(__instance.name))
            AnimationHandler.FinishedUse(__instance.name, __instance);
    }
}