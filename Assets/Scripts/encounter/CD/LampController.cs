using Microwise.Guide;
using UnityEngine;

public class LampController : MonoBehaviour {
    void Update()
    {
        if (DeviceSettings.isLampBurning)
        {
            GetComponent<Light>().intensity = 3;
        }
        else
        {
            GetComponent<Light>().intensity = 0;
        }
    }
}
