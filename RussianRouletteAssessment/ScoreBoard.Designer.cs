namespace RussianRouletteAssessment
{
    partial class frm_ScoreBoard
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_ScoreBoard));
            this.dgv_HighScores = new System.Windows.Forms.DataGridView();
            this.btn_Save = new System.Windows.Forms.Button();
            this.UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProfilePic = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.HighScore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TimesPlayed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Deaths = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BulletsFired = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CloseCalls = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeiExMachina = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_HighScores)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_HighScores
            // 
            this.dgv_HighScores.AllowUserToAddRows = false;
            this.dgv_HighScores.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            this.dgv_HighScores.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_HighScores.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgv_HighScores.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_HighScores.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.dgv_HighScores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_HighScores.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.UserName,
            this.ProfilePic,
            this.HighScore,
            this.TimesPlayed,
            this.Deaths,
            this.BulletsFired,
            this.CloseCalls,
            this.DeiExMachina});
            this.dgv_HighScores.Location = new System.Drawing.Point(12, 12);
            this.dgv_HighScores.Name = "dgv_HighScores";
            this.dgv_HighScores.RowHeadersVisible = false;
            this.dgv_HighScores.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.Info;
            this.dgv_HighScores.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_HighScores.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_HighScores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgv_HighScores.Size = new System.Drawing.Size(600, 393);
            this.dgv_HighScores.TabIndex = 0;
            this.dgv_HighScores.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgv_HighScores_EditingControlShowing);
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(537, 411);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(75, 23);
            this.btn_Save.TabIndex = 1;
            this.btn_Save.Text = "Save";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Visible = false;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // UserName
            // 
            this.UserName.HeaderText = "User Name";
            this.UserName.Name = "UserName";
            this.UserName.ReadOnly = true;
            // 
            // ProfilePic
            // 
            this.ProfilePic.HeaderText = "Profile Pic";
            this.ProfilePic.Name = "ProfilePic";
            this.ProfilePic.ReadOnly = true;
            this.ProfilePic.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ProfilePic.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // HighScore
            // 
            this.HighScore.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.HighScore.FillWeight = 50F;
            this.HighScore.HeaderText = "High Score";
            this.HighScore.Name = "HighScore";
            this.HighScore.ReadOnly = true;
            // 
            // TimesPlayed
            // 
            this.TimesPlayed.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TimesPlayed.FillWeight = 50F;
            this.TimesPlayed.HeaderText = "Times Played";
            this.TimesPlayed.Name = "TimesPlayed";
            this.TimesPlayed.ReadOnly = true;
            // 
            // Deaths
            // 
            this.Deaths.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Deaths.FillWeight = 50F;
            this.Deaths.HeaderText = "Deaths";
            this.Deaths.Name = "Deaths";
            this.Deaths.ReadOnly = true;
            // 
            // BulletsFired
            // 
            this.BulletsFired.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.BulletsFired.FillWeight = 80F;
            this.BulletsFired.HeaderText = "Bullets Fired";
            this.BulletsFired.Name = "BulletsFired";
            this.BulletsFired.ReadOnly = true;
            // 
            // CloseCalls
            // 
            this.CloseCalls.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CloseCalls.FillWeight = 50F;
            this.CloseCalls.HeaderText = "Close Calls";
            this.CloseCalls.Name = "CloseCalls";
            this.CloseCalls.ReadOnly = true;
            // 
            // DeiExMachina
            // 
            this.DeiExMachina.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DeiExMachina.FillWeight = 50F;
            this.DeiExMachina.HeaderText = "Dei Ex Machina";
            this.DeiExMachina.Name = "DeiExMachina";
            this.DeiExMachina.ReadOnly = true;
            // 
            // frm_ScoreBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.dgv_HighScores);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frm_ScoreBoard";
            this.Text = "ScoreBoard";
            this.Load += new System.EventHandler(this.frm_ScoreBoard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_HighScores)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_HighScores;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserName;
        private System.Windows.Forms.DataGridViewComboBoxColumn ProfilePic;
        private System.Windows.Forms.DataGridViewTextBoxColumn HighScore;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimesPlayed;
        private System.Windows.Forms.DataGridViewTextBoxColumn Deaths;
        private System.Windows.Forms.DataGridViewTextBoxColumn BulletsFired;
        private System.Windows.Forms.DataGridViewTextBoxColumn CloseCalls;
        private System.Windows.Forms.DataGridViewTextBoxColumn DeiExMachina;
    }
}