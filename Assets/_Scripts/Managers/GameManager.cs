using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Scripts.Managers
{
    public class GameManager : MonoBehaviour
    {
        private GameManagerView _view;

        private void Awake()
        {
            _view = GetComponent<GameManagerView>();
            MentalHealthManager.OnWin += WinGame;
            MentalHealthManager.OnLose += LoseGame;
        }

        private void OnDestroy()
        {
            MentalHealthManager.OnWin -= WinGame;
            MentalHealthManager.OnLose -= LoseGame;
        }

        private void StopTime()
        {
            Time.timeScale = 0;
        }

        private void WinGame()
        {
            StopTime();
            _view.ShowWinScreen();
        }

        private void LoseGame()
        {
            StopTime();
            _view.ShowLoseScreen();
        }
        
        public void RestartGame()
        {
            Time.timeScale = 1;
            
            // Reload the current scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}