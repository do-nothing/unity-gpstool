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
            triggers.Add(new Denglinggu_park_origin(new Vector3(0, 0, 0), 9)); // 进入点（喷泉）
            triggers.Add(new Denglinggu_park_entrance(new Vector3(0, 0, 21), 6)); // 瞪羚谷入口
            triggers.Add(new Denglinggu_park_intersection1(new Vector3(0, 0, 43), 6)); //岔路口1
            triggers.Add(new Denglinggu_park_intersection2(new Vector3(-15.5f, 0, 76), 6)); //岔路口2
            triggers.Add(new Denglinggu_park_warning1(new Vector3(-2.5f, 0, 64), 6)); //小心路滑
            triggers.Add(new Denglinggu_park_warning2(new Vector3(-12, 0, 87), 6)); //道路施工
            triggers.Add(new Denglinggu_park_intersection3(new Vector3(-31.5f, 0, 104), 6)); //岔路口3
            triggers.Add(new Denglinggu_park_warning3(new Vector3(-34, 0, 142), 10)); //时间提醒
            triggers.Add(new Denglinggu_park_recommend(new Vector3(0, 0, -20), 9)); //推荐晚饭
            triggers.Add(new Denglinggu_park_report(new Vector3(0, 0, -40), 9)); //客户行为分析语音
            triggers.Add(new Denglinggu_park_encounter(new Vector3(-44f, 0, -14), 20)); //encounter 展示

            //eh1
            triggers.Add(new Denglinggu_eh1_touchScreen1(new Vector3(-27, 0, 68), 1)); //encounter 展示



            /********************** 李军 End   *************************/
        }

    }
}