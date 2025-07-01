using System.Collections;
using UnityEngine;

public class Goblin : MonsterCore
{
    private float timer = 3f;
    private float patrolTime , idleTime;
    private float traceDist = 5f;
    private float attackDist = 1f;
    private bool isAttack;
    

    private void Start()
    {
        Init(10f, 5f, 2f);

        //StartCoroutine(FindPlayerRoutine());
    }

    protected override void Init(float hp, float speed, float attackTIme)
    {
        base.Init(hp, speed, attackTime);
    }

    public override void Idle()
    {
        timer += Time.deltaTime;
        if(timer >= idleTime)
        {
            timer = 0f;
            moveDir = Random.Range(0, 2) == 1 ? 1 : -1;
            transform.localScale = new Vector3(moveDir, 1, 1);
            patrolTime = Random.Range(1f, 5f);
            animator.SetBool("isRun", true);



            ChangeState(MonsterState.Patrol);
        }

        if(targetDist <= traceDist && isTrace)
        {
            
            timer = 0f;
            animator.SetBool("isRun", true);
            ChangeState(MonsterState.Trace);
        }
    }

    public override void Patrol()
    {
        timer += Time.deltaTime;
        
        transform.position += Vector3.right * moveDir * speed * Time.deltaTime;

        if (timer >= patrolTime)
        {
            timer = 0f;
            idleTime = Random.Range(1f, 5f);

            animator.SetBool("isRun", false);

            ChangeState(MonsterState.Idle);
        }
        if (targetDist <= traceDist && isTrace)
        {
            timer = 0f;
            ChangeState(MonsterState.Trace);
        }
    }
    public override void Trace()
    {
        var targetDir = (target.position - transform.position).normalized;

        transform.position += Vector3.right * targetDir.x * speed * Time.deltaTime;

        var scaleX = targetDir.x > 0 ? 1 : -1;
        transform.localScale = new Vector3(scaleX, 1, 1);
        if (targetDist > traceDist)
        {
            ChangeState(MonsterState.Idle);
        }
        if (targetDist < attackDist)
        {
            ChangeState(MonsterState.Attack);
        }
    }
    public override void Attack()
    {
        if (!isAttack)
        {
            StartCoroutine(AttackRoutine());
        }
    }

    IEnumerator AttackRoutine()
    {
        isAttack = true;
        animator.SetTrigger("Attack");
        yield return new WaitForSeconds(1f);
        animator.SetBool("isRun", false);

        yield return new WaitForSeconds(attackTime - 1f);

        isAttack = false;
        ChangeState(MonsterState.Idle);
    }

}
