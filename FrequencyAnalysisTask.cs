using System;
using System.Collections.Generic;

namespace TextAnalysis
{
    static class FrequencyAnalysisTask
    {
        public static Dictionary<string, string> GetMostFrequentNextWords(List<List<string>> text)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            Dictionary<string, int> frequence = new Dictionary<string, int>();

            List<string> allx2gramas = new List<string>(Get2gramas(text));
            
            foreach (var item in allx2gramas)
            {
                if (!frequence.ContainsKey(item))
                    frequence.Add(item, 1);
                else
                    frequence[item]++;
            }

            List<string> allx3gramas = new List<string>(Get3gramas(text));

            foreach (var item in allx3gramas)
            {
                if (!frequence.ContainsKey(item))
                    frequence.Add(item, 1);
                else
                    frequence[item]++;
            }

            List<string> keys = new List<string>(frequence.Keys);

            for (int i = 0; i < keys.Count - 1; i++)
            {
                if (
                    true // Условие для пары key-value: одинаковые начала есть но концов больше. Или одинаковые начала есть и концов динаково но конец старше. Или таких начал больше нет.
                    )
                {
                    // и начало и конец отправляется в ответ
                }
            }
            return result;
        }

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

        private static List<string> Get2gramas(List<List<string>> text)
        {
            List<string> res = new List<string>();
            foreach (var item in text)
            {
                for (int i = 0; i < item.Count - 1; i++)
                    res.Add(item[i] + " " + item[i + 1]);
            }
            res.Sort();
            return res;
        }
    }
}