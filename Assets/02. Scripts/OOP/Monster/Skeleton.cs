using UnityEngine;

public class Skeleton : Monster
{
    public override void Init()
    {
        hp = 5f;
        moveSpeed = 1f;
    }

    public override void Attack()
    {
        base.Attack();
    }
}
