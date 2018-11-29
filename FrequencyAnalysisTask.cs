using System;
using System.Collections.Generic;
// Условие для пары key-value: 
// Одинаковые начала есть, но этих концов больше. 
// Или: одинаковые начала есть, и концов одинаково, но конец меньше в строю. 
// Или: таких начал больше нет.
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
namespace TextAnalysis
{
    public class Frequency
    {
        public string start, and;
        public int count;
        public bool isResult;


    }

    static class FrequencyAnalysisTask
    {
        public static Dictionary<string, string> GetMostFrequentNextWords(List<List<string>> text)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
			Dictionary<string, int> frequence = new Dictionary<string, int>();
			List<string> listGramas = GetGramas(text);

			foreach (var item in listGramas)
			{
				if (!frequence.ContainsKey(item))
					frequence.Add(item, 1);
				else
					frequence[item]++;
			}
			string[] str = new string[frequence.Count];
			frequence.Keys.CopyTo(str, 0);
			int[] n = new int[frequence.Count];
			frequence.Values.CopyTo(n, 0);

			Frequency[] frs = new Frequency[frequence.Count];
			for (int i = 0; i < frs.Length; i++)
			{
					frs[i] = new Frequency();
					frs[i].start = str[i].Substring(str[i].LastIndexOf(" "));
					frs[i].and = str[i].Substring(0, str[i].LastIndexOf(" "));
					frs[i].count = n[i];
			}

//-----------------------------------------------------------

			//string[] s = new string[frs.Length];
			//for (int i = 0; i < frs.Length; i++)
			//	s[i] = str[i] + " \t " + n[i].ToString();
			//System.IO.File.WriteAllLines("ffff.txt", s);
			
//-----------------------------------------------------------
			
			return result;
        }

        private static List<string> GetGramas(List<List<string>> text)
        {
            List<string> res = new List<string>();
            foreach (var item in text)
            {
                for (int i = 1; i < item.Count - 1; i++)
                {
                    res.Add(item[i - 1] + " " + item[i]);
                    res.Add(item[i - 1] + " " + item[i] + " " + item[i + 1]);
                }
				if (item.Count > 1)
					res.Add(item[item.Count - 2] + " " + item[item.Count - 1]);
            }
            res.Sort();
            return res;
        }
    }
}
