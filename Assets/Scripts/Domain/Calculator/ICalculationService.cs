using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CalculatorApp.Domain.Calculator.Abstractions
{
    public interface ICalculationService
    {
        MathOperationResult ParseAndCalculate(string equation);
    }
}