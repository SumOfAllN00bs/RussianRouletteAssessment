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
namespace RussianRouletteAssessment
{
    public partial class frm_Menu : Form
    {
        //public variables for use in other parts of the program

        //file name of scores database
        public static string HighScoresFilename = "scores.csv";
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
        //will be first thing player sees
        frm_Intro PlayerProfile = new frm_Intro();

        public static int ProfilePicturesGetIndex(string byName)
        {
            //use lambda as predicate to extract from array
            return Array.FindIndex(ProfilePictures, (string[] x) => x[1] == byName); 
        }

        public frm_Menu()
        {
            InitializeComponent();
        }

        private void frm_Menu_Load(object sender, EventArgs e)
        {
            //Get the player to either fill in a new profile or load one from stored in the highscores data base
            PlayerProfile.ShowDialog();
            this.Text = "Main Menu - Welcome " + frm_Intro.profile_Name;
        }
    }
}
