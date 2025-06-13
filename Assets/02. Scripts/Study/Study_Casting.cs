using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Study_Casting : MonoBehaviour
{
    public List<int> intList = new List<int>();
    public List<GameObject> GameObjectList = new List<GameObject>();
    public List<Vector3> vector3s = new List<Vector3>();
    public List<bool> boolList = new List<bool>();
    public List<string> stringList = new List<string>();

    private void Start()
    {
        Monster m = new Orc();
        //Orc o1 = m;
        //Orc o = (Orc)m;

        Orc o = m as Orc; // 성공시 형변환 // 실패시 null 반환

        Debug.Log(o);

        if (o != null)
        {
            Debug.Log (o);
        }
        else
        {
            Debug.Log("형변환 되지 않음");
        }
    }
}
