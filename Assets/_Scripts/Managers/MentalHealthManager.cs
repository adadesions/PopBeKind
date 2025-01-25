using System;
using _Scripts.Bubble;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

namespace _Scripts.Managers
{
    public class MentalHealthManager : MonoBehaviour
    {
        [SerializeField] private int _totalScore;
        private int _starterScore;
        private MentalHealthView _view;
        [SerializeField] private int _minValue = -100;
        [SerializeField] private int _maxValue = 100;
        
        // Events
        public static event UnityAction OnWin;
        public static event UnityAction OnLose;

        private void Awake()
        {
            _view = GetComponent<MentalHealthView>();
            
            BubblePresenter.OnBubblePopped += ChangeScore;
        }

        private void OnDestroy()
        {
            BubblePresenter.OnBubblePopped -= ChangeScore;
        }

        private void Start()
        {
            _starterScore = Random.Range(-60, 61);
            _totalScore = _starterScore;
            _view.UpdateScore(_totalScore);
        }
        
        private void CheckWinLoseCondition()
        {
            if (_totalScore >= _maxValue)
            {
                OnWin?.Invoke();
            }
            else if (_totalScore <= _minValue)
            {
                OnLose?.Invoke();
            }
        }

        private void ChangeScore(int score)
        {
            _totalScore += score;
            _totalScore = Math.Clamp(_totalScore, _minValue, _maxValue);
            
            _view.UpdateScore(_totalScore);
            CheckWinLoseCondition();
        }
        
    }
}