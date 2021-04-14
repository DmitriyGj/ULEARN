[TestCase("text", new[] {"text"})]
[TestCase("hello world", new[] {"hello", "world"})]
[TestCase("'asd", new[]{"asd"})]
[TestCase("kto pridumal  etot course?",new[] {"kto","pridumal","etot","course?"})]
[TestCase(@"\asd, s'asd'",new [] {@"\asd,","s","asd"})]
[TestCase("        ",new string[0])]
[TestCase("\"\'a\' \'b\' \'c\' \'d\'\"", new [] {"\'a\' \'b\' \'c\' \'d\'"})]
[TestCase("\'\"a\" \"b\" \"c\" \"d\"\'", new [] {"\"a\" \"b\" \"c\" \"d\""})]
[TestCase("'asd' xy",new [] {"asd","xy"})]
[TestCase("'asd'\"asd\"\"",new []{"asd","asd",""})]
[TestCase("\"\\\"asd\\\"\"",new [] {"\"asd\""})]
[TestCase("\'\\\'asd\\\'\'",new [] {"\'asd\'"})]
[TestCase("\"\\\\\"",new [] {"\\"})]
[TestCase("' ",new []{" "})]
public static void RunTests(string input, string[] expectedOutput)
{
    // Тело метода изменять не нужно
    Test(input, expectedOutput);
}
