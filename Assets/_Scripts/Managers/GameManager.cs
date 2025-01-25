using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace _Scripts.Managers
{
    public class GameManager : MonoBehaviour
    {
        private GameManagerView _view;
        
        // Events
        public UnityEvent OnWin;
        public UnityEvent OnLose;

        private void Awake()
        {
            _view = GetComponent<GameManagerView>();
            MentalHealthManager.OnWin += WinGame;
            MentalHealthManager.OnLose += LoseGame;
        }

        private void Start()
        {
            StopTime();
        }

        private void OnDestroy()
        {
            MentalHealthManager.OnWin -= WinGame;
            MentalHealthManager.OnLose -= LoseGame;
        }
        
        public void StartGame()
        {
            Time.timeScale = 1;
        }

        private void StopTime()
        {
            Time.timeScale = 0;
        }

        private void WinGame()
        {
            StopTime();
            _view.ShowWinScreen();
            OnWin?.Invoke();
        }

        private void LoseGame()
        {
            StopTime();
            _view.ShowLoseScreen();
            OnLose?.Invoke();
        }
        
        public void RestartGame()
        {
            Time.timeScale = 1;
            
            // Reload the current scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void ExitGameplay()
        {
            Time.timeScale = 1;
            
            // Load the main menu scene
            SceneManager.LoadScene(0);
        }
    }
}