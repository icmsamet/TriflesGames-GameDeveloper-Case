using TurnTheGameOn.Timer;

namespace GameManager
{
    public class GameManagerTimer
    {
        private Timer m_timer;

        public GameManagerTimer(Timer _timer)
        {
            m_timer = _timer;
        }
        public void SetTimer(int value)
        {
            m_timer.startTime = value;
        }
        public void StartTimer()
        {
            m_timer.StartTimer();
        }
        public void RestartTimer()
        {
            m_timer.RestartTimer();
        }
    }
}
