using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
    }
}
