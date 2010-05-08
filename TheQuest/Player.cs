using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace TheQuest {
    public class Player : Mover {
        private Weapon equippedWeapon;
        private int hitPoints;

        public int HitPoints { get { return hitPoints; } }

        private List<Weapon> inventory = new List<Weapon>();
        public List<string> Weapons {
            get {
                List<string> names = new List<string>();
                foreach (Weapon weapon in inventory) {
                    names.Add(weapon.Name);
                }
                return names;
            }
        }

        public Player(Game game, Point location, Rectangle boundaries) 
                : base(game, location) {
            hitPoints = 10;
        }

        public void Hit(int maxDamage, Random random) {
            hitPoints -= random.Next(1, maxDamage);
        }

        public void IncreaseHealth(int health, Random random) {
            hitPoints += random.Next(1, health);
        }

        public void Equip(string weaponName) {
            foreach(Weapon weapon in inventory) {
                if (weapon.Name == weaponName) {
                    equippedWeapon = weapon;
                }
            }
        }

        public void Move(Direction direction) {
            base.location = Move(direction, game.Boundaries);
            if (!game.WeaponInRoom.PickedUp) {

            }
        }

        public void Attack(Direction direction, Random random) {
            if (equippedWeapon != null) {

            }
        }
    }
}
