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
            //triggers.Add(new Denglinggu_indoor_entrance(new Vector3(10.1f, 0, 15.3f), 2)); // 进入点
            //triggers.Add(new Denglinggu_indoor_door1(new Vector3(48, 0, 10.5f), 1.5f)); // 展厅口
            //triggers.Add(new Denglinggu_indoor_guanniao(new Vector3(48, 0, 13f), 0.8f)); // 观鸟捕蝉图
            //triggers.Add(new Denglinggu_indoor_rfid(new Vector3(48, 0, 15f), 0.8f)); // RFID

            triggers.Add(new Denglinggu_office_origin(new Vector3(13, 0, 15.3f), 1.5f)); // 进入点
            triggers.Add(new Denglinggu_office_entrance(new Vector3(19.7f, 0, 15.3f), 1.3f)); // 软件部入口

            triggers.Add(new Denglinggu_office_welcome(new Vector3(20.4f, 0, 13.4f), 0.7f)); // 欢迎
            triggers.Add(new Denglinggu_office_warehouse(new Vector3(22f, 0, 13.3f), 0.6f)); // 库房1
            triggers.Add(new Denglinggu_office_storeroom(new Vector3(22.6f, 0, 6.4f), 0.5f)); // 库房2
            triggers.Add(new Denglinggu_office_offStaff(new Vector3(21.4f, 0, 11.4f), 0.5f)); // 非核心区测试点

            triggers.Add(new Denglinggu_office_3A(new Vector3(16.2f, 0, 13.2f), 0.5f)); // A3
            triggers.Add(new Denglinggu_office_coreArea(new Vector3(15.4f, 0, 12.1f), 0.6f)); // 核心区测试点
            triggers.Add(new Denglinggu_office_design(new Vector3(15.4f, 0, 7.4f), 1f)); // 设计部
            triggers.Add(new Denglinggu_office_finance(new Vector3(8.6f, 0, 9.3f), 0.5f)); // 财务部
            triggers.Add(new Denglinggu_office_testing(new Vector3(8.6f, 0, 10.6f), 0.5f)); // 测试部
            triggers.Add(new Denglinggu_office_p0(new Vector3(9f, 0, 12.6f), 0.6f)); // 空工位
            triggers.Add(new Denglinggu_office_2A(new Vector3(10.4f, 0, 13.1f), 0.6f)); // A2

            triggers.Add(new Denglinggu_office_p1(new Vector3(14.3f, 0, 9.3f), 0.5f)); // 高辉工位
            triggers.Add(new Denglinggu_office_p2(new Vector3(12.8f, 0, 9.3f), 0.5f)); // 姜浩工位
            triggers.Add(new Denglinggu_office_p3(new Vector3(11.3f, 0, 9.3f), 0.5f)); // 李军工位
            triggers.Add(new Denglinggu_office_p4(new Vector3(9.8f, 0, 9.3f), 0.5f)); // 冯斌工位
            triggers.Add(new Denglinggu_office_p5(new Vector3(14.3f, 0, 10.3f), 0.5f)); // 谢林旭工位
            triggers.Add(new Denglinggu_office_p6(new Vector3(12.8f, 0, 10.3f), 0.5f)); // 段泽尧工位
            triggers.Add(new Denglinggu_office_p7(new Vector3(11.3f, 0, 10.3f), 0.5f)); // 王菁工位
            triggers.Add(new Denglinggu_office_p8(new Vector3(9.8f, 0, 10.3f), 0.5f)); // 杨伟工位


            /********************** 李军 End   *************************/
        }

    }
}