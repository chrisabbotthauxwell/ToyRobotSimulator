using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobotSimulator.State
{
    /// <summary>
    /// The robot state base class defines
    ///     - Mandatory constructors for subclasses
    ///     - Mandatory method behaviour for any subclass robot state
    ///     - Mandatory properties for any subclass robot state
    ///     - The current position of a robot
    ///     
    /// GoF state pattern
    /// </summary>
    public abstract class RobotStateBase
    {
        #region public constructors

        public RobotStateBase()
        {
        }

        /// <summary>
        /// RobotStateBase constructor used to update the robot state for turn or move
        /// </summary>
        /// <param name="state"></param>
        public RobotStateBase(RobotStateBase state)
        {
            X = state.X;
            Y = state.Y;
        }

        /// <summary>
        /// RobotStateBase constructor used to place a robot on the table
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public RobotStateBase(short x, short y)
        {
            if (x < Table.Min || x > Table.Max || y < Table.Min || y > Table.Max)
            {
                throw new ArgumentOutOfRangeException();
            }
            else
            {
                X = x;
                Y = y;
            }

        }

        #endregion

        #region public properties

        public short X { get; set; }

        public short Y { get; set; }

        #endregion

        #region public abstract members

        public abstract Direction Facing { get; }

        public virtual bool Placed { get { return false; } }
        
        public virtual bool Move(Robot robot) { return false; }

        public virtual bool TurnLeft(Robot robot) { return false; }

        public virtual bool TurnRight(Robot robot) { return false; }

        #endregion
    }
}
