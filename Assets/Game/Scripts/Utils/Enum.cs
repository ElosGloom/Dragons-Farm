using Random = UnityEngine.Random;


namespace Game.Scripts.Utils
{
    public static class Enum
    {
        public static T GetRandom<T>()
        {
            var values = System.Enum.GetValues(typeof(T));
            var random = Random.Range(0, values.Length);
            var randomElement = (T)values.GetValue(random);

            return randomElement;
        }
    }
}