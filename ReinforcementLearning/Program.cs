using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DP;
namespace ReinforcementLearning
{
    class Program
    {
        static void Main(string[] args)
        {
            Dynamic dpIteration = new Dynamic();
            Dynamic dpEvalAndImprov = new Dynamic();

            Console.WriteLine("Our initialized value function per state.");
            dpIteration.PrintV();
            Console.WriteLine("Now after Vlaue Iteration");
            dpIteration.ValueIteration();
            dpIteration.PrintV();
            Console.WriteLine("Now after Policy evaluation");
            dpEvalAndImprov.PolicyEvaluation(1000);
            dpEvalAndImprov.PrintV();

            Console.WriteLine("Now we improve our Policy");
            Console.WriteLine("This is after Value Iteration");
            dpIteration.PolicyImprovement();
            dpIteration.PrintP();
            Console.WriteLine("This is after Policy evaluation");
            dpEvalAndImprov.PolicyImprovement();
            dpEvalAndImprov.PrintP();

      
            Console.Read();
        }
    }
}
