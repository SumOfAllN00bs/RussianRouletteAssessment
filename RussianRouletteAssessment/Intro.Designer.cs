namespace RussianRouletteAssessment
{
    partial class frm_PlayerProfile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_PlayerProfile));
            this.lbl_Username = new System.Windows.Forms.Label();
            this.cb_UserName = new System.Windows.Forms.ComboBox();
            this.btn_Continue = new System.Windows.Forms.Button();
            this.lbl_ProfilePic = new System.Windows.Forms.Label();
            this.pb_ProfilePic = new System.Windows.Forms.PictureBox();
            this.btn_Exit = new System.Windows.Forms.Button();
            this.cb_ProfilePictures = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pb_ProfilePic)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_Username
            // 
            this.lbl_Username.AutoSize = true;
            this.lbl_Username.Location = new System.Drawing.Point(26, 24);
            this.lbl_Username.Name = "lbl_Username";
            this.lbl_Username.Size = new System.Drawing.Size(57, 13);
            this.lbl_Username.TabIndex = 1;
            this.lbl_Username.Text = "UserName";
            // 
            // cb_UserName
            // 
            this.cb_UserName.FormattingEnabled = true;
            this.cb_UserName.Location = new System.Drawing.Point(133, 21);
            this.cb_UserName.Name = "cb_UserName";
            this.cb_UserName.Size = new System.Drawing.Size(256, 21);
            this.cb_UserName.TabIndex = 2;
            this.cb_UserName.SelectedIndexChanged += new System.EventHandler(this.cb_UserName_SelectedIndexChanged);
            // 
            // btn_Continue
            // 
            this.btn_Continue.Location = new System.Drawing.Point(537, 406);
            this.btn_Continue.Name = "btn_Continue";
            this.btn_Continue.Size = new System.Drawing.Size(75, 23);
            this.btn_Continue.TabIndex = 3;
            this.btn_Continue.Text = "Continue";
            this.btn_Continue.UseVisualStyleBackColor = true;
            this.btn_Continue.Click += new System.EventHandler(this.btn_Continue_Click);
            // 
            // lbl_ProfilePic
            // 
            this.lbl_ProfilePic.AutoSize = true;
            this.lbl_ProfilePic.Location = new System.Drawing.Point(26, 97);
            this.lbl_ProfilePic.Name = "lbl_ProfilePic";
            this.lbl_ProfilePic.Size = new System.Drawing.Size(54, 13);
            this.lbl_ProfilePic.TabIndex = 4;
            this.lbl_ProfilePic.Text = "Profile Pic";
            // 
            // pb_ProfilePic
            // 
            this.pb_ProfilePic.Location = new System.Drawing.Point(133, 97);
            this.pb_ProfilePic.Name = "pb_ProfilePic";
            this.pb_ProfilePic.Size = new System.Drawing.Size(256, 256);
            this.pb_ProfilePic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_ProfilePic.TabIndex = 5;
            this.pb_ProfilePic.TabStop = false;
            // 
            // btn_Exit
            // 
            this.btn_Exit.Location = new System.Drawing.Point(29, 406);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(75, 23);
            this.btn_Exit.TabIndex = 6;
            this.btn_Exit.Text = "Exit Game";
            this.btn_Exit.UseVisualStyleBackColor = true;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // cb_ProfilePictures
            // 
            this.cb_ProfilePictures.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ProfilePictures.FormattingEnabled = true;
            this.cb_ProfilePictures.Location = new System.Drawing.Point(133, 359);
            this.cb_ProfilePictures.Name = "cb_ProfilePictures";
            this.cb_ProfilePictures.Size = new System.Drawing.Size(256, 21);
            this.cb_ProfilePictures.TabIndex = 7;
            this.cb_ProfilePictures.SelectedIndexChanged += new System.EventHandler(this.cb_ProfilePictures_SelectedIndexChanged);
            // 
            // frm_PlayerProfile
            // 
            this.AcceptButton = this.btn_Continue;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.ControlBox = false;
            this.Controls.Add(this.cb_ProfilePictures);
            this.Controls.Add(this.btn_Exit);
            this.Controls.Add(this.pb_ProfilePic);
            this.Controls.Add(this.lbl_ProfilePic);
            this.Controls.Add(this.btn_Continue);
            this.Controls.Add(this.cb_UserName);
            this.Controls.Add(this.lbl_Username);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frm_PlayerProfile";
            this.Text = "Intro";
            this.Load += new System.EventHandler(this.frm_PlayerProfile_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pb_ProfilePic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Username;
        private System.Windows.Forms.ComboBox cb_UserName;
        private System.Windows.Forms.Button btn_Continue;
        private System.Windows.Forms.Label lbl_ProfilePic;
        private System.Windows.Forms.PictureBox pb_ProfilePic;
        private System.Windows.Forms.Button btn_Exit;
        private System.Windows.Forms.ComboBox cb_ProfilePictures;
    }
}