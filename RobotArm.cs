using System;
using System.Collections.Generic;
using System.Text;

namespace PipettingRobotArm
{
    /// <summary>
    /// It represents a robot arm with its current X and Y coordinate.
    /// </summary>
    public class RobotArm
    {
        private int _currentXLocation = 0;
        private int _currentYLocation = 0;

        public int CurrentXLocation { get => _currentXLocation; set => _currentXLocation = value; }
        public int CurrentYLocation { get => _currentYLocation; set => _currentYLocation = value; }
    }
}
