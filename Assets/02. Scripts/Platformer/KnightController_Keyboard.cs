using UnityEngine;

public class KnightController_Keyboard : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D knightRb;
    private Vector3 inputDir;

    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float jumpPower = 13f;
    [SerializeField] private float attackDamage = 3f;

    private bool isGround;
    private bool isAttack;
    private bool isCombo;
    private bool isLadder;

    private void Start()
    {
        animator = GetComponent<Animator>();
        knightRb = GetComponent<Rigidbody2D>();
    }

    void Update() // 일반적인 작업
    {
        InputKeyboard();
        SwordAttack();
        Jump();
    }

    private void FixedUpdate() // 물리적인 작업
    {
        Move();
    }

    private void InputKeyboard()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        inputDir = new Vector3(h, v, 0).normalized;
        animator.SetFloat("JoystickX", inputDir.x);
        animator.SetFloat("JoystickY", inputDir.y);

        if (inputDir.y < 0)
        {
            GetComponent<CapsuleCollider2D>().size = new Vector2(1.05f, 0.525f);
        }
        else
        {
            GetComponent<CapsuleCollider2D>().size = new Vector2(1.05f, 1.05f);
        }
        //Jump();
        //SetAnimation();
        //SwordAttack();
    }

    private void Move()
    {
        if (inputDir.x != 0)
        {
            if (!isAttack)
            {
                var scaleX = inputDir.x > 0 ? 1 : -1;
                transform.localScale = new Vector3(scaleX, 1, 1);
                knightRb.linearVelocityX = inputDir.x * moveSpeed;
            }
            else { return; }
        }
        if (isLadder && inputDir.y != 0)
        {
            knightRb.linearVelocityY = inputDir.y * moveSpeed;
        }
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            animator.SetTrigger("Jump");
            knightRb.AddForceY(jumpPower, ForceMode2D.Impulse);
        }
    }

    //void SetAnimation()
    //{
    //    if (isAttack) { return;}
    //    if (inputDir.x != 0)
    //    {
    //        animator.SetBool("isRun", true);
    //        var scaleX = inputDir.x > 0 ? 1 : -1;
    //        transform.localScale = new Vector3(scaleX, 1, 1);
    //    }
    //    else if (inputDir.x == 0)
    //    {
    //        animator.SetBool("isRun", false);

    //    }
    //}

    void SwordAttack()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (!isAttack)
            {
                isAttack = true;
                animator.SetTrigger("Attack");
                Debug.Log("3데미지");
            }
            else
            {
                isCombo = true;
                Debug.Log("콤보 시작");
            }
        }
        
    }

    public void CheckCombo()
    {
        
        if (isCombo)
        {
            Debug.Log("콤보 동작중");
            animator.SetBool("isCombo", true);
            Debug.Log("5데미지"); 
        }
        else
        {
            animator.SetBool("isCombo", false);
            isAttack = false;
        }
        isCombo = false;
    }

    public void EndCombo()
    {
        Debug.Log("EngCombo 시작");
        isAttack = false;
        isCombo = false;
        animator.SetBool("isCombo", false);
        Debug.Log("EngCombo 종료");
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            animator.SetBool("isGround", true);
            isGround = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            animator.SetBool("isGround", false);
            isGround = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster"))
        {
            Debug.Log("공격");
        }

        if (collision.CompareTag("Ladder"))
        {
            isLadder = true;
            knightRb.gravityScale = 0f;
            knightRb.linearVelocity = Vector2.zero;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isLadder = false;
            knightRb.gravityScale = 2f;
            knightRb.linearVelocity = Vector2.zero;
        }
    }
}
