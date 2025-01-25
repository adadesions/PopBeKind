using System.Collections.Generic;
using System.IO;
using _Scripts.DataModels;
using UnityEngine;

namespace _Scripts.JsonTools
{
    public class JsonReader
    {
        public static List<Personality> LoadPersonalityJson(string fileName)
        {
            TextAsset jsonText = Resources.Load<TextAsset>(fileName);
            if (jsonText == null) return null;
            var json = jsonText.text;
            var personalities = JsonUtility.FromJson<Personalities>("{\"PersonalityTypes\":" + json + "}");
            return personalities.PersonalityTypes;

            // Get the file path
            // string filePath = Path.Combine(Application.streamingAssetsPath, fileName);
            //
            // if (File.Exists(filePath))
            // {
            //     // Read the JSON file
            //     string jsonContent = File.ReadAllText(filePath);
            //
            //     // Parse the JSON into the PersonalityData object
            //     var personalities = JsonUtility.FromJson<Personalities>("{\"PersonalityTypes\":" + jsonContent + "}");
            //
            //     // Example: Print all personality types
            //     // foreach (var type in personalities.PersonalityTypes)
            //     // {
            //     //     Debug.Log($"Personality Type: {type.PersonalityType}");
            //     //     Debug.Log($"Positive Effective: {string.Join(", ", type.PositiveEffective)}");
            //     //     Debug.Log($"Negative Effective: {string.Join(", ", type.NegativeEffective)}");
            //     //     Debug.Log($"Hints: {string.Join(" | ", type.PersonalityHints)}");
            //     // }
            //
            //     return personalities.PersonalityTypes;
            // }
            // else
            // {
            //     Debug.LogError("JSON file not found: " + filePath);
            // }

        }
    }
}