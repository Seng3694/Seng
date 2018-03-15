using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seng.Mathematics.Expressions
{
    internal class Parser : IParser
    {
        public IEnumerable<Token> Parse(string str)
        {
            str = str.Replace(" ", "");
            var buffer = new StringBuilder();
            var tokens = new List<Token>();

            //tokenize
            for (int i = 0; i < str.Length; i++)
            {
                switch (str[i])
                {
                    case '-':
                    case '+':
                        if (buffer.Length > 0)
                        {
                            tokens.Add(new Token() { Type = TokenType.Literal, Value = Convert.ToInt32(buffer.ToString()) });
                            buffer.Clear();
                        }

                        tokens.Add(new Token() { Type = TokenType.Operator, Value = (int)ConvertToOperation(str[i]), Precedence = 4 });

                        break;

                    case '*':
                    case '/':
                        if (buffer.Length > 0)
                        {
                            tokens.Add(new Token() { Type = TokenType.Literal, Value = Convert.ToInt32(buffer.ToString()) });
                            buffer.Clear();
                        }

                        tokens.Add(new Token() { Type = TokenType.Operator, Value = (int)ConvertToOperation(str[i]), Precedence = 3 });

                        break;

                    default:
                        buffer.Append(str[i]);

                        break;
                }
            }

            if (buffer.Length > 0)
                tokens.Add(new Token() { Type = TokenType.Literal, Value = Convert.ToInt32(buffer.ToString()) });

            return tokens;
        }

        private Operation ConvertToOperation(char c)
        {
            switch (c)
            {
                case '+': return Operation.Add;
                case '-': return Operation.Subtract;
                case '*': return Operation.Multiply;
                case '/': return Operation.Divide;
                default: return 0;
            }
        }
    }
}
