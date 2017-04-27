using UnityEngine;
using Microwise.Guide;

public class Denglinggu_park_encounter : TriggerLogic{
    public Denglinggu_park_encounter(Vector3 position, float radius) : base(position, radius)
    {

    }

    protected override void onVisitorIn()
    {
        // show enter time
        //Debug.Log("Enter Time: " + this.enterTime);

        Debug.Log(this.GetType());

        // test trigger in
        clearVoices(voices);
        voices.AddLast("play:Voice/stunning/介绍_1");
        voices.AddLast("play:Voice/stunning/介绍_2");
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
            voices.AddLast("play:Voice/stunning/介绍_3");
            startWait(7, nod, shake, idle);
            ask = false;
        }
    }

    private void nod()
    {
        playOthers();
    }

    private void shake()
    {
        voices.AddLast("play:Voice/stunning/介绍_5");
    }

    private void idle()
    {
        playOthers();
    }

    private void playOthers()
    {
        voices.AddLast("play:Voice/stunning/介绍_4");
    }
}
