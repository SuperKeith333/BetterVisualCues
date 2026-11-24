using System;
using System.Linq;
using System.Reflection;
using BetterVisualCues;
using HarmonyLib;
using UnityEngine;

[HarmonyPatch(typeof(CharacterAnimations), "RPCA_PlayRemove")]
static class PlayRemoveAnimationPatch
{
    public static float animTime = 0;
    public static bool countAnimTime = false;
    public static Item? item = null;
    public static ItemPatch? itemPatch = null;
    public static string anim = "";

    static void Postfix(string emoteName, CharacterAnimations __instance)
    {
        if (__instance.character.data.currentItem == null)
            return;

        Assembly assembly = Assembly.GetExecutingAssembly();

        ItemPatch? patch = assembly.GetTypes()
            .Where(type => type.IsClass && !type.IsAbstract && type.IsSubclassOf(typeof(ItemPatch)))
            .Select(type => Activator.CreateInstance(type))
            .Cast<ItemPatch>()
            .FirstOrDefault(patch => __instance.character.data.currentItem.name.StartsWith(patch.ItemName));

        if (emoteName == "A_Scout_Use_Item")
            countAnimTime = true;
        else
        {
            animTime = 0;
            countAnimTime = false;
            item = null;
            itemPatch = null;
            anim = "";
        }

        // if (patch != null) {
        //     item = __instance.character.data.currentItem;
        //     itemPatch = patch;
        //     anim = emoteName;
        //     patch.AnimationUpdated(emoteName, __instance);
        // }
        
    }
}