using FPS;
using Game.Scripts.Utils;
using UnityEngine;

namespace Game.Scripts.Common
{
    public class Randomizer : MonoBehaviour

    {
        private int[] _numbers;
        private string[] _words;
        private string _word;

        private void Start()
        {
            _numbers = new[] { 27, 0, 61, 5, 43, 9, 2, 19 };
            _words = new[] { "cat", "pet", "dog", "fish", "cow", "goat" };
            _word = "bike";

            _words.GetRandomElement();
            Debug.Log("Random int " + Random(_numbers));
            Debug.Log("Random string " + Random(_words)); 
            Debug.Log("Random char " + Random(_word.ToCharArray()));
            string word = "159ghj";
            Debug.Log(word.IsPositiveNumber());
        }

        private T Random<T>(T[] array)
        {
            int randomElement = UnityEngine.Random.Range(0, array.Length);
            return array[randomElement];
        }
    }
}