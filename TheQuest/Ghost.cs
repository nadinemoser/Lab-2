using System;
using System.Drawing;

namespace TheQuest
{
    internal class Ghost : Enemy
    {
        public Ghost(Game game, Point location) : base (game, location, 8){ }

        public override void Move(Random random)
        {
            if (!IsDead)
            {
                if (random.Next(0, 3) < 1)
                {
                    base._location = Move(FindPlayerDirection(_game.PlayerLocation), _game.Boundaries);
                }

                if (NearPlayer())
                {
                    _game.HitPlayer(4, random);
                }
            }
        }
    }
}
