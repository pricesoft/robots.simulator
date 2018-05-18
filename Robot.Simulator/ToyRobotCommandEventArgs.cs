using System;

namespace Robots.Simulator
{
  public class ToyRobotCommandEventArgs : EventArgs
  {
    public string CommandName { get; set; }
  }
}
