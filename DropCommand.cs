using System;
using System.Collections.Generic;
using System.Text;
using static PipettingRobotArm.Plate;
using static PipettingRobotArm.ICommand;

namespace PipettingRobotArm
{
    public class DropCommand : AbstractRobotCommand
    {
        private Plate _plate;

        private Plate Plate { get => _plate; set => _plate = value; }

        public DropCommand(RobotArm robot, Plate plate) : base(robot)
        {
            _plate = plate;
        }
        /// <summary>
        /// Changing the status of the well under the robot arm from empty to full if it is initially empty.
        /// </summary>
        /// <returns></returns>
        public override string Execute()
        {
            // And each well is fully filled by 1 DROP
            // If the well has been full, it stays as full. And there will be a string return whether it drops successfully.
            if (Plate.GetStatusOfAWell(Robot.CurrentXLocation, Robot.CurrentYLocation) == "EMPTY")
            {
                Plate.SetStatusOfAWell(Robot.CurrentXLocation, Robot.CurrentYLocation, "FULL");
            }
            else
            {
                Console.WriteLine("The well under the robot arm is already full. Therefore, you cannot place the drop.");
            }
            return String.Empty;
        }
    }
}
