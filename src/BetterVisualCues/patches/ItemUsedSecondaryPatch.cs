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

        Assembly assembly = Assembly.GetExecutingAssembly();

        ItemPatch? patch = assembly.GetTypes()
            .Where(type => type.IsClass && !type.IsAbstract && type.IsSubclassOf(typeof(ItemPatch)))
            .Select(type => Activator.CreateInstance(type))
            .Cast<ItemPatch>()
            .FirstOrDefault(patch => __instance.name.StartsWith(patch.ItemName));

        

        if (__instance.isUsingSecondary && __instance.usingTimePrimary > 0f) {
            if (patch != null)
                patch.SecondaryBeingUsed(__instance);
        }
    }
}