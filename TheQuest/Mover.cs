using System;
using System.Drawing;

namespace TheQuest
{
    internal abstract class Mover
    {
        private const int Move_Internal = 10;
        protected Point _location;
        protected Game _game;

        public Point Location {  get { return _location; } }

        public Mover(Game game, Point location)
        {
            _game = game;
            _location = location;
        }

        public bool Nearby(Point locationToCheck, int distance)
        {
            if(Math.Abs(_location.X - locationToCheck.X) < distance && (Math.Abs(_location.Y - locationToCheck.Y) < distance))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public virtual Point Move(Direction direction, Rectangle boundaries)
        {
            Point newLocation = _location;
            switch (direction)
            {
                case Direction.Up:
                    if (newLocation.Y - Move_Internal >= boundaries.Top)
                        newLocation.Y -= Move_Internal;
                    break;
                case Direction.Down:
                    if (newLocation.Y + Move_Internal <= boundaries.Bottom)
                        newLocation.Y += Move_Internal;
                    break;
                case Direction.Left:
                    if (newLocation.X - Move_Internal >= boundaries.Left)
                        newLocation.X -= Move_Internal;
                    break;
                case Direction.Right:
                    if (newLocation.X + Move_Internal <= boundaries.Right)
                        newLocation.X += Move_Internal;
                    break;
                default: break;
            }
            return newLocation;
        }       
    }
}
