using UnityEngine;
using Microwise.Guide;

public class Denglinggu_park_warning2 : TriggerLogic{
    public Denglinggu_park_warning2(Vector3 position, float radius) : base(position, radius)
    {

    }

    protected override void onVisitorIn()
    {
        // show enter time
        //Debug.Log("Enter Time: " + this.enterTime);

        Debug.Log(this.GetType());

        if (visitorLookat(-20, 80, false)) { 
            voices.AddLast("play:Voice/park/道路施工");
        }
    }
}
