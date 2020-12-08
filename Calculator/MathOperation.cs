using System;
using System.Collections.Generic;
namespace Calculator
{
    public enum Operator
    {
        Addition,
        Subtraction,
        Multiplication,
        Division
    }

    public interface IMathValue
    {
        double GetValue();

    }

    public class TextValue : IMathValue
    {
        public string Text { get; set; }

        public double GetValue()
        {
            return double.Parse(Text);
        }

        public override string ToString()
        {
            return Text;
        }
    }

    public class MathOperation : IMathValue
    {
        public IMathValue First { get; set; }
        public Operator Operator { get; set; }
        public IMathValue Second { get; set; }

        public MathOperation() { }

        public MathOperation(MathOperation mathOperation)
        {
            First = mathOperation;
        }


        public double GetValue()
        {
            switch (Operator)
            {
                case Operator.Addition:
                    return First.GetValue() + Second.GetValue();
                case Operator.Subtraction:
                    return First.GetValue() - Second.GetValue();
                case Operator.Multiplication:
                    return First.GetValue() * Second.GetValue();
                case Operator.Division:
                    return First.GetValue() / Second.GetValue();
            }
            return -1;
        }

        public override string ToString()
        {
            string result = First.ToString();

            switch (Operator)
            {
                case Operator.Addition:
                    result += "+";
                    break;
                case Operator.Subtraction:
                    result += "-";
                    break;
                case Operator.Multiplication:
                    result += "*";
                    break;
                case Operator.Division:
                    result += "/";
                    break;
            }

            return "(" + result + Second.ToString() + ")";
        }
    }
}