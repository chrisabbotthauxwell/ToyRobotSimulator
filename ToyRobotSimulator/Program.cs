using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotSimulator.State;

namespace ToyRobotSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            RobotCommander robotCommander = new RobotCommander(new Robot(new RobotStateDefault()));
            
            string request = string.Empty;
            string response = string.Empty;
            
            while (!request.Equals("quit", StringComparison.OrdinalIgnoreCase))
            {
                Console.Write("Command: ");

                request = Console.ReadLine();
                response = robotCommander.SendCommand(request);
                
                if (!string.IsNullOrEmpty(response))
                {
                    Console.WriteLine(string.Format("Output: {0}", response));
                }
            }
        }
    }
}
