using UnityEngine;

public class StudySwitch : MonoBehaviour
{
    public enum CalcultationType { PLUS, MINUS, MULTIPLY, DIVIDE } // 열거형 생성

    public CalcultationType calcultationType;

    public int  inputValue1, inputValue2, result;

    private void Start()
    {
        result = Calculation();
        Debug.Log($"계산 결과 : {Calculation()}");
    }

    private int Calculation()
    {
        

        switch (calcultationType)
        {
            case CalcultationType.PLUS:
                result = inputValue1 + inputValue2;
                break;
            case CalcultationType.MINUS:
                result = inputValue1 - inputValue2;
                break;
            case CalcultationType.MULTIPLY:
                result = inputValue1 * inputValue2;
                break;
            case CalcultationType.DIVIDE:
                result = inputValue1 / inputValue2;
                break;

        }

        return result;
    }
}
