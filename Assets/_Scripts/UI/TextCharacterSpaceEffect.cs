using DG.Tweening;
using TMPro;
using UnityEngine;
// Import TextMeshPro namespace

// Import DoTween namespace

namespace _Scripts.UI
{
    public class TextCharacterSpaceEffect : MonoBehaviour
    {
        public TextMeshProUGUI textComponent; // Assign your TextMeshPro component in the Inspector
        public float waveHeight = 10f; // Height of the wave
        public float waveSpeed = 2f; // Speed of the wave
        public float characterDelay = 0.1f; // Delay between characters in the wave

        private void Start()
        {
            if (textComponent == null)
            {
                textComponent = GetComponent<TextMeshProUGUI>();
            }

            StartWaveAnimation();
        }

        void StartWaveAnimation()
        {
            // Get the number of characters in the text
            textComponent.ForceMeshUpdate(); // Ensure text data is up-to-date
            int characterCount = textComponent.textInfo.characterCount;

            for (int i = 0; i < characterCount; i++)
            {
                AnimateCharacter(i);
            }
        }

        void AnimateCharacter(int index)
        {
            // Animate each character's Y offset in a sinusoidal wave
            float initialDelay = index * characterDelay; // Delay for staggered wave effect

            DOVirtual.Float(0, 1, waveSpeed, value =>
            {
                textComponent.ForceMeshUpdate(); // Refresh text info
                var textInfo = textComponent.textInfo;

                if (index >= textInfo.characterCount) return;

                var charInfo = textInfo.characterInfo[index];
                if (!charInfo.isVisible) return; // Skip invisible characters

                int vertexIndex = charInfo.vertexIndex;
                var vertices = textInfo.meshInfo[charInfo.materialReferenceIndex].vertices;

                float waveOffset = Mathf.Sin((Time.time + initialDelay) * Mathf.PI * waveSpeed) * waveHeight;

                // Modify vertices for the character
                for (int j = 0; j < 4; j++)
                {
                    vertices[vertexIndex + j].y += waveOffset;
                }

                // Update the text mesh with new vertex positions
                textComponent.UpdateVertexData(TMP_VertexDataUpdateFlags.Vertices);
            }).SetLoops(-1, LoopType.Restart); // Loop the animation infinitely
        } 
    }
}