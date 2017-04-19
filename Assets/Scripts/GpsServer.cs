using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GpsServer : MonoBehaviour {

    private Text text;
    private bool isStarted = false;
    private LocationInfo info;

    public Vector3 horizontal;

    IEnumerator Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        text = GameObject.Find("Canvas/Text").GetComponent<Text>();
        yield return startGPS();
	}
	
	void Update () {
        if (true)
        {         
            text.text = "timestamp:" + info.timestamp;
            text.text += "\nlongitude:" + info.longitude;
            text.text += "\nlatitude:" + info.latitude;
            text.text += "\nhorizontalAccuracy:" + info.horizontalAccuracy;
            text.text += "\naltitude:" + info.altitude;
            text.text += "\nverticalAccuracy:" + info.verticalAccuracy;

            text.text += "\n";

            text.text += "\ntime:" + getTime((long)info.timestamp);
            text.text += "\nhorizontal:";
            text.text += "\nvertical:";
        }
	}

    private DateTime getTime(long timeStamp)
    {
        DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
        long lTime = timeStamp * 10000000;
        TimeSpan toNow = new TimeSpan(lTime); 
        return dtStart.Add(toNow);
    }  

    private IEnumerator startGPS()
    {
        if (!Input.location.isEnabledByUser)
        {
            print("Input location is not Enabled");
            text.text = "Input location is not Enabled";
            yield break;
        }

        Input.location.Start(1,1);

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
            while (true)
            {
                info = Input.location.lastData;
                yield return new WaitForSeconds(2);
            }
        }
    }
}
