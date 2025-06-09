using UnityEngine;

public class Study_Invoke : MonoBehaviour
{

    public int count = 10;
    public float timer = 5f;
    private void Start()
    {
        InvokeRepeating("Method1", timer, 1f);

        //CancelInvoke("Method1");
    }

    private void Method1()
    {
        Debug.Log($"현재 남은 시간 : {count}");
        count--;

        if(count == 0)
        {
            Debug.Log("폭탄이 터졌습니다.");
            CancelInvoke("Method1");
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CancelInvoke("Method1");
            Debug.Log("폭탄이 해제되었습니다.");
        }
    }
}
