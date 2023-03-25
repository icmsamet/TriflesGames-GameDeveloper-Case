using UnityEngine;

public class BasketballBall : MonoBehaviour
{
    public float jumpValue = 8f;
    private Rigidbody m_rigidbody;
    private DynamicJoystick m_dynamicJoystick;

    void Start()
    {
        m_dynamicJoystick = FindObjectOfType<DynamicJoystick>();
        m_rigidbody = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        ClampPos();
    }
    private void ClampPos()
    {
        Vector3 currentLocalPos = transform.localPosition;

        currentLocalPos.x = Mathf.Clamp(currentLocalPos.x, -1, 1);
        currentLocalPos.z = Mathf.Clamp(currentLocalPos.z, -1, -1);

        transform.localPosition = currentLocalPos;
    }
    void OnCollisionEnter(Collision collision)
    {
        var value = (10 * (-1 * m_dynamicJoystick.Vertical));
        value = Mathf.Clamp(value,0,10);

        if(value > 0)
        {
            m_rigidbody.velocity = Vector3.up * (jumpValue + value);
        }
        else
        {
            float rnd = Random.Range(-1.0f, 1.0f);
            m_rigidbody.velocity = (Vector3.up + new Vector3(rnd, 0, 0)) * (jumpValue - 1);
        }
    }
}
