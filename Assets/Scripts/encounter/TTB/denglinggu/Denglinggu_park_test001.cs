using UnityEngine;
using Microwise.Guide;

public class Denglinggu_park_test001 : TriggerLogic{
    public Denglinggu_park_test001(Vector3 position, float radius) : base(position, radius)
    {

    }

    protected override void onVisitorIn()
    {
        // show enter time
        Debug.Log("Enter Time: " + this.enterTime);

        // test trigger in
        clearVoices(voices);
        voices.AddLast("play:Voice/进入");
        voices.AddLast("play:Voice/test1");
        voices.AddLast("command:denglinggu_test1_Capsule1_glisten");
        voices.AddLast("play:Voice/test2");
    }

    protected override void onVisitorOut()
    {
        // test trigger out
        clearVoices(voices);
        voices.AddLast("play:Voice/离开");
    }

    private bool ask = true;
    protected override void monitorVisitor()
    {
        // test lookat 
        if (visitorLookat(-45, 45))
        {
            voices.AddLast("play:Voice/向北");
        }

        if (visitorLookat(45, 135))
        {
            voices.AddLast("play:Voice/向东");
        }

        if (visitorLookat(135, 225))
        {
            voices.AddLast("play:Voice/向南");
        }

        if (visitorLookat(225, 315))
        {
            voices.AddLast("play:Voice/向西");
        }

        if(ask && voices.Count == 0)
        {
            voices.AddLast("play:Voice/等待");
            startWait(10, nod, shake, idle);
            ask = false;
        }
    }

    private void nod()
    {
        voices.AddLast("play:Voice/点头");
    }

    private void shake()
    {
        voices.AddLast("play:Voice/摇头");
    }

    private void idle()
    {
        voices.AddLast("play:Voice/没有动作");
    }
}
