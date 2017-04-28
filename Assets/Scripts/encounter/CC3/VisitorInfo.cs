using UnityEngine;

namespace Microwise.Guide
{
    public struct VisitorInfo
    {

        public enum Status { IDLE, NOD, SHAKE };

        private Vector3 _location;
        private Vector2 _toward;
        private Status _status;
        private float markTime;

        public Vector3 location
        {
            get
            {
                return _location;
            }

            set
            {
                _location = value;
            }
        }

        public Vector2 toward
        {
            get
            {
                return _toward;
            }

            set
            {
                //setStatus(_toward, value);
                _toward = value;
            }
        }

        public Status status
        {
            set
            {
                _status = value;
            }
            get
            {
                return _status;
            }
        }

        private void setStatus(Vector2 a, Vector2 b)
        {
            Vector2 offset = b - a;
            offset.Set(Mathf.Abs(offset.x), Mathf.Abs(offset.y));
            offset /= Time.deltaTime;
            float maxOffset = Mathf.Max(offset.x, offset.y);
            if (maxOffset > 200)
            {
                if (offset.x > offset.y)
                {
                    _status = Status.NOD;
                }
                else
                {
                    _status = Status.SHAKE;
                }

                markTime = Time.time;
            }
            else
            {
                if(Time.time - markTime > 1.1f)
                    _status = Status.IDLE;
            }
        }

        public override string ToString()
        {
            string str = "location:" + _location;
            str += "\t toward:" + _toward;
            str += "\t status:" + _status;
            return str;
        }
    }
}