using UnityEngine;

namespace Hip
{
    public class Hip : MonoBehaviour
    {
        public HipAnimator animator;

        [SerializeField] private Animator m_animator;
        [SerializeField] private DynamicJoystick m_dynamicJoystick;

        private void Start()
        {
            m_dynamicJoystick = FindObjectOfType<DynamicJoystick>();
            animator = new HipAnimator(m_animator);
        }
        private void Update()
        {
            animator.SetFloatValue("Vertical", m_dynamicJoystick.Vertical);
            animator.SetFloatValue("Horizontal", m_dynamicJoystick.Horizontal);
        }
    }
}
