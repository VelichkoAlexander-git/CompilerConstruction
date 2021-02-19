using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabWorkForms_2
{
    public class Asm
    {
        public List<string> Errors { get; private set; }
        public Dictionary<string, byte> Registers { get; private set; }
        private Dictionary<string, int> _marker { get; set; }

        public Asm()
        {
            _marker = new Dictionary<string, int>();
            Errors = new List<string>();
            Registers = Enumerable.Range(0, 16).ToDictionary(t => "r" + t, y => Byte.MinValue);
        }

        public void Interpreter(string[] program)
        {
            for (int CommandCounter = 0; CommandCounter < program.Length;)
            {
                string[] Token = Regex.Split(program[CommandCounter], @"[,|\s]+");

                switch (Token[0].ToUpper())
                {
                    case "LD": Ld(Token); CommandCounter++; break;
                    case "MOV": Mov(Token); CommandCounter++; break;
                    case "ADD": Add(Token); CommandCounter++; break;
                    case "SUB": Sub(Token); CommandCounter++; break;
                    case "BR": Br(Token, ref CommandCounter); CommandCounter++; break;
                    case "BRGZ": Brgz(Token, ref CommandCounter); CommandCounter++; break;
                    case "METKA": Metka(Token, ref CommandCounter); CommandCounter++; break;
                    default: MessageBox.Show("This command does not exist"); return;
                }

                if (Errors.Any())
                {
                    MessageBox.Show(String.Join("\n", Errors));
                    break;
                }
            }
        }

        private void Metka(string[] Tokens, ref int CommandCounter)
        {
            if (Tokens.Length == 2 && !_marker.ContainsKey(Tokens[1]))
            {
                _marker.Add(Tokens[1], CommandCounter);
            }
        }

        private void Br(string[] Tokens, ref int CommandCounter)
        {
            if (Tokens.Length == 2 && _marker.ContainsKey(Tokens[1]))
            {
                CommandCounter = _marker[Tokens[1]];
                return;
            }
            Errors.Add("Не выполнился BR");
        }

        private void Brgz(string[] Tokens, ref int CommandCounter)
        {
            if (Tokens.Length == 3 && _marker.ContainsKey(Tokens[1]) && Registers.ContainsKey(Tokens[2]))
            {
                if (Registers[Tokens[2]] > 0)
                {
                    CommandCounter = _marker[Tokens[1]];
                    return;
                }
                return;
            }
            Errors.Add("Не выполнился BR");
        }

        private void Ld(string[] Tokens)
        {
            if (Tokens.Length == 3 && Registers.ContainsKey(Tokens[1]))
            {
                if (IsNum(Tokens[2]).Ok)
                {
                    Registers[Tokens[1]] = IsNum(Tokens[2]).value;
                    return;
                }
                Errors.Add("Не выполнился LD");
            }
        }

        private void Mov(string[] Tokens)
        {
            if (Tokens.Length == 3 && Registers.ContainsKey(Tokens[1]) && Registers.ContainsKey(Tokens[2]))
            {
                Registers[Tokens[1]] = Registers[Tokens[2]];
                return;
            }
            Errors.Add("Не выполнился MOV");
        }

        private void Add(string[] Tokens)
        {
            if (Tokens.Length == 3 && Registers.ContainsKey(Tokens[1]) && Registers.ContainsKey(Tokens[2]))
            {
                Registers[Tokens[1]] += Registers[Tokens[2]];
                return;
            }
            Errors.Add("Не выполнился ADD");
        }

        private void Sub(string[] Tokens)
        {
            if (Tokens.Length == 3 && Registers.ContainsKey(Tokens[1]) && Registers.ContainsKey(Tokens[2]))
            {
                if (Registers[Tokens[1]] - Registers[Tokens[2]] < 0)
                {
                    Errors.Add($"При выполнении SUB {Tokens[1]} ушел в минус");
                }
                Registers[Tokens[1]] -= Registers[Tokens[2]];
                return;
            }
            Errors.Add("Не выполнился SUB");
        }

        private (byte value, bool Ok) IsNum(string Token)
        {
            var result = Regex.Match(Token, @"^#(\d+)$");
            if (result.Success)
            {
                byte parse;
                bool flag = Byte.TryParse(result.Groups[1].Value, out parse);
                if (!flag) Errors.Add($"{Token} не получилось преобразовать из String в Byte");
                return (parse, flag);
            }
            Errors.Add($"{Token} не прошел проверку на соответствие");
            return (0, false);
        }
    }
}
