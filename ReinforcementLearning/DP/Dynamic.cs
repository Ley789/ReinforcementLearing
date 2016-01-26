using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using World;
namespace DP
{
    class Dynamic
    {
        Gridworld grid = new Gridworld();
        Random random = new Random();
        AgentAction[] actions;
        Position currentPosition;
        AgentAction[,][] policy;
        double discount = 0.8;
        //for this example we use a equaly distributed chance
        public Dynamic()
        {
            actions = AgentAction.ReturnActions();
            currentPosition = new Position();
            currentPosition.x = 0;
            currentPosition.y = 0;
            InitPolicy();
        }


        public double Posibility(Position next, AgentAction a)
        {
            if (next == grid.NextState(currentPosition, a))
            {
                return 1;
            }
            return 0;
        }

        
        public double PolicityProb(AgentAction a)
        {
            return PolicityProb(a, currentPosition);
        }

        public double PolicityProb(AgentAction a, Position p)
        {
            if (policy[p.y, p.x].Contains(a))
            {
                return (double)1 / policy[p.y, p.x].Length;
            }
            return 0;
        }


        public void ValueIteration()
        {
            Position p = new Position();
            Position next;
            double total;
            double tmp = 0;
            //delta indicates how much the value function has changed
            double delta;
            //omega denotes the minimum change for the vlaue function
            //to terminate the calculation
            double omega = 0.001;
            do
            {
                delta = 0;
                for (int j = 0; j < grid.height; j++)
                {
                    for (int k = 0; k < grid.length; k++)
                    {
                        p.Set(k, j);
                        total = double.MinValue;
                        foreach (AgentAction a in actions)
                        {
                            if (grid.Reward(p) == 0)
                            {
                                next = p;
                            }
                            else
                            {
                                next = grid.NextState(p, a);
                            }
                            tmp = (PolicityProb(a, p) * (grid.Reward(next) + discount * grid.world[next.y, next.x]));
                            if (tmp > total)
                            {
                                total = tmp;
                            }
                        }
                        //we check if the change is bigger
                        delta = Math.Max(delta, Math.Abs(total - grid.world[j, k]));
                        grid.world[j, k] = total;
                    }
                }
            } while (delta > omega);
        }
        
        public void PoliciyImprovement(int steps)
        {
            for (int i = 0; i < steps; i++)
            {
                PolicyEvaluation(5000);
                PolicyImprovement();
            }
        }

        public void PolicyEvaluation(int steps)
        {
            Position p = new Position();
            Position next;
            double total;
            
            for (int i = 0; i < steps; i++) {
                for (int j = 0; j < grid.height; j++)
                {
                    for (int k = 0; k < grid.length; k++)
                    {
                        p.Set(k, j);
                        total = 0;
                        foreach(AgentAction a in actions){
                            if (grid.Reward(p) == 0)
                            {
                                next = p;
                            }
                            else
                            {
                                next = grid.NextState(p, a);
                            }
                            total += (PolicityProb(a,p) * (grid.Reward(next) + discount * grid.world[next.y, next.x])); 
                        }
                        grid.world[j, k] = total;                
                    }
                }
            }
        }

        public void PolicyImprovement()
        {
            Position p = new Position();
            Position next;
            AgentAction bestAction;
            double prevActionValue = Double.MinValue;
            double currentValue;
            for (int j = 0; j < grid.height; j++)
            {
                for (int k = 0; k < grid.length; k++)
                {
                    p.Set(k, j);
                    bestAction = null;
                    prevActionValue = Double.MinValue;
                    foreach (AgentAction a in policy[j, k])
                    {
                        if (a == null)
                            continue;
                        if (grid.Reward(p) == 0)
                        {
                            next = p;
                        }
                        else
                        {
                            next = grid.NextState(p, a);
                        }
                        if (PolicityProb(a,p) != 0)
                        {
                            currentValue = (PolicityProb(a,p) * (grid.Reward(next) + discount * grid.world[next.y, next.x]));
                            if (currentValue >= prevActionValue)
                            {
                                bestAction = a;
                                prevActionValue = currentValue;
                            }
                        }
                    }
                    if (bestAction != null)
                    {
                        policy[j, k] = new AgentAction[1];
                        policy[j, k][0] = bestAction;
                    }
                }
            }

        }
       
        public void PrintV()
        {
            for (int j = 0; j < grid.height; j++)
            {
                for (int k = 0; k < grid.length; k++)
                {
                    Console.Write("| " + grid.world[j,k].ToString("N2") +" | ");
                }
                Console.WriteLine();
            }
        }
        public void PrintP()
        {
            for (int j = 0; j < grid.height; j++)
            {
                for (int k = 0; k < grid.length; k++)
                {
                    Console.Write("| ");
                    foreach (AgentAction a in policy[j, k]) {
                        if (a == null)
                            continue;
                        Console.Write(a.ToString() + "  |");
                    }
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }

        private void InitPolicy()
        {
            policy = new AgentAction[grid.height, grid.length][];
            for (int j = 0; j < grid.height; j++)
            {
                for (int k = 0; k < grid.length; k++)
                {
                    policy[j, k] = actions;
                }
            }
        }
        
    }
}
