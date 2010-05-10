using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace TheQuest {
    public class Bat : Enemy {
        public Bat(Game game, Point location, Size spriteSize)
            : base(game, location, 6, spriteSize) { }

        public override void Move(Random random) {
            if (random.Next(1, 2) == 1) {
                location = Move(FindPlayerDirection(game.PlayerLocation), game.Boundaries);
            } else {
                location = Move((Direction)random.Next(1, 4), game.Boundaries);
            }
            if (NearPlayer()) {
                game.HitPlayer(2, random);
            }
        }
    }
}
