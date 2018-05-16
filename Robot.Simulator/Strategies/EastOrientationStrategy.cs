using Robots.Simulator.Abstractions;

namespace Robots.Simulator.Strategies
{
  /// <summary>
  /// Orientation Strategy for all things East
  /// </summary>
  public class EastOrientationStrategy : IOrientationStrategy
  {
    public IPosition Move(IPosition currentPosition)
    {
      if (currentPosition.X >= 4)
        return currentPosition;

      currentPosition.X++;

      return currentPosition;
    }

    public IOrientationStrategy Left()
    {
      return new NorthOrientationStrategy();
    }

    public IOrientationStrategy Right()
    {
      return new SouthOrientationStrategy();
    }

    public OrientationEnum Name => OrientationEnum.East;
  }
}
