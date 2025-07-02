using UnityEngine;
using UnityEngine.UI;

public abstract class MonsterCore : MonoBehaviour, IDamageable
{
    public enum MonsterState { Idle, Patrol, Trace, Attack}
    public MonsterState monsterState = MonsterState.Idle;
    public ItemManager itemManager;

    public Animator animator;
    public Rigidbody2D goblinRb;
    protected Collider2D monsterColl;
    public Transform target;
    public Image hpBar;

    public float hp;
    public float currHp;
    
    public float speed;
    protected float moveDir;
    protected bool isTrace;
    public float attackTime;
    public float atkDamage;
    private bool isDead;

    protected float targetDist;

    protected virtual void Init(float hp, float speed, float attackTime, float atkDamage)
    {
        this.hp = hp;
        this.speed = speed;
        this.attackTime = attackTime;
        this.atkDamage = atkDamage;

        itemManager = FindFirstObjectByType<ItemManager>();
        target = GameObject.FindGameObjectWithTag("Player").transform; // 태그로 찾기 (이게 더 빠름)
        //target = FindFirstObjectByType<KnightController_Keyboard>().transform; // 컴포넌트로 찾기

        animator = GetComponent<Animator>();
        goblinRb = GetComponent<Rigidbody2D>();
        monsterColl = GetComponent<Collider2D>();

        currHp = hp;
        hpBar.fillAmount = currHp / hp;
    }

    private void Update()
    {
        if (isDead) return;
        
        switch (monsterState)
        {
            case MonsterState.Idle:
                Idle();
                break;
            case MonsterState.Patrol:
                Patrol();
                break;
            case MonsterState.Trace:
                Trace();
                break;
            case MonsterState.Attack:
                Attack();
                break;

        }
    }

    public abstract void Idle();
    public abstract void Patrol();
    public abstract void Trace();
    public abstract void Attack();

    public void ChangeState(MonsterState newState)
    {
        if(monsterState != newState)
        {
            monsterState = newState;
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Return"))
        {
            moveDir *= -1;
            transform.localScale = new Vector3(moveDir, 1, 1);
            Debug.Log("돌아가기");
        }
        if (collision.GetComponent<IDamageable>() != null)
        {
            collision.GetComponent<IDamageable>().TakeDamage(atkDamage);
        }
    }

    public void TakeDamage(float damage)
    {
        currHp -= damage;
        hpBar.fillAmount = currHp / hp; // 현재 체력 / 최대체력 fillAmount 값은 0~1 사이 이므로 백분율을 통해서 계산
        if (currHp <= 0f)
        {
            Death();
        }
    }

    public void Death()
    {
        isDead = true;
        animator.SetTrigger("Death");
        monsterColl.enabled = false;
        goblinRb.gravityScale = 0f;
        goblinRb.linearVelocity = Vector2.zero;
        itemManager.DropItem(transform.position); // transform.position 드롭위치(고블린이 죽은 위치)
    }
}
