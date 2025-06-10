using UnityEngine;

public class ItemEvent : MonoBehaviour
{
    public enum ColliderType { Pipe, Apple, Both}
    public ColliderType colliderType;
    
    public GameObject pipe;
    public GameObject apple;
    public GameObject particle;
    
    public float moveSpeed = 2.5f;

    public float returnPosX = 15f;

    public float randomPosY;

    private void Start()
    {
        SetRandomSetting(transform.position.x);
    }

    void Update()
    {
        // 배경 왼쪽으로 이동하는 기능
        transform.position += Vector3.left * moveSpeed * Time.fixedDeltaTime;

        if (transform.position.x <= -returnPosX) // 이미지의 x축 값이 returnPos을 넘는 순간
        {
            SetRandomSetting(returnPosX);
            //randomPosY = Random.Range(-8f, -3f);
            //transform.position = new Vector3(returnPosX, randomPosY, 0);
        }
    }

    private void SetRandomSetting(float posX)
    {
        randomPosY = Random.Range(-8f, -2.5f);
        transform.position = new Vector3(posX, randomPosY, 0);

        pipe.SetActive(false);
        apple.SetActive(false);
        particle.SetActive(false);
        
        colliderType = (ColliderType)Random.Range(0, 3);

        switch(colliderType)
        {
            case ColliderType.Pipe:
                pipe.SetActive(true);
                break;
            case ColliderType.Apple:
                apple.SetActive(true);
                break;

            case ColliderType.Both:
                pipe.SetActive(true);
                apple.SetActive(true);
                break;
        }
    }
}
