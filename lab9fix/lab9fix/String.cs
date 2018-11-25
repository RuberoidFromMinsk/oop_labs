using System;
namespace lab9fix
{
	partial class Program
	{
		public static string DeleteCommas(string s)
        {
            int j = 0;
            char[] str = new char[s.Length];
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] != ',')
                {
                    str[j] = s[i];
                    j++;
                }
            }
            s = "";
            for (int i = 0; i < str.Length; i++)
            {
                s += str[i];
            }

            return s;
        }
        public static string UpperCase(string s)
        {
            return s.ToUpper();
        }
        public static string DeleteProbel(string s)
        {
            int j = 0;
            char[] str = new char[s.Length];
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] != ' ')
                {
                    str[j] = s[i];
                    j++;
                }
            }
            s = "";
            for (int i = 0; i < str.Length; i++)
            {
                s += str[i];

            }

            return s;
        }
        public static string DeleteLetterL(string s)
        {
            int j = 0;
            char[] str = new char[s.Length];
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] != 'L')
                {
                    str[j] = s[i];
                    j++;
                }
            }
            s = "";
            for (int i = 0; i < str.Length; i++)
            {
                s += str[i];

            }

            return s;
        }
        public static void AddPoint(string s)
        {
            Console.WriteLine("." + s);
        }
	}

}
