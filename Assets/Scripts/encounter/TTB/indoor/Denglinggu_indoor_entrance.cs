using UnityEngine;
using Microwise.Guide;

public class Denglinggu_indoor_entrance : TriggerLogic{
    public Denglinggu_indoor_entrance(Vector3 position, float radius) : base(position, radius)
    {

    }

    protected override void onVisitorIn()
    {
        Debug.Log(this.GetType());

        clearVoices(voices);

        voices.AddLast("play:Voice/exhibition/软件部_1");
        voices.AddLast("play:Voice/exhibition/软件部_2");
        voices.AddLast("play:Voice/exhibition/软件部_3");

    }

    protected override void onVisitorOut()
    {
        // test trigger out
        //clearVoices(voices);
        //voices.AddLast("play:Voice/离开");
    }

    private void goingToLeave()
    {
        if (visitorLookat(-135, -45))
        {
            //voices.AddLast("play:Voice/park/卖卡");
        }
    }
}
