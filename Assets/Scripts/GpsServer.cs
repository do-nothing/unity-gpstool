using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class GpsServer : MonoBehaviour {

    public enum Status { IDLE, NOD, SHAKE };

    private Text text;
    private bool isStarted = false;
    private LocationInfo info;

    private DateTime dateTime;
    private Vector3 horizontal;

    private const int R = 6371000;
    private Vector2 olal = new Vector2(108.856127f, 34.196107f);
    private Vector2 origin = new Vector2(300, 65);

    private Vector3 lastAcceleration;
    private Status status = Status.IDLE;
    private float markTime;

    IEnumerator Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        text = GameObject.Find("Canvas/Text").GetComponent<Text>();
        yield return startGPS();
	}
	
	void Update () {
        Vector3 delta = Input.acceleration - lastAcceleration;

        Vector2 maxAcc= new Vector2(Mathf.Abs(delta.x), Mathf.Abs(delta.y));

        if (Mathf.Max(maxAcc.x, maxAcc.y) > 0.5f)
        {
            if (maxAcc.x > maxAcc.y)
            {
                status = Status.SHAKE;
            }
            else
            {
                status = Status.NOD;
            }

            markTime = Time.time;
        }
        else
        {
            if (Time.time - markTime > 1.1f)
                status = Status.IDLE;
        }

        lastAcceleration = Input.acceleration;

        printLocationInfo();
	}

    private void printLocationInfo()
    {
        if (isStarted)
        {
            StringBuilder stringBuilder = new StringBuilder("timestamp:" + info.timestamp);
            stringBuilder.Append("\nlongitude:" + info.longitude);
            stringBuilder.Append("\nlatitude:" + info.latitude);
            stringBuilder.Append("\nhorizontalAccuracy:" + info.horizontalAccuracy);
            stringBuilder.Append("\naltitude:" + info.altitude);
            stringBuilder.Append("\nverticalAccuracy:" + info.verticalAccuracy);

            stringBuilder.Append("\n");
            stringBuilder.Append("\ntime:" + dateTime);
            stringBuilder.Append("\nhorizontal:" + horizontal);
            stringBuilder.Append("\nsystemTime:" + Time.time);

            stringBuilder.Append("\n");
            stringBuilder.Append("\nstatus:" + status);

            text.text = stringBuilder.ToString();
        }
    }

    private DateTime getTime(long timeStamp)
    {
        DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
        long lTime = timeStamp * 10000000;
        TimeSpan toNow = new TimeSpan(lTime); 
        return dtStart.Add(toNow);
    }

    private Vector2 getPositionFromLaL(Vector2 lal)
    {
        Vector2 p = Vector2.zero;
        Vector2 ra = calcRAfromLaL(olal, lal);
        float a = Mathf.PI / 2 - ra.y;
        p.x = ra.x * Mathf.Cos(a);
        p.y = ra.x * Mathf.Sin(a);
        p += origin;

        return p ;
    }

    private Vector2 calcRAfromLaL(Vector2 o, Vector2 t)
    {
        Vector2 ra = Vector2.zero;

        double cosc = sin(o.y) * sin(t.y) + cos(o.y) * cos(t.y) * cos(t.x - o.x);
        ra.x = (float)(Math.Acos(cosc) * R);

        double sinc = Math.Sqrt(1 - cosc * cosc);
        double sinA = sinc == 0 ? 1 : cos(t.y) * sin(t.x - o.x) / sinc;
        sinA = (float)Mathf.Clamp((float)sinA, -1, 1);
        double A = Math.Asin(sinA);
        double dx, dy;
        dx = t.x - o.x;
        dy = t.y - o.y;
        if (dy > 0 && dx < 0)
        {
            A += 2 * Mathf.PI;
        }
        else if (dy < 0)
        {
            A = Mathf.PI - A;
        }

        ra.y = (float)A;
        return ra;
    }

    private double sin(double a)
    {
        a = a / 180 * Math.PI;
        return Math.Sin(a);
    }

    private double cos(double a)
    {
        a = a / 180 * Math.PI;
        return Math.Cos(a);
    }

    private IEnumerator startGPS()
    {
        if (!Input.location.isEnabledByUser)
        {
            print("Input location is not Enabled");
            text.text = "Input location is not Enabled";
            yield break;
        }

        Input.location.Start(0.3f, 0.3f);

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
                horizontal = getHorizontal(info);
                dateTime = getTime((long)info.timestamp);
                yield return new WaitForSeconds(1);
            }
        }
    }

    private Vector3 getHorizontal(LocationInfo info)
    {
        Vector2 lal = new Vector2(info.longitude, info.latitude);
        Vector2 position = getPositionFromLaL(lal);
        Vector3 horizontal = new Vector3(position.x, position.y, info.horizontalAccuracy);
        return horizontal;
    }

    public Vector3 getHorizontal()
    {
        return horizontal;
    }
}
