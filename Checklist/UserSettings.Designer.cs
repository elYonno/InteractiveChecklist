namespace Checklist
{
    partial class UserSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserSettings));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.BtnConfirm = new System.Windows.Forms.Button();
            this.LblFontSize = new System.Windows.Forms.Label();
            this.LblTabletControlAlign = new System.Windows.Forms.Label();
            this.NumFontSize = new System.Windows.Forms.NumericUpDown();
            this.BoxAlign = new System.Windows.Forms.ComboBox();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumFontSize)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.BtnConfirm, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.LblFontSize, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.LblTabletControlAlign, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.NumFontSize, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.BoxAlign, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.BtnCancel, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(505, 123);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // BtnConfirm
            // 
            this.BtnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnConfirm.AutoSize = true;
            this.BtnConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.BtnConfirm.Location = new System.Drawing.Point(417, 76);
            this.BtnConfirm.Name = "BtnConfirm";
            this.BtnConfirm.Size = new System.Drawing.Size(85, 34);
            this.BtnConfirm.TabIndex = 5;
            this.BtnConfirm.Text = "Confirm";
            this.BtnConfirm.UseVisualStyleBackColor = true;
            this.BtnConfirm.Click += new System.EventHandler(this.BtnConfirm_Click);
            // 
            // LblFontSize
            // 
            this.LblFontSize.AutoSize = true;
            this.LblFontSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.LblFontSize.Location = new System.Drawing.Point(3, 0);
            this.LblFontSize.Name = "LblFontSize";
            this.LblFontSize.Size = new System.Drawing.Size(89, 24);
            this.LblFontSize.TabIndex = 0;
            this.LblFontSize.Text = "Font Size";
            // 
            // LblTabletControlAlign
            // 
            this.LblTabletControlAlign.AutoSize = true;
            this.LblTabletControlAlign.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.LblTabletControlAlign.Location = new System.Drawing.Point(3, 35);
            this.LblTabletControlAlign.Name = "LblTabletControlAlign";
            this.LblTabletControlAlign.Size = new System.Drawing.Size(175, 24);
            this.LblTabletControlAlign.TabIndex = 1;
            this.LblTabletControlAlign.Text = "Tablet Control Align";
            // 
            // NumFontSize
            // 
            this.NumFontSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.NumFontSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.NumFontSize.Location = new System.Drawing.Point(382, 3);
            this.NumFontSize.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.NumFontSize.Minimum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.NumFontSize.Name = "NumFontSize";
            this.NumFontSize.Size = new System.Drawing.Size(120, 29);
            this.NumFontSize.TabIndex = 2;
            this.NumFontSize.Value = new decimal(new int[] {
            14,
            0,
            0,
            0});
            // 
            // BoxAlign
            // 
            this.BoxAlign.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BoxAlign.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BoxAlign.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.BoxAlign.FormattingEnabled = true;
            this.BoxAlign.Items.AddRange(new object[] {
            "Left",
            "Right"});
            this.BoxAlign.Location = new System.Drawing.Point(381, 38);
            this.BoxAlign.Name = "BoxAlign";
            this.BoxAlign.Size = new System.Drawing.Size(121, 32);
            this.BoxAlign.TabIndex = 3;
            // 
            // BtnCancel
            // 
            this.BtnCancel.AutoSize = true;
            this.BtnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.BtnCancel.Location = new System.Drawing.Point(3, 76);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(82, 34);
            this.BtnCancel.TabIndex = 4;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // UserSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(505, 123);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UserSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User Settings";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.UserSettings_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumFontSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label LblFontSize;
        private System.Windows.Forms.Label LblTabletControlAlign;
        private System.Windows.Forms.NumericUpDown NumFontSize;
        private System.Windows.Forms.ComboBox BoxAlign;
        private System.Windows.Forms.Button BtnConfirm;
        private System.Windows.Forms.Button BtnCancel;
    }
}