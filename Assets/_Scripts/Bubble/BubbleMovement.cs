using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Scripts.Bubble
{
    public class BubbleMovement : MonoBehaviour
    {
        [SerializeField] private float approachSpeed = 2f; // Speed at which the radius decreases
        [SerializeField] private float initialRadius = 5f; // Starting radius of the orbit

        [Header("Min and Max Orbit Speed")]
        [SerializeField] private float minOrbitSpeed = 1f;
        [SerializeField] private float maxOrbitSpeed = 2f;
        
        private Transform target;         // The target point
        private float orbitSpeed = 5f;    // Speed of the circular movement
        private float angle = 0f;        // Current angle of the orbit
        private Vector3 center;          // Center of the orbit
        private float radius;            // Current radius of the orbit

        void Start()
        {
            target = GameObject.FindWithTag("HitArea").transform;
            
            // Set the initial center and radius
            center = target.position;
            radius = initialRadius;
            angle = Random.Range(0, 2 * Mathf.PI);
            
            // Random Orbit Speed
            orbitSpeed = Random.Range(minOrbitSpeed, maxOrbitSpeed);
        }

        void Update()
        {
            OrbitalMove();
        }

        private void OrbitalMove()
        {
            if (radius > 0.1f)
            {
                // Calculate the next position in the orbit
                angle += orbitSpeed * Time.deltaTime;
                float x = Mathf.Cos(angle) * radius;
                float y = Mathf.Sin(angle) * radius;

                // Move the center of the orbit closer to the target
                center = Vector3.MoveTowards(center, target.position, approachSpeed * Time.deltaTime);

                // Update the position of the object
                transform.position = center + new Vector3(x, y, 0);

                // Gradually reduce the radius to approach the target
                radius = Mathf.Lerp(radius, 0, approachSpeed * Time.deltaTime);
            }
            else
            {
                // Snap to the target once the radius is small enough
                transform.position = target.position;
            }
        }
    }
}
