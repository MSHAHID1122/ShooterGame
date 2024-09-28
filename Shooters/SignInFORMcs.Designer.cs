namespace Shooters
{
    partial class SignInFORMcs
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
            this.btnEnter = new Guna.UI2.WinForms.Guna2Button();
            this.playerPassword = new Guna.UI2.WinForms.Guna2TextBox();
            this.playerName = new Guna.UI2.WinForms.Guna2TextBox();
            this.SuspendLayout();
            // 
            // btnEnter
            // 
            this.btnEnter.BackColor = System.Drawing.Color.Gray;
            this.btnEnter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnEnter.BorderThickness = 5;
            this.btnEnter.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnEnter.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnEnter.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnEnter.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnEnter.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnEnter.Font = new System.Drawing.Font("hooge 05_55", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnter.ForeColor = System.Drawing.Color.Black;
            this.btnEnter.Location = new System.Drawing.Point(461, 490);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(294, 56);
            this.btnEnter.TabIndex = 12;
            this.btnEnter.Text = "Enter  Game";
            this.btnEnter.Click += new System.EventHandler(this.btnEnter_Click);
            // 
            // playerPassword
            // 
            this.playerPassword.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.playerPassword.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            this.playerPassword.BorderThickness = 4;
            this.playerPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.playerPassword.DefaultText = "";
            this.playerPassword.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.playerPassword.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.playerPassword.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.playerPassword.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.playerPassword.FillColor = System.Drawing.Color.PaleTurquoise;
            this.playerPassword.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.playerPassword.Font = new System.Drawing.Font("Sitka Banner", 7.874999F, System.Drawing.FontStyle.Bold);
            this.playerPassword.ForeColor = System.Drawing.Color.Black;
            this.playerPassword.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.playerPassword.Location = new System.Drawing.Point(428, 340);
            this.playerPassword.Name = "playerPassword";
            this.playerPassword.PasswordChar = '\0';
            this.playerPassword.PlaceholderForeColor = System.Drawing.Color.Black;
            this.playerPassword.PlaceholderText = "Enter  Password";
            this.playerPassword.SelectedText = "";
            this.playerPassword.Size = new System.Drawing.Size(349, 47);
            this.playerPassword.TabIndex = 11;
            this.playerPassword.TextChanged += new System.EventHandler(this.playerPassword_TextChanged);
            // 
            // playerName
            // 
            this.playerName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.playerName.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            this.playerName.BorderThickness = 4;
            this.playerName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.playerName.DefaultText = "";
            this.playerName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.playerName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.playerName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.playerName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.playerName.FillColor = System.Drawing.Color.PaleTurquoise;
            this.playerName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.playerName.Font = new System.Drawing.Font("Sitka Banner", 7.874999F, System.Drawing.FontStyle.Bold);
            this.playerName.ForeColor = System.Drawing.Color.Black;
            this.playerName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.playerName.Location = new System.Drawing.Point(428, 195);
            this.playerName.Name = "playerName";
            this.playerName.PasswordChar = '\0';
            this.playerName.PlaceholderForeColor = System.Drawing.Color.Black;
            this.playerName.PlaceholderText = "Enter Your Name";
            this.playerName.SelectedText = "";
            this.playerName.Size = new System.Drawing.Size(349, 47);
            this.playerName.TabIndex = 10;
            this.playerName.TextChanged += new System.EventHandler(this.playerName_TextChanged);
            // 
            // SignInFORMcs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1205, 740);
            this.Controls.Add(this.btnEnter);
            this.Controls.Add(this.playerPassword);
            this.Controls.Add(this.playerName);
            this.Name = "SignInFORMcs";
            this.Text = "SignInFORMcs";
            this.Load += new System.EventHandler(this.SignInFORMcs_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btnEnter;
        private Guna.UI2.WinForms.Guna2TextBox playerPassword;
        private Guna.UI2.WinForms.Guna2TextBox playerName;
    }
}