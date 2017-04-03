namespace RussianRouletteAssessment
{
    partial class frm_Game
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Game));
            this.AnimTimer = new System.Windows.Forms.Timer(this.components);
            this.pnl_canvas = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // AnimTimer
            // 
            this.AnimTimer.Interval = 40;
            this.AnimTimer.Tick += new System.EventHandler(this.AnimTimer_Tick);
            // 
            // pnl_canvas
            // 
            this.pnl_canvas.Location = new System.Drawing.Point(0, 0);
            this.pnl_canvas.Name = "pnl_canvas";
            this.pnl_canvas.Size = new System.Drawing.Size(624, 441);
            this.pnl_canvas.TabIndex = 0;
            // 
            // frm_Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this.pnl_canvas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frm_Game";
            this.Text = "Game";
            this.Load += new System.EventHandler(this.frm_Game_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer AnimTimer;
        private System.Windows.Forms.Panel pnl_canvas;
    }
}