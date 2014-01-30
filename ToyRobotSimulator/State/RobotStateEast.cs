using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobotSimulator.State
{
    /// <summary>
    /// This concrete class defines the state and behaviour of a robot when it is facing east
    /// </summary>
    public class RobotStateEast : RobotStateBase
    {
        public RobotStateEast(RobotStateBase state) : base(state)
        {
        }

        public RobotStateEast(short x, short y) : base(x, y)
        {
        }

        public override Direction Facing
        {
            get { return Direction.EAST; }
        }

        public override bool Placed
        {
            get { return true; }
        }

        public override bool Move(Robot robot)
        {
            if (X < Table.Max)
            {
                X += 1;
                return true;
            }
            return false;
        }

        public override bool TurnLeft(Robot robot)
        {
            try
            {
                robot.CurrentState = new RobotStateNorth(this);
                return true;
            }
            catch { return false; }
        }

        public override bool TurnRight(Robot robot)
        {
            try
            {
                robot.CurrentState = new RobotStateSouth(this);
                return true;
            }
            catch { return false; }
        }
    }
}
