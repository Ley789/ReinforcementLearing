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

            Console.WriteLine("We will go through the Policy Improvement iteration");
            Console.ReadLine();
            Console.WriteLine("Our initialized value function per state.");
            dpIteration.PrintV();
            Console.ReadLine();
            Console.WriteLine("Now after Policy evaluation, 1000 Iterations and discount 0.8");
            Console.ReadLine();
            dpEvalAndImprov.PolicyEvaluation(1000);
            dpEvalAndImprov.PrintV();
            Console.ReadLine();
            Console.WriteLine("Now we improve our Policy");
            Console.ReadLine();
            dpEvalAndImprov.PolicyImprovement();
            dpEvalAndImprov.PrintP();
            Console.ReadLine();

            Console.WriteLine("In this case we find the best Policy after 1 iteration");
            Console.ReadLine();
            Console.WriteLine("We will go through the Policy Improvement iteration");
            
            Console.WriteLine("Now after Vlaue Iteration of the initialized value with omega 0.001");
            Console.ReadLine();
            dpIteration.ValueIteration();
            dpIteration.PrintV();
            Console.ReadLine();
            Console.WriteLine("Now we improve our Policy");
            Console.ReadLine();
            dpIteration.PolicyImprovement();
            dpIteration.PrintP();

            Console.ReadLine();
        }
    }
}
