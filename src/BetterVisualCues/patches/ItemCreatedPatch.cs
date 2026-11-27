using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using BetterVisualCues;
using HarmonyLib;
using UnityEngine;

[HarmonyPatch(typeof(Item), "Start")]
static class ItemCreatedPatch
{
    static void Postfix(Item __instance)
    {
            
        if (AnimationHandler.IsItemSupported(__instance.name)) {
            AnimationHandler.ItemCreated(__instance.name, __instance);
        }
        
    }
}