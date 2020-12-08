using System;

namespace Calculator
{
    public class OutputFormater
    {
        public OutputFormater()
        {
        }


        public string GetOutput(string result)
        {

            return result += "\n------------------\n";
        }
    }
}