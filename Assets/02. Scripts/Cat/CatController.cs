using UnityEngine;

public class CatController : MonoBehaviour
{
    private Rigidbody2D catRb;
    public float jumpPower = 10f;

    public bool isGround = false;

    public int jumpCount;

    void Start()
    {
        catRb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        // 스페이스 바 입력
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < 2)
        {

            catRb.AddForceY(jumpPower, ForceMode2D.Impulse);
            jumpCount++;


        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
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
