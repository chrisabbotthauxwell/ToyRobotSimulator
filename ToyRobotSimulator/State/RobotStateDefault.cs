using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobotSimulator.State
{
    /// <summary>
    /// This defines the state and behaviour of a robot before it has been placed on the table
    /// </summary>
    public class RobotStateDefault : RobotStateBase
    {
        public RobotStateDefault()
        {
        }

        public override Direction Facing
        {
            get { return Direction.UNDEFINED; }
        }
    }
}
