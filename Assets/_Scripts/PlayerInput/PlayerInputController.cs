using _Scripts.Interactable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace _Scripts.PlayerInput
{
    public class PlayerInputController : MonoBehaviour
    {
        // Events
        public UnityEvent OnInteracted;
        
        public void OnMouseDownOrTouchDown()
        {
            // Get the position of the mouse click or touch
            var pointerPos = Pointer.current.position.ReadValue();
            var worldPosition = Camera.main.ScreenToWorldPoint(pointerPos);
            
            // Set the z position to 0
            worldPosition.z = 0;
            
            
            var hitCollider = Physics2D.OverlapPoint(worldPosition);
            
            if (hitCollider != null && hitCollider.TryGetComponent<IInteractable>(out var interactable))
            {
                interactable.Interact();
                OnInteracted?.Invoke();
            }
        }
    }
}