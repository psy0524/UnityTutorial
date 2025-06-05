using UnityEngine;
using Cat;

public class CatController : MonoBehaviour
{
    private Rigidbody2D catRb;

    private Animator catAnim;

    public float jumpPower = 10f;

    public bool isGround = false;

    public int jumpCount;

    public SoundManager soundManager;
    void Start()
    {
        catRb = GetComponent<Rigidbody2D>();
        catAnim = GetComponent<Animator>();

    }


    void Update()
    {
        // 스페이스 바 입력
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < 2)
        {
            catAnim.SetTrigger("Jump");
            catAnim.SetBool("isGround", false);
            catRb.linearVelocity = Vector2.zero;
            catRb.AddForceY(jumpPower, ForceMode2D.Impulse);
            jumpCount++;
            soundManager.OnJumpSound();

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            catAnim.SetBool("isGround", true);
            isGround = true;
            jumpCount = 0;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = false;
        }
    }
}
