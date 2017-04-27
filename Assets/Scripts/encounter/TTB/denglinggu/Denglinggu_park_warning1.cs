using UnityEngine;
using Microwise.Guide;

public class Denglinggu_park_warning1 : TriggerLogic{
    public Denglinggu_park_warning1(Vector3 position, float radius) : base(position, radius)
    {

    }

    protected override void onVisitorIn()
    {
        // show enter time
        //Debug.Log("Enter Time: " + this.enterTime);

        Debug.Log(this.GetType());

        voices.AddLast("play:Voice/park/小心");
    }
}
