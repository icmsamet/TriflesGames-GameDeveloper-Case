using UnityEngine;

namespace BasketballBall
{
    public class BasketballBall : MonoBehaviour
    {
        private BasketballBallRigidbody m_ballRigidbody;

        public float jumpValue = 8f;
        private Rigidbody m_rigidbody;
        private DynamicJoystick m_dynamicJoystick;
        private PhysicMaterial m_physicMaterial;

        void Start()
        {
            m_dynamicJoystick = FindObjectOfType<DynamicJoystick>();
            m_rigidbody = GetComponent<Rigidbody>();
            m_ballRigidbody = new BasketballBallRigidbody(m_rigidbody);
            m_ballRigidbody.Force = m_ballRigidbody.AddRandomForce(jumpValue);
        }
        private void FixedUpdate()
        {
            ClampPos();
        }
        private void OnCollisionEnter(Collision collision)
        {
            var swipeValue = (10 * (-1 * m_dynamicJoystick.Vertical));
            swipeValue = Mathf.Clamp(swipeValue, 0, 10);
            if (swipeValue > 0)
            {
                if (collision.gameObject.name == "Ground")
                {
                    m_ballRigidbody.Force = Vector3.up * jumpValue;
                }
                else
                {
                    m_ballRigidbody.Force = Vector3.down * (jumpValue + swipeValue);
                }
                SetPhysicMaterialBounciness(1f);
            }
            else
            {
                SetPhysicMaterialBounciness(0.965f);
            }
            m_ballRigidbody.ClampVelocity(5);
        }
        private void SetPhysicMaterialBounciness(float value)
        {
            m_physicMaterial.bounciness = value;
        }
        private void ClampPos()
        {
            Vector3 currentLocalPos = transform.localPosition;

            currentLocalPos.x = Mathf.Clamp(currentLocalPos.x, -1, 1);
            currentLocalPos.z = Mathf.Clamp(currentLocalPos.z, -1, -1);

            transform.localPosition = currentLocalPos;
        }
    }
}
