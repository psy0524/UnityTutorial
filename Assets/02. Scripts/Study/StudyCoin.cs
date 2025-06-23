using UnityEngine;

public class StudyCoin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Movement.coinCount++;

            Debug.Log($"È¹µæ ÄÚÀÎ °¹¼ö {Movement.coinCount}");

            Destroy(this.gameObject);
        }
    }
}
