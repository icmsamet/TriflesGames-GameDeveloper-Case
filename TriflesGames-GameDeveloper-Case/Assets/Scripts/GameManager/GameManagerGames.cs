using UnityEngine;

namespace GameManager
{
    public class GameManagerGames
    {
        private GameObject m_toiletPaperGame;
        private GameObject m_basketballBallGame;

        public GameManagerGames(GameObject _toiletPaperGame,GameObject _basketballBallGame)
        {
            m_toiletPaperGame = _toiletPaperGame;
            m_basketballBallGame = _basketballBallGame;
        }

        public void SetGame()
        {
            m_toiletPaperGame.SetActive(!m_toiletPaperGame.activeSelf);
            m_basketballBallGame.SetActive(!m_basketballBallGame.activeSelf);
        }
    }
}
