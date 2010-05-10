using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace TheQuest {
    public class Ghoul : Enemy, ISprite {
        public Ghoul(Game game, Point location, Size spriteSize)
            : base(game, location, 10, spriteSize) { }

        public override void Move(Random random) {
            if (random.Next(1, 3) != 1) {
                location = Move(FindPlayerDirection(game.PlayerLocation), game.Boundaries);
            }

            if (NearPlayer()) {
                game.HitPlayer(4, random);
            }
        }
    }
}
