using System.Linq;
using System.Text;

namespace UrlShortener
{
    public class UrlShorteningService
    {
        private const string Alphabet = "23456789bcdfghjkmnpqrstvwxyzBCDFGHJKLMNPQRSTVWXYZ-_";

        public string Encode(int num)
        {
            var sb = new StringBuilder();
            while (num > 0)
            {
                sb.Insert(0, Alphabet.ElementAt(num % Alphabet.Length));
                num = num / Alphabet.Length;
            }
            return sb.ToString();
        }

        public int Decode(string str)
        {
            var num = 0;
            for (var i = 0; i < str.Length; i++)
            {
                num = num * Alphabet.Length + Alphabet.IndexOf(str.ElementAt(i));
            }
            return num;
        }
    }
}
