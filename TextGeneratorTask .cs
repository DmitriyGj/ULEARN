using System.Collections.Generic;

namespace TextAnalysis
{
    static class TextGeneratorTask
    {
        public static string ContinuePhrase(
            Dictionary<string, string> nextWords,
            string phraseBeginning,
            int wordsCount)
        {
            for (int i = 0; i < wordsCount; i++)
            {
                string[] splited = phraseBeginning.Split();
                string key = string.Empty;
                if (splited.Length > 1 && 
                    nextWords.ContainsKey(splited[splited.Length - 2] + " " + splited[splited.Length - 1]))
                    key = splited[splited.Length - 2] + " " + splited[splited.Length - 1];
                else if (nextWords.ContainsKey(splited[splited.Length - 1]))
                    key = splited[splited.Length - 1];
                else
                    break;
                phraseBeginning += " " + nextWords[key];
            }
            return phraseBeginning;
        }
    }
}
