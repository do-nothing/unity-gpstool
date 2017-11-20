using UnityEngine;
using Microwise.Guide;

public class Denglinggu_office_3A : TriggerLogic
{
    public Denglinggu_office_3A(Vector3 position, float radius)
        : base(position, radius)
    {

    }

    protected override void onVisitorIn()
    {
        // show enter time
        //Debug.Log("Enter Time: " + this.enterTime);

        Debug.Log(this.GetType());

        voices.AddLast("play:Voice/office/3A1");
        voices.AddLast("play:Voice/office/3A2");
        voices.AddLast("play:Voice/office/3A3");

    }
    protected override void onVisitorOut()
    {
        // test trigger out
        clearVoices(voices);
        //voices.AddLast("play:Voice/离开");
    }
}
