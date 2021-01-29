using System;
using System.Collections.Generic;
using System.Text;

namespace PipettingRobotArm
{
    /// <summary>
    ///  This inteface is applied for any command in the system which can be executed.
    /// </summary>
    public interface ICommand
    {
        public string Execute();
    }
    /// <summary>
    ///  Using enumeration of command to improve modifiability and maintainability.
    /// </summary>
    public enum Command
    {
        PLACE,
        DETECT,
        DROP,
        MOVE,
        REPORT,
        EXIT,
        INVALID
    };
}
