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
            Dynamic dp = new Dynamic();

  
            dp.PolicyEvaluation(997);
            dp.PrintV();
            dp.PolicyImprovement();
            dp.PrintP();

      
            Console.Read();
        }
    }
}
