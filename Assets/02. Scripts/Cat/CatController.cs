using UnityEngine;
using Cat;

public class CatController : MonoBehaviour
{
    private Rigidbody2D catRb;

    private Animator catAnim;

    public float jumpPower = 10f;

    public bool isGround = false;

    public int jumpCount;

    public GameObject fadeUI;

    public SoundManager soundManager;

    public GameObject gameOverUI;

    public GameObject happyVideo;
    public GameObject sadVideo;
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

        var catRotation = transform.eulerAngles;
        catRotation.z = catRb.linearVelocity.y * 2.5f;
        transform.eulerAngles = catRotation;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Apple"))
        {
            other.gameObject.SetActive(false);
            other.transform.parent.GetComponent<ItemEvent>().particle.SetActive(true);
            GameManager.score++;

            if(GameManager.score == 10)
            {
                fadeUI.SetActive(true);
                fadeUI.GetComponent<FadeRoutine>().OnFade(3f, Color.white);
                this.GetComponent<CircleCollider2D>().enabled = false;

                Invoke("HappyVideo", 5f);
            }
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
        else if (collision.gameObject.CompareTag("Pipe"))
        {
            soundManager.OnColliderSound();
            gameOverUI.SetActive(true);
            fadeUI.SetActive(true);
            fadeUI.GetComponent<FadeRoutine>().OnFade(3f, Color.black);
            this.GetComponent<CircleCollider2D>().enabled = false;

            Invoke("SadVideo", 5f);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = false;
        }
    }

    public void HappyVideo()
    {
        happyVideo.SetActive(true);
        fadeUI.SetActive(false);
        gameOverUI.SetActive(false);

        soundManager.audioSource.mute = true;
    }

    public void SadVideo()
    {
        sadVideo.SetActive(true);
        fadeUI.SetActive(false);
        gameOverUI.SetActive(false);

        soundManager.audioSource.mute = true;
    }
}
