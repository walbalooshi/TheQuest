using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TheQuest {
    public partial class Dungeon : Form {
        private Game game;
        private Random random = new Random();

        public Dungeon() {
            InitializeComponent();
        }

        private void Dungeon_Load(object sender, EventArgs e) {
            game = new Game(new Rectangle(78, 57, 420, 155));
            game.NewLevel(random);
            UpdateCharacters();
        }

        private void SwordInvSprite_Click(object sender, EventArgs e) {
            SelectInventoryItem(SwordInvSprite, "Sword", "weapon");
        }

        private void RedPotionInvSprite_Click(object sender, EventArgs e) {
            SelectInventoryItem(RedPotionInvSprite, "Red Potion", "potion");
        }

        private void BowInvSprite_Click(object sender, EventArgs e) {
            SelectInventoryItem(BowInvSprite, "Bow", "weapon");
        }

        private void BluePotionInvSprite_Click(object sender, EventArgs e) {
            SelectInventoryItem(BluePotionInvSprite, "Blue Potion", "potion");
        }

        private void MaceInvSprite_Click(object sender, EventArgs e) {
            SelectInventoryItem(MaceInvSprite, "Mace", "weapon");
        }

        private void SelectInventoryItem(PictureBox itemSprite, string itemName, string weaponType) {
            if (game.CheckPlayerInventory(itemName)) {
                game.Equip(itemName);
                RemoveInventorySpriteBorders();
                itemSprite.BorderStyle = BorderStyle.FixedSingle;
                SetupAttackButtons(weaponType);
            }
        }

        private void RemoveInventorySpriteBorders() {
            SwordInvSprite.BorderStyle = BorderStyle.None;
            RedPotionInvSprite.BorderStyle = BorderStyle.None;
            BowInvSprite.BorderStyle = BorderStyle.None;
            BluePotionInvSprite.BorderStyle = BorderStyle.None;
            MaceInvSprite.BorderStyle = BorderStyle.None;
        }

        private void SetupAttackButtons(string weaponType) {
            switch (weaponType.ToLower()) {
                case "weapon":
                    AttackUp.Text = "Up";
                    AttackRight.Visible = true;
                    AttackDown.Visible = true;
                    AttackLeft.Visible = true;
                    break;
                case "potion":
                    AttackUp.Text = "Drink";
                    AttackRight.Visible = false;
                    AttackDown.Visible = false;
                    AttackLeft.Visible = false;
                    break;
            }
        }

        private void MoveUp_Click(object sender, EventArgs e) {
            game.Move(Direction.Up, random);
            UpdateCharacters();
        }

        private void MoveRight_Click(object sender, EventArgs e) {
            game.Move(Direction.Right, random);
            UpdateCharacters();
        }

        private void MoveDown_Click(object sender, EventArgs e) {
            game.Move(Direction.Down, random);
            UpdateCharacters();
        }

        private void MoveLeft_Click(object sender, EventArgs e) {
            game.Move(Direction.Left, random);
            UpdateCharacters();
        }
    }
}
