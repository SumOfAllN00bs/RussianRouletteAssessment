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

namespace RussianRouletteAssessment
{
    public partial class frm_ScoreBoard : Form
    {
        string[] ScoreBoardCheats;

        public frm_ScoreBoard()
        {
            InitializeComponent();
            ScoreBoardCheats = null;
        }
        public frm_ScoreBoard(string [] cheats)
        {
            InitializeComponent();
            ScoreBoardCheats = cheats;
        }

        private void frm_ScoreBoard_Load(object sender, EventArgs e)
        {
            //handle cheats

            //override previous cheat usage possibly redundent in future
            /*
            dgv_HighScores.Columns["UserName"].ReadOnly = true;
            dgv_HighScores.Columns["HighScore"].ReadOnly = true;
            dgv_HighScores.Columns["TimesPlayed"].ReadOnly = true;
            dgv_HighScores.Columns["BulletsFired"].ReadOnly = true;
            dgv_HighScores.Columns["Deaths"].ReadOnly = true;
            dgv_HighScores.Columns["CloseCalls"].ReadOnly = true;
            dgv_HighScores.Columns["DeiExMachina"].ReadOnly = true;*/

            if (ScoreBoardCheats != null)
            {
                foreach (string cheat in ScoreBoardCheats)
                {
                    switch (cheat)
                    {
                        case "Edit Scores":
                            dgv_HighScores.Columns["HighScore"].ReadOnly = false;
                            btn_Save.Visible = true;
                            btn_Save.Enabled = true;
                            break;
                        case "Edit All":
                            dgv_HighScores.Columns["UserName"].ReadOnly = false;
                            dgv_HighScores.Columns["HighScore"].ReadOnly = false;
                            dgv_HighScores.Columns["TimesPlayed"].ReadOnly = false;
                            dgv_HighScores.Columns["BulletsFired"].ReadOnly = false;
                            dgv_HighScores.Columns["Deaths"].ReadOnly = false;
                            dgv_HighScores.Columns["CloseCalls"].ReadOnly = false;
                            dgv_HighScores.Columns["DeiExMachina"].ReadOnly = false;
                            btn_Save.Visible = true;
                            btn_Save.Enabled = true;
                            break;
                        default:
                            break;
                    }
                }
            }

            this.Text = "High Scores - Welcome " + frm_PlayerProfile.profile_Name;
            if (!File.Exists(frm_Menu.HighScoresFilename))
            {
                MessageBox.Show("Error: High Scores file not found: " + frm_Menu.HighScoresFilename + ".\r\n Creating new High Scores file");
                File.Create(frm_Menu.HighScoresFilename).Close();
            }

            using (StreamReader reader = new StreamReader(frm_Menu.HighScoresFilename))
            { 
                while (!reader.EndOfStream)
                {
                    string [] player_info = reader.ReadLine().Split(',');
                    dgv_HighScores.Rows.Add(new string[] { player_info[0],  //username
                                                            player_info[2], //score
                                                            player_info[3], //times played
                                                            player_info[4], //deaths
                                                            player_info[5], //shots fired
                                                            player_info[6], //close calls
                                                            player_info[7] }); //dei ex machina
                }
            }
        }

        private void dgv_HighScores_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            //some code copy pasted from http://stackoverflow.com/questions/12645458/make-a-specific-column-only-accept-numeric-value-in-datagridview-in-keypress-eve
            e.Control.KeyPress -= new KeyPressEventHandler(HighScore_Column_KeyPress);

            if (dgv_HighScores.CurrentCell.ColumnIndex >= dgv_HighScores.Columns["HighScore"].Index)
            {
                TextBox ScoreTextBox = e.Control as TextBox;
                if (ScoreTextBox != null) ScoreTextBox.KeyPress += new KeyPressEventHandler(HighScore_Column_KeyPress);
            }
        }

        private void HighScore_Column_KeyPress(object sender, KeyPressEventArgs e)
        {
            //only allowing digits through
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar)) e.Handled = true;
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            using (StreamWriter writer = new StreamWriter(frm_Menu.HighScoresFilename))
            {
                for (int record = 0; record < dgv_HighScores; record++)
                {

                }
            }
        }
    }
}
