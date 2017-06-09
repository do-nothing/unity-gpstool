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

    public void addMessageListener(ProcessMessage processMessage)
    {
        messenger.addMessageListener(processMessage);
    }
}
