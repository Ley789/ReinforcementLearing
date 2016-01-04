using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace World
{
    class Gridworld
    {
        //static parameter to change gridwold properties
        public int length = 7;
        public int height = 7;
        //to keep it simple we will address each field with a number,
        //we start to count by [0][0] = 0 , [0][1] = 1, ... , [n][m] = n * length + m
        private static int[] terminalStates = { 24, 0 , 30 };
        public double[,] world;
        public Gridworld()
        {
            world = new double[height, length];

        }

        public Position NextState(Position currentPosition, AgentAction a)
        {
            Position p = new Position();
            p.x = currentPosition.x + a.x;
            p.y = currentPosition.y + a.y;
            if (p.x >= 0 && p.x < length && p.y >= 0 && p.y < height) { 
                return p;
            }
            else { 
                return currentPosition;
            }
        }

        public double Reward(Position p){
            if(terminalStates.Contains(p.y * length + p.x)){
                return 0;
            }else{
                return -1;
            }
        }
     
    }


    class Position
    {
        public int x;
        public int y;

        public Position() { }
        public Position(int x, int y){
            this.x = x;
            this.y = y;
        }

        public void Set(int x, int y){
            this.x = x;
            this.y = y;
        }

    }
}
