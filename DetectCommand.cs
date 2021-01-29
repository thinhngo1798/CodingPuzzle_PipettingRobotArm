using System;
using System.Collections.Generic;
using System.Text;
using static PipettingRobotArm.Plate;
using static PipettingRobotArm.ICommand;
using static PipettingRobotArm.PipettingRobotArmProgram;

namespace PipettingRobotArm
{
    public class DetectCommand : AbstractRobotCommand
    {
        private Plate _plate;

        private Plate Plate { get => _plate; set => _plate = value; }

        public DetectCommand(RobotArm robot, Plate plate) : base(robot)
        {
            _plate = plate;
        }
        /// <summary>
        /// Outputting the status of current well under the robot arm.
        /// </summary>
        /// <returns>
        /// A string indicate whether the place position is valid or invalid.
        /// </returns>
        public override string Execute()
        {
            if (IsInsideThePlate(Robot.CurrentXLocation, Robot.CurrentYLocation))
            {
                Console.WriteLine("The well under the robot arm is " + Plate.GetStatusOfAWell(Robot.CurrentXLocation, Robot.CurrentYLocation));
            }
            else
            {
                Console.WriteLine("ERR");
            }
            return String.Empty;
        }
    }
}
