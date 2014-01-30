using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ToyRobotSimulator.State;

namespace ToyRobotSimulator
{
    /// <summary>
    /// The robot pilot class is responsible for:
    ///     - parsing and validating the user input
    ///     - issuing commands to the robot
    /// </summary>
    public class RobotCommander
    {
        private Robot _robot;

        public RobotCommander(Robot robot)
        {
            _robot = robot;
        }

        public string SendCommand(string command)
        {
            string result = string.Empty;
            Instruction instruction = Instruction.UNDEFINED;
            Dictionary<string, string> arguments = new Dictionary<string, string>();

            command = command.Trim();

            if(ValidateCommand(command, ref instruction))
            {
                if(ValidateCommandArguments(command, instruction, ref arguments))
                {
                    return ExecuteCommand(instruction, arguments);
                }
            }

            return result;
        }

        private bool ValidateCommand(string command, ref Instruction instruction)
        {
            if (command.IndexOf(' ') > 0)
            {
                command = command.Substring(0, command.IndexOf(' '));
            }
            
            return Enum.TryParse<Instruction>(command, true, out instruction);            
        }

        private bool ValidateCommandArguments(string command, Instruction instruction, ref Dictionary<string, string> arguments)
        {
            bool result = false;

            try
            {
                switch (instruction)
                {
                    case Instruction.PLACE:                        
                        Regex placeInstructionArguments = new Regex(@"^\d{1},\d{1},\w{4,5}$");
                        if (placeInstructionArguments.IsMatch(command.Split(' ')[1]))
                        {
                            string[] coordinateArgs = command.Split(' ')[1].Split(',');
                            arguments.Add("x", coordinateArgs[0]);
                            arguments.Add("y", coordinateArgs[1]);
                            arguments.Add("d", coordinateArgs[2]);

                            result = true;
                        }                        
                        break;
                    default:
                        //valid instruction with no arguments
                        return true;
                }
            }
            catch
            {
                result = false;
            }

            return result;
        }

        private string ExecuteCommand(Instruction instruction, Dictionary<string, string> arguments)
        {
            string result = string.Empty;

            try
            {
                switch (instruction)
                {
                    case Instruction.PLACE:
                        _robot = new Robot(RobotStatePlaced(arguments));
                        break;
                    case Instruction.LEFT:
                        _robot.TurnLeft();
                        break;
                    case Instruction.RIGHT:
                        _robot.TurnRight();
                        break;
                    case Instruction.MOVE:
                        _robot.Move();
                        break;
                    case Instruction.REPORT:
                        return _robot.Report();
                    default:
                        // Invalid command
                        break;
                }
            }
            catch
            {
                // Invalid command
            }

            return string.Empty;
        }

        private static RobotStateBase RobotStatePlaced(Dictionary<string, string> arguments)
        {
            short x;
            short.TryParse(arguments["x"], out x);
            short y;
            short.TryParse(arguments["y"], out y);
            Direction direction;
            Enum.TryParse<Direction>(arguments["d"], true, out direction);

            RobotStateBase robotState = new RobotStateDefault();
            switch (direction)
            {
                case Direction.NORTH:
                    robotState = new RobotStateNorth(x, y);
                    break;
                case Direction.EAST:
                    robotState = new RobotStateEast(x, y);
                    break;
                case Direction.SOUTH:
                    robotState = new RobotStateSouth(x, y);
                    break;
                case Direction.WEST:
                    robotState = new RobotStateWest(x, y);
                    break;
                default:
                    // Invalid direction
                    break;
            }
            return robotState;
        }
    }
}
