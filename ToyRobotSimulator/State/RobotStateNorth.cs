using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobotSimulator.State
{
    /// <summary>
    /// This concrete class defines the state and behaviour of a robot when it is facing north
    /// </summary>
    public class RobotStateNorth : RobotStateBase
    {
        public RobotStateNorth(RobotStateBase state) : base(state)
        {
        }

        public RobotStateNorth(short x, short y) : base(x, y)
        {
        }

        public override Direction Facing
        {
            get { return Direction.NORTH; }
        }

        public override bool Placed
        {
            get { return true; }
        }

        public override bool Move(Robot robot)
        {
            if (Y < Table.Max)
            {
                Y += 1;
                return true;
            }
            return false;
        }

        public override bool TurnLeft(Robot robot)
        {
            try
            {
                robot.CurrentState = new RobotStateWest(this);
                return true;
            }
            catch { return false; }
        }

        public override bool TurnRight(Robot robot)
        {
            try
            {
                robot.CurrentState = new RobotStateEast(this);
                return true;
            }
            catch { return false; }
        }
    }
}
