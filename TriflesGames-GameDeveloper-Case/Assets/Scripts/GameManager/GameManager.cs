using UnityEngine;
using TurnTheGameOn.Timer;

namespace GameManager
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance { get; private set;}

        private GameManagerTimer m_managerTimer;
        private GameManagerGames m_managerGames;

        [SerializeField] private GameObject m_toiletPaperGame;
        [SerializeField] private GameObject m_basketballBallGame;
        [SerializeField] private Timer m_timer;
        [SerializeField] private int m_time = 90;
        public bool isStarted = false;

        private void Awake()
        {
            if (!instance)
                instance = this;
        }
        private void Start()
        {
            Application.targetFrameRate = 60;
            m_managerTimer = new GameManagerTimer(m_timer);
            m_managerGames = new GameManagerGames(m_toiletPaperGame, m_basketballBallGame);
            SetTimer();
        }
        public void SetTimer()
        {
            m_managerTimer.SetTimer(m_time);
        }
        public void StartTimer()
        {
            m_managerTimer.StartTimer();
        }
        public void RestartTimer()
        {
            m_managerTimer.RestartTimer();
        }
        public void SetGame()
        {
            m_managerGames.SetGame();
        }
        public void StartGame()
        {
            StartTimer();
            isStarted = true;
        }
        public bool CheckStarted()
        {
            return isStarted;
        }
    }
}
