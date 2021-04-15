using System;
using System.Collections.Generic;
using LabWorkPolynomialAnalyzer.Base;

namespace LabWorkPolynomialAnalyzer.Translator
{
    public class ParserTranslator
    {
        #region Alalyze

        public List<String> Logger { get; private set; }
        public Poly Poly { get; private set; }


        private Token _token;
        private Lexer _lexer;

        private readonly string _input;

        public ParserTranslator(String input)
        {
            _input = input;
        }

        public ParserTranslator Run()
        {
            Logger = new List<string>();
            _lexer = new Lexer(_input);
            _token = _lexer.NextToken();
            Poly = new Poly();

            Polynom();

            Poly.PowerCount();

            return this;
        }

        private void NextCh() => _token = _lexer.NextToken();

        private void Polynom()
        {
            int a = 0;
            int k = 0;
            Token.TokenType op;

            Logger.Add("<Query>");
            if (_token.Type == Token.TokenType.Sum || _token.Type == Token.TokenType.Difference)
            {
                Logger.Add($"<{_token.Type}> {_token.Value} </{_token.Type}>");
                op = _token.Type;
                NextCh();
            }
            else
            {
                op = Token.TokenType.Sum;
            }

            Addend(out a, out k);
            do
            {
                if (op == Token.TokenType.Sum)
                {
                    Poly.Odds[k] = Poly.Odds[k] + a;
                }

                if (op == Token.TokenType.Difference)
                {
                    Poly.Odds[k] = Poly.Odds[k] - a;
                }

                Logger.Add($"<{_token.Type}> {_token.Value} </{_token.Type}>");
                op = _token.Type;
                if (op == Token.TokenType.EOI) break;
                NextCh();
                Addend(out a, out k);
            } while (true);

            if (_token.Type == Token.TokenType.EOI)
            {
                Logger.Add("</Query>");
            }

            if (_token.Type == Token.TokenType.Invalid)
            {
                Error(_token.Type);
                NextCh();
            }
        }

        private void Addend(out int a, out int k)
        {
            if (_token.Type == Token.TokenType.Keyword)
            {
                Logger.Add($"<{_token.Type}> {_token.Value} </{_token.Type}>");
                a = 1;
                NextCh();
                Power(out k);
            }
            else
            {
                Number(out a);
                if (_token.Type == Token.TokenType.Keyword)
                {
                    Logger.Add($"<{_token.Type}> {_token.Value} </{_token.Type}>");
                    NextCh();
                    Power(out k);
                }
                else
                {
                    k = 0;
                }
            }
        }

        private void Power(out int p)
        {
            if (_token.Type == Token.TokenType.Power)
            {
                Logger.Add($"<{_token.Type}> {_token.Value} </{_token.Type}>");
                NextCh();
                Number(out p);
            }
            else
            {
                p = 1;
            }
        }

        private void Number(out int y)
        {
            y = 0;
            if (_token.Type == Token.TokenType.Number)
            {
                Logger.Add($"<{_token.Type}> {_token.Value} </{_token.Type}>");
                y = Convert.ToInt32(_token.Value);
                NextCh();
            }
            else
            {
                Error(Token.TokenType.Number);
            }

            while (_token.Type == Token.TokenType.Number)
            {
                NextCh();
            }
        }

        private void Error(Token.TokenType type)
        {
            throw new Exception("Syntax error: Expecting: " + Token.TypeToString(type) + "; saw: " +
                                Token.TypeToString(_token.Type));
        }

        #endregion
    }
}