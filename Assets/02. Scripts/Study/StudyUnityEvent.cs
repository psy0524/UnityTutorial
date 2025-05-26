using UnityEngine;

public class StudyUnityEvent : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        Debug.Log("Awake");
    }

    void Start()
    {
        Debug.Log("Start");
    }

    void OnEnable()
    {
        Debug.Log("OnEnable");
    }
    // Update is called once per frame
    private void OnDisable()
    {
        Debug.Log("OnDisable");
    }
    void Update()
    {
        
    }
}
