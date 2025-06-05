using UnityEngine;

public class DoorEvent2 : MonoBehaviour
{
    private Animator door2Animator;

    public GameObject doorLock;

    public string openKey;
    public string closeKey;

    private void Start()
    {
        door2Animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            doorLock.SetActive(true);
            //door2Animator.SetTrigger(openKey);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            doorLock.SetActive(false);
            //door2Animator.SetTrigger(closeKey);
        }
    }
}
