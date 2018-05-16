namespace Robots.Simulator.Abstractions
{
  public interface IOrientationStrategy
  {
    OrientationEnum Name { get; }

    IOrientationStrategy Right();
    IOrientationStrategy Left();
    IPosition Move(IPosition currentPosition);
  }
}
