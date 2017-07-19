using UnityEngine;
using Microwise.Guide;

public class Denglinggu_indoor_rfid : TriggerLogic
{
    public Denglinggu_indoor_rfid(Vector3 position, float radius)
        : base(position, radius)
    {

    }

    protected override void onVisitorIn()
    {
        Debug.Log(this.GetType());

        clearVoices(voices);

        voices.AddLast("play:Voice/exhibition/RFID_1");
        voices.AddLast("play:Voice/exhibition/RFID_2");
        voices.AddLast("command:denglingu_eh1_rfid_turnOn");
        voices.AddLast("play:Voice/exhibition/RFID_3");
        voices.AddLast("command:denglingu_eh1_rfid_turnOff");
        voices.AddLast("play:Voice/exhibition/RFID_4");
        voices.AddLast("command:denglingu_eh1_rfid_flash6");
        voices.AddLast("play:Voice/exhibition/RFID_5");
        voices.AddLast("play:Voice/exhibition/RFID_6");
        voices.AddLast("play:Voice/exhibition/RFID_7");
        voices.AddLast("play:Voice/exhibition/RFID_8");
        voices.AddLast("play:Voice/exhibition/RFID_9");
        voices.AddLast("command:denglingu_eh1_rfid_turnOff");

    }

    protected override void onVisitorOut()
    {
        // test trigger out
        clearVoices(voices);
        voices.AddLast("command:denglingu_eh1_rfid_turnOff");
        //voices.AddLast("play:Voice/离开");
    }

    private void goingToLeave()
    {
        if (visitorLookat(-135, -45))
        {
            //voices.AddLast("play:Voice/park/卖卡");
        }
    }
}
