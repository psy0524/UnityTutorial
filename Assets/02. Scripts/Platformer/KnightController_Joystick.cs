using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.UI;

public class KnightController_Joystick : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D knightRb;
    private Vector3 inputDir;
    [SerializeField] private Button jumpButton;
    [SerializeField] private Button attackButton;

    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpPower = 13f;
    [SerializeField] private float attackDamage = 3f;
    private bool isGround;
    private bool isAttack;
    private bool isCombo;

    private void Start()
    {
        animator = GetComponent<Animator>();
        knightRb = GetComponent<Rigidbody2D>();
        jumpButton.onClick.AddListener(Jump);
        attackButton.onClick.AddListener(SwordAttack);
    }

    void Update() // 일반적인 작업
    {
        
    }

    private void FixedUpdate() // 물리적인 작업
    {
        Move();
    }

    //private void InputKeyboard()
    //{
    //    float h = Input.GetAxisRaw("Horizontal");
    //    float v = Input.GetAxisRaw("Vertical");

    //    inputDir = new Vector3(h, v, 0).normalized;

    //    Jump();
    //    SetAnimation();
    //}

    private void Move()
    {
        if(isAttack) { return; }
        if (inputDir.x != 0)
        {
            knightRb.linearVelocityX = inputDir.x * moveSpeed;
        }
    }

    public void InputJoystick(float x, float y)
    {
        inputDir = new Vector3(x, y, 0).normalized;
        animator.SetFloat("JoystickX", inputDir.x);
        animator.SetFloat("JoystickY", inputDir.y);
        if(isAttack) {return;}
        if (inputDir.x != 0)
        {
            var scaleX = inputDir.x > 0 ? 1 : -1;
            transform.localScale = new Vector3(scaleX, 1, 1);
        }
    }
    void Jump()
    {
        if (isGround)
        {
            animator.SetTrigger("Jump");
            knightRb.AddForceY(jumpPower, ForceMode2D.Impulse);
        }
    }

    void SwordAttack()
    {
        if (!isAttack)
        {
            isAttack = true;
            attackDamage = 3f;
            Debug.Log("3데미지");
            animator.SetTrigger("Attack");
        }
        else
        {
            isCombo = true;
            Debug.Log("콤보 확인");
        }
    }

    public void CheckCombo()
    {
        Debug.Log("콤보");
        if (isCombo)
        {
            attackDamage = 5f;
            Debug.Log("5데미지");
            animator.SetBool("isCombo", true);
        }
        else
        {
            animator.SetBool("isCombo", false);
            isAttack = false;
        }
    }
    
    public void EndCombo()
    {
        isAttack = false;
        isCombo = false;
        animator.SetBool("isCombo", false);
    }

    //void SetAnimation()
    //{
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
    }
}
