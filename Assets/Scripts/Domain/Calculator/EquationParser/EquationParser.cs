using CalculatorApp.Domain.Calculator.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;


namespace CalculatorApp.Domain.Calculator
{
    public class EquationParser : IEquationParser
    {
        private string pattern;

        private string Pattern
        {
            get
            {
                if (string.IsNullOrEmpty(pattern))
                {
                    throw new Exception("Pattern is not built.");
                }

                return pattern;
            }
            set => pattern = value;
        }


        // Builds one pattern with named groups
        public void BuildExpression(IEnumerable<MathOperationPattern> expressions)
        {
            Pattern = string.Join('|', expressions.Select(e => $"(?<{e.Alias}>{ValidatePattern(e.Pattern)})"));
        }


        public EquationParserResult Parse(string equation)
        {
            Regex regex = new Regex(Pattern);
            MatchCollection matches = regex.Matches(equation.Trim());

            if (matches.Count > 0)
            {
                EquationParserResult result = new EquationParserResult();
                // We always will have <= 1 match
                Match match = matches[0];
                // First group is full match, last is named group, needed groups between
                for (int i = 1; i < match.Groups.Count - 1; i++)
                {
                    if (match.Groups[i].Success)
                    {
                        result.Parameters.Add(match.Groups[i].Value);
                    }
                }

                result.Alias = match.Groups[^1].Name;

                return result;
            }

            return null;
        }


        // Every pattern should search in full string
        private static string ValidatePattern(string pattern)
        {
            if (!pattern.StartsWith("^"))
            {
                pattern = $"^{pattern}";
            }

            if (!pattern.StartsWith("$"))
            {
                pattern = $"{pattern}$";
            }

            return pattern;
        }
    }
}
