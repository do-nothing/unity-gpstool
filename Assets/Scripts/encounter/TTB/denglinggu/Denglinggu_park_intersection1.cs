using UnityEngine;
using Microwise.Guide;

public class Denglinggu_park_intersection1 : TriggerLogic{
    public Denglinggu_park_intersection1(Vector3 position, float radius) : base(position, radius)
    {

    }

    private bool isFistEnter;

    protected override void onVisitorIn()
    {
        // show enter time
        //Debug.Log("Enter Time: " + this.enterTime);

        Debug.Log(this.GetType());

        clearVoices(voices);
    }

    protected override void onVisitorOut()
    {
        // test trigger out
        clearVoices(voices);
        //voices.AddLast("play:Voice/离开");
    }

    protected override void monitorVisitor()
    {
        if (visitorLookat(-45, 45))
        {
            clearVoices(voices);
            voices.AddLast("play:Voice/park/岔路1_北");
        }

        if (visitorLookat(45, 135))
        {
            clearVoices(voices);
            voices.AddLast("play:Voice/park/岔路1_东");
        }

        if (visitorLookat(135, 225))
        {
            clearVoices(voices);
            voices.AddLast("play:Voice/park/岔路1_南");
        }

        if (visitorLookat(225, 315))
        {
            clearVoices(voices);
            voices.AddLast("play:Voice/park/岔路1_西");
        }

    }
}
