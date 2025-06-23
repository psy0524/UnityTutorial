using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private GameObject hitBoxAttack;
    [SerializeField] private float moveSpeed = 5f;
    private float h, v;
    private bool isAttack = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Move();
        Attack();
    }

    void Move()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        if(h == 0 && v == 0) // 움직이지 않는 상태 -> 키 입력X
        {
            animator.SetBool("Run", false);
        }
        else // 어떠한 키 하나라도 누른 상태 -> 이동 상태
        {
            int scaleX = h > 0 ? 1 : -1;
            transform.localScale = new Vector3(scaleX, 1, 1);
                animator.SetBool("Run", true);
            var dir = new Vector3(h, v, 0).normalized;

            transform.position += dir * moveSpeed * Time.deltaTime;
        }
    }

    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isAttack)
        {
            StartCoroutine(AttackRoutine());
        }
    }



    IEnumerator AttackRoutine()
    {
        isAttack = true;
        hitBoxAttack.SetActive(true);

        yield return new WaitForSeconds(0.25f);
        hitBoxAttack.SetActive(false);
        isAttack = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<Monster>() != null)
        {
            Monster monster = other.GetComponent<Monster>();
            StartCoroutine(monster.Hit(1));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<IItem>() != null)
        {
            IItem item = collision.gameObject.GetComponent<IItem>();
            item.Get();
        }
    }
}


