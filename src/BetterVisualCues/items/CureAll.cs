using BetterVisualCues;
using UnityEngine;

public class CureAllPatch : ItemPatch
{
    public override string ItemName => "Cure-All";

    public override void Created(Item __instance)
    {
        if (__instance.HasData(DataEntryKey.ItemUses)) {
            if (__instance.GetData<OptionableIntItemData>(DataEntryKey.ItemUses).Value == 2)
            {
                __instance.transform.Find("Jug/Jug (1)").GetComponent<MeshFilter>().sharedMesh = MeshRegistry.Get("CureAll_2_Uses");
                __instance.transform.Find("Jug/Jug (1)").localPosition = new Vector3(0, 0, -1);
            }            
            else if (__instance.GetData<OptionableIntItemData>(DataEntryKey.ItemUses).Value == 1)
            {
                __instance.transform.Find("Jug/Jug (1)").GetComponent<MeshFilter>().sharedMesh = MeshRegistry.Get("CureAll_1_Use");
                __instance.transform.Find("Jug/Jug (1)").localPosition = new Vector3(0, 0, -1);
            }
        }
    }

    public override void UsedFinished(Item __instance)
    {
        if (__instance.HasData(DataEntryKey.ItemUses)) {
            if (__instance.GetData<OptionableIntItemData>(DataEntryKey.ItemUses).Value == 2)
            {
                __instance.transform.Find("Jug/Jug (1)").GetComponent<MeshFilter>().sharedMesh = MeshRegistry.Get("CureAll_2_Uses");
                __instance.transform.Find("Jug/Jug (1)").localPosition = new Vector3(0, 0, -1);
            }            
            else if (__instance.GetData<OptionableIntItemData>(DataEntryKey.ItemUses).Value == 1)
            {
                __instance.transform.Find("Jug/Jug (1)").GetComponent<MeshFilter>().sharedMesh = MeshRegistry.Get("CureAll_1_Use");
                __instance.transform.Find("Jug/Jug (1)").localPosition = new Vector3(0, 0, -1);
            }
        }

        __instance.view.RPC("SetItemInstanceDataRPC", Photon.Pun.RpcTarget.Others, __instance.data);
    }    

    public override void ItemDataUpdate(ItemInstanceData instanceData, Item __instance)
    {
        if (instanceData.HasData(DataEntryKey.ItemUses)) {
            if (((OptionableIntItemData)instanceData.data[DataEntryKey.ItemUses]).Value == 2)
            {
                __instance.transform.Find("Jug/Jug (1)").GetComponent<MeshFilter>().sharedMesh = MeshRegistry.Get("CureAll_2_Uses");
                __instance.transform.Find("Jug/Jug (1)").localPosition = new Vector3(0, 0, -1);
            }            
            else if (((OptionableIntItemData)instanceData.data[DataEntryKey.ItemUses]).Value == 1)
            {
                __instance.transform.Find("Jug/Jug (1)").GetComponent<MeshFilter>().sharedMesh = MeshRegistry.Get("CureAll_1_Use");
                __instance.transform.Find("Jug/Jug (1)").localPosition = new Vector3(0, 0, -1);
            }
        }
    }
}