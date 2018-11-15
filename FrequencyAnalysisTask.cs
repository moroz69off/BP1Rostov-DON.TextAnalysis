using System;
using System.Collections.Generic;

namespace TextAnalysis
{
    static class FrequencyAnalysisTask
    {
        public static Dictionary<string, string> GetMostFrequentNextWords(List<List<string>> text)
        {
            Dictionary<string, string> n_gramDict = new Dictionary<string, string>();
            List<string> x2grams = new List<string>();
            if (text.Count > 0)
            {
                for (int i = 0; i < text.Count; i++)
                {
                    List<string> x2gramsTemp = Get2grams(text[i]);
                    x2grams.AddRange(x2gramsTemp);
                }
                x2grams.Sort();
            }
            return n_gramDict;
        }

        private static List<string> Get2grams(List<string> list)
        {
            List<string> x2gramsTemp = new List<string>();
            for (int i = 0; i < list.Count - 1; i++)
            {
                x2gramsTemp.Add(list[i] + " " + list[i + 1]);
            }
            return x2gramsTemp;
        }
    }
}