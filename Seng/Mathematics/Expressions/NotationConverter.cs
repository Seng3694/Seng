using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seng.Mathematics.Expressions
{
    public static class NotationConverter
    {
        public static List<Token> InfixToPostfix(this List<Token> tokens)
        {
            var postFixTokens = new List<Token>();
            var stack = new Stack<Token>();

            for (int i = 0; i < tokens.Count; i++)
            {
                switch (tokens[i].Type)
                {
                    case TokenType.Operator:
                        if (stack.Count > 0)
                        {
                            var top = stack.Peek();
                            if (top.Precedence < tokens[i].Precedence)
                                while (stack.Count > 0)
                                    postFixTokens.Add(stack.Pop());

                        }
                        stack.Push(tokens[i]);
                        break;

                    case TokenType.Literal:
                        postFixTokens.Add(tokens[i]);
                        break;
                }
            }

            while (stack.Count > 0)
                postFixTokens.Add(stack.Pop());

            return postFixTokens;
        }
    }
}
