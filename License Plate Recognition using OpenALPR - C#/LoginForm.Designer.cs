namespace Campus_Gate_KOU
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.userLoadingLabel = new System.Windows.Forms.Label();
            this.userLoadingSpinner = new MetroFramework.Controls.MetroProgressSpinner();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.userNameTB = new MetroFramework.Controls.MetroTextBox();
            this.passwordTB = new MetroFramework.Controls.MetroTextBox();
            this.girBtn = new MetroFramework.Controls.MetroButton();
            this.metroPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // metroPanel1
            // 
            this.metroPanel1.Controls.Add(this.userLoadingLabel);
            this.metroPanel1.Controls.Add(this.userLoadingSpinner);
            this.metroPanel1.Controls.Add(this.pictureBox1);
            this.metroPanel1.Controls.Add(this.metroLabel2);
            this.metroPanel1.Controls.Add(this.metroLabel1);
            this.metroPanel1.Controls.Add(this.userNameTB);
            this.metroPanel1.Controls.Add(this.passwordTB);
            this.metroPanel1.Controls.Add(this.girBtn);
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(1, 57);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(501, 115);
            this.metroPanel1.TabIndex = 4;
            this.metroPanel1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // userLoadingLabel
            // 
            this.userLoadingLabel.AutoSize = true;
            this.userLoadingLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.userLoadingLabel.Location = new System.Drawing.Point(169, 93);
            this.userLoadingLabel.Name = "userLoadingLabel";
            this.userLoadingLabel.Size = new System.Drawing.Size(65, 13);
            this.userLoadingLabel.TabIndex = 6;
            this.userLoadingLabel.Text = "Yükleniyor...";
            this.userLoadingLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.userLoadingLabel.Visible = false;
            // 
            // userLoadingSpinner
            // 
            this.userLoadingSpinner.Location = new System.Drawing.Point(150, 7);
            this.userLoadingSpinner.Maximum = 100;
            this.userLoadingSpinner.Name = "userLoadingSpinner";
            this.userLoadingSpinner.Size = new System.Drawing.Size(84, 83);
            this.userLoadingSpinner.Speed = 3F;
            this.userLoadingSpinner.Style = MetroFramework.MetroColorStyle.Orange;
            this.userLoadingSpinner.TabIndex = 2;
            this.userLoadingSpinner.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.userLoadingSpinner.UseSelectable = true;
            this.userLoadingSpinner.Value = 7;
            this.userLoadingSpinner.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(27, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(104, 101);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(272, 44);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(46, 19);
            this.metroLabel2.TabIndex = 4;
            this.metroLabel2.Text = "Parola";
            this.metroLabel2.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(240, 14);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(79, 19);
            this.metroLabel1.TabIndex = 3;
            this.metroLabel1.Text = "Kullanıcı Adı";
            this.metroLabel1.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // userNameTB
            // 
            // 
            // 
            // 
            this.userNameTB.CustomButton.Image = null;
            this.userNameTB.CustomButton.Location = new System.Drawing.Point(112, 1);
            this.userNameTB.CustomButton.Name = "";
            this.userNameTB.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.userNameTB.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.userNameTB.CustomButton.TabIndex = 1;
            this.userNameTB.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.userNameTB.CustomButton.UseSelectable = true;
            this.userNameTB.CustomButton.Visible = false;
            this.userNameTB.Lines = new string[0];
            this.userNameTB.Location = new System.Drawing.Point(328, 14);
            this.userNameTB.MaxLength = 32767;
            this.userNameTB.Name = "userNameTB";
            this.userNameTB.PasswordChar = '\0';
            this.userNameTB.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.userNameTB.SelectedText = "";
            this.userNameTB.SelectionLength = 0;
            this.userNameTB.SelectionStart = 0;
            this.userNameTB.ShortcutsEnabled = true;
            this.userNameTB.Size = new System.Drawing.Size(134, 23);
            this.userNameTB.TabIndex = 1;
            this.userNameTB.UseSelectable = true;
            this.userNameTB.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.userNameTB.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // passwordTB
            // 
            // 
            // 
            // 
            this.passwordTB.CustomButton.Image = null;
            this.passwordTB.CustomButton.Location = new System.Drawing.Point(112, 1);
            this.passwordTB.CustomButton.Name = "";
            this.passwordTB.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.passwordTB.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.passwordTB.CustomButton.TabIndex = 1;
            this.passwordTB.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.passwordTB.CustomButton.UseSelectable = true;
            this.passwordTB.CustomButton.Visible = false;
            this.passwordTB.Lines = new string[0];
            this.passwordTB.Location = new System.Drawing.Point(328, 44);
            this.passwordTB.MaxLength = 32767;
            this.passwordTB.Name = "passwordTB";
            this.passwordTB.PasswordChar = '•';
            this.passwordTB.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.passwordTB.SelectedText = "";
            this.passwordTB.SelectionLength = 0;
            this.passwordTB.SelectionStart = 0;
            this.passwordTB.ShortcutsEnabled = true;
            this.passwordTB.Size = new System.Drawing.Size(134, 23);
            this.passwordTB.TabIndex = 2;
            this.passwordTB.UseSelectable = true;
            this.passwordTB.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.passwordTB.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // girBtn
            // 
            this.girBtn.BackColor = System.Drawing.Color.PapayaWhip;
            this.girBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.girBtn.Location = new System.Drawing.Point(328, 73);
            this.girBtn.Name = "girBtn";
            this.girBtn.Size = new System.Drawing.Size(134, 27);
            this.girBtn.TabIndex = 0;
            this.girBtn.Text = "Giriş Yap";
            this.girBtn.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.girBtn.UseSelectable = true;
            // 
            // LoginForm
            // 
            this.AcceptButton = this.girBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(501, 173);
            this.Controls.Add(this.metroPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LoginForm";
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.DropShadow;
            this.Text = "Yetkili Giriş";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroPanel metroPanel1;
        private System.Windows.Forms.Label userLoadingLabel;
        private MetroFramework.Controls.MetroProgressSpinner userLoadingSpinner;
        private System.Windows.Forms.PictureBox pictureBox1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTextBox userNameTB;
        private MetroFramework.Controls.MetroTextBox passwordTB;
        private MetroFramework.Controls.MetroButton girBtn;
    }
}