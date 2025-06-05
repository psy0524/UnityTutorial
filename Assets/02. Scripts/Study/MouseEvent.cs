using UnityEngine;

public class MouseEvent : MonoBehaviour
{
    void Update()
    {
        //MouseClickEvent();
    }

    private void MouseClickEvent()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("마우스 다운");
        }
        if (Input.GetMouseButton(0))
        {
            Debug.Log("마우스");
        }
        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("마우스 업");
        }
    }
}
