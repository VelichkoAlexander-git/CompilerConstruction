using System;

namespace LabWorkPolynomialAnalyzer
{
    public class Token
    {
        public TokenType Type { get; private set; }

        public string Value { get; private set; }


        public Token(TokenType type, string value)
        {
            Type = type;
            Value = value;
        }

        #region GetToken
        
        public enum TokenType
        {
            Number,
            Keyword,
            Operator,
            Power,

            Invalid,
            EOI
        }
        
        public static String TypeToString(TokenType tp)
        {
            String v = "";
            switch (tp)
            {
                case TokenType.Power:
                    v = "Power";
                    break;
                case TokenType.Keyword:
                    v = "Keyword";
                    break;
                case TokenType.Number:
                    v = "Number";
                    break;
                case TokenType.Operator:
                    v = "Operator";
                    break;
                case TokenType.Invalid:
                    v = "Invalid";
                    break;
                case TokenType.EOI:
                    v = "EOI";
                    break;
            }

            return v;
        }
        
        #endregion
    }
}