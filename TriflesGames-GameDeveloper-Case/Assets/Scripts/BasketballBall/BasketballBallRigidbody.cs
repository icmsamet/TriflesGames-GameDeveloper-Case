using UnityEngine;

namespace BasketballBall
{
    public class BasketballBallRigidbody
    {
        private Rigidbody m_rigidbody;

        public BasketballBallRigidbody(Rigidbody _rigidbody)
        {
            m_rigidbody = _rigidbody;
        }
        public Vector3 Force
        {
            set { m_rigidbody.AddForce(value); }
        }
        public Vector3 AddRandomForce(float value)
        {
            float rnd = Random.Range(-5.0f, 5.0f);
            return Vector3.up + new Vector3(rnd, 0, 0) * value;
        }
        public Vector3 Velocity
        {
            get { return m_rigidbody.velocity; }
            set { m_rigidbody.velocity = value; }
        }
        public RigidbodyConstraints Constraints
        {
            get { return m_rigidbody.constraints; }
            set { m_rigidbody.constraints = value; }
        }
        public void ClampVelocity(float maxLength)
        {
            m_rigidbody.velocity = Vector3.ClampMagnitude(m_rigidbody.velocity,maxLength);
        }
    }
}
