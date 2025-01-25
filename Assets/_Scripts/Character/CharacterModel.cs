using _Scripts.DataModels;
using UnityEngine;

namespace _Scripts.Character
{
    public class CharacterModel
    {
        private Sprite _characterSprite;
        private Personality _personality;

        public CharacterModel(Sprite characterSprite, Personality randPersonality)
        {
            CharacterSprite = characterSprite;
            Personality = randPersonality;
        }

        public Personality Personality
        {
            get => _personality;
            set => _personality = value;
        }

        public Sprite CharacterSprite
        {
            get => _characterSprite;
            set => _characterSprite = value;
        }
    }
}