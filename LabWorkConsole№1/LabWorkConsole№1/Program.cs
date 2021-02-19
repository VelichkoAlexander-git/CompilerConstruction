using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LabWorkConsole_1
{
    class Program
    {
        static void Main(string[] args)
        {
            WorkOne();
            WorkTwo();
            WorkTree();
        }

        public static void WorkOne()
        {
            Console.WriteLine(Count("234567, 323452, 333, 234123,:::;; 23 423421 34 23"));
        }

        public static void WorkTwo()
        {
            string str = "2315 3jshdf sgjgfh3f7834gf8 734gf4837hf84 7fh874 74hf 8734h f873h4 8f37 jshdf ";

            Console.WriteLine(Replace(str));
        }

        public static void WorkTree()
        {
            string str = "2315 3jshdf sgjgfh3f7834gf8 734g:-f4837hf84 7fh874 74hf 8734h f873h4 8f37 jshdf ;rs:---- :::- :-";

            Console.WriteLine(CountSmiles(str));
        }

        /*
         * (Count) Написать функцию, которая определяет количество входящих в 
         * заданную строку почтовых индексов (почтовый индекс состоит из 6 цифр).
         */
        public static int Count(string postcode)
        {
            string pattern = @"\d{6}";
            Regex regex = new Regex(pattern);
            MatchCollection match = regex.Matches(postcode);
            return match.Count;
        }

        /* (Regex.Replace) Дана строка — предложение на русском языке. Поменять местами 
         * первую и последнюю буквы каждого слова. 
         */
        public static string Replace(string multiString)
        {
            string str = Regex.Replace(multiString, @"(\w)(\w+)(\w)", $"$3$2$1");
            return str;
        }

        /*
         * Дана строка. Посчитать, сколько смайликов в ней содержится. 
         * Смайликом будем считать последовательность символов, удовлетворяющую условиям:
         *  o	первым символом является либо ; (точка с запятой) либо : (двоеточие) ровно один раз
         *  o	далее может идти символ - (минус) сколько угодно раз (в том числе символ минус может идти ноль раз)
         */
        public static int CountSmiles(string str)
        {
            string pattern = @"[;|:]{1}-*";
            Regex regex = new Regex(pattern);
            MatchCollection match = regex.Matches(str);
            return match.Count;
        }
    }
}
