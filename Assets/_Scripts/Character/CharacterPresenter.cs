using System;
using System.Collections.Generic;
using _Scripts.JsonTools;
using Nueng_s_Brance.Scripts.ScriptableObjects;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Scripts.Character
{
    public class CharacterPresenter : MonoBehaviour
    {
        private CharacterModel _model;
        [SerializeField] private List<Sprite> _characterSpriteList;
        [SerializeField] private string _personalityJsonPath;
        private SpriteRenderer _sprite;
        private CharacterView _view;

        private void Awake()
        {
            _view = GetComponent<CharacterView>();
            _sprite = GetComponent<SpriteRenderer>();
            SetupCharacterModel();
        }

        private void Start()
        {
            _view.SetPersonality(_model.Personality.PersonalityType);
        }

        private void SetupCharacterModel()
        {
            var characterSprite = _characterSpriteList[Random.Range(0, _characterSpriteList.Count)];
            var personalityData = JsonReader.LoadPersonalityJson(_personalityJsonPath);
            var randPersonality = personalityData[Random.Range(0, personalityData.Count)];
            _model = new CharacterModel(characterSprite, randPersonality);
            _sprite.sprite = _model.CharacterSprite;
            print(_model.Personality.PersonalityType);
        }

        public int CheckBubbleScore(string emojiName)
        {
            return _model.Personality.PositiveEffective.Contains(emojiName) ? 10 :
                _model.Personality.NegativeEffective.Contains(emojiName) ? -10 : 0;
        }

        public List<string> GetEmojiScopeList()
        {
            var emojiScopeList = new List<string>();
            foreach (var emojiName in _model.Personality.PositiveEffective)
            {
                emojiScopeList.Add(emojiName);
            }

            foreach (var emojiName in _model.Personality.NegativeEffective)
            {
                emojiScopeList.Add(emojiName);
            }

            return emojiScopeList;
        }
    }
}