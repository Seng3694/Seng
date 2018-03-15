using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seng.Mathematics.Expressions
{
    public interface ITokenEvaluator
    {
        int Evaluate(List<Token> tokens);
    }
}
