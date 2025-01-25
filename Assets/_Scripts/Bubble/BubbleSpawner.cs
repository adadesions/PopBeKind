using System;
using System.Collections;
using System.Collections.Generic;
using _Scripts.Character;
using Nueng_s_Brance.Scripts.ScriptableObjects;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Scripts.Bubble
{
    public class BubbleSpawner : MonoBehaviour
    {
        [SerializeField] private List<EmojiSO> _emojisList = new();
        
        private BubbleFactory _bubbleFactory;
        private CharacterPresenter _characterPresenter;
        private List<EmojiSO> _emojiScopeList = new();
        [SerializeField] private int _bubbleAmountPerRound = 3;

        private void Awake()
        {
            _bubbleFactory = new BubbleFactory();
        }

        private void Start()
        {
            _characterPresenter = FindFirstObjectByType<CharacterPresenter>();
            CreateEmojiScopeList();
            StartCoroutine(BubbleGenerator());
        }

        private void CreateEmojiScopeList()
        {
            var stringEmojiScopeList = _characterPresenter.GetEmojiScopeList();
            
            // Add Positive and Negative Effective Emoji to EmojiScopeList first
            foreach (var emoji in _emojisList)
            {
                if (stringEmojiScopeList.Contains(emoji.name))
                {
                    _emojiScopeList.Add(emoji);
                }
            }
            
            // Randomly add other 2 emojis to EmojiScopeList
            var count = 0;
            while (count < 2)
            {
                var randomEmoji = _emojisList[Random.Range(0, _emojisList.Count)];
                if (_emojiScopeList.Contains(randomEmoji)) continue;
                _emojiScopeList.Add(randomEmoji);
                count++;
            }
        }

        private IEnumerator BubbleGenerator()
        {
            while (true)
            {
                var randBubbleAmount = Random.Range(1, _bubbleAmountPerRound + 1);
                for (var i = 0; i < randBubbleAmount; i++)
                {
                    var randomEmoji = _emojiScopeList[Random.Range(0, _emojiScopeList.Count)];
                    _bubbleFactory.CreateBubble(randomEmoji);
                }

                yield return new WaitForSeconds(Random.Range(1, 5));
            }
        }
    }
}