using UnityEngine;

public class TownPerson : MonoBehaviour, IMove, ITalk
{
    public float hp;
    public float speed;

    public void Move()
    {
        Debug.Log("Move");
    }

    public void Talk()
    {
        Debug.Log("Talk");
    }
}