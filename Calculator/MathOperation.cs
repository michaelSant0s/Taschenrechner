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
        public bool Sealed { get; set; }
        public IMathValue First { get; set; }
        public Operator Operator { get; set; }
        public IMathValue Second { get; set; }
        public MathOperation() { }

        public MathOperation(MathOperation mathOperation)
        {
            First = mathOperation;
        }

        /*
        *
        ╠═─ *
        ║   ╠═─ +
        ║   ║   ╠═─1
        ║   ║   ╚═─1
        ║   ║  
        ║   ╚═─ +
        ║       ╠═─1
        ║       ╚═─1
        ║      
        ║  
        ╚═─ *
            ╠═─ +
            ║   ╠═─1
            ║   ╚═─1
            ║  
            ╚═─ +
                ╠═─1
                ╚═─1

        Goes one level deeper each time GetValue() is called
        */
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

        // Only needed for debugging 
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



        /* 
        1 + 2 * 3 - 4 / 5

        ╠═─ -
        |   ╠═─ *
        |   |   ╠═─ +
        |   |   |   ╠═─1
        |   |   |   ╚═─2
        |   |   |  
        |   |   ╚═─3
        |   |  
        |   ╚═─4
        |  
        ╚═─5
        
        If at the current node is * or / and the next is + or - then they need to be "changed". 
        For example "3"-4 needs to be changed with 4/5 in the Order, which is not possible because they are on differnt levels.
        The solution for this problem is to change the value of 4 with the result of 4/5 and then seal it, so if there is another
        operation can not get prioritized wrong by mistake.
        */
        public MathOperation Balance()
        {
            if (First is MathOperation first)
            {
                First = first.Balance();
            }
            if (Second is MathOperation second)
            {
                Second = second.Balance();
            }

            if (!Sealed && (Operator == Operator.Multiplication || Operator == Operator.Division))
            {
                if (First is MathOperation a && (a.Operator == Operator.Addition || a.Operator == Operator.Subtraction))
                {
                    a.Second = new MathOperation()
                    {
                        First = a.Second,
                        Operator = this.Operator,
                        Second = this.Second
                    };
                    return a;
                }
            }
            return this;
        }
    }
}