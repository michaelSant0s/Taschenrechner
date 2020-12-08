using System;
using System.Linq;
using System.Text;

namespace Calculator
{
    public class Parser
    {
        public MathOperation ParseInput(string input)
        {

            input = input.Replace(" ", "");
            int index = 0;
            return Parse(null, input, ref index);
        }
        private MathOperation Parse(MathOperation lastOperation, string input, ref int index)
        {
            MathOperation operation = new MathOperation();
            int writtenTo = 0;
            while (index < input.Length)
            {
                if (writtenTo == 2)
                {
                    writtenTo = 1;
                    lastOperation = operation;
                    operation = new MathOperation(operation);
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
                        operation.Second = number;
                    }
                    else
                    {
                        operation.First = number;
                    }

                    writtenTo++;
                    continue;
                }
                else
                {
                    switch (input[index++])
                    {
                        case '+':
                            operation.Operator = Operator.Addition;
                            break;
                        case '-':
                            operation.Operator = Operator.Subtraction;
                            break;
                        case '/':
                            operation.Operator = Operator.Division;
                            break;
                        case '*':
                            operation.Operator = Operator.Multiplication;
                            break;
                        case '(':
                            if (writtenTo == 0)
                            {
                                operation.First = Parse(operation, input, ref index);
                            }
                            else
                            {
                                operation.Second = Parse(operation, input, ref index);
                            }
                            writtenTo++;
                            break;
                        case ')':
                            return lastOperation;
                    }
                }
            }
            return operation;
        }
    }
}