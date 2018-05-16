using System;

namespace Robots.Simulator.Abstractions
{
  public interface IWorker
  {
    //starts game
    void ProcessCommand(string command);
  }

  [AttributeUsage(AttributeTargets.Class, Inherited = false)]
  public class ActionCommandAttibute : Attribute
  {
    public string CommandArgumentName { get; set; }
  }

  public abstract class ToyRobotCommandBase
  {
    
  }

  [ActionCommandAttibute(CommandArgumentName = "move")]
  public class MoveCommand : ToyRobotCommandBase
  {
    
  }

  [ActionCommandAttibute(CommandArgumentName = "right")]
  public class RightCommand : ToyRobotCommandBase
  {

  }

  [ActionCommandAttibute(CommandArgumentName = "left")]
  public class LeftCommand : ToyRobotCommandBase
  {

  }
}
