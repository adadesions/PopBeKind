using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.Managers
{
    public class MentalHealthView : MonoBehaviour
    {
        [SerializeField] private Slider _slider;

        public void UpdateScore(int totalScore)
        {
            _slider.value = totalScore;
        }
    }
}