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

        public Frequency(string start, string and, int count)
        {
            this.start = start;
            this.and = and;
            this.count = count;
        }

        public KeyValuePair<string, string> FindFrequencyElement(string start)
        {
            KeyValuePair<string, string> kvp = new KeyValuePair<string, string>();
            return kvp;
        }
    }

    static class FrequencyAnalysisTask
    {
        public static Dictionary<string, string> GetMostFrequentNextWords(List<List<string>> text)
        {
            Dictionary<string, string> frequency = new Dictionary<string, string>();
            return frequency;
        }
    }
}