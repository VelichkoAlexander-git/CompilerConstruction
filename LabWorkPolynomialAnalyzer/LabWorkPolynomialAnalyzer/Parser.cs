using System;
using System.Collections.Generic;

namespace LabWorkPolynomialAnalyzer
{
    public class Parser
    {
        public List<String> Logger { get; private set; }

        private Token _token;
        private Lexer _lexer;

        public Parser(String input)
        {
            Logger = new List<string>();
            _lexer = new Lexer(input);
            _token = _lexer.NextToken();
        }

        public void Run()
        {
            Polynom();
            Console.WriteLine(String.Join("\n", Logger));
        }

        private void NextCh() => _token = _lexer.NextToken();

        private void Polynom()
        {
            Logger.Add("<Query>");
            if (_token.Type == Token.TokenType.Operator)
            {
                Logger.Add($"<{_token.Type}> {_token.Value} </{_token.Type}>");
                NextCh();
            }
            
            Addend();
            while (_token.Type == Token.TokenType.Operator)
            {
                Logger.Add($"<{_token.Type}> {_token.Value} </{_token.Type}>");
                NextCh();
                Addend();
            }

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

        private void Addend()
        {
            if (_token.Type == Token.TokenType.Keyword)
            {
                Logger.Add($"<{_token.Type}> {_token.Value} </{_token.Type}>");
                NextCh();
                Power();
            }
            else
            {
                Number();
                if (_token.Type == Token.TokenType.Keyword)
                {
                    Logger.Add($"<{_token.Type}> {_token.Value} </{_token.Type}>");
                    NextCh();
                    Power();
                }
            }
        }

        private void Power()
        {
            if (_token.Type == Token.TokenType.Power)
            {
                Logger.Add($"<{_token.Type}> {_token.Value} </{_token.Type}>");
                NextCh();
                Number();
            }
        }

        private void Number()
        {
            if (_token.Type == Token.TokenType.Number)
            {
                Logger.Add($"<{_token.Type}> {_token.Value} </{_token.Type}>");
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
    }
}