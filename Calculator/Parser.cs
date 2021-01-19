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
            bool negativeNumberIsPossible = false;
            MathOperation operation = new MathOperation() { Sealed = true };
            int writtenTo = 0;
            while (index < input.Length)
            {
                if (writtenTo == 2)
                {
                    writtenTo = 1;
                    lastOperation = operation;
                    operation = new MathOperation(operation);
                }

                if (char.IsDigit(input[index]) || (negativeNumberIsPossible || index == 0 || input[index - 1] == '(') && input[index] == '-')
                {
                    TextValue number = new TextValue();
                    do
                    {
                        number.Text += input[index++];
                        negativeNumberIsPossible = false;
                    }
                    while (index < input.Length && (char.IsDigit(input[index]) || input[index] == '.' || input[index] == ',' || (
                    (negativeNumberIsPossible || index == 0 || input[index - 1] == '(') && input[index] == '-')));

                    if (number?.Text.Length > 15)
                    {
                        throw new ArgumentOutOfRangeException();
                    }

                    if (writtenTo == 1)
                    {
                        operation.Second = number;
                    }
                    else
                    {
                        operation.First = number;
                    }
                    negativeNumberIsPossible = false;
                    writtenTo++;
                    continue;
                }
                else
                {
                    switch (input[index++])
                    {
                        case '+':
                            operation.Operator = Operator.Addition;
                            negativeNumberIsPossible = true;
                            break;

                        case '-':
                            operation.Operator = Operator.Subtraction;
                            negativeNumberIsPossible = true;
                            break;

                        case '/':
                            operation.Operator = Operator.Division;
                            negativeNumberIsPossible = true;
                            break;

                        case '*':
                            operation.Operator = Operator.Multiplication;
                            negativeNumberIsPossible = true;
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