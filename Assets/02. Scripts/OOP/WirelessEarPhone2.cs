using UnityEngine;

public class WirelessEarPhone2 : EarPhone
{
    public float batterySize;
    public bool isNoiseCancelling;

    public virtual void NoiseCancelling()
    {
        string msg = isNoiseCancelling ? "노이즈 캔슬링 on" : "노이즈 캔슬링 off";
        Debug.Log(msg);
    }
}
