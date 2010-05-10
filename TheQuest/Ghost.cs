using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace TheQuest {
    public class Ghost : Enemy, ISprite {
        public Ghost(Game game, Point location, Size spriteSize) 
            : base(game, location, 8, spriteSize) { }

        public override void Move(Random random) {
            if (random.Next(1, 3) == 1) {
                location = Move(FindPlayerDirection(game.PlayerLocation), game.Boundaries);
            }

            if (NearPlayer()) {
                game.HitPlayer(3, random);
            }
        }
    }
}
