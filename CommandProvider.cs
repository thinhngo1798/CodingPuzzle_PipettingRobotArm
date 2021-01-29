using System;
using System.Collections.Generic;
using System.Text;

namespace PipettingRobotArm
{
    public class CommandProvider
    {
        /// <summary>
        /// This method return a command object that corresponding to the command input from user.
        /// </summary>
        /// <param name="command"></param>
        /// <param name="param"></param>
        /// <param name="robot"></param>
        /// <param name="plate"></param>
        /// <returns></returns>
        public AbstractRobotCommand GetCommand(Command command, string param,RobotArm robot,Plate plate)
        {
            AbstractRobotCommand cmd = null;
            switch (command)
            {
                case Command.PLACE:
                    {
                        cmd = new PlaceCommand(robot,param);
                        break;
                    }
                case Command.DETECT:
                    {
                        cmd = new DetectCommand(robot,plate);
                        break;
                    }
                case Command.DROP:
                    {
                        cmd = new DropCommand(robot,plate);
                        break;
                    }
                case Command.MOVE:
                    {
                        cmd = new MoveCommand(robot,param);
                        break;
                    }
                case Command.REPORT:
                    {
                        cmd = new ReportCommand(robot,plate);
                        break;
                    }
                default:
                    {
                        Console.WriteLine(" Your command does not exist or it is invalid. Please try again");
                        break;
                    }
            }
            return cmd;
        }
    }
}
