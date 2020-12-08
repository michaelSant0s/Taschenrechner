using System;
using System.Collections.Generic;

// namespace Calculator
// {
//     public enum Operator
//     {
//         Addition,
//         Subtraction,
//         Multiplication,
//         Division
//     }

//     public class MathOperation
//     {
//         public List<MathOperation> DependsOn { get; set; } = new List<MathOperation>();
//         public string First { get; set; }
//         public Operator Operator { get; set; }
//         public string Second { get; set; }
//     }


//     public class DiesDas
//     {
//         public DiesDas erste { get; set; }
//         public DiesDas zweite { get; set; }
//         public string wert { get; set; }
//     }
// }

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
    }

    // public class DataValue : IMathValue
    // {
    //     public MathOperation MathOperation { get; set; }

    //     public double GetValue()
    //     {
    //         return MathOperation.GetValue();
    //     }
    // }

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
    }
}