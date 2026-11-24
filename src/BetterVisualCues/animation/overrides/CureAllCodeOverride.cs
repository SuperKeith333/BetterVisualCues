using BetterVisualCues;
using Newtonsoft.Json;
using UnityEngine;

public class CureAllCodeOverride : BaseCodeOverride
{
    public override void Created(string ItemName, Item item)
    {
        if (item.HasData(DataEntryKey.ItemUses)) {
            if (item.GetData<OptionableIntItemData>(DataEntryKey.ItemUses).Value == 2)
            {
                item.transform.Find("Jug/Jug (1)").GetComponent<MeshFilter>().sharedMesh = MeshRegistry.Get("CureAll_2_Uses");
                item.transform.Find("Jug/Jug (1)").localPosition = new Vector3(0, 0, -1);
            }            
            else if (item.GetData<OptionableIntItemData>(DataEntryKey.ItemUses).Value == 1)
            {
                item.transform.Find("Jug/Jug (1)").GetComponent<MeshFilter>().sharedMesh = MeshRegistry.Get("CureAll_1_Use");
                item.transform.Find("Jug/Jug (1)").localPosition = new Vector3(0, 0, -1);
            }
        }
    }

    public override void UsedFinished(string ItemName, Item item)
    {
        item.view.RPC("SetItemInstanceDataRPC", Photon.Pun.RpcTarget.All, item.data);
    }

    public override void SecondaryUsedFinished(string ItemName, Item item)
    {
        if (item.HasData(DataEntryKey.ItemUses)) {
            if (item.GetData<OptionableIntItemData>(DataEntryKey.ItemUses).Value == 2)
            {
                item.transform.Find("Jug/Jug (1)").GetComponent<MeshFilter>().sharedMesh = MeshRegistry.Get("CureAll_2_Uses");
                item.transform.Find("Jug/Jug (1)").localPosition = new Vector3(0, 0, -1);
            }            
            else if (item.GetData<OptionableIntItemData>(DataEntryKey.ItemUses).Value == 1)
            {
                item.transform.Find("Jug/Jug (1)").GetComponent<MeshFilter>().sharedMesh = MeshRegistry.Get("CureAll_1_Use");
                item.transform.Find("Jug/Jug (1)").localPosition = new Vector3(0, 0, -1);
            }
        }

        // var json = JsonConvert.SerializeObject(item.data);
        // var modifiedData = JsonConvert.DeserializeObject<ItemInstanceData>(json);
        // ((OptionableIntItemData)modifiedData.data[DataEntryKey.ItemUses]).Value -= 1;
        // item.view.RPC("SetItemInstanceDataRPC", Photon.Pun.RpcTarget.AllBuffered, modifiedData);
    }

    public override void ItemDataUpdated(string ItemName, ItemInstanceData instanceData, Item item)
    {
        if (instanceData.HasData(DataEntryKey.ItemUses)) {
            if (((OptionableIntItemData)instanceData.data[DataEntryKey.ItemUses]).Value == 2)
            {
                item.transform.Find("Jug/Jug (1)").GetComponent<MeshFilter>().sharedMesh = MeshRegistry.Get("CureAll_2_Uses");
                item.transform.Find("Jug/Jug (1)").localPosition = new Vector3(0, 0, -1);
            }            
            else if (((OptionableIntItemData)instanceData.data[DataEntryKey.ItemUses]).Value == 1)
            {
                item.transform.Find("Jug/Jug (1)").GetComponent<MeshFilter>().sharedMesh = MeshRegistry.Get("CureAll_1_Use");
                item.transform.Find("Jug/Jug (1)").localPosition = new Vector3(0, 0, -1);
            }
        }
    }
}