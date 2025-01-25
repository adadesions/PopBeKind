using Nueng_s_Brance.Scripts.ScriptableObjects;
using UnityEngine;

namespace _Scripts.Bubble
{
    public class BubbleModel
    {
        private readonly EmojiSO _emojiSO;
        public Color BubbleColor { get; set; }

        public EmojiSO Emoji => _emojiSO;

        public BubbleModel(EmojiSO emojiSO, Color color)
        {
            _emojiSO = emojiSO;
            BubbleColor = color;
        }

    }
}