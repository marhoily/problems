using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace DesignPatters
{
    public sealed class Pattern4
    {
        public class Computer
        {
            public int Value { get; private set; }
            public void Calc(char @operator, int operand)
            {
                switch (@operator)
                {
                    case '+': Value += operand; break;
                    case '-': Value -= operand; break;
                    case '*': Value *= operand; break;
                    case '/': Value /= operand; break;
                }
            }
        }

        public class Operation
        {
            public char Operator { get; }
            public int Operand { get; }
            private readonly Computer _computer;

            public Operation(Computer computer, char @operator, int operand)
            {
                _computer = computer;
                Operator = @operator;
                Operand = operand;
            }

            public virtual void Apply() => _computer.Calc(Operator, Operand);
            public virtual void UnApply() => _computer.Calc(Opposite(Operator), Operand);

            private static char Opposite(char @operator)
            {
                switch (@operator)
                {
                    case '+': return '-';
                    case '-': return '+';
                    case '*': return '/';
                    default: return '*';
                }
            }
        }

        sealed class Calculator
        {
            private readonly Computer _computer = new Computer();
            private readonly Stack<Operation> _memory = new Stack<Operation>();

            public int Push(char @operator, int operand)
            {
                var operation = new Operation(_computer, @operator, operand);
                operation.Apply();
                _memory.Push(operation);
                return _computer.Value;
            }
            public int Pop()
            {
                var operation = _memory.Pop();
                operation.UnApply();
                return _computer.Value;
            }
        }
        private readonly Calculator _calculator = new Calculator();

        [Fact]
        public void Test()
        {
            _calculator.Push('+', 3).Should().Be(3);
            _calculator.Push('*', 2).Should().Be(6);
            _calculator.Pop().Should().Be(3);
            _calculator.Pop().Should().Be(0);
        }
    }
}
