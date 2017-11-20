using UnityEngine;
using Microwise.Guide;

public class Denglinggu_office_welcome : TriggerLogic{
    public Denglinggu_office_welcome(Vector3 position, float radius)
        : base(position, radius)
    {

    }

    protected override void onVisitorIn()
    {
        // show enter time
        //Debug.Log("Enter Time: " + this.enterTime);

        Debug.Log(this.GetType());

        voices.AddLast("play:Voice/office/欢迎1");
        voices.AddLast("play:Voice/office/欢迎2");
        voices.AddLast("play:Voice/office/欢迎3");
        voices.AddLast("play:Voice/office/欢迎4");
        voices.AddLast("play:Voice/office/欢迎5");

    }
    protected override void onVisitorOut()
    {
        // test trigger out
        clearVoices(voices);
        //voices.AddLast("play:Voice/离开");
    }
}
