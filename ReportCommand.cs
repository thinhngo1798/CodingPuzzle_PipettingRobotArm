using System;
using System.Collections.Generic;
using System.Text;
using static PipettingRobotArm.Plate;
using static PipettingRobotArm.ICommand;

namespace PipettingRobotArm
{
    public class ReportCommand : AbstractRobotCommand
    {
        private Plate _plate;

        private Plate Plate { get => _plate; set => _plate = value; }

        public ReportCommand(RobotArm robot, Plate plate) : base (robot)
        {
            _plate = plate;
        }
        /// <summary>
        /// Outputting to the screen the location and status of the well under the robot arm.      
        /// </summary>
        /// <returns></returns>
        public override string Execute()
        {
            Console.WriteLine("Output: {0},{1},{2}", Robot.CurrentXLocation + 1, Robot.CurrentYLocation + 1, Plate.GetStatusOfAWell(Robot.CurrentXLocation, Robot.CurrentYLocation));
            return String.Empty;
        }
    }
}
