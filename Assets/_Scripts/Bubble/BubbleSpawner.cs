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
            foreach (var emoji in _emojisList)
            {
                if (stringEmojiScopeList.Contains(emoji.name))
                {
                    _emojiScopeList.Add(emoji);
                }
            }
        }

        private IEnumerator BubbleGenerator()
        {
            while (true)
            {
                for (var i = 0; i < 3; i++)
                {
                    var randomEmoji = _emojiScopeList[Random.Range(0, _emojiScopeList.Count)];
                    var bubble = _bubbleFactory.CreateBubble(randomEmoji);
                }

                yield return new WaitForSeconds(Random.Range(1, 5));
            }
        }
    }
}