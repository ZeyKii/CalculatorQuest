using System;
using Avalonia.Controls;
using System.Linq;

namespace CalculatorQuest
{
    public class Calc 
    {
        private string[] _signs = { "+", "-", "x", "/", "%" };

        public Calc() {}

        public string Operator(string Input)
        {
            string[] parts = Input.Split(_signs, StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length != 2)
            {
                return "Not valid operator";
            }

            double chiffre1, chiffre2;
            if (!double.TryParse(parts[0], out chiffre1) || !double.TryParse(parts[1], out chiffre2))
            {
                return "Not valid Number";
            }

            if (Input.Contains("+"))
            {
                return (chiffre1 + chiffre2).ToString();
            }
            else if (Input.Contains("-"))
            {
                return (chiffre1 - chiffre2).ToString();
            }
            else if (Input.Contains("x"))
            {
                return (chiffre1 * chiffre2).ToString();
            }
            else if (Input.Contains("/"))
            {
                if (chiffre1 == 0 || chiffre2 == 0)
                {
                    return "You cannot Divide by 0 my man";
                }
                return (chiffre1 / chiffre2).ToString();
            }
            else if (Input.Contains("%"))
            {
                return (chiffre1 % chiffre2).ToString();
            }

            return "Operation not support";
        }
    }
    
}


