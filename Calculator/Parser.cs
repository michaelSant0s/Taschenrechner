using System;
using System.Text;

namespace Calculator
{
    public class Parser
    {
        public void ParseInput(string input)
        {
            MathOperation data = new MathOperation();
            input = input.Replace(" ", "");

            for (int i = 0; i < input.Length; i++)
            {
                while (char.IsDigit(input[i]))
                {
                    i++;

                }

            }
        }

    }
}