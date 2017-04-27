using UnityEngine;
using Microwise.Guide;

public class Denglinggu_park_warning3 : TriggerLogic{
    public Denglinggu_park_warning3(Vector3 position, float radius) : base(position, radius)
    {

    }

    private int visitTimes = 0;

    protected override void onVisitorIn()
    {
        // show enter time
        //Debug.Log("Enter Time: " + this.enterTime);

        Debug.Log(this.GetType());

        // test trigger in
        clearVoices(voices);

        if (visitTimes < 2)
        {
            voices.AddLast("command:denglingu_DirectionalLight_switch");
            voices.AddLast("play:Voice/park/下午5点");
        }

        visitTimes++;
    }

    protected override void onVisitorOut()
    {
        // test trigger out
        clearVoices(voices);
        if (visitTimes < 2)
        {
            voices.AddLast("command:denglingu_DirectionalLight_switch");
            ask = true;
        }
    }

    private bool ask = true;
    protected override void monitorVisitor()
    {
        if (ask && voices.Count == 0)
        {
            voices.AddLast("play:Voice/park/开路灯吗");
            startWait(20, nod, shake, idle);
            ask = false;
        }
    }

    private void nod()
    {
        voices.AddLast("command:denglingu_park_lamp_switch");
        voices.AddLast("play:Voice/park/开路灯");
    }

    private void shake()
    {
        voices.AddLast("play:Voice/park/不开路灯");
    }

    private void idle()
    {
        voices.AddLast("play:Voice/park/不开路灯");
    }
}
