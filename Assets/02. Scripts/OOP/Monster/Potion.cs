using System.Xml.Serialization;
using UnityEngine;

public class Potion : MonoBehaviour, IItem
{
    private Inventory inventory;
    public enum PotionType { HP, MP, Stemina }
    public PotionType potionType;

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
        this.gameObject.SetActive(false);
    }

    void OnMouseDown()
    {
        Get();
    }
}
