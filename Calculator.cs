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
        public double Answer { get; set; }
    }
    class Calculator
    {
        public event EventHandler<CalculatorEventArgs> Result;

        private double doubleResult = 0.0;
        private int intResult = 0;
        private double doubleResult1 = 1.0;

        private Stack<double> doubleResults = new Stack<double>();
        private Stack<int> intResults = new Stack<int>();
        private Stack<double> doubleResults1 = new Stack<double>();

        private void StartEvent()
        {
            Result?.Invoke(this, new CalculatorEventArgs { Answer = doubleResult });
        }
        private void StartEvent1()
        {
            Result?.Invoke(this, new CalculatorEventArgs { Answer = doubleResult1 });
        }

        private void StartEvent(double result)
        {
            doubleResult = result;
            StartEvent();
        }
        private void StartEvent(int result)
        {
            doubleResult = result;
            StartEvent();
        }
        private void StartEvent1(double result1)
        {
            doubleResult1 = result1;
            StartEvent1();
        }


        public static Calculator operator +(Calculator calc, int value)
        {
            calc.Add(value);
            return calc;
        }

        public static Calculator operator +(Calculator calc, double value)
        {
            calc.Add(value);
            return calc;
        }

        public static Calculator operator -(Calculator calc, int value)
        {
            calc.Sub(value);
            return calc;
        }

        public static Calculator operator -(Calculator calc, double value)
        {
            calc.Sub(value);
            return calc;
        }

        public static Calculator operator *(Calculator calc, int value)
        {
            calc.Mul(value);
            return calc;
        }

        public static Calculator operator *(Calculator calc, double value)
        {
            calc.Mul(value);
            return calc;
        }

        public static Calculator operator /(Calculator calc, int value)
        {
            calc.Div(value);
            return calc;
        }

        public static Calculator operator /(Calculator calc, double value)
        {
            calc.Div(value);
            return calc;
        }
        public void Add(int value)
        {
            intResults.Push(intResult);
            intResult += value;
            StartEvent(intResult);
        }
        public void Add(double value)
        {
            doubleResults.Push(doubleResult);
            doubleResult += value;
            StartEvent(doubleResult);
        }
        public void Sub(int value)
        {
            intResults.Push(intResult);
            intResult -= value;
            StartEvent(intResult);
        }
        public void Sub(double value)
        {
            doubleResults.Push(doubleResult);
            doubleResult -= value;
            StartEvent(doubleResult);
        }
        public void Mul(int value)
        {
            doubleResults1.Push(doubleResult1);
            doubleResult1 *= value;
            StartEvent1(doubleResult1);
        }
        public void Mul(double value)
        {
            doubleResults1.Push(doubleResult1);
            doubleResult1 *= value;
            StartEvent1(doubleResult1);
        }
        public void Div(int value)
        {
            doubleResults1.Push(doubleResult1);
            doubleResult1 /= value;
            StartEvent1(doubleResult1);
        }
        public void Div(double value)
        {
            doubleResults1.Push(doubleResult1);
            doubleResult1 /= value;
            StartEvent1(doubleResult1);
        }

        public void Cancel()
        {
            if (intResults.Count > 0)
            {
                intResult = intResults.Pop();
                StartEvent(intResult);
            }
            else if (doubleResults.Count > 0)
            {
                doubleResult = doubleResults.Pop();
                StartEvent(doubleResult);
            }
        }

        public void Clear()
        {
            doubleResult = 0.0;
            doubleResults.Clear();
            intResult = 0;
            intResults.Clear();
            doubleResult1 = 1.0;
            doubleResults1.Clear();
        }
    }
}
