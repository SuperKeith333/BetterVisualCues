using UnityEngine;

public class AntiZookaPatch : ItemPatch
{
    public override string ItemName => "AntiZooka";

    public override void Created(Item __instance)
    {
        __instance.transform.Find("Anti-Zooka").GetComponent<MeshFilter>().sharedMesh = MeshRegistry.Get("Anti_Zooka_New");
        if (__instance.HasData(DataEntryKey.ItemUses)) {
            if (__instance.GetData<OptionableIntItemData>(DataEntryKey.ItemUses).Value == 3) {
                var newAntiSphere = GameObject.Instantiate(__instance.transform.Find("Anti-Zooka/Shell/AntiSphere"), __instance.transform.Find("Anti-Zooka/Shell"));
                newAntiSphere.localScale = new Vector3(0.4f, 0.4f, 0.4f);
                newAntiSphere.localPosition = new Vector3(-0.017f, 2.5f, 0.125f);
                newAntiSphere.localRotation = Quaternion.identity;
                newAntiSphere.name = "AmmoSphere";
            }
            if (__instance.GetData<OptionableIntItemData>(DataEntryKey.ItemUses).Value >= 2) {
                var newAntiSphere = GameObject.Instantiate(__instance.transform.Find("Anti-Zooka/Shell/AntiSphere"), __instance.transform.Find("Anti-Zooka/Shell"));
                newAntiSphere.localScale = new Vector3(0.4f, 0.4f, 0.4f);
                newAntiSphere.localPosition = new Vector3(-0.017f, 2.91f, 0.15f);
                newAntiSphere.localRotation = Quaternion.identity;
                newAntiSphere.name = "AmmoSphere";
            }
            if (__instance.GetData<OptionableIntItemData>(DataEntryKey.ItemUses).Value >= 1) {
                var newAntiSphere = GameObject.Instantiate(__instance.transform.Find("Anti-Zooka/Shell/AntiSphere"), __instance.transform.Find("Anti-Zooka/Shell"));
                newAntiSphere.localScale = new Vector3(0.4f, 0.4f, 0.4f);
                newAntiSphere.localPosition = new Vector3(-0.017f, 3.27f, 0.125f);
                newAntiSphere.localRotation = Quaternion.identity;
                newAntiSphere.name = "AmmoSphere";
            }
        }
    }

    public override void UsedFinished(Item __instance)
    {
        for (int i = 0; i < __instance.transform.Find("Anti-Zooka/Shell").childCount; i++)
        {
            if (__instance.transform.Find("Anti-Zooka/Shell").GetChild(i).name == "AmmoSphere")
            {
                GameObject.Destroy(__instance.transform.Find("Anti-Zooka/Shell").GetChild(i).gameObject);
            }
        }

        if (__instance.HasData(DataEntryKey.ItemUses)) {
            if (__instance.GetData<OptionableIntItemData>(DataEntryKey.ItemUses).Value == 3) {
                var newAntiSphere = GameObject.Instantiate(__instance.transform.Find("Anti-Zooka/Shell/AntiSphere"), __instance.transform.Find("Anti-Zooka/Shell"));
                newAntiSphere.localScale = new Vector3(0.4f, 0.4f, 0.4f);
                newAntiSphere.localPosition = new Vector3(-0.017f, 2.5f, 0.125f);
                newAntiSphere.localRotation = Quaternion.identity;
                newAntiSphere.name = "AmmoSphere";
            }
            if (__instance.GetData<OptionableIntItemData>(DataEntryKey.ItemUses).Value >= 2) {
               var newAntiSphere = GameObject.Instantiate(__instance.transform.Find("Anti-Zooka/Shell/AntiSphere"), __instance.transform.Find("Anti-Zooka/Shell"));
                newAntiSphere.localScale = new Vector3(0.4f, 0.4f, 0.4f);
                newAntiSphere.localPosition = new Vector3(-0.017f, 2.91f, 0.15f);
                newAntiSphere.localRotation = Quaternion.identity;
                newAntiSphere.name = "AmmoSphere";
            }
            if (__instance.GetData<OptionableIntItemData>(DataEntryKey.ItemUses).Value >= 1) {
                var newAntiSphere = GameObject.Instantiate(__instance.transform.Find("Anti-Zooka/Shell/AntiSphere"), __instance.transform.Find("Anti-Zooka/Shell"));
                newAntiSphere.localScale = new Vector3(0.4f, 0.4f, 0.4f);
                newAntiSphere.localPosition = new Vector3(-0.017f, 3.27f, 0.125f);
                newAntiSphere.localRotation = Quaternion.identity;
                newAntiSphere.name = "AmmoSphere";
            }
        }
    }

    public override void ItemDataUpdate(ItemInstanceData instanceData, Item __instance)
    {
        for (int i = 0; i < __instance.transform.Find("Anti-Zooka/Shell").childCount; i++)
        {
            if (__instance.transform.Find("Anti-Zooka/Shell").GetChild(i).name == "AmmoSphere")
            {
                GameObject.Destroy(__instance.transform.Find("Anti-Zooka/Shell").GetChild(i).gameObject);
            }
        }

        if (instanceData.HasData(DataEntryKey.ItemUses)) {
            if (((OptionableIntItemData)instanceData.data[DataEntryKey.ItemUses]).Value == 3) {
                var newAntiSphere = GameObject.Instantiate(__instance.transform.Find("Anti-Zooka/Shell/AntiSphere"), __instance.transform.Find("Anti-Zooka/Shell"));
                newAntiSphere.localScale = new Vector3(0.4f, 0.4f, 0.4f);
                newAntiSphere.localPosition = new Vector3(-0.017f, 2.5f, 0.125f);
                newAntiSphere.localRotation = Quaternion.identity;
                newAntiSphere.name = "AmmoSphere";
            }
            if (((OptionableIntItemData)instanceData.data[DataEntryKey.ItemUses]).Value>= 2) {
               var newAntiSphere = GameObject.Instantiate(__instance.transform.Find("Anti-Zooka/Shell/AntiSphere"), __instance.transform.Find("Anti-Zooka/Shell"));
                newAntiSphere.localScale = new Vector3(0.4f, 0.4f, 0.4f);
                newAntiSphere.localPosition = new Vector3(-0.017f, 2.91f, 0.15f);
                newAntiSphere.localRotation = Quaternion.identity;
                newAntiSphere.name = "AmmoSphere";
            }
            if (((OptionableIntItemData)instanceData.data[DataEntryKey.ItemUses]).Value >= 1) {
                var newAntiSphere = GameObject.Instantiate(__instance.transform.Find("Anti-Zooka/Shell/AntiSphere"), __instance.transform.Find("Anti-Zooka/Shell"));
                newAntiSphere.localScale = new Vector3(0.4f, 0.4f, 0.4f);
                newAntiSphere.localPosition = new Vector3(-0.017f, 3.27f, 0.125f);
                newAntiSphere.localRotation = Quaternion.identity;
                newAntiSphere.name = "AmmoSphere";
            }
        }
    }
}