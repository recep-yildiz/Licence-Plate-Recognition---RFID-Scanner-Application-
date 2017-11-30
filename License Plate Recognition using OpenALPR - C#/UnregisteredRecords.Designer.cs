namespace Campus_Gate_KOU
{
    partial class UnregisteredRecords
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.recordList = new MetroFramework.Controls.MetroGrid();
            this.metroLabel10 = new MetroFramework.Controls.MetroLabel();
            this.exitDate = new MetroFramework.Controls.MetroDateTime();
            this.enterDate = new MetroFramework.Controls.MetroDateTime();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.allRecordsBtn = new MetroFramework.Controls.MetroTile();
            this.recordSearchBtn = new MetroFramework.Controls.MetroTile();
            this.plateTb = new MetroFramework.Controls.MetroTextBox();
            this.trackNoTB = new MetroFramework.Controls.MetroTextBox();
            this.searchNameTB = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel9 = new MetroFramework.Controls.MetroLabel();
            this.metroProgressSpinner1 = new MetroFramework.Controls.MetroProgressSpinner();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel8 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            ((System.ComponentModel.ISupportInitialize)(this.recordList)).BeginInit();
            this.SuspendLayout();
            // 
            // recordList
            // 
            this.recordList.AllowUserToResizeRows = false;
            this.recordList.BackgroundColor = System.Drawing.Color.LightSteelBlue;
            this.recordList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.recordList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.recordList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.recordList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.recordList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.recordList.DefaultCellStyle = dataGridViewCellStyle8;
            this.recordList.EnableHeadersVisualStyles = false;
            this.recordList.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.recordList.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.recordList.Location = new System.Drawing.Point(245, 66);
            this.recordList.Name = "recordList";
            this.recordList.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.recordList.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.recordList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.recordList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.recordList.Size = new System.Drawing.Size(1096, 637);
            this.recordList.TabIndex = 1;
            // 
            // metroLabel10
            // 
            this.metroLabel10.AutoSize = true;
            this.metroLabel10.Location = new System.Drawing.Point(60, 534);
            this.metroLabel10.Name = "metroLabel10";
            this.metroLabel10.Size = new System.Drawing.Size(136, 19);
            this.metroLabel10.TabIndex = 19;
            this.metroLabel10.Text = "Sonuçlar Gösteriliyor...";
            this.metroLabel10.Visible = false;
            // 
            // exitDate
            // 
            this.exitDate.FontSize = MetroFramework.MetroDateTimeSize.Small;
            this.exitDate.FontWeight = MetroFramework.MetroDateTimeWeight.Light;
            this.exitDate.Location = new System.Drawing.Point(54, 312);
            this.exitDate.MinimumSize = new System.Drawing.Size(0, 25);
            this.exitDate.Name = "exitDate";
            this.exitDate.Size = new System.Drawing.Size(155, 25);
            this.exitDate.TabIndex = 17;
            this.exitDate.ValueChanged += new System.EventHandler(this.exitDate_ValueChanged);
            // 
            // enterDate
            // 
            this.enterDate.FontSize = MetroFramework.MetroDateTimeSize.Small;
            this.enterDate.FontWeight = MetroFramework.MetroDateTimeWeight.Light;
            this.enterDate.Location = new System.Drawing.Point(54, 274);
            this.enterDate.MinimumSize = new System.Drawing.Size(0, 25);
            this.enterDate.Name = "enterDate";
            this.enterDate.Size = new System.Drawing.Size(155, 25);
            this.enterDate.TabIndex = 18;
            this.enterDate.ValueChanged += new System.EventHandler(this.enterDate_ValueChanged);
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel6.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel6.Location = new System.Drawing.Point(8, 246);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(207, 15);
            this.metroLabel6.TabIndex = 16;
            this.metroLabel6.Text = "-> Tarih seçerek aramanızı özelleştirin:";
            // 
            // allRecordsBtn
            // 
            this.allRecordsBtn.ActiveControl = null;
            this.allRecordsBtn.Location = new System.Drawing.Point(54, 471);
            this.allRecordsBtn.Name = "allRecordsBtn";
            this.allRecordsBtn.Size = new System.Drawing.Size(155, 47);
            this.allRecordsBtn.Style = MetroFramework.MetroColorStyle.Lime;
            this.allRecordsBtn.TabIndex = 14;
            this.allRecordsBtn.Text = "Tüm Sonuçlar";
            this.allRecordsBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.allRecordsBtn.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.allRecordsBtn.UseSelectable = true;
            this.allRecordsBtn.Click += new System.EventHandler(this.allRecordsBtn_Click);
            // 
            // recordSearchBtn
            // 
            this.recordSearchBtn.ActiveControl = null;
            this.recordSearchBtn.Location = new System.Drawing.Point(54, 357);
            this.recordSearchBtn.Name = "recordSearchBtn";
            this.recordSearchBtn.Size = new System.Drawing.Size(155, 47);
            this.recordSearchBtn.Style = MetroFramework.MetroColorStyle.Lime;
            this.recordSearchBtn.TabIndex = 15;
            this.recordSearchBtn.Text = "Ara";
            this.recordSearchBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.recordSearchBtn.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.recordSearchBtn.UseSelectable = true;
            this.recordSearchBtn.Click += new System.EventHandler(this.recordSearchBtn_Click);
            // 
            // plateTb
            // 
            // 
            // 
            // 
            this.plateTb.CustomButton.Image = null;
            this.plateTb.CustomButton.Location = new System.Drawing.Point(133, 1);
            this.plateTb.CustomButton.Name = "";
            this.plateTb.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.plateTb.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.plateTb.CustomButton.TabIndex = 1;
            this.plateTb.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.plateTb.CustomButton.UseSelectable = true;
            this.plateTb.CustomButton.Visible = false;
            this.plateTb.Lines = new string[0];
            this.plateTb.Location = new System.Drawing.Point(54, 173);
            this.plateTb.MaxLength = 32767;
            this.plateTb.Name = "plateTb";
            this.plateTb.PasswordChar = '\0';
            this.plateTb.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.plateTb.SelectedText = "";
            this.plateTb.SelectionLength = 0;
            this.plateTb.SelectionStart = 0;
            this.plateTb.ShortcutsEnabled = true;
            this.plateTb.Size = new System.Drawing.Size(155, 23);
            this.plateTb.TabIndex = 11;
            this.plateTb.UseSelectable = true;
            this.plateTb.WaterMark = "(Plaka)";
            this.plateTb.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.plateTb.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // trackNoTB
            // 
            // 
            // 
            // 
            this.trackNoTB.CustomButton.Image = null;
            this.trackNoTB.CustomButton.Location = new System.Drawing.Point(133, 1);
            this.trackNoTB.CustomButton.Name = "";
            this.trackNoTB.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.trackNoTB.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.trackNoTB.CustomButton.TabIndex = 1;
            this.trackNoTB.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.trackNoTB.CustomButton.UseSelectable = true;
            this.trackNoTB.CustomButton.Visible = false;
            this.trackNoTB.Lines = new string[0];
            this.trackNoTB.Location = new System.Drawing.Point(54, 141);
            this.trackNoTB.MaxLength = 32767;
            this.trackNoTB.Name = "trackNoTB";
            this.trackNoTB.PasswordChar = '\0';
            this.trackNoTB.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.trackNoTB.SelectedText = "";
            this.trackNoTB.SelectionLength = 0;
            this.trackNoTB.SelectionStart = 0;
            this.trackNoTB.ShortcutsEnabled = true;
            this.trackNoTB.Size = new System.Drawing.Size(155, 23);
            this.trackNoTB.TabIndex = 12;
            this.trackNoTB.UseSelectable = true;
            this.trackNoTB.WaterMark = "(Sicil No)";
            this.trackNoTB.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.trackNoTB.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // searchNameTB
            // 
            // 
            // 
            // 
            this.searchNameTB.CustomButton.Image = null;
            this.searchNameTB.CustomButton.Location = new System.Drawing.Point(133, 1);
            this.searchNameTB.CustomButton.Name = "";
            this.searchNameTB.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.searchNameTB.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.searchNameTB.CustomButton.TabIndex = 1;
            this.searchNameTB.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.searchNameTB.CustomButton.UseSelectable = true;
            this.searchNameTB.CustomButton.Visible = false;
            this.searchNameTB.Lines = new string[0];
            this.searchNameTB.Location = new System.Drawing.Point(54, 110);
            this.searchNameTB.MaxLength = 32767;
            this.searchNameTB.Name = "searchNameTB";
            this.searchNameTB.PasswordChar = '\0';
            this.searchNameTB.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.searchNameTB.SelectedText = "";
            this.searchNameTB.SelectionLength = 0;
            this.searchNameTB.SelectionStart = 0;
            this.searchNameTB.ShortcutsEnabled = true;
            this.searchNameTB.ShowClearButton = true;
            this.searchNameTB.Size = new System.Drawing.Size(155, 23);
            this.searchNameTB.TabIndex = 13;
            this.searchNameTB.UseSelectable = true;
            this.searchNameTB.WaterMark = "(Ad, Soyad)";
            this.searchNameTB.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.searchNameTB.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel5.Location = new System.Drawing.Point(54, 199);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(151, 15);
            this.metroLabel5.TabIndex = 10;
            this.metroLabel5.Text = "*(En Az Bir Kutuyu Doldurun!)";
            // 
            // metroLabel9
            // 
            this.metroLabel9.AutoSize = true;
            this.metroLabel9.BackColor = System.Drawing.Color.Cornsilk;
            this.metroLabel9.Location = new System.Drawing.Point(112, 427);
            this.metroLabel9.Name = "metroLabel9";
            this.metroLabel9.Size = new System.Drawing.Size(39, 19);
            this.metroLabel9.TabIndex = 20;
            this.metroLabel9.Text = "Veya:";
            // 
            // metroProgressSpinner1
            // 
            this.metroProgressSpinner1.Location = new System.Drawing.Point(85, 571);
            this.metroProgressSpinner1.Maximum = 100;
            this.metroProgressSpinner1.Name = "metroProgressSpinner1";
            this.metroProgressSpinner1.Size = new System.Drawing.Size(80, 78);
            this.metroProgressSpinner1.Style = MetroFramework.MetroColorStyle.Red;
            this.metroProgressSpinner1.TabIndex = 21;
            this.metroProgressSpinner1.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroProgressSpinner1.UseSelectable = true;
            this.metroProgressSpinner1.Visible = false;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(-1, 61);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(246, 19);
            this.metroLabel1.TabIndex = 22;
            this.metroLabel1.Text = "-------------Arama Yapın--------------";
            this.metroLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // metroLabel8
            // 
            this.metroLabel8.AutoSize = true;
            this.metroLabel8.Location = new System.Drawing.Point(4, 311);
            this.metroLabel8.Name = "metroLabel8";
            this.metroLabel8.Size = new System.Drawing.Size(42, 19);
            this.metroLabel8.TabIndex = 23;
            this.metroLabel8.Text = "Çıkış: ";
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.Location = new System.Drawing.Point(3, 276);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(41, 19);
            this.metroLabel7.TabIndex = 24;
            this.metroLabel7.Text = "Giriş: ";
            // 
            // UnregisteredRecords
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1364, 726);
            this.Controls.Add(this.metroLabel8);
            this.Controls.Add(this.metroLabel7);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.metroProgressSpinner1);
            this.Controls.Add(this.metroLabel9);
            this.Controls.Add(this.metroLabel10);
            this.Controls.Add(this.exitDate);
            this.Controls.Add(this.enterDate);
            this.Controls.Add(this.metroLabel6);
            this.Controls.Add(this.allRecordsBtn);
            this.Controls.Add(this.recordSearchBtn);
            this.Controls.Add(this.plateTb);
            this.Controls.Add(this.trackNoTB);
            this.Controls.Add(this.searchNameTB);
            this.Controls.Add(this.metroLabel5);
            this.Controls.Add(this.recordList);
            this.Name = "UnregisteredRecords";
            this.Text = "Kayıtsız Rapor";
            this.Load += new System.EventHandler(this.UnregisteredRecords_Load);
            ((System.ComponentModel.ISupportInitialize)(this.recordList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroGrid recordList;
        private MetroFramework.Controls.MetroLabel metroLabel10;
        private MetroFramework.Controls.MetroDateTime exitDate;
        private MetroFramework.Controls.MetroDateTime enterDate;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroTile allRecordsBtn;
        private MetroFramework.Controls.MetroTile recordSearchBtn;
        private MetroFramework.Controls.MetroTextBox plateTb;
        private MetroFramework.Controls.MetroTextBox trackNoTB;
        private MetroFramework.Controls.MetroTextBox searchNameTB;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroLabel metroLabel9;
        private MetroFramework.Controls.MetroProgressSpinner metroProgressSpinner1;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel8;
        private MetroFramework.Controls.MetroLabel metroLabel7;
    }
}