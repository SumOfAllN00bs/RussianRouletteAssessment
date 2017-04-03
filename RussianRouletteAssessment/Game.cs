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
    public partial class frm_Game : Form
    {
        //private variables
        Bitmap buffer;
        Graphics GameGraphics;

        //private methods
        private void PaintCanvas()
        {
            GameGraphics.FillRectangle(Brushes.Black, new Rectangle(0, 0, pnl_canvas.Width, pnl_canvas.Height));
            DrawItems(GameGraphics);
            pnl_canvas.CreateGraphics().DrawImageUnscaled(buffer, 0, 0);
        }

        private void DrawItems(Graphics gameGraphics)
        {
            throw new NotImplementedException();
        }

        public frm_Game()
        {
            InitializeComponent();
            //apparently this sets up the form to do painting in the most simplest way
            //I understand OptimizedDoubleBuffer as I have used buffers before when creating animations in software
            //Not 100% sure about UserPaint and AllPaintinInWmPaint need to look these up
            //Although WmPaint sounds like the Windows Message event in C++ win32 painting
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);

            buffer = new Bitmap(pnl_canvas.Width, pnl_canvas.Height);
            GameGraphics = Graphics.FromImage(buffer);
        }

        private void frm_Game_Load(object sender, EventArgs e)
        {
            this.Text = "Russian Roulette - Welcome " + frm_PlayerProfile.profileName;
        }

        private void AnimTimer_Tick(object sender, EventArgs e)
        {

        }
    }
}
