using System.Collections.Generic;

namespace Seng.Mathematics.Expressions
{
    public interface ITokenEvaluator
    {
        int Evaluate(List<Token> tokens);
    }
}
