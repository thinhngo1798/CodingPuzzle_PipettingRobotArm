using System;
using System.Collections.Generic;
using System.Text;
using static PipettingRobotArm.PipettingRobotArmProgram;
namespace PipettingRobotArm
{
    public static class TestDatas
    {
        /// <summary>
        /// Getting the test data from txt files.
        /// </summary>
        /// <param name="plate"></param>
        /// <returns>
        /// Returning true or false indicates whether the data is received sucessfully.
        /// </returns>
        public static bool GettingTestData(Plate plate)
        {
            if (Int32.TryParse(Console.ReadLine(), out int inputTestDataIndex))
            {
                if (inputTestDataIndex < 1 || inputTestDataIndex > NUMBER_OF_TEST_DATA)
                {
                    Console.WriteLine("Your selection is out of range. Please try again!");
                    return false;
                }
                else
                {

                    try
                    {
                        string[] lines = System.IO.File.ReadAllLines("..\\..\\..\\TestData" + inputTestDataIndex + ".txt");
                        // The test data table in the text file is started with row  index 4 and down to row index 0.
                        // Therefore, the last row in the text file is the first row of the plate array.
                        for (int y = PLATE_DIMENSION - 1; y >= 0; y--)
                        {
                            string[] aLine = lines[(PLATE_DIMENSION - 1) - y].Split(" ");
                            for (int x = 0; x < PLATE_DIMENSION; x++)
                            {
                                plate.SetStatusOfAWell(x, y, aLine[x]);
                            }
                        }
                        return true;
                    }
                    // This catch handles the situation where the input text files cannot be found.
                    catch
                    {
                        Console.WriteLine("Your testData files are not placed in the correct folder, or this text file doesnt exist. \n" +
                            "The default test (all wells are empty) will be applied.");
                        for (int y = 0; y < PLATE_DIMENSION; y++)
                        {
                            for (int x = 0; x < PLATE_DIMENSION; x++)
                            {
                                plate.SetStatusOfAWell(x, y, "EMPTY");
                            }
                        }
                        return true;
                    }
                }
            }
            else
            {
                Console.WriteLine("Your selection is invalid. Please enter the number of test data you want (1, 2 or 3)!");
                return false;
            }
        }
    }
}
