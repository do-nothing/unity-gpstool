using UnityEngine;
using Microwise.Guide;

public class Denglinggu_office_offStaff : TriggerLogic
{
    public Denglinggu_office_offStaff(Vector3 position, float radius)
        : base(position, radius)
    {

    }

    protected override void onVisitorIn()
    {
        // show enter time
        //Debug.Log("Enter Time: " + this.enterTime);

        Debug.Log(this.GetType());

        voices.AddLast("play:Voice/office/非核心区域测试点");

    }
    protected override void onVisitorOut()
    {
        // test trigger out
        //clearVoices(voices);
        //voices.AddLast("play:Voice/离开");
    }
}
