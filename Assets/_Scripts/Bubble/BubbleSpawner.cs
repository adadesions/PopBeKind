using System;
using System.Collections;
using System.Collections.Generic;
using Nueng_s_Brance.Scripts.ScriptableObjects;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Scripts.Bubble
{
    public class BubbleSpawner : MonoBehaviour
    {
        [SerializeField] private List<EmojiSO> _emojisList = new();
        
        private BubbleFactory _bubbleFactory;

        private void Awake()
        {
            _bubbleFactory = new BubbleFactory();

            StartCoroutine(BubbleGenerator());
        }

        private IEnumerator BubbleGenerator()
        {
            while (true)
            {
                for (var i = 0; i < 3; i++)
                {
                    var randomEmoji = _emojisList[Random.Range(0, _emojisList.Count)];
                    var bubble = _bubbleFactory.CreateBubble(randomEmoji);
                }

                yield return new WaitForSeconds(Random.Range(1, 5));
            }
        }
    }
}