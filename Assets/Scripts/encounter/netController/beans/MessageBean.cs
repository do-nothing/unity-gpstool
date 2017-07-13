using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageBean {
    public string id;
    public string target;
    public string monitorId;
    public string logType;
    public string strategy;
    public int quality;
    public long timestamp;
    public ContentBean contentBean = new ContentBean();
    public string token;


    public static MessageBean CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<MessageBean>(jsonString);
    }
    public string GetJson()
    {
        return JsonUtility.ToJson(this);
    }
    public void Load(string savedData)
    {
        JsonUtility.FromJsonOverwrite(savedData, this);
    }
}
