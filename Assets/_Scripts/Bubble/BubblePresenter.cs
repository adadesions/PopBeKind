using System;
using _Scripts.Character;
using _Scripts.Interactable;
using UnityEngine;
using UnityEngine.Events;

namespace _Scripts.Bubble
{
    public class BubblePresenter : MonoBehaviour, IInteractable
    {
        private BubbleModel _model;
        [SerializeField] private SpriteRenderer _sprite;
        
        public static event UnityAction<int> OnBubblePopped;

        public BubbleModel Model
        {
            get => _model;
            set => _model = value;
        }

        private void Start()
        {
            RenderSpriteFromModel();
        }

        private void RenderSpriteFromModel()
        {
            _sprite.color = _model.BubbleColor;
            _sprite.sprite = _model.Emoji.sprite;
        }

        public void Interact()
        {
            print("Bubble Popped");
            Destroy(gameObject);
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("HitArea"))
            {
                if (other.transform.parent.TryGetComponent<CharacterPresenter>(out var characterPresenter))
                {
                    var score = characterPresenter.CheckBubbleScore(_model.Emoji.name);
                    OnBubblePopped?.Invoke(score);
                    print($"Score: {score} from {_model.Emoji.name}");
                }
                
                // Destroy the bubble when it reaches the target
                Destroy(gameObject);
            }
        }
    }
}