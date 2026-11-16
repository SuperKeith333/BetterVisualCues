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
        Assembly assembly = Assembly.GetExecutingAssembly();

        ItemPatch? patch = assembly.GetTypes()
            .Where(type => type.IsClass && !type.IsAbstract && type.IsSubclassOf(typeof(ItemPatch)))
            .Select(type => Activator.CreateInstance(type))
            .Cast<ItemPatch>()
            .FirstOrDefault(patch => __instance.name.StartsWith(patch.ItemName));

        

        if (__instance.isUsingPrimary && __instance.usingTimePrimary > 0f) {
            if (patch != null)
                patch.BeingUsed(__instance);
        }
    }
}