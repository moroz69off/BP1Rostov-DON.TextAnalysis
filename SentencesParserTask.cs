using System.Collections.Generic;
using System.Text;
//В этом задании нужно реализовать метод в классе SentencesParserTask.Метод должен делать следующее:
//1.Разделять текст на предложения, а предложения на слова.
//1.a.Считайте, что слова состоят только из букв(используйте метод char.IsLetter) или символа апострофа ' и отделены друг от друга любыми другими символами.
//1.b.Предложения состоят из слов и отделены друг от друга одним из следующих символов.!?;:()
//2.Приводить символы каждого слова в нижний регистр.
//3.Пропускать предложения, в которых не оказалось слов.
//Метод должен возвращать список предложений, где каждое предложение — это список из одного или более слов в нижнем регистре.
namespace TextAnalysis
{
    static class SentencesParserTask
    {
        public static List<List<string>> ParseSentences(string text)
        {
            List<List<string>> sentencesList = new List<List<string>>();
            char[] sentenceSeparators = new char[]
            {
                '.', '!', '?', ';', ':', '(', ')'
            };
            char[] wordSeparators = new char[] { ' ', ',' };
            text = text.Normalize();
            string[] sentences = text
                .Split(sentenceSeparators,
                System.StringSplitOptions.RemoveEmptyEntries);
            ParseAndAddWordsToLists(sentencesList, wordSeparators, sentences);
            return sentencesList;
        }

        private static void ParseAndAddWordsToLists(
            List<List<string>> sentencesList,
            char[] wordSeparators,
            string[] sentences)
        {
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
        }
    }
}
