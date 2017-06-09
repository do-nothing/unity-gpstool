using LitJson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Microwise.Guide
{
    public class GuideServer : MonoBehaviour
    {
        public GuideClient client;

        private TriggersController trigersController = TriggersController.controller;

        private ConnController conn = ConnController.instance;
        private string color;
        private JsonData info;
        private Vector3 origin;

        private IEnumerator Start()
        {
            conn.init();
            conn.addMessageListener(processMessage);
            Application.runInBackground = true;

            color = ColorUtility.ToHtmlStringRGBA(Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f));
            info = JsonMapper.ToObject("{\"x\":0,\"y\":0,\"z\":0,\"w\":0,\"status\":\"idle\",\"work\":\"play:Voice/park/停一下\"}");
            //origin = Terrain.activeTerrain.GetPosition();
            origin = new Vector3(345, 0, 81);

            while (true)
            {
                yield return new WaitForSeconds(1);
                checkClients();
                sendClientInfo();
            }
        }

        private void OnDestroy()
        {
            conn.close();
        }

        //ComputeVoices will run at server in ther future;
        private void checkClients()
        {
            trigersController.computeVoices(client.info, client.voices);
            //print(client.info);
        }

        //This function just want send client info to server.
        private void sendClientInfo()
        {
            info["x"] = client.info.location.x + origin.x;
            info["y"] = client.info.location.z + origin.z;
            info["z"] = client.accuracy;
            if (client.info.toward.y != 0)
                info["w"] = 360 - client.info.toward.y;
            else
                info["w"] = 0;
            info["status"] = client.info.status.ToString();
            if (client.voices.First != null)
            {
                info["work"] = client.voices.First.Value;
            }
            else
            {
                info["work"] = "";
            }
            conn.sendGuideInfo(color, info);
            //print(info.ToJson());
        }

        private void processMessage(JsonData json)
        {
            print(json.ToJson());
            client.voices.AddLast("play:Voice/park/停一下");
        }
    }
}

