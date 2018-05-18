using System;

namespace Robots.Simulator.Abstractions
{
  public abstract class ToyRobotBase
  {
    public abstract bool Place(int x, int y);
    public abstract void Move();
    public abstract void ChangeLeft();
    public abstract void ChangeRight();

    public virtual void Report(string command)
    {
      var toyRobotEventArgs = new ToyRobotCommandEventArgs
      {
        CommandName = command,
      };

      OnCommandCompletedEvent(toyRobotEventArgs);
    }

    public abstract IOrientationStrategy GetCurrentOrientation();
    public abstract IPosition GetCurrentPosition();
    public event EventHandler<ToyRobotCommandEventArgs> CommandCompletedEvent;

    private void OnCommandCompletedEvent(ToyRobotCommandEventArgs e)
    {
      var handler = CommandCompletedEvent;
      handler?.Invoke(this, e);
    }
  }
}
