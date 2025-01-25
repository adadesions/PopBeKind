using TMPro;
using UnityEngine;

namespace _Scripts.Character
{
    public class CharacterView : MonoBehaviour
    {
        [SerializeField] private TextMeshPro _personalityText;

        public void SetPersonality(string personalityPersonalityType)
        {
            _personalityText.text = personalityPersonalityType;
        }
    }
}