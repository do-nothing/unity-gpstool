using LitJson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Microwise.Guide.NetConn
{
    public delegate void ProcessMessage(JsonData json);
    public interface Messenger
    {
        void sendMessage(JsonData json);
        void addMessageListener(ProcessMessage processMessage);
        void destroy();
    }
}
