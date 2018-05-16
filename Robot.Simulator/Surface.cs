using Robots.Simulator.Abstractions;

namespace Robots.Simulator
{
  public class Surface : ISurface
  {
    public Surface()
    {
      IsRobotPlaced = false;
    }

    public bool IsRobotPlaced { get; set; }
  }
}
