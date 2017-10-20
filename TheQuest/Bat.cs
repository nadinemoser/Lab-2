using System;
using System.Drawing;

namespace TheQuest
{
    internal class Bat : Enemy
    {
        public Bat(Game game, Point location) : base (game, location, 6){}

        public override void Move(Random random)
        {
            if (!IsDead)
            {
                if (random.Next(0, 2) < 1)
                {
                    base._location = Move(FindPlayerDirection(_game.PlayerLocation), _game.Boundaries);
                }
                else
                {
                    int direction = random.Next(0, 4);
                    base._location = Move((Direction)direction, _game.Boundaries);
                }

                if (NearPlayer())
                {
                    _game.HitPlayer(2, random);
                }
            }
        }
    }
}
