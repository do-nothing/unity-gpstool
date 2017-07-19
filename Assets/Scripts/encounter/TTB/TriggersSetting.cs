using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

namespace Microwise.Guide
{
    public class TriggersSetting
    {
        public static List<ITriggerLogic> triggers = new List<ITriggerLogic>();
        private TriggersSetting() { }

        static TriggersSetting()
        {
            //triggers.Add(new Denglinggu_park_test001(new Vector3(10, 0, 10), 5)); // test trigger 

            /********************** 姜浩 Start *************************/

            /********************** 姜浩 End   *************************/

            /********************** 杨伟 Start *************************/

            /********************** 杨伟 End   *************************/

            /********************** 冯斌 Start *************************/

            /********************** 冯斌 End   *************************/

            /********************** 李军 Start *************************/
            triggers.Add(new Denglinggu_indoor_entrance(new Vector3(42, 0, 10.5f), 2)); // 进入点
            triggers.Add(new Denglinggu_indoor_door1(new Vector3(48, 0, 10.5f), 1.5f)); // 展厅口
            triggers.Add(new Denglinggu_indoor_guanniao(new Vector3(48, 0, 13f), 0.8f)); // 观鸟捕蝉图
            triggers.Add(new Denglinggu_indoor_rfid(new Vector3(48, 0, 15f), 0.8f)); // RFID





            /********************** 李军 End   *************************/
        }

    }
}