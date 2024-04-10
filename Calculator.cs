using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleHW01
{
    class CalculatorEventArgs : EventArgs
    {
        public double answer;
    }
    class Calculator
    {
        public event EventHandler<CalculatorEventArgs> Result;
        private double result = 0;
        Stack<double> results = new Stack<double>();

        private double result1 = 1;
        Stack<double> results1 = new Stack<double>();

        private void StartEvent()
        {
            Result?.Invoke(this, new CalculatorEventArgs { answer = result });
        }
        private void StartEvent1()
        {
            Result?.Invoke(this, new CalculatorEventArgs { answer = result1 });
        }

        public void Add(double value)
        {
            results.Push(result);
            result += value;
            StartEvent(); 
        }
        public void Sub(double value)
        {
            results.Push(result);
            result -= value;
            StartEvent(); 
        }
        public void Mul(double value)
        {
            results1.Push(result1);
            result1 *= value;
            StartEvent1();
        }
        public void Div(double value)
        {
            results1.Push(result1);
            result1 /= value;
            StartEvent1(); 
        }
        public void Cancel()
        {
            if (results.Count > 0)
            {
                result = results.Pop();
                StartEvent();
            }
        }
        public void Clear()
        {
            result = 0;
            results.Clear();
        }
        public void Clear1()
        {
            result1 = 1;
            results1.Clear();
        }
    }
}
