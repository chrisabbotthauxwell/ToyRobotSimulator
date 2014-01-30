using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobotSimulator
{
    public enum Instruction : byte
    {
        PLACE = 0,
        LEFT = 1,
        RIGHT = 2,
        MOVE = 3,
        REPORT = 4,
        UNDEFINED = 5
    }

    public enum Direction : byte
    {        
        NORTH = 0,
        EAST = 1,
        SOUTH = 2,
        WEST = 3,
        UNDEFINED = 4
    }
}
