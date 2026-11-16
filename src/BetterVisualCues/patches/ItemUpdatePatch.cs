using System;
using System.Linq;
using System.Reflection;
using BetterVisualCues;
using ExitGames.Client.Photon.StructWrapping;
using HarmonyLib;
using UnityEngine;

[HarmonyPatch(typeof(Item), "SetItemInstanceDataRPC")]
static class ItemUpdatePatch
{
    static void Prefix(ItemInstanceData instanceData, Item __instance)
    {
        Assembly assembly = Assembly.GetExecutingAssembly();

        ItemPatch? patch = assembly.GetTypes()
            .Where(type => type.IsClass && !type.IsAbstract && type.IsSubclassOf(typeof(ItemPatch)))
            .Select(type => Activator.CreateInstance(type))
            .Cast<ItemPatch>()
            .FirstOrDefault(patch => __instance.name.StartsWith(patch.ItemName));

        if (patch != null)
            patch.ItemDataUpdate(instanceData, __instance);
        
    }
}