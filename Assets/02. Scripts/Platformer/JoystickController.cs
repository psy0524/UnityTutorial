using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickController : MonoBehaviour, IPointerDownHandler,IDragHandler, IPointerUpHandler
{
    [SerializeField] private GameObject backgroundUI; // 큰 원
    [SerializeField] private GameObject handlerUI; // 작은 원
    [SerializeField] private KnightController_Joystick knightController_Joystick;

    private Vector2 startPos, currPos;
    
    void Start()
    {
        backgroundUI.SetActive(false);
    }

    public void OnDrag(PointerEventData eventData)
    {
        currPos = eventData.position;
        Vector2 dragDir = currPos - startPos;

        float maxDist = Mathf.Min(dragDir.magnitude, 100f);

        handlerUI.transform.position = startPos + dragDir.normalized * maxDist;
        knightController_Joystick.InputJoystick(dragDir.x, dragDir.y);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        backgroundUI.SetActive(true);
        backgroundUI.transform.position = eventData.position;
        
        startPos = eventData.position;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        
        handlerUI.transform.localPosition = Vector2.zero;
        backgroundUI.SetActive(false);
        knightController_Joystick.InputJoystick(0, 0);
    }
}
