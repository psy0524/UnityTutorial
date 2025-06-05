using UnityEngine;

public class WhileLoop : MonoBehaviour
{
    private int count = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        while (count <= 10)
        {
            if(count % 3 == 0) // 나머지 연산 3의 배수
            {
                Debug.Log("박수 짝!");
                count++;
                continue;
            }

            Debug.Log(count);
        }
    }

}
