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
        Assembly assembly = Assembly.GetExecutingAssembly();

        ItemPatch? patch = assembly.GetTypes()
            .Where(type => type.IsClass && !type.IsAbstract && type.IsSubclassOf(typeof(ItemPatch)))
            .Select(type => Activator.CreateInstance(type))
            .Cast<ItemPatch>()
            .FirstOrDefault(patch => __instance.name.StartsWith(patch.ItemName));

        if (patch != null)
            patch.Created(__instance);
    }
}