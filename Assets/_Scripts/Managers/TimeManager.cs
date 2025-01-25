using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace _Scripts.Managers
{
    public class TimeManager : MonoBehaviour
    {
        [SerializeField] private float _startTimeInSeconds = 60.0f;
        
        [Header("View")]
        [SerializeField] private TextMeshProUGUI _timeText;
        
        private float _currentTimeInSeconds;
        
        [Header("Events")]
        public UnityEvent OnTimeUp;

        private void Start()
        {
            _currentTimeInSeconds = _startTimeInSeconds;
            StartCoroutine(Countdown());
        }

        private IEnumerator Countdown()
        {
            while (_currentTimeInSeconds > 0)
            {
                _currentTimeInSeconds -= 1;
                // Display the time as mm:ss and zero lead the single digit seconds
                _timeText.text = $"{(int)_currentTimeInSeconds / 60:00}:{(int)_currentTimeInSeconds % 60:00}";
                yield return new WaitForSeconds(1);
            }
            
            OnTimeUp?.Invoke();
        }
    }
}