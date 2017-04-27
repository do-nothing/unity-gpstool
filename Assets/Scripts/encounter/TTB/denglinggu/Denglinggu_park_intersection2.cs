using UnityEngine;
using Microwise.Guide;

public class Denglinggu_park_intersection2 : TriggerLogic{
    public Denglinggu_park_intersection2(Vector3 position, float radius) : base(position, radius)
    {

    }

    private bool isFistEnter;
    protected override void onVisitorIn()
    {
        // show enter time
        //Debug.Log("Enter Time: " + this.enterTime);

        Debug.Log(this.GetType());

        clearVoices(voices);
        if(this.enterTime == -1)
        {
            isFistEnter = true;
            voices.AddLast("play:Voice/park/岔路2_左");
        }
        else
        {
            isFistEnter = false;
        }
    }

    protected override void onVisitorOut()
    {
        // test trigger out
        //clearVoices(voices);
        //voices.AddLast("play:Voice/离开");
    }

    private bool ask = true;
    protected override void monitorVisitor()
    {
        if (!isFistEnter && ask && voices.Count == 0)
        {
            voices.AddLast("play:Voice/park/岔路2_问");
            startWait(20, nod, shake, idle);
            ask = false;
        }
    }

    private void nod()
    {
        voices.AddLast("play:Voice/park/岔路2_2");
    }

    private void shake()
    {
        voices.AddLast("play:Voice/park/岔路2_1");
    }

    private void idle()
    {
        voices.AddLast("play:Voice/park/岔路2_1");
    }
}
