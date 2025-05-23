using UnityEngine;

public class StudyLog : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Start 함수 실행"); // Console.Write(유니티 버전)
        Debug.LogWarning("Start 함수 실행"); // 경고 로그
        Debug.LogError("Start 함수 실행"); // 에러 로그
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Update 함수 실행");
    }
}