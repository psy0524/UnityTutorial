using UnityEngine;
using Cat;
using System.Collections;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class CatController : MonoBehaviour
{
    private Rigidbody2D catRb;

    private Animator catAnim;

    public float jumpPower = 10f;

    public bool isGround = false;

    public int jumpCount;

    public GameObject fadeUI;

    public SoundManager soundManager;
    public VideoManager videoManager;

    public GameObject gameOverUI;
    public GameObject playUI;

    void Awake()
    {
        catRb = GetComponent<Rigidbody2D>();
        catAnim = GetComponent<Animator>();

    }

    private void OnEnable()
    {
        transform.localPosition = new Vector3(-8.21f, -2.05f, 0);
        GetComponent<CircleCollider2D>().enabled = true;
        soundManager.audioSource.mute = false;
    }

    void Update()
    {
        Jump();
    }

    private void Jump()
    {
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
            other.transform.GetComponentInParent<ItemEvent>().particle.SetActive(true);
            GameManager.score++;

            if (GameManager.score == 15)
            {
                fadeUI.SetActive(true);
                fadeUI.GetComponent<FadeRoutine>().OnFade(3f, Color.white, true); // 페이드 실행
                this.GetComponent<CircleCollider2D>().enabled = false;

                //Invoke("HappyVideo", 5f);
                StartCoroutine(EndingRoutine(true));
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
            fadeUI.GetComponent<FadeRoutine>().OnFade(3f, Color.black, true); // 페이드 실행
            this.GetComponent<CircleCollider2D>().enabled = false;

            StartCoroutine(EndingRoutine(false));
            //Invoke("SadVideo", 5f);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = false;
        }
    }

    //public void HappyVideo()
    //{
    //    videoManager.VideoPlay(true);
    //    fadeUI.SetActive(false);
    //    gameOverUI.SetActive(false);

    //    soundManager.audioSource.mute = true;
    //}

    //public void SadVideo()
    //{
    //    videoManager.VideoPlay(false);

    //    fadeUI.SetActive(false);
    //    gameOverUI.SetActive(false);
    //    playUI.SetActive(false);

    //    soundManager.audioSource.mute = true;
    //}

    IEnumerator EndingRoutine(bool isHappy)
    {
        yield return new WaitForSeconds(3.5f);
        // PLAY 그룹 오브젝트를 off

        videoManager.VideoPlay(isHappy);
        yield return new WaitForSeconds(1f);

        var newColor = isHappy ? Color.white : Color.black;
        fadeUI.GetComponent<FadeRoutine>().OnFade(3f, newColor, false);
        
        yield return new WaitForSeconds(3f);
        fadeUI.SetActive(false);
        gameOverUI.SetActive(false);
        playUI.SetActive(false);
        soundManager.audioSource.Stop();
        transform.parent.gameObject.SetActive(false); // PLAY 오브젝트 off

        Debug.Log("음소거");
    }
}
