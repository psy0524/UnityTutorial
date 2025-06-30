using UnityEngine;

public class Tranfoline : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D targetRb;
    [SerializeField] private float pushPower = 30f;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            targetRb = collision.GetComponent<Rigidbody2D>();
            Invoke("PushCharacter", 1f);
        }
    }

    void PushCharacter()
    {
        targetRb.AddForceY(pushPower, ForceMode2D.Impulse);
        animator.SetTrigger("Push");
    }
}
