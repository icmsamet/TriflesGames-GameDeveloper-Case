using UnityEngine;
using GG.Infrastructure.Utils.Swipe;

namespace ToiletPaper
{
    [RequireComponent(typeof(Rigidbody))]
    public class ToiletPaper : MonoBehaviour
    {
        private ToiletPaperRigidbody m_rigidbody;
        private ToiletPaperMovement m_movement;

        private SwipeListener m_swipeListener;
        private Rigidbody m_myRb;
        [SerializeField] private bool m_isMoving;
        [SerializeField] private Vector2 m_clamp;

        private void Start()
        {
            m_swipeListener = FindObjectOfType<SwipeListener>();
            m_swipeListener.OnSwipe.AddListener(OnSwipeHandler);

            m_myRb = GetComponent<Rigidbody>();
            m_rigidbody = new ToiletPaperRigidbody(m_myRb, m_swipeListener);
            m_rigidbody.StartGame();

            m_movement = new ToiletPaperMovement(this.transform,m_clamp);
            SetMoving(false);
        }
        private void FixedUpdate()
        {
            if(m_isMoving)
                m_movement.Clamp();
        }
        public void OnSwipeHandler(string id)
        {
            if (!m_isMoving && this.gameObject.activeSelf)
            {
                transform.tag = "ToiletPaper";
                m_rigidbody.Velocity(id);
                m_movement.Move(id, SetMoving);
                transform.SetParent(null);
            }
        }
        public void SetMoving(bool value)
        {
            m_isMoving = value;
        }
        private void OnCollisionEnter(Collision collision)
        {
            if (GameManager.GameManager.instance.CheckStarted() && transform.tag == "ToiletPaper")
            {
                transform.tag = "Untagged";
                transform.SetParent(collision.transform);
                SetMoving(false);
            }
        }
    }
}
