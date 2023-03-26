using UnityEngine;

namespace Hip
{
    public class Hip : MonoBehaviour
    {
        private HipAnimator m_hipAnimator;

        [SerializeField] private Animator m_animator;
        [SerializeField] private DynamicJoystick m_dynamicJoystick;

        private void Start()
        {
            m_animator = GetComponent<Animator>();
            m_dynamicJoystick = FindObjectOfType<DynamicJoystick>();
            m_hipAnimator = new HipAnimator(m_animator);
        }
        private void Update()
        {
            m_hipAnimator.SetFloatValue("Vertical", m_dynamicJoystick.Vertical);
            m_hipAnimator.SetFloatValue("Horizontal", m_dynamicJoystick.Horizontal);
        }
    }
}
