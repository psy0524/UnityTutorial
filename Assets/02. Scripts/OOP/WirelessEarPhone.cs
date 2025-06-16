using UnityEngine;

public class WirelessEarPhone : EarPhone
{
    public float batterySize;
    public bool isWirelessCharged;

    private void Start()
    {
        name = "Airpod1";
        price = 100f;
        releaseYear = 2007;
        batterySize = 70f;
    }

    public void Charged()
    {
        if (isWirelessCharged)
        {
            Debug.Log("무선 충전");
        }
        else
        {
            Debug.Log("유선 충전");
        }
    }
}
