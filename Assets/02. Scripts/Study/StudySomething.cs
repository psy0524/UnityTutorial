using UnityEngine;

public class StudySomething : MonoBehaviour
{
    public int currentLevel = 10;

    public int maxLevel = 99;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //비교 연산에 의한 결과를 bool 값으로 받는 코드
        bool isMaxLevel = currentLevel >= maxLevel;

        Debug.Log($"현재 레벨은 만렙이 {isMaxLevel}입니다.");
    }

}
