using System;
using Robots.Simulator.Abstractions;

namespace Robots.Simulator
{
  public class ToyRobotCommandEventArgs : EventArgs
  {
    public string CommandName { get; set; }
    public IPosition Position { get; set; }
  }
}
