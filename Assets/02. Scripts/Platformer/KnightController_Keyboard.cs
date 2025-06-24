using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class KnightController_Keyboard : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D knightRb;
    private Vector3 inputDir;

    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float jumpPower = 13f;
    private bool isGround;
    private bool isAttack;
    private bool isCombo;

    private void Start()
    {
        animator = GetComponent<Animator>();
        knightRb = GetComponent<Rigidbody2D>();
    }

    void Update() // 일반적인 작업
    {
        InputKeyboard();
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

        Jump();
        SetAnimation();
        SwordAttack();
    }

    private void Move()
    {
        if (inputDir.x != 0)
        {
            if (!isAttack)
            {
                knightRb.linearVelocityX = inputDir.x * moveSpeed;
            }
            else { return; }
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

    void SetAnimation()
    {
        if (inputDir.x != 0)
        {
            animator.SetBool("isRun", true);
            var scaleX = inputDir.x > 0 ? 1 : -1;
            transform.localScale = new Vector3(scaleX, 1, 1);
        }
        else if (inputDir.x == 0)
        {
            animator.SetBool("isRun", false);

        }
    }

    void SwordAttack()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (!isAttack)
            {
                isAttack = true;
                animator.SetTrigger("Attack");
            }
            else
            {
                isCombo = true;
                Debug.Log("콤보 확인");
            }
        }
        
    }

    public void CheckCombo()
    {
        Debug.Log("콤보");
        if (isCombo)
        {
            animator.SetBool("isCombo", true);
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
        isAttack = false;
        isCombo = false;
        animator.SetBool("isCombo", false);
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
}
