using Robots.Simulator.Abstractions;

namespace Robots.Simulator.Strategies
{
  /// <summary>
  /// Orientation Strategy for all things West
  /// </summary>
  public class WestOrientationStrategy : IOrientationStrategy
  {
    public IPosition Move(IPosition currentPosition)
    {
      if (currentPosition.X <= 0)
        return currentPosition;

      currentPosition.X--;

      return currentPosition;
    }

    public IOrientationStrategy Left()
    {
      return new SouthOrientationStrategy();
    }

    public IOrientationStrategy Right()
    {
      return new NorthOrientationStrategy();
    }

    public OrientationEnum Name => OrientationEnum.West;
  }
}
