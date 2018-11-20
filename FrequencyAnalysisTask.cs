using System;
using System.Collections.Generic;

namespace TextAnalysis
{
    static class FrequencyAnalysisTask
    {
        private static bool mue;

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

            List<KeyValuePair<string, string>> keyValuePairs = new List<KeyValuePair<string, string>>();

            for (int i = 0; i < keys.Count; i++)
            {
                keyValuePairs.Add(new KeyValuePair<string, string>(keys[i].Substring(0, keys[i].LastIndexOf(' ')), 
                    keys[i].Substring(keys[i].LastIndexOf(' '))));
                if (Mue(i, keys, frequence, keyValuePairs))
                {
                    //пара отправляется в ответ
                }
            }
            return result;
        }

        private static bool Mue(int i,
            List<string>keys, 
            Dictionary<string, int> frequence, 
            List<KeyValuePair<string, string>> kvp)
        {// Условие для пары key-value: 
         // Одинаковые начала есть, но этих концов больше. 
         // Или: одинаковые начала есть, и концов одинаково, но конец меньше в строю. 
         // Или: таких начал больше нет.

            string keyCondidat = keys[i];
            int fr = frequence[keyCondidat];
            bool hiFreq = CompareFreq(i,keys,frequence,kvp);
            if (!
                (i==0)
                )
                return true;
            else  return false; 
        }

        private static bool CompareFreq(int i, 
            List<string> keys, 
            Dictionary<string, int> frequence, 
            List<KeyValuePair<string, string>> kvp)
        {
            string start = keys[i].Split()[0];
            List<string> list = new List<string>();
            for (int j = 0; j < keys.Count; j++)
                if (keys[j].Split()[0] == keys[i].Split()[0])
                    list.Add(keys[j]);
            for (int j = 0; j < list.Count; j++)
                if (frequence[keys[i]] > frequence[list[j]])
                    list.Remove(keys[i]); // список одинаковых началов для i-того члена
            return true;
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
        //---------------------------------------------------------------------wcido?
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