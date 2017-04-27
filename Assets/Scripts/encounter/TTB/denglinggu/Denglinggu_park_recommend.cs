using UnityEngine;
using Microwise.Guide;

public class Denglinggu_park_recommend : TriggerLogic{
    public Denglinggu_park_recommend(Vector3 position, float radius) : base(position, radius)
    {

    }

    protected override void onVisitorIn()
    {
        // show enter time
        //Debug.Log("Enter Time: " + this.enterTime);

        Debug.Log(this.GetType());

        // test trigger in
        clearVoices(voices);
    }

    protected override void onVisitorOut()
    {
        // test trigger out
        clearVoices(voices);
        ask = true;
        //voices.AddLast("play:Voice/离开");
    }

    private bool ask = true;
    protected override void monitorVisitor()
    {
        if (ask && voices.Count == 0)
        {
            voices.AddLast("play:Voice/park/晚饭");
            startWait(20, nod, shake, idle);
            ask = false;
        }
    }

    private void nod()
    {
        voices.AddLast("play:Voice/park/报价");
    }

    private void shake()
    {
        playOthers();
    }

    private void idle()
    {
        playOthers();
    }

    private void playOthers()
    {
        voices.AddLast("play:Voice/park/还机");
    }
}
