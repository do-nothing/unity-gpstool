using UnityEngine;
using Microwise.Guide;

public class Denglinggu_eh1_touchScreen1 : TriggerLogic{
    public Denglinggu_eh1_touchScreen1(Vector3 position, float radius) : base(position, radius)
    {

    }

    protected override void onVisitorIn()
    {
        // show enter time
        //Debug.Log("Enter Time: " + this.enterTime);

        Debug.Log(this.GetType());

        // test trigger in
        clearVoices(voices);

        voices.AddLast("command:denglingu_eh1_touchscreen1_playVideo");
    }
}
