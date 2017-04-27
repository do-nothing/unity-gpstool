using UnityEngine;
using Microwise.Guide;

public class Denglinggu_park_report : TriggerLogic{
    public Denglinggu_park_report(Vector3 position, float radius) : base(position, radius)
    {

    }

    protected override void onVisitorIn()
    {
        // show enter time
        //Debug.Log("Enter Time: " + this.enterTime);

        Debug.Log(this.GetType());

        voices.AddLast("play:Voice/stunning/分析_1");
        voices.AddLast("play:Voice/stunning/分析_2");
        voices.AddLast("play:Voice/stunning/分析_3");
        voices.AddLast("play:Voice/stunning/分析_4");
        voices.AddLast("play:Voice/stunning/分析_5");
        voices.AddLast("play:Voice/stunning/完");

    }
    protected override void onVisitorOut()
    {
        // test trigger out
        clearVoices(voices);
        //voices.AddLast("play:Voice/离开");
    }
}
