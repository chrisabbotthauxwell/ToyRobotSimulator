using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobotSimulator.State
{
    /// <summary>
    /// This concrete class defines the state and behaviour of a robot when it is facing south
    /// </summary>
    public class RobotStateSouth : RobotStateBase
    {
        public RobotStateSouth(RobotStateBase state) : base(state)
        {
        }

        public RobotStateSouth(short x, short y) : base(x, y)
        {
        }

        public override Direction Facing
        {
            get { return Direction.SOUTH; }
        }

        public override bool Placed
        {
            get { return true; }
        }

        public override bool Move(Robot robot)
        {
            if (Y > Table.Min)
            {
                Y -= 1;
                return true;
            }
            return false;
        }

        public override bool TurnLeft(Robot robot)
        {
            try
            {
                robot.CurrentState = new RobotStateEast(this);
                return true;
            }
            catch { return false; }
        }

        public override bool TurnRight(Robot robot)
        {
            try
            {
                robot.CurrentState = new RobotStateWest(this);
                return true;
            }
            catch { return false; }
        }
    }
}
