using UnityEngine;

public class ObjectMouseEvent : MonoBehaviour
{
    private void OnMouseDown()
    {
        Debug.Log("Mouse Down");
    }

    private void OnMouseUp()
    {
        Debug.Log("Mouse UP");
    }

    private void OnMouseEnter()
    {
        Debug.Log("Mouse Enter");
    }

    private void OnMouseExit()
    {
        Debug.Log("Mouse Exit");
    }

    private void OnMouseDrag()
    {
        Debug.Log("Mouse Drag");
        Debug.Log(Input.mousePosition);
    }

    private void OnMouseUpAsButton()
    {
        Debug.Log("Mouse UpAsButton");
    }

    private void OnMouseOver()
    {
        Debug.Log("Mouse Over");
    }
}
