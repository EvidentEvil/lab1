using System;

public class CalcService
{
    public int firstRnd;
    public int secondRnd;
    
    public string title = "AccessServiceDirectly";

    public CalcService()
    {
        var rnd = new Random();

        firstRnd = rnd.Next(0, 10);
        secondRnd = rnd.Next(0, 10);
    }

    public int add()
    {
        return firstRnd + secondRnd;
    }

    public int sub()
    {
        return firstRnd - secondRnd;
    }

    public int mult()
    {
        return firstRnd * secondRnd;
    }

    public string div()
    {
        try {
            var result = firstRnd / secondRnd;
            return result.ToString();
        }
        catch (DivideByZeroException) {
            Console.Write("error");
            return "error";
        }
    }
}