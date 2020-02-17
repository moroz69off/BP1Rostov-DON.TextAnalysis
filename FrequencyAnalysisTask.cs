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

    static class FrequencyAnalysisTask
    {
        public static Dictionary<string, string> GetMostFrequentNextWords(List<List<string>> text)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            Dictionary<string, int> frequency = new Dictionary<string, int>();
            List<string> allx2gramas = new List<string>(Get2gramas(text));
            foreach (var item in allx2gramas)
            {
                if (!frequency.ContainsKey(item))
                    frequency.Add(item, 1);
                else
                    frequency[item]++;
            }
            List<string> allx3gramas = new List<string>(Get3gramas(text));
            foreach (var item in allx3gramas)
            {
                if (!frequency.ContainsKey(item))
                    frequency.Add(item, 1);
                else
                    frequency[item]++;
            }
            for (int i = 0; i < frequency.Count; i++)
            {

            }

            return result;
        }

        private static List<string> Get3gramas(List<List<string>> text)
        {
            List<string> result = new List<string>();
            foreach (var item in text)
            {
                for (int i = 0; i < item.Count - 2; i++)
                    result.Add(item[i] + " "
                        + item[i + 1] + " "
                        + item[i + 2]);
            }
            result.Sort();
            return result;
        }

        private static List<string> Get2gramas(List<List<string>> text)
        {
            List<string> result = new List<string>();
            foreach (var item in text)
            {
                for (int i = 0; i < item.Count - 1; i++)
                    result.Add(item[i] + " "
                        + item[i + 1]);
            }
            result.Sort();
            return result;
        }
    }
}
