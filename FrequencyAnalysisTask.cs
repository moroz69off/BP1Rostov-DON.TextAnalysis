using System;
using System.Collections.Generic;

namespace TextAnalysis
{
    internal static class FrequencyAnalysisTask
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