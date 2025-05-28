using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public float moveSpeed = 3f;

    public Rigidbody2D carRb;

    private float h;
    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxis("Horizontal");

        //Transform 이동
        //transform.position += Vector3.right * h * moveSpeed * Time.deltaTime;

    }

    private void FixedUpdate()
    {
       
        //RigidBody 속도를 활용한 이동
        carRb.linearVelocityX = h * moveSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision) // 충돌하는 순간 1번 실행 (GetKeyDown이랑 비슷함)
    {
        Debug.Log("Collision Enter");
    }
    
    private void OnCollisionStay2D(Collision2D collision) // 충돌중일 경우 계속 실행 (GetKey랑 비슷함)
    {
        Debug.Log("Collision Stay");
    }
    
    private void OnCollisionExit2D(Collision2D collision) // 충돌에서 벗어났을 때 1번 실행 (GetKeyUP이랑 비슷함)
    {
        Debug.Log("Collision Exit");
    }
    private void OnTriggerEnter2D(Collider2D collision) // 충돌에서 벗어났을 때 1번 실행 (GetKeyUP이랑 비슷함)
    {
        Debug.Log("Trigger Enter");
    }

    private void OnTriggerStay2D(Collider2D collision) // 충돌에서 벗어났을 때 1번 실행 (GetKeyUP이랑 비슷함)
    {
        Debug.Log("Trigger Stay");
    }

    private void OnTriggerExit2D(Collider2D collision) // 충돌에서 벗어났을 때 1번 실행 (GetKeyUP이랑 비슷함)
    {
        Debug.Log("Trigger Exit");
    }
}
