using UnityEngine;

public class Coin : MonoBehaviour, IItem
{
    private Inventory inventory;
    public enum CoinType {  Gold, Chest, Blue }
    public CoinType coinType;
    public float price;

    public GameObject Obj { get; set; }

    void Start()
    {
        inventory = FindFirstObjectByType<Inventory>();
        Obj = this.gameObject;
    }
    public void Get()
    {
        Debug.Log($"{this.name}¿ª »πµÊ«ﬂΩ¿¥œ¥Ÿ.");
        inventory.AddItem(this);
        this.gameObject.SetActive( false );
    }

    void OnMouseDown()
    {
        Get();
    }
}
