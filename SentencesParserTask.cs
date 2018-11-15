using System.Collections.Generic;
using System.Text;
namespace TextAnalysis
{
    static class SentencesParserTask
    {
        public static List<List<string>> ParseSentences(string text)
        {
            char[] sentenceSeparators = new char[]{'.', '!', '?', ';', ':', '(', ')' };
            text = text.Normalize();
            string[] sentences = text
                .Split(sentenceSeparators,
                System.StringSplitOptions.RemoveEmptyEntries);
            return ParseAndAddWordsToLists(sentences);
        }

        private static List<List<string>> ParseAndAddWordsToLists(string[] sentences)
        {
            List<List<string>> sentencesList = new List<List<string>>();
            char[] wordSeparators = new char[] { ' ', ',' };
            for (int i = 0; i < sentences.Length; i++)
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
                    System.StringSplitOptions.RemoveEmptyEntries));
                sentencesList.Add(words);
            }
            sentencesList.RemoveAll(x => x.Count == 0);
            return sentencesList;
        }
    }
}
