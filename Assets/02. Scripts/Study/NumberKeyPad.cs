using UnityEngine;

public class NumberKeyPad : MonoBehaviour
{
    public Animator doorAnim;
    public GameObject doorLock;
    
    public string password; // 비밀번호 설정
    public string keyPadNumber; // 입력한 숫자

    public void OnInputNumber(string numString)
    {
        keyPadNumber += numString;
    }

    public void OnCheckNumber()
    {
        if(keyPadNumber == password)
        {
            Debug.Log("비밀번호가 맞았습니다.");
            doorAnim.SetTrigger("Open");
            doorLock.SetActive(false);
            keyPadNumber = "";
        }
        else
        {
            keyPadNumber = "";
            Debug.Log("비밀번호가 틀렸습니다.");
        }
    }
}
