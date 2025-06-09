using UnityEngine;

public class Study_Random : MonoBehaviour
{
    private void OnEnable()
    {
        float ranNumber = Random.Range(0f, 100f);

        Debug.Log(ranNumber);
    }
}
