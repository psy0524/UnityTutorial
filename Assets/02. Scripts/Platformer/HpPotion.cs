using UnityEngine;

public class HpPotion : MonoBehaviour, IItemObject
{
    public ItemManager Inventory { get; set; }
    public GameObject Object { get; set; }
    public string ItemName { get; set; }
    public Sprite Icon { get; set; }

    void Start()
    {
        Inventory = FindFirstObjectByType<ItemManager>();
        Object = this.gameObject;
        ItemName = name;
        Icon = GetComponent<SpriteRenderer>().sprite;
    }
    
    public void Get()
    {
        gameObject.SetActive(false);
        Inventory.GetItem(this);

    }

    public void Use()
    {
        Debug.Log("HP 포션 사용");
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Get();
        }
    }
}
