using UnityEngine;
using Microwise.Guide;

public class Denglinggu_park_intersection3 : TriggerLogic{
    public Denglinggu_park_intersection3(Vector3 position, float radius) : base(position, radius)
    {

    }

    protected override void onVisitorIn()
    {
        // show enter time
        //Debug.Log("Enter Time: " + this.enterTime);

        Debug.Log(this.GetType());

        // test trigger in
        clearVoices(voices);

        if (visitorLookat(-90, 90, false))
        {
            voices.AddLast("play:Voice/park/左转2号");
            return;
        }
    }
}
