using System.Collections.Generic;
using System.Linq;
using System;

namespace TextAnalysis
{
    static class SentencesParserTask
    {
        public static List<List<string>> ParseSentences(string text)
        {
            text = text.ToLower();
            var sentencesList = new List<List<string>>();
            var sentences = text.Trim().Split(new char[] { '.', '!', '?', ';', ':', '(', ')' }, 
                StringSplitOptions.RemoveEmptyEntries);
            foreach (string sentence in sentences)
            {
                List<string> sentanceForAdd = new List<string>();
                sentanceForAdd = WordBuilder(sentence).Split(new[] { ' ' }, 
                    StringSplitOptions.RemoveEmptyEntries).ToList();
                if (sentanceForAdd.Count != 0)
                    sentencesList.Add(sentanceForAdd);
            }
            return sentencesList;
        }

        static string WordBuilder(string text)
        {
            string word = string.Empty;
            foreach (char symbol in text.Trim())
            {
                if (char.IsLetter(symbol) || symbol == '\'')
                     word+= symbol.ToString().ToLower();
                else
                    word += ' ';
            }
            return word;
        }
    }
}
