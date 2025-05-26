using UnityEngine;

public class StudyTransform : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float rotateSpeed = 70f;
    

    void Update()
    {
        // 월드 방향으로 이동하는 기능
        //transform.position += Vector3.forward * moveSpeed * Time.deltaTime;
        
        // 로컬 방향으로 이동하는 기능
        //transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

        // 월드 방향으로 회전
        //transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y + rotateSpeed * Time.deltaTime, transform.eulerAngles.z);
        
        float angle = transform.rotation.eulerAngles.y;
        float localX = transform.eulerAngles.x;
        float localZ = transform.eulerAngles.z;
        // 로컬 방향으로 회전
        //transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime ); // Space.Self 생략

        // 월드 방향으로 회전 2
        //transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime, Space.World);
        
        // 특정 위치의 주변을 회전
        //transform.RotateAround(Vector3.zero, Vector3.up, rotateSpeed * Time.deltaTime);
        //                      new Vector3(0, 0, 0) 이런식으로도 가능

        // 특정 위치를 바라보면 회전
        transform.LookAt(Vector3.zero);
    }
}
