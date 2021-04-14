public static double Calculate(string userInput)
{
	var a = userInput.Trim().Split().Select(s=>double.Parse(s)).ToArray();
    return a[0]*Math.Pow(1+(a[1]/1200),a[2]);
}
    
