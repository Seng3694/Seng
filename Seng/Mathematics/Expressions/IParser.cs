using System.Collections.Generic;

namespace Seng.Mathematics.Expressions
{
    public interface IParser
    {
        IEnumerable<Token> Parse(string str);
    }
}
