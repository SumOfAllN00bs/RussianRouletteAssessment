using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//todo: create new image based on color choice to make profile pictures colored

namespace RussianRouletteAssessment
{
    public partial class frm_PlayerProfile : Form
    {
        //public variables for use in other parts of the program
        public static string profile_Name;
        public static string profile_Pic_Name;
        public static Image profile_Pic;

        //private variables
        private static frm_PlayerProfile me;
        private static Assembly assembly;
        private static Stream imagestream;
        private bool firstRun = true;
        private List<string> UserProfiles = new List<string>();

        //private methods
        private void set_PictureBox_To_Profile_Picture(int index)
        {
            if (assembly == null) //just in case
            {
                return;
            }
            imagestream = assembly.GetManifestResourceStream(frm_Menu.ProfilePictures[index][0]);
            pb_ProfilePic.Image = new Bitmap(imagestream);
            profile_Pic = pb_ProfilePic.Image;
        }
        //overloaded
        private void set_PictureBox_To_Profile_Picture(string byName)
        {
            //calls its other version so we don't have duplicate code
            set_PictureBox_To_Profile_Picture(frm_Menu.ProfilePicturesGetIndex(byName));
        }

        //public methods

        /// <summary>
        /// Used to update the stored picture if edited from highscore board
        /// </summary>
        public static void UpdatePic(string NewPicName)
        {
            if (assembly == null || me == null) //just in case
            {
                return;
            }
            profile_Pic_Name = NewPicName;
            imagestream = assembly.GetManifestResourceStream(frm_Menu.ProfilePictures[frm_Menu.ProfilePicturesGetIndex(NewPicName)][0]);
            profile_Pic = new Bitmap(imagestream);
        }

        public frm_PlayerProfile()
        {
            InitializeComponent();
        }

        private void btn_Continue_Click(object sender, EventArgs e)
        {
            //test to see if user inputed actual text or anything other than space if not return
            if (String.IsNullOrEmpty(cb_UserName.Text) || cb_UserName.Text.Trim().Length == 0)
            {
                return;
            }
            profile_Name = cb_UserName.Text;

            this.Close();
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cb_ProfilePictures_SelectedIndexChanged(object sender, EventArgs e)
        {
            //instantly change picture box to selected picture
            set_PictureBox_To_Profile_Picture(cb_ProfilePictures.SelectedItem.ToString());
            profile_Pic_Name = cb_ProfilePictures.SelectedItem.ToString();
        }

        private void cb_UserName_SelectedIndexChanged(object sender, EventArgs e)
        {
            profile_Name = cb_UserName.Text;
            using (StreamReader reader = new StreamReader(frm_Menu.HighScoresFilename))
            {
                while (!reader.EndOfStream)
                {
                    string[] tmpArray = reader.ReadLine().Split(',');
                    if (tmpArray[0] == profile_Name)
                    {
                        set_PictureBox_To_Profile_Picture(tmpArray[1]);
                        cb_ProfilePictures.SelectedItem = tmpArray[1];
                        profile_Pic_Name = tmpArray[1];
                    }
                }
            }
        }

        private void frm_PlayerProfile_Load(object sender, EventArgs e)
        {
            try
            {
                me = this;
                //Grab the assembly our form belongs to
                assembly = Assembly.GetExecutingAssembly();

                //Check if scores exist and load user names from score board
                if (File.Exists(frm_Menu.HighScoresFilename))
                {
                    using (StreamReader reader = new StreamReader(frm_Menu.HighScoresFilename))
                    {
                        UserProfiles.Clear();
                        UserProfiles.Add("");
                        while (!reader.EndOfStream)
                        {
                            UserProfiles.Add(reader.ReadLine().Split(',')[0]);
                        }
                        //List<string> tmpList = UserProfiles.Distinct().ToList();
                        //UserProfiles = tmpList;
                    }
                    cb_UserName.DataSource = UserProfiles;
                }

                //Load Combo box with the Profile Picture Options
                cb_ProfilePictures.Items.Clear();
                for (int i = 0; i < 25; i++)
                {
                    cb_ProfilePictures.Items.Add(frm_Menu.ProfilePictures[i][1]);
                }

                //stop running so as to load the current selected picture when we 
                //click on New User from main form
                if (firstRun)
                {
                    //Load the Picture box with the first Profile picture as a default
                    //select the first item which will call set_PictureBox_To_Profile_Picture
                    cb_ProfilePictures.SelectedIndex = 0;
                    firstRun = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
