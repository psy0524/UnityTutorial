using UnityEngine;

public class StudyLog : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Start �Լ� ����"); // Console.Write(����Ƽ ����)
        Debug.LogWarning("Start �Լ� ����"); // ��� �α�
        Debug.LogError("Start �Լ� ����"); // ���� �α�
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Update �Լ� ����");
    }
}