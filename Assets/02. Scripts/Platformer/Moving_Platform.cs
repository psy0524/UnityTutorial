using UnityEngine;

public class Moving_Platform : MonoBehaviour
{
    public float theta;
    public float power = 0.1f;
    public float speed = 1f;

    private Vector3 initPos;

    private void Start()
    {
        initPos = transform.position;
    }

    private void Update()
    {
        theta += Time.deltaTime * speed;
        transform.position = new Vector3(initPos.x + power * Mathf.Sin(theta), initPos.y, initPos.z);
    }

    private void OnCollisionEnter2D(Collision2D collision) // 나이트가 움직이는 발판에 닿았을 때 발판의 자식으로 넣어줘서 같이 움직이는 기능
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }
}
