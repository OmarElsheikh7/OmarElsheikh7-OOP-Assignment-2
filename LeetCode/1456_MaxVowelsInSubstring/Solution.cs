using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class Solution
    {

        public bool IsVowel(char a)
        {
            switch (a)
            {
                case 'a':
                case 'A':
                case 'i':
                case 'I':
                case 'o':
                case 'O':
                case 'u':
                case 'U':
                case 'e':
                case 'E': return true;
                default:
                    return false;

            }
        }

        public int MaxVowels(string s, int k)
        {
            int windowmax = 0;
            int window = 0;

            for (int i = 0; i < k-1; i++)
            {
                if (IsVowel(s[i]))
                    window++;


            }

            windowmax = window;

            for (int i = k;i<s.Length;i++)
            {

                if (IsVowel(s[i]))
                {
                    window++;
                }

                if (IsVowel(s[i - k]))
                {
                    window--;
                }

                if (window > windowmax)
                {
                    windowmax = window;
                }

            }


            return windowmax;

        }



    }
}
