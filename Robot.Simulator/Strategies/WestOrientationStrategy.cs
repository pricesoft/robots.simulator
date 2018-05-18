using Robots.Simulator.Abstractions;

namespace Robots.Simulator.Strategies
{
  /// <summary>
  /// Orientation Strategy for all things West
  /// </summary>
  public class WestOrientationStrategy : IOrientationStrategy
  {
    public IPosition MoveFrom(IPosition currentPosition)
    {
      if (currentPosition.X <= 0)
        return currentPosition;

      currentPosition.X = currentPosition.X - 1;

      return currentPosition;
    }

    public IOrientationStrategy TurnLeft()
    {
      return new SouthOrientationStrategy();
    }

    public IOrientationStrategy TurnRight()
    {
      return new NorthOrientationStrategy();
    }

    public OrientationEnum Name => OrientationEnum.West;
  }
}
