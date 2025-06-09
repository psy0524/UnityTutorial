using UnityEngine;

public class Transform_LoopMap : MonoBehaviour
{
    public float moveSpeed = 2.5f;

    public float returnPosX = 15f;

    public float randomPosY;
    // Update is called once per frame
    void Update()
    {
        // 배경 왼쪽으로 이동하는 기능
        transform.position += Vector3.left * moveSpeed * Time.fixedDeltaTime;

        if(transform.position.x <= -returnPosX) // 이미지의 x축 값이 returnPos을 넘는 순간
        {
            randomPosY = Random.Range(-8, -3);
            transform.position = new Vector3(returnPosX, randomPosY, 0);
        }
    }
}
