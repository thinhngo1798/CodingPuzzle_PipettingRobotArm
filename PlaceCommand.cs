using System;
using System.Collections.Generic;
using System.Text;
using static PipettingRobotArm.Plate;
using static PipettingRobotArm.ICommand;
using static PipettingRobotArm.PipettingRobotArmProgram;

namespace PipettingRobotArm
{
    public class PlaceCommand : AbstractRobotCommand
    {
        private string _inputParam;
        /// <summary>
        ///  Parameter comes from the user input.
        /// </summary>
        private string InputParam { get => _inputParam; set => _inputParam = value; }

        public PlaceCommand(RobotArm robot, string inputParam) : base(robot)
        {
            _inputParam = inputParam;
        }
        /// <summary>
        /// Updating the X and Y location of the robot arm based on a valid PLACE command.
        /// </summary>
        /// <returns>
        /// A string indicate whether the place position is valid or invalid.
        /// </returns>
        public override string Execute()
        {
            string[] inputArray = InputParam.Split(" ");
            string commandKey = inputArray[0].ToUpper();
            bool isValidStart = false;
            if (GetCommand(commandKey) != Command.PLACE)
            {
                Console.WriteLine("Your command is invalid. Only PLACE command is valid in the start");
            }
            else if (inputArray.Length < 2)
            {
                Console.WriteLine("Please include the X and Y coordinates of the location you want to place the robot arm.");
            }
            else if (inputArray[1].Split(",").Length <= 1)
            {
                Console.WriteLine("Your input must include both X and Y coordinate, seperated by a comma. Please try again");
            }
            else
            {
                string[] coordinate = inputArray[1].Split(",");
                if (!Int32.TryParse(coordinate[0], out int inputX) || !Int32.TryParse(coordinate[1], out int inputY))
                {
                    Console.WriteLine("Your X and/or Y coordinate input is invalid. Please try again");
                }
                else
                {
                    if (IsInsideThePlate(inputX - 1, inputY - 1))
                    {
                        // Current X and Y location is indexed from 0 to 4.
                        Robot.CurrentXLocation = inputX - 1;
                        Robot.CurrentYLocation = inputY - 1;
                        isValidStart = true;
                    }
                    else
                    {
                        Console.WriteLine("Your X and/or Y coordinate input is beyond of the boundaries of the plate. Please try again");
                    }
                }
               
            }
            return isValidStart.ToString();
        }

    }
}
