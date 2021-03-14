using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace FiniteStateMachine
{
    public enum State : ushort
    {
        Zero = 0,
        PlusThreeHundredSeventyThree = 1,
        OneToNine = 2,
        Space = 3,
        OpenParenthesis = 4,
        ClosingParenthesis = 5
    }

    public class AutomatonArray
    {
        private int[,] array { get; set; }

        public AutomatonArray()
        {
            array = new int[,]
            {
                {1, 1, 7, 12, 12, 12},
                {12, 12, 12, 1, 2, 12},
                {12, 12, 3, 12, 12, 12},
                {4, 12, 4, 12, 12, 12},
                {5, 12, 5, 12, 12, 12},
                {12, 12, 12, 12, 12, 6},
                {12, 12, 7, 6, 12, 12},
                {8, 12, 8, 7, 12, 12},
                {9, 12, 9, 8, 12, 12},
                {10, 12, 10, 9, 12, 12},
                {11, 12, 11, 10, 12, 12},
                {12, 12, 12, 12, 12, 12},
                {12, 12, 12, 12, 12, 12}
            };
        }

        private List<int> Parser(IEnumerable<char> s)
        {
            List<int> keys = new List<int>();
            string key = "";
            for (int i = 0; i < s.Count(); i++)
            {
                key += s.ElementAt(i);
                switch (key)
                {
                    case "0":
                        keys.Add((int)State.Zero);
                        key = "";
                        break;
                    case "+373":
                        keys.Add((int)State.PlusThreeHundredSeventyThree);
                        key = "";
                        break;
                    case "1":
                    case "2":
                    case "3":
                    case "4":
                    case "5":
                    case "6":
                    case "7":
                    case "8":
                    case "9":
                        keys.Add((int)State.OneToNine);
                        key = "";
                        break;
                    case " ":
                        keys.Add((int)State.Space);
                        key = "";
                        break;
                    case "(":
                        keys.Add((int)State.OpenParenthesis);
                        key = "";
                        break;
                    case ")":
                        keys.Add((int)State.ClosingParenthesis);
                        key = "";
                        break;
                }
            }

            return keys;
        }

        public (List<int> keys,bool flag) Run(IEnumerable<char> s)
        {
            int lineY = 0;
            var keys = Parser(s);
            List<int> Transitions = new List<int>() {0};
            
            foreach (var lineX in keys)
            {
                lineY = array[lineY, lineX];
                Transitions.Add(lineY);
            }

            if (lineY == 11)
                return (Transitions, true);
            else
                return (Transitions, false);
        }
    }
}