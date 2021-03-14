using System;

namespace FiniteStateMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            var test = new AutomatonArray();
            var value = test.Run("0 (777) 87 57 5");
            Console.WriteLine($"Phone number = {value.flag}");
            Console.WriteLine($"Transitions = {String.Join(", ",value.keys)}");
        }
    }
}