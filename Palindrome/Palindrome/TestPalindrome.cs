using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palindrome
{
    public static class TestPalindrome
    {
        public static bool IsPalyndrome(string s)
        {
            ReverseWord(s, out string word);
            return s.ToLower() == word ? true : false;
        }

        private static void ReverseWord(string s, out string word)
        {
            Stack<char> letters = new Stack<char>();
            Stack<char> spaces = new Stack<char>();
            Queue<int> lettersAmmount = new Queue<int>();
            int symbols = 0;

            s = s.ToLower();

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == ' ')
                {
                    spaces.Push(s[i]);
                    lettersAmmount.Enqueue(symbols);
                    symbols = 0;
                    continue;
                }

                if (i == s.Length - 1)
                {
                    lettersAmmount.Enqueue(symbols);
                }

                symbols++;
                letters.Push(s[i]);
            }


            StringBuilder builder = new StringBuilder();

            for (int i = letters.Count; i > 0; i--)
            {
                builder.Append(letters.Pop());
            }

            int index = 0;

            foreach (var space in spaces)
            {
                index += lettersAmmount.Dequeue();
                builder.Insert(index, space);
                index++;
            }

            word = builder.ToString();
        }
    }
}
