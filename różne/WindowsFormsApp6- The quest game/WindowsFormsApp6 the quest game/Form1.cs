using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp6_the_quest_game
{
    public partial class Form1 : Form
    {
        public void UpdateCharacters()
        {
            playerPictureBox.Location = game.PlayerLocation;
            playerHitPointsLabel.Text = game.PlayerHitPoints.ToString();
            bool showBat = false;
            bool showGhost = false;
            bool showGhoul = false;
            int enemiesShown = 0;

            //wyswietlenie zmiennych przeciwnikow i ich hp
            foreach (Enemy enemy in game.Enemies)
            {
                if (enemy is Bat)
                {
                    batInGamePictureBox.Location = enemy.Location;
                    batHitPointsLabel.Text = enemy.HitPoints.ToString();
                    if (enemy.HitPoints > 0)
                    {
                        showBat = true;
                        enemiesShown++;
                        //?enemy.Move(random);
                    }
                }

                if (enemy is Ghoul)
                {
                    ghoulInGamePictureBox.Location = enemy.Location;
                    ghoulHitPointsLabel.Text = enemy.HitPoints.ToString();
                    if (enemy.HitPoints > 0)
                    {
                        showGhoul = true;
                        enemiesShown++;
                    }
                }

                if (enemy is Ghost)
                {
                    ghostInGamePictureBox.Location = enemy.Location;
                    ghostHitPointsLabel.Text = enemy.HitPoints.ToString();
                    if (enemy.HitPoints > 0)
                    {
                        showGhost = true;
                        enemiesShown++;
                    }
                }
            }

            ///wyswietlanie przeciwnikow
             {
            if (showBat == false)
            {
                batInGamePictureBox.Visible = false;
            }
            else
            {
                batInGamePictureBox.Visible = true;
            }

            if (showGhoul == false)
            {
                ghoulInGamePictureBox.Visible = false;
            }
            else
            {
                ghoulInGamePictureBox.Visible = true;
            }

            if (showGhost == false)
            {
                ghostInGamePictureBox.Visible = false;
            }
            else
            {
                ghostInGamePictureBox.Visible = true;
            }

        }

            //domyslnie bronie sa niewidzoczne- potem trzeba sprawdzic
            {
                swordInGamePictureBox.Visible = false;
                bowInGamePictureBox.Visible = false;
                redPotionInGamePictureBox.Visible = false;
                bluePotionInGamePictureBox.Visible = false;
                maceInGamePictureBox.Visible = false;
            }

            ///sprawdzanie i wyswietlenie broni na mapie  (zawsze max jedna)          
                Control weaponControl = null;
           
                switch (game.WeaponInRoom.Name)
                {
                
                    case "Sword":
                        weaponControl = swordInGamePictureBox;
                        break;

                    case "Bow":
                        weaponControl = bowInGamePictureBox;
                        break;

                    case "Mace":
                        weaponControl = maceInGamePictureBox;
                        break;

                    case "Blue Potion":
                        weaponControl = bluePotionInGamePictureBox;
                        break;

                    case "Red Potion":
                        weaponControl = redPotionInGamePictureBox;
                        break;
                }
                weaponControl.Visible = true;
            
            


            //check inventory and set visible
            {
                if (game.CheckPlayerInventory("Bow"))
                {
                    bowInventoryPictureBox.Visible = true;
                }
                else
                {
                    bowInventoryPictureBox.Visible = false;
                }


                if (game.CheckPlayerInventory("Mace"))
                {
                    maceInventoryPictureBox.Visible = true;
                }
                else
                {
                    maceInventoryPictureBox.Visible = false;
                }



                if (game.CheckPlayerInventory("Sword"))
                {
                    swordInventoryPictureBox.Visible = true;
                }
                else
                {
                    swordInventoryPictureBox.Visible = false;
                }




                if (game.CheckPlayerInventory("Red Potion"))
                {
                    redPotionInventoryPictureBox.Visible = true;
                }
                else
                {
                    redPotionInventoryPictureBox.Visible = false;
                }


                if (game.CheckPlayerInventory("Blue Potion"))
                {
                    bluePotionInventoryPictureBox.Visible = true;
                }
                else
                {
                    bluePotionInventoryPictureBox.Visible = false;
                }
            }

            //ustawienie broni na ziemi
            weaponControl.Location = game.WeaponInRoom.Location;
            //sprawdzenie czy bron podniesiona- jesli nie to ja wyswietla

            if (game.WeaponInRoom.PickedUp)
                weaponControl.Visible = false;
            else
                weaponControl.Visible = true;

            //sprawdzenie HP gracza
            if (game.PlayerHitPoints <= 0)
            {
                MessageBox.Show("You died");
                Application.Exit();
            }

            //sprawdzenie przeciwnikow
            if (enemiesShown < 1)
            {
                MessageBox.Show("You have defeated the enemies on this level");
                game.NewLevel(random);
                UpdateCharacters();
            }

            





        }

        private Game game;
       
        private Random random = new Random();
     


        /*
            private void Form1_Load(object sender, EventArgs e)
        {
            game = new Game(new Rectangle(78, 57, 420, 155));
            game.NewLevel(random);
            UpdateCharacters();
        }*/

        public Form1()
        {
            InitializeComponent();
            game = new Game(new Rectangle(78, 57, 420, 155));
            game.NewLevel(random);
            UpdateCharacters();

        }

        private void moveUpButton_Click(object sender, EventArgs e)
        {
            game.Move(Direction.Up, random);
            UpdateCharacters();
        }

        private void moveDownButton_Click(object sender, EventArgs e)
        {
            game.Move(Direction.Down, random);
            UpdateCharacters();
        }

        private void moveRightButton_Click(object sender, EventArgs e)
        {
            game.Move(Direction.Right, random);
            UpdateCharacters();
        }

        private void moveLeftButton_Click(object sender, EventArgs e)
        {
            game.Move(Direction.Left, random);
            UpdateCharacters();
        }

        private void attackUpButton_Click(object sender, EventArgs e)
        {
            game.Attack(Direction.Up,random);
            UpdateCharacters();
            makeButtonsDefault();
        }

        private void attackRightButton_Click(object sender, EventArgs e)
        {
            game.Attack(Direction.Right, random);
            UpdateCharacters();

        }

        private void attackDownButton_Click(object sender, EventArgs e)
        {
            game.Attack(Direction.Down, random);
            UpdateCharacters();
        }

        private void attackLeftButton_Click(object sender, EventArgs e)
        {
            game.Attack(Direction.Left, random);
            UpdateCharacters();
        }

        private void swordPictureBox_Click(object sender, EventArgs e)
        {
            if (game.CheckPlayerInventory("Sword"))//jesli faktycznie ma miecz
            {
                game.Equip("Sword");
                swordInventoryPictureBox.BorderStyle = BorderStyle.Fixed3D;
                //set every other to none
                makeButtonsDefault();
            };

        }

        private void bowPictureBox_Click(object sender, EventArgs e)
        {
            if (game.CheckPlayerInventory("bow"))
            {
                game.Equip("bow");
                swordInventoryPictureBox.BorderStyle = BorderStyle.FixedSingle;
                //set every other to none
                makeButtonsDefault();
            };
        }

        private void macePictureBox_Click(object sender, EventArgs e)
        {
            if (game.CheckPlayerInventory("mace"))
            {
                game.Equip("mace");
                swordInventoryPictureBox.BorderStyle = BorderStyle.FixedSingle;
                //set every other to none
                makeButtonsDefault();
            };

        }

        private void bluePotionPictureBox_Click(object sender, EventArgs e)
        {
            if (game.CheckPlayerInventory("Blue Potion"))
            {
                game.Equip("Blue Potion");
                bluePotionInventoryPictureBox.BorderStyle = BorderStyle.FixedSingle;
                attackDownButton.Visible = false;
                attackLeftButton.Visible = false;
                attackRightButton.Visible = false;
                attackUpButton.Text = "Drink";
                UpdateCharacters();
            };
        }

        private void redPotionPictureBox_Click(object sender, EventArgs e)
        {
            if (game.CheckPlayerInventory("Red Potion"))
            {
                game.Equip("Red Potion");
                redPotionInventoryPictureBox.BorderStyle = BorderStyle.FixedSingle;
               

                attackDownButton.Visible = false;
                attackLeftButton.Visible = false;
                attackRightButton.Visible = false;
                attackUpButton.Text = "Drink";
                UpdateCharacters();
            };
        }

        private void makeButtonsDefault()
        {
            attackDownButton.Visible = true;
            attackLeftButton.Visible = true;
            attackRightButton.Visible = true;
            attackUpButton.Text = "Up";
        }
    }
}
