using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02StackQueue
{
    class RPN_Calculator
    {
        MyStack<float> operands = new MyStack<float>();

        public bool IsEndOfOperands { get; private set; }

        public void ReadInput(string text)
        {
            float f;
            if (float.TryParse(text, out f))
            {
                operands.Push(f);
            }
            else
            {
                if (text.Length == 1)
                {
                    switch (text[0])
                    {
                        case '+':
                            PushToOperands(DoAddition());
                            return;
                        case '-':
                            PushToOperands(DoSubtraction());
                            return;
                        case '/':
                            PushToOperands(DoDivision());
                            return;
                        case '*':
                            PushToOperands(DoMultiplication());
                            return;
                        default:
                            return;
                    }
                }
            }
        }

        private void PushToOperands(float f)
        {
            if (!float.IsNaN(f))
                operands.Push(f);
        }

        private void PushToOperands(string text)
        {
            if (!string.IsNullOrEmpty(text))
                operands.Push(float.Parse(text));
        }

        private float DoMultiplication()
        {
            if (operands.Count > 1)
            {
                return (operands.Pop() * operands.Pop());
            }
            return float.NaN;
        }

        private float DoDivision()
        {
            if (operands.Count > 1)
            {
                var op1 = operands.Pop();
                return (operands.Pop() / op1);
            }
            return float.NaN;
        }

        private float DoAddition()
        {
            if (operands.Count > 1)
            {
                return (operands.Pop() + operands.Pop());
            }
            return float.NaN;

        }

        private float DoSubtraction()
        {
            if (operands.Count > 1)
            {
                var op1 = operands.Pop();
                return (operands.Pop() - op1);
            }
            return float.NaN;
        }

        public void ShowResult()
        {
            var str = "Stack:";
            foreach (var f in operands)
            {
                str += " " + f;
            }
            Console.WriteLine(str);
        }

    }
}
