using UnityEngine;

public abstract class MonsterCore : MonoBehaviour
{
    public enum MonsterState { Idle, Patrol, Trace, Attack}
    public MonsterState monsterState = MonsterState.Idle;

    public Animator animator;
    public Rigidbody2D goblinRb;
    protected Collider2D monsterColl;
    public Transform target;


    public float hp;
    public float speed;
    protected float moveDir;
    protected bool isTrace;
    public float attackTime;

    protected float targetDist;

    protected virtual void Init(float hp, float speed, float attackTime)
    {
        this.hp = hp;
        this.speed = speed;
        this.attackTime = attackTime;

        target = GameObject.FindGameObjectWithTag("Player").transform; // 태그로 찾기 (이게 더 빠름)
        //target = FindFirstObjectByType<KnightController_Keyboard>().transform; // 컴포넌트로 찾기

        animator = GetComponent<Animator>();
        goblinRb = GetComponent<Rigidbody2D>();
        monsterColl = GetComponent<Collider2D>();
    }

    private void Update()
    {
        targetDist = Vector3.Distance(transform.position, target.position);

        Vector3 monsterDir = Vector3.right * moveDir;
        Vector3 playerDir = (transform.position - target.position).normalized;

        float dotValue = Vector3.Dot(monsterDir, playerDir);

        isTrace = dotValue < -0.5f && dotValue >= -1f;
        
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
    }
}
