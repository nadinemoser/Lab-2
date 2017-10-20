using System;
using System.Drawing;

namespace TheQuest
{
    internal abstract class Weapon : Mover
    {
        public bool PickedUp { get; private set; }

        public Weapon(Game game, Point location) : base(game, location)
        {
            PickedUp = false;
        }

        public void PickUpWeaopon()
        {
            PickedUp = true;
        }

        public abstract string Name { get; }

        public abstract void Attack(Direction direction, Random random);

        protected bool DamageEnemy(Direction direction, int radius, int damage, Random random)
        {
            Point target = _game.PlayerLocation;
            for (int distance = 0; distance < radius  ; distance++)
            {
                foreach (Enemy enemy in _game.Enemies)
                {
                    if(Nearby(enemy.Location, target, distance))
                    {
                        enemy.Hit(damage, random);
                        return true;
                    }
                }
                target = Move(direction, target, _game.Boundaries);
            }
            return false;
        }

        public bool Nearby(Point locationToCheck, Point target, int distance)
        {
            if (Math.Abs(target.X - locationToCheck.X) < distance && (Math.Abs(target.Y - locationToCheck.Y) < distance))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Point Move(Direction direction, Point target, Rectangle boundaries)
        {
            Point newLocation = target;
            int moveInternal = 10;

            switch (direction)
            {
                case Direction.Up:
                    if (newLocation.Y + moveInternal >= boundaries.Top)
                        newLocation.Y -= moveInternal;
                    break;
                case Direction.Down:
                    if (newLocation.Y + moveInternal <= boundaries.Bottom)
                        newLocation.Y += moveInternal;
                    break;
                case Direction.Left:
                    if (newLocation.X - moveInternal >= boundaries.Left)
                        newLocation.X -= moveInternal;
                    break;
                case Direction.Right:
                    if (newLocation.X + moveInternal <= boundaries.Right)
                        newLocation.X += moveInternal;
                    break;
                default: break;
            }
            return newLocation;
        }
    }
}
