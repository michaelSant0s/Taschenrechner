using System;
using System.Linq;
using System.Text;

namespace Calculator
{
    public class Parser
    {
        private MathOperation data;
        public MathOperation ParseInput(string input)
        {
            data = new MathOperation();
            input = input.Replace(" ", "");
            data = Parse(data, input, 0);

            return data;
        }
        private MathOperation Parse(MathOperation data, string input, int index)
        {
            MathOperation operation = new MathOperation();
            int writtenTo = 0;
            for (; index < input.Length; index++)
            {
                if (writtenTo == 2)
                {
                    writtenTo = 1;
                }

                if (char.IsDigit(input[index]))
                {
                    TextValue number = new TextValue();
                    do
                    {
                        number.Text += input[index++];
                    }
                    while (index < input.Length && (char.IsDigit(input[index]) || input[index] == '.' || input[index] == ','));

                    if (writtenTo == 1)
                    {
                        operation.Second = Parse(operation, input, index);
                    }
                    else
                    {
                        operation.First = number;
                    }

                    writtenTo++;
                    continue;

                }
                else if (input[index] == '+')
                {
                    operation.Operator = Operator.Addition;
                }
                else if (input[index] == '-')
                {
                    operation.Operator = Operator.Subtraction;
                }
                else if (input[index] == '/')
                {
                    operation.Operator = Operator.Division;
                }
                else if (input[index] == '*')
                {
                    operation.Operator = Operator.Multiplication;
                }
                else if (input[index] == '(')
                {
                    operation.First = Parse(operation, input, index);
                }
                else if (input[index] == ')')
                {
                    return Parse(data, input, index);
                }
            }
            return operation;
        }
    }
}