using DevA;
using UnityEngine;

public class StudyComponent : MonoBehaviour
{
    GameObject obj; // ť�� ���ӿ�����Ʈ�� �������� �ʹ�.

    public string changeName;

    void Start()
    {
        obj = GameObject.Find("Main Camera"); // Main Camera ������Ʈ�� ã�Ƽ� �Ҵ��ϴ� ���

        obj.name = changeName;
    }
}
