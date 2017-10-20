using System;
using System.Drawing;

namespace TheQuest
{
    internal class Ghoul : Enemy
    {
        public Ghoul(Game game, Point location) : base (game, location, 10){ }

        public override void Move(Random random)
        {
            if (!IsDead)
            {
                if (random.Next(0, 3) < 2)
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
