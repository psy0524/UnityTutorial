using UnityEngine;

public class Calculator : MonoBehaviour
{
    public int number1;
    public int number2;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int addResult = AddMethod(); // �Լ� ȣ��

        int minusResult = MinusMethod(); // �Լ� ȣ��

        Debug.Log($"���� �� : {addResult} / �� �� : {minusResult}");
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
