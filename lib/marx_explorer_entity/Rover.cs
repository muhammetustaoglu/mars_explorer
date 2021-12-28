using System.Collections.Generic;

namespace mars_explorer_entity
{
    public class Rover
    {
        public int PointX { get; set; }
        public int PointY { get; set; }
        public Direction Direction { get; set; }
        public List<char> Moves { get; set; }

        public Rover()
        {
            this.PointX = 0;
            this.PointY = 0;
            this.Direction = Direction.N;
            this.Moves = new List<char>();
        }

        public void TurnRight()
        {
            switch (this.Direction)
            {
                case Direction.N:
                    this.Direction = Direction.E;
                    break;
                case Direction.S:
                    this.Direction = Direction.W;
                    break;
                case Direction.E:
                    this.Direction = Direction.S;
                    break;
                case Direction.W:
                    this.Direction = Direction.N;
                    break;
                default:
                    break;
            }
        }

        public void TurnLeft()
        {
            switch (this.Direction)
            {
                case Direction.N:
                    this.Direction = Direction.W;
                    break;
                case Direction.S:
                    this.Direction = Direction.E;
                    break;
                case Direction.E:
                    this.Direction = Direction.N;
                    break;
                case Direction.W:
                    this.Direction = Direction.S;
                    break;
                default:
                    break;
            }
        }

        public void ActOneGrid()
        {
            switch (this.Direction)
            {
                case Direction.N:
                    this.PointY += 1;
                    break;
                case Direction.S:
                    this.PointY -= 1;
                    break;
                case Direction.E:
                    this.PointX += 1;
                    break;
                case Direction.W:
                    this.PointX -= 1;
                    break;
                default:
                    break;
            }
        }
    }
}