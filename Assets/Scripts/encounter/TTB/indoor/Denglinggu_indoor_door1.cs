using UnityEngine;
using Microwise.Guide;

public class Denglinggu_indoor_door1 : TriggerLogic{
    public Denglinggu_indoor_door1(Vector3 position, float radius)
        : base(position, radius)
    {

    }

    protected override void onVisitorIn()
    {
        Debug.Log(this.GetType());

        clearVoices(voices);

        voices.AddLast("play:Voice/exhibition/展厅_1_1");
        voices.AddLast("play:Voice/exhibition/展厅_1_2");
        voices.AddLast("play:Voice/exhibition/展厅_1_3");

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
