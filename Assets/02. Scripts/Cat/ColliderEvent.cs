using UnityEngine;

public class ColliderEvent : MonoBehaviour
{
    public GameObject fadeUI;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            fadeUI.SetActive(true);
        }
    }
}
