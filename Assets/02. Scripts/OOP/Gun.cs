using System.Collections;
using UnityEngine;


public class Gun : MonoBehaviour, IDropItem
{
    public GameObject bulletPrefab;
    public Transform shootPos;
    public void Drop()
    {
        Debug.Log("총을 버렸다.");
        transform.SetParent(null);
        transform.position = Vector3.zero;
    }

    public void Grab(Transform grabPos)
    {
        transform.SetParent(grabPos);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;

        Debug.Log("총을 주웠다.");
    }

    public void Use()
    {
        GameObject bullet = Instantiate(bulletPrefab, shootPos.position, Quaternion.identity);
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();

        bulletRb.AddForce(shootPos.forward * 100f, ForceMode.Impulse);
    }
}
