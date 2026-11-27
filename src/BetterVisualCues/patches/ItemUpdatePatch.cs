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

        if (AnimationHandler.IsItemSupported(__instance.name))
            AnimationHandler.ItemDataUpdated(__instance.name, instanceData, __instance);
        
    }
}