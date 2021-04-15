using System;

namespace LabWorkPolynomialAnalyzer.Base
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
            Sum,
            Difference,
            Power,
            Multiplication,

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
                case TokenType.Sum:
                    v = "Sum";
                    break;
                case TokenType.Multiplication:
                    v = "Multiplication";
                    break;
                case TokenType.Difference:
                    v = "Difference";
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