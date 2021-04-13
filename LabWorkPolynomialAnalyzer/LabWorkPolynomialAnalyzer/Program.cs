using System;
using System.IO;
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
            var value = new Parser("-1 2 3 x X x x ^ 4 + 5 6 7 x + 8 9");
            value.Run();
        }
    }
}