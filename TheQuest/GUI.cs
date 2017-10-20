using System;
using System.Drawing;
using System.Windows.Forms;

namespace TheQuest
{
    public partial class GUI : Form
    {
        private Game _game;
        private static readonly Random _random = new Random();

        public GUI()
        {
            InitializeComponent();
        }

        private void GUI_Load(object sender, EventArgs e)
        {
            _game = new Game(new Rectangle(78, 57, 420, 155));
            _game.NewLevel(_random);
            UpdateGame();
        }

        private void SetAllPictureBoxBordersToNone()
        {
            pictureBoxItemSword.BorderStyle = BorderStyle.None;
            pictureBoxItemBluePotion.BorderStyle = BorderStyle.None;
            pictureBoxItemBow.BorderStyle = BorderStyle.None;
            pictureBoxItemRedPotion.BorderStyle = BorderStyle.None;
            pictureBoxItemMace.BorderStyle = BorderStyle.None;
        }

        private void pictureBoxItemSword_Click(object sender, EventArgs e)
        {
            buttonAttackDown.Show();
            buttonAttackLeft.Show();
            buttonAttackRight.Show();
            buttonAttackUp.Text = "↑";
            if (_game.CheckPlayerInventory("Sword"))
            {
                _game.Equip("Sword");
                SetAllPictureBoxBordersToNone();
                pictureBoxItemSword.BorderStyle = BorderStyle.FixedSingle;
            }
        }
        private void pictureBoxItemMace_Click(object sender, EventArgs e)
        {
            buttonAttackDown.Show();
            buttonAttackLeft.Show();
            buttonAttackRight.Show();
            buttonAttackUp.Text = "↑";
            if (_game.CheckPlayerInventory("Mace"))
            {
                _game.Equip("Mace");
                SetAllPictureBoxBordersToNone();
                pictureBoxItemMace.BorderStyle = BorderStyle.FixedSingle;
            }
        }
        private void pictureBoxItemBow_Click(object sender, EventArgs e)
        {
            buttonAttackDown.Show();
            buttonAttackLeft.Show();
            buttonAttackRight.Show();
            buttonAttackUp.Text = "↑";
            if (_game.CheckPlayerInventory("Bow"))
            {
                _game.Equip("Bow");
                SetAllPictureBoxBordersToNone();
                pictureBoxItemBow.BorderStyle = BorderStyle.FixedSingle;
            }
        }
        private void pictureBoxItemRedPotion_Click(object sender, EventArgs e)
        {
            if (_game.CheckPlayerInventory("Red Potion"))
            {
                _game.Equip("Red Potion");
                SetAllPictureBoxBordersToNone();
                pictureBoxItemRedPotion.BorderStyle = BorderStyle.FixedSingle;
                buttonAttackUp.Text = "Drink";
                buttonAttackDown.Hide();
                buttonAttackLeft.Hide();
                buttonAttackRight.Hide();
            }
        }
        private void pictureBoxItemBluePotion_Click(object sender, EventArgs e)
        {
            if (_game.CheckPlayerInventory("Blue Potion"))
            {
                _game.Equip("Blue Potion");
                SetAllPictureBoxBordersToNone();
                pictureBoxItemBluePotion.BorderStyle = BorderStyle.FixedSingle;
                buttonAttackUp.Text = "Drink";
                buttonAttackDown.Hide();
                buttonAttackLeft.Hide();
                buttonAttackRight.Hide();
            }
        }

        private void buttonMoveUp_Click(object sender, EventArgs e)
        {
            _game.Move(Direction.Up, _random);
            UpdateGame();
        }
        private void buttonMoveRight_Click(object sender, EventArgs e)
        {
            _game.Move(Direction.Right, _random);
            UpdateGame();
        }
        private void buttonMoveDown_Click(object sender, EventArgs e)
        {
            _game.Move(Direction.Down, _random);
            UpdateGame();
        }
        private void buttonMoveLeft_Click(object sender, EventArgs e)
        {
            _game.Move(Direction.Left, _random);
            UpdateGame();
        }

        private void buttonAttackUp_Click(object sender, EventArgs e)
        {
            _game.Attack(Direction.Up, _random);

            UpdateGame();

            if (pictureBoxItemBluePotion.BorderStyle == BorderStyle.FixedSingle)
            {
                buttonAttackDown.Show();
                buttonAttackLeft.Show();
                buttonAttackRight.Show();
                buttonAttackUp.Text = "↑";
                pictureBoxItemBluePotion.Visible = false;
                _game.RemoveWeaponInRoom(true);
            }
            if (pictureBoxItemRedPotion.BorderStyle == BorderStyle.FixedSingle)
            {
                buttonAttackDown.Show();
                buttonAttackLeft.Show();
                buttonAttackRight.Show();
                buttonAttackUp.Text = "↑";
                pictureBoxItemRedPotion.Visible = false;
                _game.RemoveWeaponInRoom(false);
            }
        }
        private void buttonAttackRight_Click(object sender, EventArgs e)
        {
            _game.Attack(Direction.Right, _random);
            UpdateGame();
        }
        private void buttonAttackDown_Click(object sender, EventArgs e)
        {
            _game.Attack(Direction.Down, _random);
            UpdateGame();
        }
        private void buttonAttackLeft_Click(object sender, EventArgs e)
        {
            _game.Attack(Direction.Left, _random);
            UpdateGame();
        }

        public void UpdateGame()
        {
            int enemiesShown = UpdateCharacters();

            if (enemiesShown < 1)
            {
                MessageBox.Show("You have defeated the enemies on this level");
                _game.NewLevel(_random);
                UpdateCharacters();
            }
        }

        public int UpdateCharacters()
        {
            player.Location = _game.PlayerLocation;
            playerHitPoints.Text = _game.PlayerHitPoints.ToString();

            bool showBat = false;
            bool showGhost = false;
            bool showGhoul = false;
            int enemiesShown = 0;

            foreach (Enemy enemy in _game.Enemies)
            {
                if (enemy is Bat)
                {
                    bat.Location = enemy.Location;
                    batHitPoints.Text = enemy.HitPoints.ToString();
                    if (enemy.HitPoints > 0)
                    {
                        showBat = true;
                        enemiesShown++;
                    }
                }

                if (enemy is Ghost)
                {
                    ghost.Location = enemy.Location;
                    ghostHitPoints.Text = enemy.HitPoints.ToString();
                    if (enemy.HitPoints > 0)
                    {
                        showGhost = true;
                        enemiesShown++;
                    }
                }

                if (enemy is Ghoul)
                {
                    ghoul.Location = enemy.Location;
                    ghoulHitPoints.Text = enemy.HitPoints.ToString();
                    if (enemy.HitPoints > 0)
                    {
                        showGhoul = true;
                        enemiesShown++;
                    }
                }
            }

            if (!showBat)
            {
                bat.Visible = false;
                batHitPoints.Text = "";
            }
            else
            {
                bat.Visible = true;
            }
            if (!showGhost)
            {
                ghost.Visible = false;
                ghostHitPoints.Text = "";
            }
            else
            {
                ghost.Visible = true;
            }
            if (!showGhoul)
            {
                ghoul.Visible = false;
                ghoulHitPoints.Text = "";
            }
            else
            {
                ghoul.Visible = true;
            }

            sword.Visible = false;
            bow.Visible = false;
            redPotion.Visible = false;
            bluePotion.Visible = false;
            mace.Visible = false;

            Control weaponControl = null;
            switch (_game.WeaponInRoom.Name)
            {
                case "Sword":
                    weaponControl = sword;
                    break;
                case "Bow":
                    weaponControl = bow;
                    break;
                case "Mace":
                    weaponControl = mace;
                    break;
                case "Blue Potion":
                    weaponControl = bluePotion;
                    break;
                case "Red Potion":
                    weaponControl = redPotion;
                    break;
            }
            weaponControl.Visible = true;

            pictureBoxItemSword.Visible = false;
            pictureBoxItemBluePotion.Visible = false;
            pictureBoxItemBow.Visible = false;
            pictureBoxItemRedPotion.Visible = false;
            pictureBoxItemMace.Visible = false;

            if (_game.CheckPlayerInventory("Sword"))
                pictureBoxItemSword.Visible = true;
            if (_game.CheckPlayerInventory("Blue Potion"))
                pictureBoxItemBluePotion.Visible = true;
            if (_game.CheckPlayerInventory("Bow"))
                pictureBoxItemBow.Visible = true;
            if (_game.CheckPlayerInventory("Red Potion"))
                pictureBoxItemRedPotion.Visible = true;
            if (_game.CheckPlayerInventory("Mace"))
                pictureBoxItemMace.Visible = true;

            weaponControl.Location = _game.WeaponInRoom.Location;
            if (_game.WeaponInRoom.PickedUp)
                weaponControl.Visible = false;
            else
                weaponControl.Visible = true;

            if (_game.PlayerHitPoints <= 0)
            {
                MessageBox.Show("You died");
                Application.Exit();
            }

            return enemiesShown;
        }
    }
}
