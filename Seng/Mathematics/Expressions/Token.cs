namespace Seng.Mathematics.Expressions
{
    public struct Token
    {
        public TokenType Type;
        public int Value;
        public int Precedence;

        public override string ToString()
        {
            return (Type.ToString().PadRight(10)) + " " + (Type == TokenType.Operator ? ((Operation)Value).ToString() : Value.ToString());
        }
    }
}
