using System;
using System.Collections.Generic;
using CalculatorApp.Domain.Calculator.Abstractions;


namespace CalculatorApp.Domain.Calculator
{
    public class SubtractionProcessor : IMathOperationProcessor
    {
        public string Alias { get; } = "subtraction";
        public string Pattern { get; } = @"^([0-9]+)(-)([0-9]+)$";

        private const string Operator = "-";


        public MathOperationResult Process(List<string> parameters)
        {
            if (parameters == null)
            {
                throw new ArgumentException("Parameters is null.");
            }

            if (parameters.Count != 3 || parameters[1] != Operator)
            {
                throw new ArgumentException(
                    $"Invalid parameters provided. Count {parameters.Count} != 3 or {parameters[1]} != {Operator}");
            }

            if (!int.TryParse(parameters[0], out int left))
            {
                throw new ArgumentException("Left argument is not integer.");
            }

            if (!int.TryParse(parameters[2], out int right))
            {
                throw new ArgumentException("Right argument is not integer.");
            }


            MathOperationResult result = new MathOperationResult()
            {
                Request = $"{parameters[0]}{Operator}{parameters[2]}",
                IsValid = true,
                Answer = (left - right).ToString()
            };

            return result;
        }
    }
}
