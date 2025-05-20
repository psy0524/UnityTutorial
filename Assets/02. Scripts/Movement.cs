using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //this.transform.position = this.transform.position + Vector3.forward * moveSpeed;

        //transform.position += Vector3.forward * moveSpeed * Time.deltaTime;

        if (Input.GetKey(KeyCode.W)) // 앞으로 가는 기능
        {
            transform.position += Vector3.forward * moveSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A)) // 왼쪽으로 가는 기능
        {
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S)) // 뒤로 가는 기능
        {
            transform.position += Vector3.back * moveSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D)) // 오른쪽으로 가는 기능
        {
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;
        }
    }
}
