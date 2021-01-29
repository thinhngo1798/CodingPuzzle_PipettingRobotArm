using System;
using System.Collections.Generic;
using System.Text;

namespace PipettingRobotArm
{ 
    /// <summary>
    /// This abstract class applies ICommand interface, which has Execute method.
    /// The abstract class is use as base class for all command classes which has a RobotArm field in it.
    /// </summary>
    public abstract class AbstractRobotCommand : ICommand
    {
        private RobotArm _robot;
        public RobotArm Robot { get => this._robot; set => this._robot = value; }
        public AbstractRobotCommand(RobotArm robot)
        {
            Robot = robot;
        }
        public abstract string Execute();
    }
}
