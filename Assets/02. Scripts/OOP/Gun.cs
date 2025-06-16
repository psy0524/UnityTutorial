using System.Collections;
using UnityEngine;


public class Gun : MonoBehaviour, IDropItem
{
    public void Drop()
    {
        Debug.Log("총을 버렸다.");
    }

    public void Grab()
    {
        Debug.Log("총을 주웠다.");
        Destroy(gameObject);
    }

    public void Use()
    {
        Debug.Log("총을 발사한다.");
    }
}
