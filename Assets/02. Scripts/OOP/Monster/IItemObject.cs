using UnityEngine;

public interface IItemObject
{
    ItemManager Inventory { get; set; }
    GameObject Object { get; set; }
    string ItemName { get; set; }
    Sprite Icon { get; set; }

    void Get();
    void Use();
}
