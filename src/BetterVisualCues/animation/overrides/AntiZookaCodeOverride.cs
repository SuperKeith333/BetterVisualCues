using UnityEngine;

public class AntiZookaCodeOverride : BaseCodeOverride
{
    public override void Created(string ItemName, Item item)
    {
        item.transform.Find("Anti-Zooka").GetComponent<MeshFilter>().sharedMesh = MeshRegistry.Get("Anti_Zooka_New");
        if (item.HasData(DataEntryKey.ItemUses)) {
            if (item.GetData<OptionableIntItemData>(DataEntryKey.ItemUses).Value == 3) {
                var newAntiSphere = GameObject.Instantiate(item.transform.Find("Anti-Zooka/Shell/AntiSphere"), item.transform.Find("Anti-Zooka/Shell"));
                newAntiSphere.localScale = new Vector3(0.4f, 0.4f, 0.4f);
                newAntiSphere.localPosition = new Vector3(-0.017f, 2.5f, 0.125f);
                newAntiSphere.localRotation = Quaternion.identity;
                newAntiSphere.name = "AmmoSphere";
            }
            if (item.GetData<OptionableIntItemData>(DataEntryKey.ItemUses).Value >= 2) {
                var newAntiSphere = GameObject.Instantiate(item.transform.Find("Anti-Zooka/Shell/AntiSphere"), item.transform.Find("Anti-Zooka/Shell"));
                newAntiSphere.localScale = new Vector3(0.4f, 0.4f, 0.4f);
                newAntiSphere.localPosition = new Vector3(-0.017f, 2.91f, 0.15f);
                newAntiSphere.localRotation = Quaternion.identity;
                newAntiSphere.name = "AmmoSphere";
            }
            if (item.GetData<OptionableIntItemData>(DataEntryKey.ItemUses).Value >= 1) {
                var newAntiSphere = GameObject.Instantiate(item.transform.Find("Anti-Zooka/Shell/AntiSphere"), item.transform.Find("Anti-Zooka/Shell"));
                newAntiSphere.localScale = new Vector3(0.4f, 0.4f, 0.4f);
                newAntiSphere.localPosition = new Vector3(-0.017f, 3.27f, 0.125f);
                newAntiSphere.localRotation = Quaternion.identity;
                newAntiSphere.name = "AmmoSphere";
            }
        }
    }

    public override void UsedFinished(string ItemName, Item item)
    {
        item.view.RPC("SetItemInstanceDataRPC", Photon.Pun.RpcTarget.All, item.data);
    }

    public override void ItemDataUpdated(string ItemName, ItemInstanceData instanceData, Item item)
    {
        for (int i = 0; i < item.transform.Find("Anti-Zooka/Shell").childCount; i++)
        {
            if (item.transform.Find("Anti-Zooka/Shell").GetChild(i).name == "AmmoSphere")
            {
                GameObject.Destroy(item.transform.Find("Anti-Zooka/Shell").GetChild(i).gameObject);
            }
        }

        if (instanceData.HasData(DataEntryKey.ItemUses)) {
            if (((OptionableIntItemData)instanceData.data[DataEntryKey.ItemUses]).Value == 3) {
                var newAntiSphere = GameObject.Instantiate(item.transform.Find("Anti-Zooka/Shell/AntiSphere"), item.transform.Find("Anti-Zooka/Shell"));
                newAntiSphere.localScale = new Vector3(0.4f, 0.4f, 0.4f);
                newAntiSphere.localPosition = new Vector3(-0.017f, 2.5f, 0.125f);
                newAntiSphere.localRotation = Quaternion.identity;
                newAntiSphere.name = "AmmoSphere";
            }
            if (((OptionableIntItemData)instanceData.data[DataEntryKey.ItemUses]).Value>= 2) {
               var newAntiSphere = GameObject.Instantiate(item.transform.Find("Anti-Zooka/Shell/AntiSphere"), item.transform.Find("Anti-Zooka/Shell"));
                newAntiSphere.localScale = new Vector3(0.4f, 0.4f, 0.4f);
                newAntiSphere.localPosition = new Vector3(-0.017f, 2.91f, 0.15f);
                newAntiSphere.localRotation = Quaternion.identity;
                newAntiSphere.name = "AmmoSphere";
            }
            if (((OptionableIntItemData)instanceData.data[DataEntryKey.ItemUses]).Value >= 1) {
                var newAntiSphere = GameObject.Instantiate(item.transform.Find("Anti-Zooka/Shell/AntiSphere"), item.transform.Find("Anti-Zooka/Shell"));
                newAntiSphere.localScale = new Vector3(0.4f, 0.4f, 0.4f);
                newAntiSphere.localPosition = new Vector3(-0.017f, 3.27f, 0.125f);
                newAntiSphere.localRotation = Quaternion.identity;
                newAntiSphere.name = "AmmoSphere";
            }
        }
    }
}