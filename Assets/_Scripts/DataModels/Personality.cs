using System;
using System.Collections.Generic;

namespace _Scripts.DataModels
{
    [Serializable]
    public class Personality
    {
        public string PersonalityType;
        public List<string> PositiveEffective;
        public List<string> NegativeEffective;
        public List<string> PersonalityHints;
    }
}