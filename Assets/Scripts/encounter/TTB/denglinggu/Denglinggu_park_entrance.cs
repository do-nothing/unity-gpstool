using UnityEngine;
using Microwise.Guide;

public class Denglinggu_park_entrance : TriggerLogic{
    public Denglinggu_park_entrance(Vector3 position, float radius) : base(position, radius)
    {

    }

    protected override void onVisitorIn()
    {
        // show enter time
        //Debug.Log("Enter Time: " + this.enterTime);

        Debug.Log(this.GetType());

        // test trigger in
        clearVoices(voices);
        if (this.enterTime > 60)
            return;

        if (visitorLookat(90, 270, false))
        {
            voices.AddLast("play:Voice/park/离开吗");
            ask = false;
            return;
        }

        if (this.enterTime == -1)
        {
            voices.AddLast("play:Voice/park/研发园_1");
            voices.AddLast("play:Voice/park/停一下");
            voices.AddLast("play:Voice/park/研发园_2");
        }
        else
        {
            voices.AddLast("play:Voice/park/欢迎");
        }
    }

    protected override void onVisitorOut()
    {
        // test trigger out
        clearVoices(voices);
        //voices.AddLast("play:Voice/离开");
    }

    private bool ask = true;
    protected override void monitorVisitor()
    {
        if (ask && voices.Count == 0)
        {
            voices.AddLast("play:Voice/park/方向_6");
            startWait(15, nod, shake, idle);
            ask = false;
        }
    }

    private void nod()
    {
        playOthers();
    }

    private void shake()
    {
        voices.AddLast("play:Voice/park/方向_7");
        voices.AddLast("play:Voice/park/继续");
    }

    private void idle()
    {
        playOthers();
    }

    private void playOthers()
    {
        voices.AddLast("play:Voice/park/研发园_3");
        voices.AddLast("play:Voice/park/研发园_4");
        voices.AddLast("play:Voice/park/研发园_5");
        voices.AddLast("play:Voice/park/研发园_6");
        voices.AddLast("play:Voice/park/研发园_7");
        voices.AddLast("play:Voice/park/继续");
    }
}
