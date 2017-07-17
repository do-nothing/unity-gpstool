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
            triggers.Add(new Denglinggu_park_origin(new Vector3(0, 0, 0), 1)); // 进入点（喷泉）
            triggers.Add(new Denglinggu_park_entrance(new Vector3(0, 0, 5), 1)); // 瞪羚谷入口





            /********************** 李军 End   *************************/
        }

    }
}