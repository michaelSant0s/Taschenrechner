using System;

namespace Calculator
{
    public class MathOperation
    {
        public MathOperation DependsOn { get; set; }
        public string First { get; set; }
        public string Operator { get; set; }
        public string Second { get; set; }
    }
}