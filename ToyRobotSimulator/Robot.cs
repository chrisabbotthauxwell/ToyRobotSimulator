using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotSimulator.State;

namespace ToyRobotSimulator
{
    public class Robot
    {
        /// <summary>
        /// The robot class is responsible for
        ///     - Accepting commands from the robot pilot
        ///     - Knowing and reporting the current state of the robot
        ///     
        /// The robot needs to be given a state when it's powered up
        /// </summary>
        /// <param name="state"></param>
        public Robot(RobotStateBase receivedState)
        {
            state = receivedState;
        }
        
        private RobotStateBase state;

        public RobotStateBase CurrentState
        {
            get { return state; }
            set { state = value; }
        }

        public bool Move()
        {
            return state.Move(this);
        }

        public bool TurnLeft()
        {
            return state.TurnLeft(this);
        }

        public bool TurnRight()
        {
            return state.TurnRight(this);
        }

        public string Report()
        {
            if (state.Placed)
            {
                return string.Format("{0},{1},{2}", state.X, state.Y, state.Facing.ToString());
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
