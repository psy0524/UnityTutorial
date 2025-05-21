using DevA;
using UnityEngine;

public class StudyComponent : MonoBehaviour
{
    GameObject obj; // 큐브 게임오브젝트를 가져오고 싶다.

    public string changeName;

    void Start()
    {
        obj = GameObject.Find("Main Camera"); // Main Camera 오브젝트를 찾아서 할당하는 기능

        obj.name = changeName;
    }
}
