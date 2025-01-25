using Nueng_s_Brance.Scripts.ScriptableObjects;
using UnityEngine;

namespace _Scripts.Bubble
{
    public class BubbleFactory
    {
        private readonly GameObject _bubblePrefab = Resources.Load<GameObject>("Prefabs/Bubble");

        public GameObject CreateBubble(EmojiSO emojiSO)
        {
            var bubble = Object.Instantiate(_bubblePrefab);
            var bubblePresenter = bubble.GetComponent<BubblePresenter>();
            var bubbleColor = Color.white;
            bubblePresenter.Model = new BubbleModel(emojiSO, bubbleColor);
            
            return bubble;
        }
    }
}