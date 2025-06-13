using UnityEngine;

public class Study_Casting : MonoBehaviour
{
    int number1 = 1;
    float number2 = 10f;

    private void Start()
    {
        number1 = (int)number2;
        Debug.Log(number1);
    }
}
