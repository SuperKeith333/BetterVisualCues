using UnityEngine;

public class RopeCannonCodeOverride : BaseCodeOverride
{
    public override void BeingUsed(string ItemName, Item item, float progress)
    {
        Vector3 offset = new Vector3(Random.Range(-progress, progress) / 16, Random.Range(-progress, progress) / 16, Random.Range(-progress, progress) / 16);
        item.transform.Find("RopeCannon").localPosition += offset;
        item.transform.Find("HideOnFire").localPosition += offset;
    }

    public override void UseCanceled(string ItemName, Item item)
    {
        item.transform.Find("RopeCannon").localPosition = new Vector3(0, 0.179f, 0.461f);
        item.transform.Find("HideOnFire").localPosition = new Vector3(0, 0, 0);
    }
}