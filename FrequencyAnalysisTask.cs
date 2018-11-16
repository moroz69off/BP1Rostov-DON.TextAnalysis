using System;
using System.Collections.Generic;

namespace TextAnalysis
{
    static class FrequencyAnalysisTask
    {
        public static Dictionary<string, string> GetMostFrequentNextWords(List<List<string>> text)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            List<KeyValuePair<string, string>> listKeyValuePair = new List<KeyValuePair<string, string>>();
            List<string> nGramas = new List<string>();
            if (text.Count > 0)
            {
                for (int i = 0; i < text.Count; i++)
                {
                    List<string> n2gramasTemp = Get2gramas(text[i]);
                    nGramas.AddRange(n2gramasTemp);
                    List<string> n3gramasTemp = Get3gramas(text[i]);
                    nGramas.AddRange(n3gramasTemp);
                }
                nGramas.Sort();
                for (int i = 0; i < nGramas.Count; i++)
                {
                    if (nGramas[i].Split().Length == 2)
                    {
                        listKeyValuePair.Add(new KeyValuePair<string, string>(nGramas[i].Split()[0], nGramas[i].Split()[1]));
                    }
                    else 
                    if (nGramas[i].Split().Length == 3)
                    {
                        listKeyValuePair.Add(new KeyValuePair<string, string>(
                            nGramas[i].Split()[0], 
                            nGramas[i].Split()[1]));
                        listKeyValuePair.Add(new KeyValuePair<string, string>(
                            nGramas[i].Split()[0] + 
                            " " + nGramas[i].Split()[1], 
                            nGramas[i].Split()[2]));
                    }
                }
            }
            return result;
        }

        private static List<string> Get3gramas(List<string> list)
        {
            List<string> x2gramsTemp = new List<string>();
            for (int i = 0; i < list.Count - 2; i++)
            {
                x2gramsTemp.Add(list[i] + " " + list[i + 1] + " " + list[i + 2]);
            }
            return x2gramsTemp;
        }

        private static List<string> Get2gramas(List<string> list)
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