using UnityEngine;
using Microwise.Guide;

public class Denglinggu_indoor_guanniao : TriggerLogic{
    public Denglinggu_indoor_guanniao(Vector3 position, float radius)
        : base(position, radius)
    {

    }

    protected override void onVisitorIn()
    {
        Debug.Log(this.GetType());

        clearVoices(voices);

        voices.AddLast("command:denglingu_eh1_guanniao_lockpage");
        voices.AddLast("play:Voice/exhibition/观鸟_1");
        voices.AddLast("play:Voice/exhibition/观鸟_2");
        voices.AddLast("play:Voice/exhibition/观鸟_3");
        voices.AddLast("command:denglingu_eh1_guanniao_highlightChan");
        voices.AddLast("play:Voice/exhibition/观鸟_4");
        voices.AddLast("play:Voice/exhibition/观鸟_5");
        voices.AddLast("command:denglingu_eh1_guanniao_unlockpage");
    }

    protected override void onVisitorOut()
    {
        // test trigger out
        clearVoices(voices);
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
