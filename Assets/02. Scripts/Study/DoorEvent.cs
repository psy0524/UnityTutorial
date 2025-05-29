using System.Runtime.CompilerServices;
using UnityEngine;

public class DoorEvent : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        animator.SetTrigger("Open");
    }

    private void OnTriggerExit(Collider other)
    {
        animator.SetTrigger("Close");
    }

}
