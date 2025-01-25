using UnityEngine;

namespace TitleScene.Scripts
{
    public class NpcPresenter : MonoBehaviour
    {
        private Animator animator;
        private float minStateTime = 2f; // Minimum time to stay in a state
        private float maxStateTime = 5f; // Maximum time to stay in a state
        private float stateTimer;

        // Animation state names from your diagram
        private string[] animationStates = new string[]
        {
            "Idle",
            "IdleLazy",
            "IdlePhone",
            "PlayPhone",
            "LookHand"
        };

        private void Start()
        {
            animator = GetComponent<Animator>();
            SetRandomTimer();
        }

        private void Update()
        {
            if (stateTimer <= 0)
            {
                PlayRandomAnimation();
                SetRandomTimer();
            }

            stateTimer -= Time.deltaTime;
        }

        private void PlayRandomAnimation()
        {
            // Get a random animation state from the array
            string randomState = animationStates[Random.Range(0, animationStates.Length)];
        
            // Play the random animation
            animator.CrossFade(randomState, 0.25f); // 0.25f is the transition time, adjust as needed
        }

        private void SetRandomTimer()
        {
            stateTimer = Random.Range(minStateTime, maxStateTime);
        }
    }
}