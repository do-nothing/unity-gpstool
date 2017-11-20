using UnityEngine;
using Microwise.Guide;

public class Denglinggu_office_design : TriggerLogic{
    public Denglinggu_office_design(Vector3 position, float radius)
        : base(position, radius)
    {

    }

    protected override void onVisitorIn()
    {
        // show enter time
        //Debug.Log("Enter Time: " + this.enterTime);

        Debug.Log(this.GetType());

        if (visitorLookat(135, 225, false))
        {
            voices.AddLast("play:Voice/office/设计部1");
        }
        else if (visitorLookat(225, 315, false))
        {
            voices.AddLast("play:Voice/office/设计部2");
        }
        else if (visitorLookat(45, 135, false))
        {
            voices.AddLast("play:Voice/office/设计部3");
        }

    }
    protected override void onVisitorOut()
    {
        // test trigger out
        //clearVoices(voices);
        //voices.AddLast("play:Voice/离开");
    }
}
