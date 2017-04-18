using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GpsServer : MonoBehaviour {

    private Text text;
    private bool isStarted = false;
    IEnumerator Start()
    {
        text = GameObject.Find("Canvas/Text").GetComponent<Text>();
        yield return startGPS();
	}
	
	void Update () {
        if (!isStarted)
            return;
        text.text = "timestamp:" + Input.location.lastData.timestamp;
        text.text += "\nlongitude:" + Input.location.lastData.longitude;
        text.text += "\nlatitude:" + Input.location.lastData.latitude;
        text.text += "\nhorizontalAccuracy:" + Input.location.lastData.horizontalAccuracy;
        text.text += "\naltitude:" + Input.location.lastData.altitude;
        text.text += "\nverticalAccuracy:" + Input.location.lastData.verticalAccuracy;
	}

    private IEnumerator startGPS()
    {
        if (!Input.location.isEnabledByUser)
        {
            print("Input location is not Enabled");
            text.text = "Input location is not Enabled";
            yield break;
        }
        Input.compass.enabled = true;
        Input.location.Start();

        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        if (maxWait < 1)
        {
            print("Timed out");
            text.text = "Timed out";
            yield break;
        }

        if (Input.location.status == LocationServiceStatus.Failed)
        {
            print("Unable to determine device location");
            text.text = "Unable to determine device location";
            yield break;
        }
        else
        {
            print("Device location server started");
            text.text = "Device location server started";
            text.color = Color.black;
            isStarted = true;
        }
    }
}
