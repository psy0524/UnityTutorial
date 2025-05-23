using UnityEngine;

public class PlanetRotation : MonoBehaviour
{
    public Transform targetPlanet;

    public float rotSpeed = 30f;

    public float revolutionSpeed = 100f;

    public bool isRevolution = false; // �� Ÿ�� -> true / false
    // Update is called once per frame
    void Update()
    {

        // �ڱ� �ڽ��� ȸ���ϴ� ���
        transform.Rotate(Vector3.up * rotSpeed * Time.deltaTime);


        if (isRevolution == true) // ���ǹ� -> ���� ������ �Ѵٸ�,
        {
            // �����ϴ� ���
            transform.RotateAround(targetPlanet.position, Vector3.up, revolutionSpeed * Time.deltaTime);
        }
    }
}
