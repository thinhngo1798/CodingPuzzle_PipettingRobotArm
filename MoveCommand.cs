using System;
using System.Collections.Generic;
using System.Text;
using static PipettingRobotArm.Plate;
using static PipettingRobotArm.PipettingRobotArmProgram;
namespace PipettingRobotArm
{
    public class MoveCommand : AbstractRobotCommand
    {
        private string _inputParam;
        /// <summary>
        ///  Parameter comes from the user input.
        /// </summary>
        private string InputParam { get => _inputParam; set => _inputParam = value; }

        public MoveCommand(RobotArm robot, string inputParam) : base (robot)
        {
            _inputParam = inputParam;
        }
        /// <summary>
        /// Validating and changing the robot arm location on the plate based on the direction of MOVE command.
        /// </summary>
        /// <returns></returns>
        public override string Execute()
        {
            string[] inputArray = InputParam.Split(" ");
            // Getting the current location of the robot.
            var currentXLocation = Robot.CurrentXLocation;
            var currentYLocation = Robot.CurrentYLocation;
            if (inputArray.Length > 1 && Char.TryParse(inputArray[1], out char direction))
            {
                switch (char.ToUpper(direction))
                {
                    // Move North direction (increase the Y coordinator)
                    case 'N':
                        {
                            // Checking whether the new location is inside the boundaries of the plate
                            if (IsInsideThePlate(currentXLocation, currentYLocation + 1))
                                currentYLocation++;
                            else
                                Console.WriteLine("The robot arm does not allow to go beyond the boudary. Please move in other directions!");
                            break;
                        }
                    // Move South direction (decrease the Y coordinator)
                    case 'S':
                        {
                            // Checking whether the new location is inside the boundaries of the plate
                            if (IsInsideThePlate(currentXLocation, currentYLocation - 1))
                                currentYLocation--;
                            else
                                Console.WriteLine("The robot arm does not allow to go beyond the boudary. Please move in other directions!");
                            break;
                        }
                    // Move East direction (increase the X coordinator)
                    case 'E':
                        {
                            // Checking whether the new location is inside the boundaries of the plate
                            if (IsInsideThePlate(currentXLocation + 1, currentYLocation))
                                currentXLocation++;
                            else
                                Console.WriteLine("The robot arm does not allow to go beyond the boudary. Please move in other directions!");
                            break;
                        }
                    // Move West direction (decrease the X coordinator)
                    case 'W':
                        {
                            // Checking whether the new location is inside the boundaries of the plate
                            if (IsInsideThePlate(currentXLocation - 1, currentYLocation))
                                currentXLocation--;
                            else
                                Console.WriteLine("The robot arm does not allow to go beyond the boudary. Please move in other directions!");
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Your input direction is invalid. " +
                                "Please insert the direction as N (for North), S (for South), E (for East) and W (for West).");
                            break;
                        }
                }
            }
            else
            {
                Console.WriteLine("Your direction of MOVE input is invalid. Please try again");
            }
            // Updating the robot location
            Robot.CurrentXLocation = currentXLocation;
            Robot.CurrentYLocation = currentYLocation;
            return String.Empty;
        }

    }
}
