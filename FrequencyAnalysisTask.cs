using System.Collections.Generic;
using System.Linq;
using System;

namespace TextAnalysis
{
    static class FrequencyAnalysisTask
    {
        public static Dictionary<string, string> GetMostFrequentNextWords(List<List<string>> text)
        {
            var biGramms = BuildTheFrequencyOfNGramm(text, 1);
            var triGramms =  BuildTheFrequencyOfNGramm(text, 2);
            var result =  BuildTheMostFrequencyNGramms(biGramms.Union(triGramms).ToDictionary(x=>x.Key,x=>x.Value));
            return result;
        }

        static Dictionary<string,Dictionary<string,int>> BuildTheFrequencyOfNGramm(List<List<string>> text, int n)
        {
            var frequencyOfNGramms = new Dictionary<string, Dictionary<string, int>>();
            foreach (var sentence in text)
            {
                if (sentence.Count >= 2)
                {
                    for (int i = 0; i != sentence.Count - n; i++)
                    {
                        int key = i + n;
                        string beginOfGramm = GetNGramBegin(i,n, sentence);
                        if (frequencyOfNGramms.ContainsKey(beginOfGramm))
                        {
                            if (frequencyOfNGramms[beginOfGramm].ContainsKey(sentence[key]))
                                frequencyOfNGramms[beginOfGramm][sentence[key]]++;
                            else
                                frequencyOfNGramms[beginOfGramm][sentence[key]] = 1;
                        }
                        else
                            frequencyOfNGramms.Add(beginOfGramm,new Dictionary<string, int> { { sentence[key], 1 } });
                    }
                }
            }
            return frequencyOfNGramms;
        }

        static string GetNGramBegin(int indexOfStart, int range, List<string> sentence)
        {
            var beginOfGramm = sentence[indexOfStart];
            for (int i = indexOfStart + 1; i < range + indexOfStart; i++)
                beginOfGramm += " " + sentence[i];
            return beginOfGramm;
        }

        static Dictionary<string,string> BuildTheMostFrequencyNGramms(Dictionary<string,Dictionary<string,int>> pp )
        {
            var result = new Dictionary<string, string>();
            foreach(KeyValuePair<string,Dictionary<string,int>> begins in pp )
            {
                int maxCount = 0;
                string beginOfGramm = begins.Key;
                string endOfGramm = string.Empty;
                foreach(KeyValuePair<string,int> end in begins.Value)
                {
                    if (end.Value > maxCount)
                    {
                        maxCount = end.Value;
                        endOfGramm = end.Key;
                    }
                    else if (end.Value == maxCount && string.CompareOrdinal(endOfGramm, end.Key ) > 0)
                        endOfGramm = end.Key;
                }
                result[beginOfGramm] = endOfGramm;
            }
            return result;
        }
    }
}
