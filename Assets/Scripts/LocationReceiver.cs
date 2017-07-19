using LitJson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationReceiver : MonoBehaviour
{
    private ConnController conn = ConnController.instance;
    private Vector2 location;

	void Start () {
        conn.init();
        conn.addMessageListener(processMessage);
	}

    public Vector2 getLocation()
    {
        return location;
    }

    private void processMessage(JsonData json)
    {
        if (json["monitorId"] == null)
        {
            json["monitorId"] = "";
        }
        //Debug.Log(json.ToJson());
        if(json["contentBean"]["command"].ToString() == "placePlayer"){
            location.x = (float)(double)json["contentBean"]["args"][0];
            location.y = (float)(double)json["contentBean"]["args"][1];
        }
        //print(location);
    }
}
