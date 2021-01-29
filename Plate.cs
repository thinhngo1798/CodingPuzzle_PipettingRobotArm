using System;
using System.Collections.Generic;
using System.Text;

namespace PipettingRobotArm
{
    public class Plate
    {
        private string[,] _plateBoard;
        private int _plateDimention;
        // Represent all wells in the board.
        private string[,] PlateBoard { get => _plateBoard; set => _plateBoard = value; }
        private int PlateDimention { get => _plateDimention; set => _plateDimention = value; }

        public Plate(int plateDimension)
        {
            // Using a two-dimensional string array to represent the plate
            // Each element in the array stands for a well, and it is filled with information such as FULL or EMPTY
            _plateBoard = new string[plateDimension, plateDimension];
        }
        public string GetStatusOfAWell(int X, int Y)
        {
            return PlateBoard[X, Y];
        }
        public void SetStatusOfAWell(int X, int Y,string status)
        {
            PlateBoard[X, Y] = status;
        }
        public int GetDimension()
        {
            return PlateDimention;
        }
    }
}
