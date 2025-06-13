using UnityEngine;

public class Study_Generic : MonoBehaviour
{
    //private void Start()
    //{
    //    Factory<Monster> factory = new Factory<Monster>();
    //}

    public void CreateAccount(string name)
    {
        int dummyAge = 20;
        CreateAccount(name, dummyAge);
    }
    public void CreateAccount(string name, int age)
    {
        string dummyPhoneNumber = "01012345678";
        CreateAccount(name, age, dummyPhoneNumber);
    }
    public void CreateAccount(string name, int age, string phoneNumber)
    {
        string dummyEmail = "HelloUnity@unity.com";
        CreateAccount(name, age, phoneNumber, dummyEmail);
    }
    public void CreateAccount(string name, int age, string phoneNumber, string eMail)
    {
        // 계정 생성
    }
    
}
