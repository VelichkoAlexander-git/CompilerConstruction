using System;

namespace LabWorkPolynomialAnalyzer.Translator
{
    public class Poly
    {
        public int Power { get; set; }
        public int[] Odds { get; set; }

        public Poly()
        {
            Power = 0;
            Odds = new int[255];
            Array.Clear(Odds, 0, 255);
        }

        #region OperatorOverloading

        public static Poly operator *(Poly a, Poly b)
        {
            return MultPoly(a, b);
        }

        #endregion

        public override string ToString()
        {
            string value = "";
            for (int i = Power; i >= 0; i--)
            {
                if (Odds[i] != 0)
                {
                    char op = Odds[i] > 0 ? '+' : '-';
                    int num = Math.Abs(Odds[i]);

                    if (i != Power)
                    {
                        value += $" {op} ";
                    }

                    if (i > 1)
                    {
                        value += $"{num}x^{i}";
                    }

                    if (i == 1)
                    {
                        value += $"{num}x";
                    }

                    if (i == 0)
                    {
                        value += $"{num}";
                    }
                }
            }

            return value;
        }

        #region Operations

        private static Poly MultPoly(Poly x, Poly y)
        {
            Poly value = new Poly();
            for (int i = 0; i <= x.Power; i++)
            {
                for (int j = 0; j <= y.Power; j++)
                {
                    value.Odds[i + j] = value.Odds[i + j] + x.Odds[i] * y.Odds[j];
                }
            }

            value.PowerCount();
            return value;
        }
        
        public void PowerCount()
        {
            Power = Odds.Length - 1;
            while (Power > 0 && Odds[Power] == 0)
            {
                Power -= 1;
            }
        }

        #endregion
    }
}