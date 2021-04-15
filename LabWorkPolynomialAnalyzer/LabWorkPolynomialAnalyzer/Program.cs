using System;
using System.IO;
using LabWorkPolynomialAnalyzer.Translator;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Fluent;

namespace LabWorkPolynomialAnalyzer
{
    class Program
    {
        static void Main(string[] args)
        {
            var resultOne = new ParserTranslator("3x^2+3x-5").Run().Poly;
            var resultTwo = new ParserTranslator("x^3-2x").Run().Poly;
            var result = resultOne * resultTwo;
            Console.WriteLine(result);
        }
    }
}