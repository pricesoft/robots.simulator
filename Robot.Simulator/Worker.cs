using System.IO;
using Robots.Simulator.Abstractions;

namespace Robots.Simulator
{
  public class Worker : IWorker
  {
    private readonly ToyRobotBase _robot;
    private readonly ISurface _surface;
    private readonly TextWriter _writer;

    public Worker(ToyRobotBase robot, ISurface surface, TextWriter writer)
    {
      _robot = robot;
      _surface = surface;
      _writer = writer;

      _robot.CommandCompletedEvent += PrintToOutput;
    }

    /// <summary>
    /// Entry point for command processing.
    /// </summary>
    /// <param name="commandLineArgs"></param>
    public void ProcessCommand(string commandLineArgs)
    {
      if (!TryGetCommand(commandLineArgs, out var command))
      {
        _writer.WriteLine("Supplied command is unreadable.");
        return;
      }

      //if robot hasn't been placed, and the current command is not a place command
      if (!_surface.IsRobotPlaced && !command.ToLower().Equals("place"))
      {
        _writer.WriteLine("Robot not placed yet! Send 'Place' command to get started");
        return;
      }

      //TODO: Use of switch statement here could be tidied-up to use a Strategy pattern.
      switch (command.ToLower())
      {
        case "place":

          if (TryGetPlacementCommandArgument(commandLineArgs, out var placeArgument))
          {
            _surface.IsRobotPlaced = _robot.Place(placeArgument.ArgsX, placeArgument.ArgsY);
          }
          else
          {
            _writer.WriteLine("Invalid placement instructions, please provide position instructions in format 'place 0:0'.");
          }

        break;

        case "move":

           _robot.Move();

        break;

        case "right":

          _robot.ChangeRight();

        break;

        case "left":

          _robot.ChangeLeft();

        break;

        default:

          _writer.WriteLine("Invalid command. Please provide a valid command");

        break;
      }
    }

    private void PrintToOutput(object sender, ToyRobotCommandEventArgs args)
    {
      var currentOrientation = _robot.GetCurrentOrientation();
      var currentPosition = _robot.GetCurrentPosition();

      _writer.WriteLine($"Completed: {args.CommandName}. ({currentPosition.X},{currentPosition.Y}) { currentOrientation.Name }");
    }

    private bool TryGetCommand(string argString, out string command)
    {
      var containsArgs = argString.Contains(" ");

      //handle for PLACE command
      if (containsArgs)
      {
        var commandArgs = argString.Split(' ');

        command = commandArgs[0];
        return true;
      }

      //can check for valid commands here and return false
      //return false

      command = argString;
      return true;
    }

    private bool TryGetPlacementCommandArgument(string argString, out PlaceToyRobotCommandArgument args)
    {
      var commandInstructions = argString.Split(' ');

      if (commandInstructions.Length.Equals(2))
      {
        var argParts = commandInstructions[1].Split(':');

        if (argParts.Length.Equals(2) && int.TryParse(argParts[0], out var xArg) &&
            int.TryParse(argParts[1], out var yArg))
        {
          args = new PlaceToyRobotCommandArgument
          {
            ArgsX = xArg,
            ArgsY = yArg,
          };

          return true;
        }
      }

      args = null;
      return false;
    }
  }
}
