using UnityEngine;
using Microwise.Guide;

public class Denglinggu_park_origin : TriggerLogic{
    public Denglinggu_park_origin(Vector3 position, float radius) : base(position, radius)
    {

    }

    protected override void onVisitorIn()
    {
        // show enter time
        //Debug.Log("Enter Time: " + this.enterTime);

        Debug.Log(this.GetType());

        // test trigger in
        clearVoices(voices);
        if(this.enterTime == -1)
        {
            voices.AddLast("play:Voice/park/导游小李");
        }
        else
        {
            voices.AddLast("play:Voice/park/离开");
        }
    }

    protected override void onVisitorOut()
    {
        // test trigger out
        clearVoices(voices);
        //voices.AddLast("play:Voice/离开");
    }

    protected override void monitorVisitor()
    {
        //Debug.Log(this.enterTime);
        if (this.enterTime < 2)
            fistEnter();
        if (this.enterTime > 60)
            goingToLeave();

    }

    private void fistEnter()
    {
        if (visitorLookat(-45, 45))
        {
            voices.AddLast("play:Voice/park/原点_前");
        }

        if (visitorLookat(45, 135))
        {
            clearVoices(voices);
            voices.AddLast("play:Voice/park/原点_左");
        }

        if (visitorLookat(135, 225))
        {
            clearVoices(voices);
            voices.AddLast("play:Voice/park/原点_后");
        }

        if (visitorLookat(225, 315))
        {
            clearVoices(voices);
            voices.AddLast("play:Voice/park/原点_右");
        }
    }

    private void goingToLeave()
    {
        if (visitorLookat(-45, 45))
        {
            voices.AddLast("play:Voice/park/卖卡");
        }

        if (visitorLookat(225, 315))
        {
            voices.AddLast("play:Voice/park/VR基地");
        }
    }
}
