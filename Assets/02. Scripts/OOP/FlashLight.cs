using System.Collections;
using UnityEngine;


public class FlashLight : MonoBehaviour, IDropItem
{
    public GameObject lightObj;
    public bool isLight;

    public void Drop()
    {
        Debug.Log("손전등을 버렸다.");
    }

    public void Grab()
    {
        Debug.Log("손전등을 주웠다.");
        Destroy(gameObject);
    }

    public void Use()
    {
        //isLight = !isLight;
        //lightObj.SetActive(isLight);

        Debug.Log("라이트를 켠다.");
    }
}
