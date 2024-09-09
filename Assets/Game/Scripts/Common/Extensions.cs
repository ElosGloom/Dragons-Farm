
namespace Game.Scripts.Common
{
    public static class Extensions
    {
        public static bool IsPositiveNumber(this string str)
        {
            int number;
            if (int.TryParse(str, out number))
            {
                if (number >= 0)
                {
                    return true;
                }
            }

            return false;
        }
    }
}