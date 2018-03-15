using Seng.Mathematics.Expressions;
using System.Linq;

namespace Seng.Mathematics
{
    public static class SMath
    {
        private static readonly Parser _parser = new Parser();
        private static readonly TokenEvaluator _evaluator = new TokenEvaluator();
        
        /// <summary>
        /// Evaluates a mathematical expression. Only + - * / are supported.
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static int Evaluate(string expression)
        {
            return _evaluator.Evaluate(_parser.Parse(expression).ToList().InfixToPostfix());
        }
    }
}
