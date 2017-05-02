using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Microwise.Guide
{
    public interface ITriggerLogic
    {
        float radius { get; set; }
        void computeVoices(VisitorInfo info, LinkedList<string> voices);
        Vector3 getTrigger();
    }
}
