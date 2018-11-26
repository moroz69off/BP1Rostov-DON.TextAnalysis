using System;
using System.Collections.Generic;
// Условие для пары key-value: 
// Одинаковые начала есть, но этих концов больше. 
// Или: одинаковые начала есть, и концов одинаково, но конец меньше в строю. 
// Или: таких начал больше нет.
namespace TextAnalysis
{
    public class Frequency
    {
        public string start, and;
        public int count;
        public bool isResult;

        public Frequency(string start, string and, int count)
        {
            this.start = start;
            this.and = and;
            this.count = count;
        }

        public KeyValuePair<string, string> FrequencyElement(string start)
        {
            KeyValuePair<string, string> kvp = new KeyValuePair<string, string>();
            return kvp;
        }
    }

    static class FrequencyAnalysisTask
    {
        public static Dictionary<string, string> GetMostFrequentNextWords(List<List<string>> text)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
                //"a": "b"
                //"b": "c"
                //"c": "d"
                //"e": "b"
                //"a b": "c"
                //"b c": "d"
                //"e b": "c"
                //"c a": "d"
                //------------
                //{[a b, 1]}
                //{[a d, 1]}
                //{[b c, 3]}
                //{[c a, 1]}
                //{[c d, 2]}
                //{[e b, 1]}
                //{[a b c, 1]}
                //{[b c a, 1]}
                //{[b c d, 2]}
                //{[c a d, 1]}
                //{[e b c, 1]}
            return result;
        }

        //=====================================================================
        private static List<string> Get3gramas(List<List<string>> text)
        {
            List<string> res = new List<string>();
            foreach (var item in text)
            {
                for (int i = 0; i < item.Count - 2; i++)
                    res.Add(item[i] + " "
                        + item[i + 1] + " "
                        + item[i + 2]);
            }
            res.Sort();
            return res;
        }

        private static List<string> GetNgramas(List<List<string>> text, int n)
        {
            List<string> res = new List<string>();
            foreach (var item in text)
            {
                for (int i = 1; i < item.Count - 1; i++)
                {

                }
            }
            res.Sort();
            return res;
        }

        private static List<string> Get2gramas(List<List<string>> text)
        {
            List<string> res = new List<string>();
            foreach (var item in text)
            {
                for (int i = 0; i < item.Count - 1; i++)
                    res.Add(item[i] + " "
                        + item[i + 1]);
            }
            res.Sort();
            return res;
        }
        //=====================================================================
    }
}