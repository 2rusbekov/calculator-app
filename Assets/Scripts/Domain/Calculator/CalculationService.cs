using System;
using System.Collections.Generic;
using System.Linq;
using CalculatorApp.Domain.Calculator.Abstractions;


namespace CalculatorApp.Domain.Calculator
{
    public class CalculationService : ICalculationService
    {
        private Dictionary<string, IMathOperationProcessor> processors;

        //TODO: Use DI
        private IEquationParser parser;

        
        public CalculationService(IEquationParser parser)
        {
            this.parser = parser;
        }


        public CalculationService AddProcessor(IMathOperationProcessor processor)
        {
            processors ??= new Dictionary<string, IMathOperationProcessor>();

            if (processors.ContainsKey(processor.Alias))
            {
                throw new ArgumentException($"Processor with alias {processor.Alias} already added");
            }

            processors.Add(processor.Alias, processor);

            //TODO: Bad idea to build expression every time, but ok for now
            parser.BuildExpression(processors.Select(p =>
                new MathOperationPattern()
                {
                    Alias = p.Value.Alias,
                    Pattern = p.Value.Pattern
                }
            ));

            return this;
        }


        public MathOperationResult ParseAndCalculate(string equation)
        {
            EquationParserResult parsedResult = parser.Parse(equation);
            if (parsedResult == null)
            {
                return new MathOperationResult()
                {
                    Request = equation,
                    IsValid = false,
                };
            }

            return processors[parsedResult.Alias].Process(parsedResult.Parameters);
        }
    }
}
