using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;


public class StudyArray : MonoBehaviour
{
    //public int[] arrayNumber = new int[5] { 1, 2, 3, 4, 5 };
    //List<int> listNumber = new List<int>();

    int number1 = 1;
    private int number2 = 2;
    public int number3 = 3;

    [SerializeField] private int number4 = 4;

    [SerializeField] int number5 = 5;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        /*Debug.Log($"���� �迭 Array�� ù��° �� : {arrayNumber[0]}");
        Debug.Log($"���� �迭 Array�� ����° �� : {arrayNumber[2]}");
        Debug.Log($"���� �迭 Array�� ������° �� : {arrayNumber[5]}");*/ //�迭�� �ε��� ����
        //listNumber.Add(1);
        //listNumber.Add(2);
        //listNumber.Add(3);
        //listNumber.Add(4);
        //listNumber.Add(5);

        //Debug.Log($"���� List�� �ִ� ������ �� : {listNumber.Count}");
        //Debug.Log($"���� List�� �ִ� ������ �ڸ��� �ִ� �� : {listNumber[listNumber.Count - 1]}");
    }

}
