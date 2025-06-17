using UnityEngine;

public class StudyProperty : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;

    private float moveSpeed2 = 10f;

    public float MoveSpeed2
    {
        get { return moveSpeed2; }
        set { moveSpeed2 = value; }
    }
}
