using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Monster : MonoBehaviour
{
    public SpawnManager spawner;
    
    public SpriteRenderer sRenderer;
    private Animator monsterAnim;
    protected float hp = 3f;
    protected float moveSpeed = 3f;
    public int dir = 1;
    private bool isMove = true;
    private bool isHit = false;

    public abstract void Init();

    private void Start()
    {
        spawner = FindFirstObjectByType<SpawnManager>();
        sRenderer = GetComponent<SpriteRenderer>();
        monsterAnim = GetComponent<Animator>();
        Init();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (isMove)
        {
            transform.position += Vector3.right * dir * moveSpeed * Time.deltaTime;

            if (transform.position.x > 8f)
            {
                dir = -1;
                sRenderer.flipX = true;
            }
            else if (transform.position.x < -8f)
            {
                dir = 1;
                sRenderer.flipX = false;
            }
        }
    }
    private void OnMouseDown()
    {
        StartCoroutine(Hit(1));
    }
    IEnumerator Hit(float damage)
    {
        if (isHit)
        {
            yield break;
        }
        isHit = true;
        isMove = false;
        monsterAnim.SetTrigger("Hit");
        hp -= damage;


        if(hp <= 0)
        {
            monsterAnim.SetTrigger("Death");
            spawner.DropCoin(transform.position);

            yield return new WaitForSeconds(3f);
            Destroy(gameObject);
            
            yield break;
        }

        yield return new WaitForSeconds(0.65f);
        
        isHit = false;
        isMove = true;
    }

    public virtual void Attack()
    {

    }
}
