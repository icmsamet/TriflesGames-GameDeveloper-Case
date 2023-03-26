using UnityEngine;
using GG.Infrastructure.Utils.Swipe;

namespace ToiletPaper
{
    public class ToiletPaperRigidbody
    {
        private Rigidbody m_rigidbody;
        private SwipeListener m_swipeListener;
        public ToiletPaperRigidbody(Rigidbody _rigidbody,SwipeListener _swipeListener)
        {
            m_rigidbody = _rigidbody;
            m_swipeListener = _swipeListener;
        }
        private Vector3 velocity
        {
            get { return m_rigidbody.velocity; }
            set { m_rigidbody.velocity = value; }
        }
        public void SetConstraints(RigidbodyConstraints constraints)
        {
            m_rigidbody.constraints = constraints;
        }
        public void StartGame()
        {
            SetConstraints(RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionZ);
        }
        public void Velocity(string id)
        {
            switch (id)
            {
                case DirectionId.ID_UP:
                    velocity = Vector3.up * (3.7f + m_swipeListener.swipeTime);
                    break;
                case DirectionId.ID_LEFT:
                    velocity = (Vector3.left + Vector3.up) * (2.2f + m_swipeListener.swipeTime);
                    break;
                case DirectionId.ID_UP_LEFT:
                    velocity = (Vector3.left + Vector3.up) * (2.2f + m_swipeListener.swipeTime);
                    break;
                case DirectionId.ID_RIGHT:
                    velocity = (Vector3.right + Vector3.up) * (2.2f + m_swipeListener.swipeTime);
                    break;
                case DirectionId.ID_UP_RIGHT:
                    velocity = (Vector3.right + Vector3.up) * (2.2f + m_swipeListener.swipeTime);
                    break;
            }
        }
    }
}
