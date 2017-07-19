using LitJson;
using Microwise.Guide;
using Microwise.Guide.NetConn;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnController
{
    public static readonly ConnController instance = new ConnController();

    private ConnController()
    {

    }

    private Messenger messenger;

    public void init()
    {
        messenger = UdpMessenger.getInstance("121.42.196.133", 5555);
        messenger.addMessageListener(messageHandler);
    }

    public void close()
    {
        messenger.destroy();
    }

    public void sendGuideInfo(string id, JsonData info)
    {

        string str = "{\"id\":\"guide machine\",\"target\":\"monitor\",\"logType\":\"guide info\",\"strategy\":\"relay\",\"quality\":0,\"timestamp\":1494825498577," +
                "\"contentBean\":{\"command\":\"processGuideInfo\",\"args\":[\"sth\"]}}";
        JsonData json = JsonMapper.ToObject(str);
        json["id"] = id;
        json["contentBean"]["args"][0] = info;
        messenger.sendMessage(json);
    }

    public void turnLight(bool flag)
    {
        String str = "{\"id\":\"monitor\",\"target\":\"JY05SfZdGcM0WDdO\",\"logType\":\"path\",\"strategy\":\"relay\",\"quality\":1,\"timestamp\":1494825498577," +
            "\"contentBean\":{\"command\":\"setStatus\",\"args\":[2, 1]}}";
        JsonData json = JsonMapper.ToObject(str);
        if (flag)
            json["contentBean"]["args"][1] = 1;
        else
            json["contentBean"]["args"][1] = 0;
        messenger.sendMessage(json);
    }

    public void flashLight(int times)
    {
        String str = "{\"id\":\"monitor\",\"target\":\"JY05SfZdGcM0WDdO\",\"logType\":\"path\",\"strategy\":\"relay\",\"quality\":1,\"timestamp\":1494825498577," +
            "\"contentBean\":{\"command\":\"setFlashTimes\",\"args\":[2, 1]}}";
        JsonData json = JsonMapper.ToObject(str);

        json["contentBean"]["args"][1] = times;

        messenger.sendMessage(json);
    }

    private void messageHandler(JsonData json)
    {

        if (json["monitorId"] == null)
        {
            json["monitorId"] = "";
        }
        if (json["id"].ToString() == "JY05SfZdGcM0WDdO")
        {
            //lightFlag = json["contentBean"]["args"][0].ToString().Substring(1, 1);
        }
    }

    public void addMessageListener(ProcessMessage processMessage)
    {
        messenger.addMessageListener(processMessage);
    }
}
