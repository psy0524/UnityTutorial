using UnityEngine;

public class RouletteController : MonoBehaviour
{
    public float rotSpeed = 5f;
    public bool isStop;

    void Start()
    {
        rotSpeed = 0f;
    }

    void Update()
    {
        transform.Rotate(Vector3.forward * rotSpeed); // z축 기준으로 회전하는 기능

        //transform.Rotate(0f, 0f, rotSpeed);

        // Vector3.forward = new Vector3(0f, 0f, 1f)

        // 마우스 왼쪽 버튼을 눌렀을 때 회전하는 기능

        if (Input.GetMouseButtonDown(0))
        {
            rotSpeed = 5f;
        }

        
        // 키보드 스페이스 버튼을 눌렀을 때 -> 1번 실행
        if(Input.GetKeyDown(KeyCode.Space))
        {
            isStop = true;
        }

        if(isStop == true)
        {
            rotSpeed *= 0.98f;
            if (rotSpeed < 0.01f)
            {
                rotSpeed = 0f;
                isStop = false;
            }
        }
    }
}
