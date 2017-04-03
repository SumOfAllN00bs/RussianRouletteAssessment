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
                            dgv_HighScores.Columns["ProfilePic"].ReadOnly = false;
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

            this.Text = "High Scores - Welcome " + frm_PlayerProfile.profileName;
            if (!File.Exists(frm_Menu.HighScoresFilename))
            {
                MessageBox.Show("Error: High Scores file not found: " + frm_Menu.HighScoresFilename + ".\r\n Creating new High Scores file");
                File.Create(frm_Menu.HighScoresFilename).Close();
            }

            using (StreamReader reader = new StreamReader(frm_Menu.HighScoresFilename))
            {
                //need to create array of names before its used in the while loop
                //to fill combobox in gridview
                string[] ProfileNames = new string [25];
                for (int i = 0; i < 25; i++)
                {
                    ProfileNames[i] = frm_Menu.ProfilePictures[i][1];
                }
                /*
                 * The following code was really hard to learn how it works
                 * and took 2-3 days research to get right
                 */
                while (!reader.EndOfStream)
                {
                    string [] player_info = reader.ReadLine().Split(',');
                    DataGridViewComboBoxCell ProfilePics = new DataGridViewComboBoxCell();
                    ProfilePics.Items.AddRange(ProfileNames);
                    ProfilePics.Value = player_info[1];
                    DataGridViewRow PlayerInfoRow = new DataGridViewRow();
                    PlayerInfoRow.Cells.Add(new DataGridViewTextBoxCell() { Value = player_info[0] });  //username
                    PlayerInfoRow.Cells.Add(ProfilePics);                                               //profile pic is combobox
                    PlayerInfoRow.Cells.Add(new DataGridViewTextBoxCell() { Value = player_info[2] });  //score
                    PlayerInfoRow.Cells.Add(new DataGridViewTextBoxCell() { Value = player_info[3] });  //times played
                    PlayerInfoRow.Cells.Add(new DataGridViewTextBoxCell() { Value = player_info[4] });  //deaths
                    PlayerInfoRow.Cells.Add(new DataGridViewTextBoxCell() { Value = player_info[5] });  //shots fired
                    PlayerInfoRow.Cells.Add(new DataGridViewTextBoxCell() { Value = player_info[6] });  //close calls
                    PlayerInfoRow.Cells.Add(new DataGridViewTextBoxCell() { Value = player_info[7] });  //dei ex machina
                    dgv_HighScores.Rows.Add(PlayerInfoRow);
                }
            }
        }

        private void dgv_HighScores_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
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
                for (int record = 0; record < dgv_HighScores.Rows.Count; record++)
                {
                    StringBuilder recordstring = new StringBuilder();
                    for (int data = 0; data < dgv_HighScores.Columns.Count; data++)
                    {
                        recordstring.Append(dgv_HighScores.Rows[record].Cells[data].Value.ToString()+ ",");
                    }
                    recordstring.Remove(recordstring.Length - 1, 1);
                    writer.WriteLine(recordstring.ToString());
                }
            }
            //update the Main form
            frm_Menu.SetProfileStats();
        }
    }
}
