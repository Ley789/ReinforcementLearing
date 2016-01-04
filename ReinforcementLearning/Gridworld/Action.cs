using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace World
{
    class AgentAction
    {
        public static HashSet<AgentAction> actions = new HashSet<AgentAction>();
        public int x = 0;
        public int y = 0;
        private AgentAction(){}


        public static AgentAction[] ReturnActions()
        {
            actions.Add(moveDown());
            actions.Add(moveUp());
            actions.Add(moveLeft());
            actions.Add(moveRight());
            return actions.ToArray<AgentAction>();
        }
        public static AgentAction moveDownJump()
        {
            AgentAction action = new AgentAction();
            action.y = 3;
            return action;
        }
        public static AgentAction moveUp()
        {
            AgentAction action = new AgentAction();
            action.y = 1;
            return action;
        }
        public static AgentAction moveDown()
        {
            AgentAction action = new AgentAction();
            action.y = -1;
            return action;
        }
        public static AgentAction moveLeft()
        {
            AgentAction action = new AgentAction();
            action.x = -1;
            return action;
        }
        public static AgentAction moveRight()
        {
            AgentAction action = new AgentAction();
            action.x = 1;
            return action;
        }
        public static AgentAction moveJump()
        {
            AgentAction action = new AgentAction();
            action.x = 4;
            return action;
        }

        public String ToString(){
            switch (this.x)
            {
                case 1: return "Right";
                case 4: return "Jump";
                case -1: return "Left";
            }
            switch(this.y){
                case 1: return "Down";
                case -1: return "UP";
                case 3: return "Djump";
                default: return "ToDefine";
            }
        }
    }
}
