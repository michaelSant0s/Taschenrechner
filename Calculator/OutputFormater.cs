using System;

namespace Calculator
{
    public static class OutputFormater
    {
        public static string GetOutput(string input, string result)
        {
            return input + "\n" + result + "\n------------------\n";
        }
    }
}