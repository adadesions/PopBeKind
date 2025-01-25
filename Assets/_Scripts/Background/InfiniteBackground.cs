using System;
using UnityEngine;

namespace _Scripts.Background
{
    public class InfiniteBackground : MonoBehaviour
    {
        public float scrollSpeed = 2f; // Speed of the scrolling
        public Transform[] backgrounds; // Array of background objects
        public float backgroundWidth; // Width of the background sprite
        [SerializeField] private float _offset;

        private void Start()
        {
            backgroundWidth = backgrounds[0].GetComponent<SpriteRenderer>().bounds.size.x;
        }

        private void Update()
        {
            // Move each background leftward
            foreach (var bg in backgrounds)
            {
                bg.position += Vector3.left * (scrollSpeed * Time.deltaTime);

                // If a background moves completely off-screen, reposition it
                if (bg.position.x <= -backgroundWidth)
                {
                    Vector3 newPos = bg.position;
                    newPos.x += backgroundWidth * backgrounds.Length + _offset; // Move to the end
                    bg.position = newPos;
                }
            }
        }
    }
}