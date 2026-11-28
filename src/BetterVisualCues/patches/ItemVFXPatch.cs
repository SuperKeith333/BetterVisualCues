using System;
using System.Linq;
using System.Reflection;
using BetterVisualCues;
using HarmonyLib;
using UnityEngine;

[HarmonyPatch(typeof(ItemVFX), "Shake")]
static class ItemVFXPatch
{
    static bool Prefix(ItemVFX __instance)
    {
		if (!__instance.item.finishedCast)
		{
			GamefeelHandler.instance.AddPerlinShake(__instance.item.castProgress * __instance.shakeAmount * Time.deltaTime * 60f);
		}
		if (__instance.item.finishedCast && __instance.item.castProgress == 0)
		{
			for (int i = 0; i < __instance.doneSFX.Length; i++)
			{
				__instance.doneSFX[i].Play(__instance.transform.position);
			}
		}
		__instance.castProgress = __instance.item.castProgress;

        return false;
    }
}