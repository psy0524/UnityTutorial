using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 100f;
    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * bulletSpeed * Time.deltaTime;
    }
}
