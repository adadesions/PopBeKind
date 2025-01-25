using System;
using _Scripts.Bubble;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Scripts.Managers
{
    public class MentalHealthManager : MonoBehaviour
    {
        [SerializeField] private int _totalScore;
        private int _starterScore;
        private MentalHealthView _view;

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

        public void ChangeScore(int score)
        {
            _totalScore += score;
            _view.UpdateScore(_totalScore);
        }
        
    }
}