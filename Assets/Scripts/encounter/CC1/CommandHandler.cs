using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Microwise.Guide
{
    public class CommandHandler : MonoBehaviour
    {
        private Light directionalLight;

        void Start()
        {
            directionalLight = GameObject.Find("Directional Light").GetComponent<Light>();
        }

        public void command(string message)
        {
            switch (message)
            {
                case "denglinggu_test1_Capsule1_glisten":
                    //Capsule1Controller.getInstance().glisten();
                    break;
                case "denglingu_park_lamp_switch":
                    DeviceSettings.isLampBurning = !DeviceSettings.isLampBurning;
                    break;
                case "denglingu_DirectionalLight_switch":
                    directionalLight.intensity = directionalLight.intensity == 0 ? 1 : 0;
                    break;
                case "denglingu_eh1_touchscreen1_playVideo":
                    TouchScreen1.getInstance().playVideo();
                    break;
                case "denglingu_eh1_rfid_turnOn":
                    ConnController.instance.turnLight(true);
                    break;
                case "denglingu_eh1_rfid_turnOff":
                    ConnController.instance.turnLight(false);
                    break;
                case "denglingu_eh1_rfid_flash6":
                    ConnController.instance.flashLight(6);
                    break;
            }
        }
    }
}
