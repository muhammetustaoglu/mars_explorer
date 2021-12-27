using System;
using System.Collections.Generic;

namespace mars_explorer_service
{
    public class ExploreService : IExploreService
    {
        public int HorizonX { get; set; }
        public int HorizonY { get; set; }
        public List<Rover> Rovers { get; set; }
        protected IEvaluator InputEvaluator { get; set; }
        public ExploreService(IEvaluator evaluator)
        {
            this.InputEvaluator = evaluator;
            this.InputEvaluator.Evaluate(this.HorizonX, this.HorizonY, this.Rovers);
        }

        public void Explore(Rover rover)
        {
            foreach (string move in rover.Moves)
            {
                switch (move)
                {
                    case "L":
                        rover.TurnLeft();
                        break;
                    case "R":
                        rover.TurnRight();
                        break;
                    case "M":
                        rover.ActOneGrid();
                        break;
                    default:
                        throw new ArgumentException(string.Format("Not expected character. {0}", move));
                }
            }
        }
    }
}
