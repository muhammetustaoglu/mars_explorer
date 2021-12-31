using mars_explorer_entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace mars_explorer_business
{
    public class InputEvaluator : IEvaluator
    {
    private const string[] Directions=new[]{"N","S","W","E"};
    private const string[] Commands=new[]{"L","R","M"};
        protected IExploreEntity ExploreEntity { get; set; }
        public InputEvaluator(IExploreEntity exploreEntity)
        {
            this.ExploreEntity = exploreEntity;
        }

        public IExploreEntity Evaluate(List<string> inputLines)
        {
            string[] horizon = inputLines[0].Trim().Split(' ');

            if (inputLines.Count == 1)
                throw new ArgumentException("No rover defined");

            int horizonX, horizonY;

            if (int.TryParse(horizon[0], out horizonX))
                this.ExploreEntity.HorizonX = horizonX;
            else
                throw new ArgumentException("Horizon X should be positive integer");

            if (int.TryParse(horizon[1], out horizonY))
                this.ExploreEntity.HorizonY = horizonY;
            else
                throw new ArgumentException("Horizon Y should be positive integer");

            if (this.ExploreEntity.HorizonX < 0 || this.ExploreEntity.HorizonY < 0)
                throw new ArgumentException("Horizon can not be less than 0");

            List<string> inputLinesExceptFirst = inputLines.Skip(1).ToList();
            Rover rover = null;
            int roverX, roverY;
            string direction = string.Empty;

            for (int i = 0; i <= inputLinesExceptFirst.Count - 1; i++)
            {
                if (i % 2 == 0)
                {
                    rover = new Rover();
                    this.ExploreEntity.Rovers.Add(rover);
                    string[] roverPosition = inputLinesExceptFirst[i].Split(' ');

                    if (roverPosition.Length != 3)
                        throw new ArgumentException("Line requires 2 positive digits and 1 direction with 1 space between them");

                    if (int.TryParse(roverPosition[0], out roverX))
                        rover.PointX = roverX;
                    else
                        throw new ArgumentException("Rover X point should be positive integer");

                    if (int.TryParse(roverPosition[1], out roverY))
                        rover.PointY = roverY;
                    else
                        throw new ArgumentException("Rover Y point should be positive integer");

                    rover.PointX = roverX;
                    rover.PointY = roverY;

                    direction = roverPosition[2];

                    if (!Directions.Contains(direction))
                        throw new ArgumentException($"Direction can only be {string.Join(",",Directions)}");

                    rover.Direction = (Direction)Enum.Parse(typeof(Direction), direction);
                }
                else if (i % 2 == 1)
                {
                    rover.Moves = inputLinesExceptFirst[i].ToCharArray().ToList();

                    if (rover.Moves.All(p => Commands.Contains(p))
                        throw new ArgumentException($"Rover command can only be {string.Join(",",Commands)}");
                }
            }

            return this.ExploreEntity;
        }
    }
}
