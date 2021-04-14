using System.Collections.Generic;
using NUnit.Framework;

namespace TableParser
{
    [TestFixture]
    public class FieldParserTaskTests
    {
        public static void Test(string input, string[] expectedResult)
        {
            var actualResult = FieldsParserTask.ParseLine(input);
            Assert.AreEqual(expectedResult.Length, actualResult.Count);
            for (int i = 0; i < expectedResult.Length; ++i)
                Assert.AreEqual(expectedResult[i], actualResult[i].Value);
        }
		
		[TestCase("text", new[] { "text" })]
        [TestCase("hello world", new[] { "hello", "world" })]
        [TestCase("'asd", new[] { "asd" })]
        [TestCase("kto pridumal  etot course?", new[] { "kto", "pridumal", "etot", "course?" })]
        [TestCase(@"\asd, s'asd'", new[] { @"\asd,", "s", "asd" })]
        [TestCase("        ", new string[0])]
        [TestCase("\"\'a\' \'b\' \'c\' \'d\'\"", new[] { "\'a\' \'b\' \'c\' \'d\'" })]
        [TestCase("\'\"a\" \"b\" \"c\" \"d\"\'", new[] { "\"a\" \"b\" \"c\" \"d\"" })]
        [TestCase("'asd' xy", new[] { "asd", "xy" })]
        [TestCase("'asd'\"asd\"\"", new[] { "asd", "asd", "" })]
        [TestCase("\"\\\"asd\\\"\"", new[] { "\"asd\"" })]
        [TestCase("\'\\\'asd\\\'\'", new[] { "\'asd\'" })]
        [TestCase("\"\\\\\"", new[] { "\\" })]
        [TestCase("' ", new[] { " " })]
		
        public static void RunTests(string input, string[] expectedOutput)
        {
            Test(input, expectedOutput);
        }
    }

    public class FieldsParserTask
    {
        public static List<Token> ParseLine(string line)
        {
            List<Token> result = new List<Token>();
            for(int i=0; i < line.Length;)
            {
                Token adder = new Token(string.Empty,0,0);
                if (line[i] == '\'' || line[i] == '\"')
                    adder = ReadQuotedField(line, i);
                else if (line[i] == ' ')
                {
                    i++;
                    continue;
                }
                else
                    adder = ReadField(line, i);
                i += adder.Length;
                result.Add(adder);
            }
            return result; 
        }
        
        private static Token ReadField(string line, int startIndex)
        {
            string value = string.Empty;
            int i = startIndex;
            while (i != line.Length && line[i] != '\'' && line[i] != '\"' && line[i] != ' ')
            {
                value += line[i];
                i++;
            }
            return new Token(value, startIndex, value.Length);
        }

        public static Token ReadQuotedField(string line, int startIndex)
        {
            return QuotedFieldTask.ReadQuotedField(line, startIndex);
        }
    }
}
