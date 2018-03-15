using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seng.Mathematics.Expressions
{
    internal class TokenEvaluator : ITokenEvaluator
    {
        public int Evaluate(List<Token> tokens)
        {
            var stack = new Stack<Token>();

            for (int i = 0; i < tokens.Count; i++)
            {
                if (tokens[i].Type == TokenType.Literal)
                {
                    stack.Push(tokens[i]);
                }
                else if (tokens[i].Type == TokenType.Operator)
                {
                    var op2 = stack.Pop();
                    var op1 = stack.Pop();
                    stack.Push(Calculate(op1, op2, tokens[i]));
                }
            }

            return stack.Pop().Value;
        }

        public Token Calculate(Token a, Token b, Token op)
        {
            switch ((Operation)op.Value)
            {
                case Operation.Add: return new Token() { Type = TokenType.Literal, Value = a.Value + b.Value };
                case Operation.Subtract: return new Token() { Type = TokenType.Literal, Value = a.Value - b.Value };
                case Operation.Multiply: return new Token() { Type = TokenType.Literal, Value = a.Value * b.Value };
                case Operation.Divide: return new Token() { Type = TokenType.Literal, Value = a.Value / b.Value };
            }

            return default(Token);
        }
    }
}
