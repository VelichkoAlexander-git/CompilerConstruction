using System;
using System.Linq;
using System.Text;

namespace LabWorkPolynomialAnalyzer
{
    public class Lexer
    {
        private static readonly String _letters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private static readonly String _digits = "0123456789";

        private String _stmt = "";
        private int _index = 0;
        private char _ch;

        private char last;

        public Lexer(String input)
        {
            _stmt = input;
            _index = 0;
            _ch = NextChar();
        }

        public Token NextToken()
        {
            do
            {
                switch (_ch)
                {
                    case var ch when (_letters.IndexOf(ch) >= 0):
                        String str = Concat(_letters + _digits);
                        return new Token(Token.TokenType.Keyword, str);
                    
                    case var ch when (_digits.IndexOf(_ch) >= 0):
                        String num = Concat(_digits);
                        return new Token(Token.TokenType.Number, num);
                    
                    case ' ':
                        _ch = NextChar();
                        break;
                    case '*':
                        last = _ch;
                        _ch = NextChar();
                        return new Token(Token.TokenType.Operator, Char.ToString(last));
                    case '-':
                        last = _ch;
                        _ch = NextChar();
                        return new Token(Token.TokenType.Operator, Char.ToString(last));
                    case '+':
                        last = _ch;
                        _ch = NextChar();
                        return new Token(Token.TokenType.Operator, Char.ToString(last));
                    case '^':
                        last = _ch;
                        _ch = NextChar();
                        return new Token(Token.TokenType.Power, Char.ToString(last));
                    case '\0':
                        return new Token(Token.TokenType.EOI, "EndOfInput");
                    default:
                        _ch = NextChar();
                        Error("Invalid token type");
                        return new Token(Token.TokenType.Invalid, Char.ToString(_ch));
                }
            } while (true);
        }

        private char NextChar()
        {
            _ch = _stmt.ElementAtOrDefault(_index);
            _index += 1;
            return _ch;
        }

        private String Concat(String set)
        {
            StringBuilder r = new StringBuilder("");
            do
            {
                r.Append(_ch);
                _ch = NextChar();
                while (_ch == ' ')
                {
                    _ch = NextChar();
                }
            } while (set.IndexOf(_ch) >= 0);

            return r.ToString();
        }

        private void Error(String msg)
        {
            throw new Exception("\nError: location " + _index + " " + msg);
        }
    }
}