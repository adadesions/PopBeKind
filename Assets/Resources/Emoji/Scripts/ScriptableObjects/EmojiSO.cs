using UnityEngine;

namespace Nueng_s_Brance.Scripts.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Create EmojiSO", fileName = "EmojiSO")]
    public class EmojiSO : ScriptableObject
    {
        public int idx;
        public Sprite sprite;
        public string name;
    }
}
