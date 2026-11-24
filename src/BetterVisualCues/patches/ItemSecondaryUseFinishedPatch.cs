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

        Assembly assembly = Assembly.GetExecutingAssembly();

        ItemPatch? patch = assembly.GetTypes()
            .Where(type => type.IsClass && !type.IsAbstract && type.IsSubclassOf(typeof(ItemPatch)))
            .Select(type => Activator.CreateInstance(type))
            .Cast<ItemPatch>()
            .FirstOrDefault(patch => __instance.name.StartsWith(patch.ItemName));

        

        if (AnimationHandler.IsItemSupported(__instance.name))
            AnimationHandler.FinishedSecondaryUse(__instance.name, __instance);
    }
}