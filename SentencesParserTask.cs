using System;
using System.Collections.Generic;
using System.Text;

namespace TextAnalysis
{
    static class SentencesParserTask
    {
        public static List<List<string>> ParseSentences(string text)
        {
            char[] sentenceSeparators = new char[]{'.', '!', '?', ';', ':', '(', ')' };
            string[] sentences = text
                .Split(sentenceSeparators,
                StringSplitOptions.RemoveEmptyEntries);
            return ParseAndAddWordsToLists(sentences);
        }

        private static List<List<string>> ParseAndAddWordsToLists(string[] sentences)
        {
            List<List<string>> sentencesList = new List<List<string>>();
            char[] wordSeparators = new char[] { ' ', ',' };
            for (int i = 0; i < sentences.Length; i++)
            {
                List<string> words = SentencesParse(sentences, wordSeparators, i);
                sentencesList.Add(words);
            }
            return RemoteEmptyWords(sentencesList);
        }

        private static List<List<string>> RemoteEmptyWords(List<List<string>> sentencesList)
        {
            List<List<string>> list = new List<List<string>>(sentencesList.Count / 8);
            foreach (var item in sentencesList)
                if (item.Count != 0)
                    list.Add(item);
            return list;
        }

        private static List<string> SentencesParse(string[] sentences, 
            char[] wordSeparators, int i)
        {
            StringBuilder sb = new StringBuilder();
            char[] chars = sentences[i].ToLower().ToCharArray();
            for (int l = 0; l < chars.Length; l++)
            {
                if (char.IsLetter(chars[l]) || chars[l] == '\'')
                    sb.Append(chars[l]);
                else
                    sb.Append(' ');
            }
            sentences[i] = sb.ToString().Trim(wordSeparators);
            List<string> words = new List<string>(sentences[i]
                .Split(
                wordSeparators,
                StringSplitOptions.RemoveEmptyEntries));
            words.RemoveAll(x => x.Length == 0);
            return words;
        }
    }
}
