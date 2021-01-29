using System;
using static PipettingRobotArm.TestDatas;

namespace PipettingRobotArm
{
    public class PipettingRobotArmProgram
    {
        // Declaring constants.
        public const int PLATE_DIMENSION = 5;
        public const int NUMBER_OF_TEST_DATA = 3;

        static void Main(string[] args)
        {
            // Initiate a robot arm and a plate with given dimension
            Plate plate = new Plate(PLATE_DIMENSION);
            RobotArm robotArm = new RobotArm();
            // Initiate a provider to get the corresponding command based on user input.
            CommandProvider provider = new CommandProvider();
            // Have a boolean function to determine it is a valid start (by a valid PLACE command)
            bool isValidStart = false;

            // Welcome and ask for selection of test data
            Console.WriteLine("Welcome new user! \n" +
                              "This app is a simulation of the laboratory pipetting robot arm.");
            // Getting the test data from text files.
            Console.WriteLine("Please select 1, 2, or 3 for the corresponding test data \n" +
                              "\t 1 - All wells are initially empty.\n" +
                              "\t 2 - All wells are initially full.\n" +
                              "\t 3 - Only wells in row 1 (y = 1) are initially full. Other wells are empty.");
            // In case user has added more test data. The default number is 3.
            for (int j = 0; j < (NUMBER_OF_TEST_DATA - 3); j++)
            {
                Console.WriteLine("\t {0} - New test data which user has added.", 4 + j);
            }
            // User can select one of the provided test data.
            while (true)
            {
                // If getting data sucessfully, get out of the while loop.
                if (GettingTestData(plate))
                {
                    break;
                }
            }
            Console.WriteLine("The test data has been completely input." +
                              " Please use the following commands to control the robot arm: \n" +
                              "\t PLACE X,Y for initialize the robot's arm location at coordinate (X,Y).\n" +
                              "\t DETECT for sensoring the status of the current well under the robot arm.\n" +
                              "\t DROP for dropping solution into the current well under the robot arm.\n" +
                              "\t MOVE N, MOVE S, MOVE W, MOVE E for moving the robot arm around the plates corresponding to the direction). \n" +
                              "\t REPORT for reporting the current location and the status of the well under the robot arm. \n" +
                              "\t EXIT for exiting the program.\n" +
                              "Note: Both lower case or uppercase are accepted.");
            // The program continuously getting input.
            while (true)
            {
                string input = Console.ReadLine();
                // Splitting the input into a string array. It is appled for composite command like PLACE and MOVE.
                string[] inputArray = input.Split(" ");
                string commandKey = inputArray[0].ToUpper();
                // Getting the type of command from the enumeration.
                var command = GetCommand(commandKey);
                if (String.IsNullOrEmpty(commandKey))
                {
                    Console.WriteLine("Your input cannot be empty. Please try again");
                    continue;
                }
                else if (command == Command.EXIT)
                {
                    break;
                }
                else if (command == Command.INVALID)
                {
                    Console.WriteLine(" Your command is invalid. Please try again");
                    continue;
                }
                // This condition statement can handle the scenario when user has entered PLACE command successfully, and user may still want to enter PLACE it again. 
                if (isValidStart && (command != Command.PLACE))
                {
                    //Get Command Object by CommandProvider
                    var commandObject = provider.GetCommand(command, input,robotArm,plate);
                    // There is a command object  corresponding to the input command.
                    if (commandObject != null)
                    {
                        commandObject.Execute();
                    }
                }
                else
                {
                    // User has not been entered a valid PLACE command. Or user wants to enter again.
                    // Process PLACE command and validate whether it is valid.
                    var placeCmd = new PlaceCommand(robotArm, input);
                    // Save the result of execute command. It is used mainly for PLACE command.
                    string result = placeCmd.Execute();
                    if (result == true.ToString())
                    {
                        isValidStart = true;
                    }
                }

            }
            Console.WriteLine("Thank you for using the app. See you again later ^-^");
        }
        /// <summary>
        /// Checking whether the robot arm is inside or beyond the plate's boundaries.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bool IsInsideThePlate(int x, int y)
        {
            return (x >= 0 && x < PLATE_DIMENSION && y >= 0 && y < PLATE_DIMENSION);
        }
        /// <summary>
        /// Getting the corresponding command in the declared enum.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public static Command GetCommand(string command)
        {
            try
            {
                return (Command)System.Enum.Parse(typeof(Command), command);
            }
            catch
            {
                return Command.INVALID;
            }
        }
    }
}
