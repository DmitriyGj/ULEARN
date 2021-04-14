using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace TableParser
{
    [TestFixture]
    public class QuotedFieldTaskTests
    {
        [TestCase("''", 0, "", 2)]
        [TestCase("'a'", 0, "a", 3)]
        public void Test(string line, int startIndex, string expectedValue, int expectedLength)
        {
            var actualToken = QuotedFieldTask.ReadQuotedField(line, startIndex);
            Assert.AreEqual(new Token(expectedValue, startIndex, expectedLength), actualToken);
        }
    }

    class QuotedFieldTask
    {
        public static Token ReadQuotedField(string line, int startIndex)
        {
            char bodyBegin = line[startIndex];
            string value = string.Empty;
            int lengthOfField = 1;
            for (int i = startIndex+1; i != line.Length; i++)
            {
                lengthOfField++;
                if (line[i] == bodyBegin)
                    break;
                else if (line[i] == '\\')
                {
                    i++;
                    lengthOfField++;
                    value += line[i];
                }
                else
                    value += line[i];
            }
            return new Token(value, startIndex, lengthOfField);
        }
    }
}
