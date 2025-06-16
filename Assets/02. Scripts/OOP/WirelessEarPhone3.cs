using UnityEngine;

public class WirelessEarPhone3 : WirelessEarPhone2
{
    public enum NoiseCancelType { Off, On, Around}
    public NoiseCancelType noiseCancelType;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void SetNoiseCancelType(NoiseCancelType type)
    {
        noiseCancelType = type;
    }
    
    public override void NoiseCancelling()
    {
        SetNoiseCancelType(noiseCancelType);
        base.NoiseCancelling();
    }
}
