using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using ServiceStack.FluentValidation;
using ServiceStack.ServiceHost;
using ServiceStack.ServiceInterface;
using ServiceStack.ServiceInterface.ServiceModel;
using ServiceStack.Text;

namespace ServiceStackLearning
{
    [Route("/Calculation")]
    [Route("/Calculation/{CalculationRequest}")]
    public class Calculation : IReturn<CalculationResponse>
    {
        public int Operand1 { get; set; }
        public int Operand2 { get; set; }
        public string Operator { get; set; }
    }

    public class CalculationResponse
    {
        public ResponseStatus ResponseStatus { get; set; }
        public double Result { get; set; }
    }

    public class CalculationService : Service
    {
        private ICalculator calculator;

        public CalculationService(ICalculator calculator)
        {
            this.calculator = calculator;
        }

        public CalculationResponse Any(Calculation request)
        {
            if (request.Operator == "%") throw new ArgumentException("modulus not supported");
            return new CalculationResponse { Result = calculator.Calculate(request.Operand1, request.Operand2, request.Operator) };
        }
    }

    public class Calculator : ICalculator
    {
        public double Calculate(int operand1, int operand2, string op)
        {
            switch (op)
            {
                case "+":
                    return operand1 + operand2;
                case "-":
                    return operand1 - operand2;
                case "/":
                    return operand1 / operand2;
                case "*":
                    return operand1 * operand2;
                default:
                    return 0;
            }
        }
    }

    public interface ICalculator
    {
        double Calculate(int operand1, int operand2, string op);
    }
}