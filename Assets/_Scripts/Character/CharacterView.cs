using System;
using TMPro;
using UnityEngine;

namespace _Scripts.Character
{
    public class CharacterView : MonoBehaviour
    {
        [SerializeField] private TextMeshPro _personalityText;
        [SerializeField] private GameObject _goodFeelingBubble;
        [SerializeField] private GameObject _badFeelingBubble;
        [SerializeField] private float _cooldown = 1.0f;

        private float _lastTimeShowFeeling;

        private void Start()
        {
            _goodFeelingBubble.SetActive(false);
            _badFeelingBubble.SetActive(false);
        }

        private void Update()
        {
            if (Time.time > _lastTimeShowFeeling + _cooldown)
            {
                _goodFeelingBubble.SetActive(false);
                _badFeelingBubble.SetActive(false);
            }
        }

        public void ShowGoodFeeling()
        {
            _lastTimeShowFeeling = Time.time;
            _badFeelingBubble.SetActive(false);
            _goodFeelingBubble.SetActive(true);
        }

        public void ShowBadFeeling()
        {
            _lastTimeShowFeeling = Time.time;
            _goodFeelingBubble.SetActive(false);
            _badFeelingBubble.SetActive(true);
        }

        public void SetPersonality(string personalityPersonalityType)
        {
            _personalityText.text = personalityPersonalityType;
        }
    }
}