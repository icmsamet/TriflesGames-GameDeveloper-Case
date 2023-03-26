using UnityEngine;
using GG.Infrastructure.Utils.Swipe;

namespace ToiletPaper
{
    [RequireComponent(typeof(Rigidbody))]
    public class ToiletPaper : MonoBehaviour
    {
        private ToiletPaperRigidbody m_toiletRigidbody;
        private ToiletPaperMovement m_toiletMovement;

        private SwipeListener m_swipeListener;
        private Rigidbody m_rigidbody;
        [SerializeField] private bool m_isMoving;
        [SerializeField] private Vector2 m_clamp;

        private void Start()
        {
            m_swipeListener = FindObjectOfType<SwipeListener>();
            m_swipeListener.OnSwipe.AddListener(OnSwipeHandler);

            m_rigidbody = GetComponent<Rigidbody>();
            m_toiletRigidbody = new ToiletPaperRigidbody(m_rigidbody, m_swipeListener);
            m_toiletRigidbody.StartGame();

            m_toiletMovement = new ToiletPaperMovement(this.transform,m_clamp);
            SetMoving(false);
        }
        private void FixedUpdate()
        {
            if(m_isMoving)
                m_toiletMovement.Clamp();
        }
        private void OnCollisionEnter(Collision collision)
        {
            if (GameManager.GameManager.instance.CheckStarted() && transform.tag == "ToiletPaper")
            {
                transform.tag = "Untagged";
                transform.SetParent(collision.transform);
                m_toiletMovement.LocalRotation = Quaternion.Euler(Vector3.zero);
                SetMoving(false);
            }
        }
        public void OnSwipeHandler(string id)
        {
            if (!m_isMoving && this.gameObject.activeSelf)
            {
                transform.tag = "ToiletPaper";
                m_toiletRigidbody.Velocity(id);
                m_toiletMovement.Move(id, SetMoving);
                transform.SetParent(null);
            }
        }
        public void SetMoving(bool value)
        {
            m_isMoving = value;
        }
    }
}
