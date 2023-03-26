using UnityEngine;

namespace Hip
{
    public class HipAnimator
    {
        private Animator m_animator;

        public HipAnimator(Animator _animator)
        {
            m_animator = _animator;
        }
        public void SetFloatValue(string name, float value)
        {
            m_animator.SetFloat(name, value);
        }
    }
}
