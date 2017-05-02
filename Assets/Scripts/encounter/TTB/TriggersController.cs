using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Microwise.Guide
{
    public class TriggersController
    {
        internal static readonly TriggersController controller = new TriggersController();
        private List<ITriggerLogic> triggers;
        private TriggersController()
        {
            triggers = TriggersSetting.triggers;

            triggers.Sort(delegate(ITriggerLogic x, ITriggerLogic y)
            {
                return x.radius.CompareTo(y.radius);
            });

            //printList();
        }

        private void printList()
        {
            foreach (TriggerLogic triggerLogic in triggers)
            {
                Debug.Log(triggerLogic);
            }
        }

        internal void computeVoices(VisitorInfo info, LinkedList<string> voices)
        {
            foreach(ITriggerLogic triggerLogic in triggers)
            {
                triggerLogic.computeVoices(info, voices);
            }
        }

        public List<Vector3> getTriggers()
        {
            List<Vector3> triggerList = new List<Vector3>();

            foreach (ITriggerLogic tiggerLogic in triggers)
            {
                triggerList.Add(tiggerLogic.getTrigger());
            }

            return triggerList;
        }
    }
}
