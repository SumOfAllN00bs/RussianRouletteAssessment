using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

/*This will be the main form from which the main operation of the overall game is handled
 * It will contain the Resource name strings for the Profile Pictures (using string [][] ProfilePictures) 25 pictures with an associated name
 * It will launch the Profile selection screen
 * It will handle new games and exiting of the game
 */
 //todo:Animate Opacity of non-main forms when loading to fade in over a half second
namespace RussianRouletteAssessment
{
    public partial class frm_Menu : Form
    {
        //public variables for use in other parts of the program

        //High score board
        public static frm_ScoreBoard HighScores = new frm_ScoreBoard();
        //file name of scores database
        public static string HighScoresFilename = "scores.csv";
        //the number of fields used in the highscore records
        public static int HighScoresFileFieldsCount = 8;
        //all the profile pictures embedded in the program and names to use when listing them must remember this is jagged array
        public static string[][] ProfilePictures = new string[][] {     new string []{"RussianRouletteAssessment.PlayerIcons.abstract-007.png", "Abstract 1"},
                                                                        new string []{"RussianRouletteAssessment.PlayerIcons.abstract-061.png", "Abstract 2"},
                                                                        new string []{"RussianRouletteAssessment.PlayerIcons.abstract-113.png", "Abstract 3"},
                                                                        new string []{"RussianRouletteAssessment.PlayerIcons.alien-skull.png", "Alien Skull"},
                                                                        new string []{"RussianRouletteAssessment.PlayerIcons.android-mask.png", "Android Mask"},
                                                                        new string []{"RussianRouletteAssessment.PlayerIcons.angler-fish.png", "Angler Fish"},
                                                                        new string []{"RussianRouletteAssessment.PlayerIcons.arrest.png", "Arrest"},
                                                                        new string []{"RussianRouletteAssessment.PlayerIcons.baby-face.png", "Baby Face"},
                                                                        new string []{"RussianRouletteAssessment.PlayerIcons.balaclava.png", "Balaclava"},
                                                                        new string []{"RussianRouletteAssessment.PlayerIcons.biceps.png", "Biceps"},
                                                                        new string []{"RussianRouletteAssessment.PlayerIcons.big-egg.png", "Big Egg"},
                                                                        new string []{"RussianRouletteAssessment.PlayerIcons.blade-bite.png", "Blade Bite"},
                                                                        new string []{"RussianRouletteAssessment.PlayerIcons.boxing-glove.png", "Boxing Glove"},
                                                                        new string []{"RussianRouletteAssessment.PlayerIcons.broken-skull.png", "Broken Skull"},
                                                                        new string []{"RussianRouletteAssessment.PlayerIcons.bullseye.png", "Bullseye"},
                                                                        new string []{"RussianRouletteAssessment.PlayerIcons.dagger-rose.png", "Dagger Rose"},
                                                                        new string []{"RussianRouletteAssessment.PlayerIcons.dodging.png", "Dodging"},
                                                                        new string []{"RussianRouletteAssessment.PlayerIcons.grenade.png", "Grenade"},
                                                                        new string []{"RussianRouletteAssessment.PlayerIcons.gunshot.png", "Gunshot"},
                                                                        new string []{"RussianRouletteAssessment.PlayerIcons.ice-cream-cone.png", "Ice Cream Cone"},
                                                                        new string []{"RussianRouletteAssessment.PlayerIcons.jason-mask.png", "Jason Mask"},
                                                                        new string []{"RussianRouletteAssessment.PlayerIcons.mad-scientist.png", "Mad Scientist"},
                                                                        new string []{"RussianRouletteAssessment.PlayerIcons.mite-alt.png", "Mite Alt"},
                                                                        new string []{"RussianRouletteAssessment.PlayerIcons.overkill.png", "Overkill"},
                                                                        new string []{"RussianRouletteAssessment.PlayerIcons.pistol-gun.png", "Pistol Gun"}};
        //private variables
        private bool Cheating = false;
        //will be first thing player sees
        private frm_PlayerProfile PlayerProfile = new frm_PlayerProfile();
        //hold a copy of itself
        private static frm_Menu me = null;
        //The Game Form
        private frm_Game Game = new frm_Game();

        //public functions

        /// <summary>
        /// Returns the index of byName which is the name associated with an embedded resource image
        /// </summary>
        /// <param name="byName"></param>
        /// <returns>integer that represents the index into the ProfilePictures array</returns>
        public static int ProfilePicturesGetIndex(string byName)
        {
            //use lambda as predicate to extract from array
            return Array.FindIndex(ProfilePictures, (string[] x) => x[1] == byName); 
        }

        /// <summary>
        /// To allow a form that edits the score board to update the main form
        /// I create a static method that will call a non-static method on a reference to the form
        /// </summary>
        public static void SetProfileStats()
        {
            if (me == null)
            {
                return;
            }
            me.SetMyProfileStats();
        }
        
        //private utility functions functions

        private void SetMyProfileStats()
        {
            try
            {
                if (File.Exists(HighScoresFilename))
                {
                    using (StreamReader reader = new StreamReader(HighScoresFilename))
                    {
                        string playerinfo = "";
                        bool player_found = false;
                        bool fieldformatfaultfound = false;
                        while (!reader.EndOfStream)
                        {
                            playerinfo = reader.ReadLine();
                            string[] player_data = playerinfo.Split(',');
                            if (player_data.Length != HighScoresFileFieldsCount)
                            {
                                fieldformatfaultfound = true;
                            }
                            if (player_data[0] == txt_UserName.Text)
                            {
                                player_found = true;
                                try
                                {
                                    txt_HighScore.Text = player_data[2];
                                    txt_TimesPlayed.Text = player_data[3];
                                    txt_Deaths.Text = player_data[4];
                                    txt_BulletsShot.Text = player_data[5];
                                    txt_CloseCalls.Text = player_data[6];
                                    txt_DeiExMachina.Text = player_data[7];
                                    frm_PlayerProfile.UpdatePic(player_data[1]);
                                    pb_ProfilePic.Image = frm_PlayerProfile.profilePic;
                                }
                                catch (IndexOutOfRangeException ex)
                                {
                                    fieldformatfaultfound = true;
                                    Console.WriteLine(ex.Message);
                                }
                            }
                        }
                        if (fieldformatfaultfound)
                        {
                            MessageBox.Show("Possible Error in High Score File");
                        }
                        if (!player_found)
                        {
                            txt_HighScore.Text = 0 + "";
                            txt_TimesPlayed.Text = 0 + "";
                            txt_Deaths.Text = 0 + "";
                            txt_BulletsShot.Text = 0 + "";
                            txt_CloseCalls.Text = 0 + "";
                            txt_DeiExMachina.Text = 0 + "";

                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        /// <summary>
        /// Returns an array of strings each string being a cheat that was entered 
        /// into the lb_ActiveCheats listbox.
        /// </summary>
        /// <returns>string []</returns>
        private string [] CheatsFromListBox()
        {
            if (lb_ActiveCheats != null)
            {
                if (lb_ActiveCheats.Items.Count != 0)
                {
                    List<string> stringCollector = new List<string>();
                    foreach (string cheat in lb_ActiveCheats.Items)
                    {
                        stringCollector.Add(cheat);
                    }
                    return stringCollector.ToArray();
                }
                else return new string[] { "" };
            }
            else return new string[] { "" };
        }

        private void NewPlayer()
        {
            PlayerProfile.ShowDialog();
            this.Text = "Main Menu - Welcome " + frm_PlayerProfile.profileName;
            txt_UserName.Text = frm_PlayerProfile.profileName;
            SetMyProfileStats();
        }

        public frm_Menu()
        {
            InitializeComponent();
        }

        private void frm_Menu_Load(object sender, EventArgs e)
        {
            me = this;
            this.KeyPreview = true;
            //Get the player to either fill in a new profile or load one from stored in the highscores data base
            NewPlayer();
        }

        private void frm_Menu_KeyDown(object sender, KeyEventArgs e)
        {
            //Ctrl+Alt+C activates Cheater menu
            if(e.Control && e.Alt && e.KeyCode == Keys.C)
            {
                if (!Cheating)
                {
                    Cheating = true;
                    pnl_CheatMenu.Visible = true;
                    pnl_CheatMenu.Enabled = true;
                }
                else
                {
                    Cheating = false;
                    pnl_CheatMenu.Visible = false;
                    pnl_CheatMenu.Enabled = false;
                }
            }
        }

        private void btn_ExitGame_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lb_AvailableCheats_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lb_AvailableCheats.SelectedItem != null)
            {
                lb_ActiveCheats.Items.Add(lb_AvailableCheats.SelectedItem);
                lb_AvailableCheats.Items.Remove(lb_AvailableCheats.SelectedItem);
            }

        }

        private void lb_ActiveCheats_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lb_ActiveCheats.SelectedItem != null)
            {
                lb_AvailableCheats.Items.Add(lb_ActiveCheats.SelectedItem);
                lb_ActiveCheats.Items.Remove(lb_ActiveCheats.SelectedItem);
            }
        }

        private void btn_HighScores_Click(object sender, EventArgs e)
        {
            //only allow one instance of the highscore board
            if (Application.OpenForms["frm_ScoreBoard"] == null)
            {
                if (Cheating)
                {
                    HighScores = new frm_ScoreBoard(CheatsFromListBox());
                }
                else HighScores = new frm_ScoreBoard();

                HighScores.Show(); 
            }
            else
            {
                HighScores.Focus();
            }
        }

        private void btn_NewPlayer_Click(object sender, EventArgs e)
        {
            NewPlayer();
        }

        private void btn_NewGame_Click(object sender, EventArgs e)
        {
            frm_Game.NewGame = true;
            //run game
            //In modal mode so we don't get confused by multiple high scores and player profiles
            while (frm_Game.NewGame)
            {
                Game = new frm_Game();
                Game.ShowDialog();
            }
        }
    }
}
