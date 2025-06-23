using UnityEngine;

public class MathLight : MonoBehaviour
{
    private Light light;
    private float theta;
    [SerializeField] private float power, speed;

    private void Start()
    {
        light = GetComponent<Light>();
    }

    private void Update()
    {
        theta += Time.deltaTime * speed;
        //light.intensity = Mathf.Sin(theta) * power; // 단순한 삼각함수 그래프

        light.intensity = Mathf.PerlinNoise(theta, 0) * power;
    }
}
