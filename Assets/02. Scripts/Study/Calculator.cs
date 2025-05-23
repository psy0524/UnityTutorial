using UnityEngine;

public class Calculator : MonoBehaviour
{
    public int number1;
    public int number2;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int addResult = AddMethod(); // 함수 호출

        int minusResult = MinusMethod(); // 함수 호출

        Debug.Log($"더한 값 : {addResult} / 뺀 값 : {minusResult}");
    }

    int AddMethod()
    {
        int result = number1 + number2;
        return result;
    }

    int MinusMethod()
    {
        int result = number1 - number2;
        return result;
    }
}
