using System;
using UnityEngine;

namespace _Scripts.Managers
{
    public class GameManagerView : MonoBehaviour
    {
        [SerializeField] private GameObject _winningScreen;
        [SerializeField] private GameObject _losingScreen;

        private void Awake()
        {
            _winningScreen.SetActive(false);
            _losingScreen.SetActive(false);
        }

        public void ShowWinScreen()
        {
            _winningScreen.SetActive(true);
        }

        public void ShowLoseScreen()
        {
            _losingScreen.SetActive(true);
        }
    }
}