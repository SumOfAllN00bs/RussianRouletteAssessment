using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RussianRouletteAssessment
{
    public partial class frm_ScoreBoard : Form
    {
        public frm_ScoreBoard()
        {
            InitializeComponent();
        }

        private void frm_ScoreBoard_Load(object sender, EventArgs e)
        {
            this.Text = "High Scores - Welcome " + frm_Intro.profile_Name;
        }
    }
}
