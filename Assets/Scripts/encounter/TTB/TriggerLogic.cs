using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Microwise.Guide
{
    public class TriggerLogic : ITriggerLogic
    {
        private Vector3 targetLocation;
        private float _radius;
        public float radius
        {
            get
            {
                return _radius;
            }
            set
            {
                _radius = value;
            }
        }
        private float offset;
        private float dynamicRadius;
        private bool inRange;
        private HashSet<Vector2> visitorlog = new HashSet<Vector2>();
        private int waitTimes = 0;
        private DoSth nod;
        private DoSth shake;
        private DoSth idle;

        protected VisitorInfo info;
        protected LinkedList<string> voices;
        protected float enterTime = -1;
        protected delegate void DoSth();

        public TriggerLogic(Vector3 position, float radius)
        {
            this.targetLocation = position;
            this.radius = radius;
            inRange = false;
            offset = radius * 0.1f;
            offset = Mathf.Min(offset, 1);
            dynamicRadius = radius - offset;
        }

        public void computeVoices(VisitorInfo info, LinkedList<string> voices)
        {
            this.info = info;
            this.voices = voices;
            if (isVisitorInRange(info.location) != inRange)
            {
                inRange = !inRange;
                if (inRange)
                {
                    onVisitorIn();
                    enterTime = Time.time;
                    dynamicRadius = radius + offset;
                }
                else
                {
                    onVisitorOut();
                    dynamicRadius = radius - offset;
                    visitorlog.Clear();
                }
            }

            if (inRange)
            {
                monitorVisitor();
            }

            if(waitTimes > 0)
            {
                if(info.status == VisitorInfo.Status.NOD)
                {
                    nod();
                    waitTimes = 0;
                }
                else if (info.status == VisitorInfo.Status.SHAKE)
                {
                    shake();
                    waitTimes = 0;
                }
                else
                {
                    waitTimes--;
                    if(waitTimes == 0)
                    {
                        idle();
                    }
                }
            }
        }

        protected virtual void onVisitorIn()
        {

        }

        protected virtual void onVisitorOut()
        {

        }

        protected virtual void monitorVisitor()
        {

        }

        //At present only over the 2D calculation.
        private bool isVisitorInRange(Vector3 position)
        {
            float distance_x = Mathf.Abs(position.x - targetLocation.x);
            if (distance_x > dynamicRadius)
                return false;
            float distance_z = Mathf.Abs(position.z - targetLocation.z);
            if (distance_z > dynamicRadius)
                return false;
            if (distance_x + distance_z < dynamicRadius)
                return true;
            if (distance_x * distance_x + distance_z * distance_z > dynamicRadius * dynamicRadius)
                return false;
            return true;
        }

        protected bool visitorLookat(float a, float b, bool onlyone = true)
        {
            float toward = info.toward.y;
            if (a >= 0)
            {
                if (toward <= a || toward >= b)
                    return false;
            }
            else
            {
                if ((toward <= a || toward >= b) && toward - 360 <= a || toward - 360 >= b)
                    return false;
            }

            if (onlyone)
                return visitorlog.Add(new Vector2(a, b));
            else
                return true;
        }

        protected void startWait(int times, DoSth nod, DoSth shake, DoSth idle)
        {
            waitTimes = times;
            this.nod = nod;
            this.shake = shake;
            this.idle = idle;
        }

        public void clearVoices(LinkedList<string> voices)
        {
            if(voices.Count == 0)
            {
                return;
            }
            voices.Clear();
            voices.AddFirst("");
        }

        public override string ToString()
        {
            return "Radius: " + radius + " \t Location:" + targetLocation + " \t Type:" + this.GetType();
        }
    }
}
