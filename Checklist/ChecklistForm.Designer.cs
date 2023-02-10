namespace Checklist
{
    partial class ChecklistForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChecklistForm));
            this.sectionsControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnPrevCheck = new System.Windows.Forms.ToolStripButton();
            this.btnNextChecklist = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnComplete = new System.Windows.Forms.ToolStripButton();
            this.btnSettings = new System.Windows.Forms.ToolStripButton();
            this.btnResetAll = new System.Windows.Forms.ToolStripButton();
            this.btnResetCurrent = new System.Windows.Forms.ToolStripButton();
            this.separatorCount = new System.Windows.Forms.ToolStripSeparator();
            this.lblCount = new System.Windows.Forms.ToolStripLabel();
            this.progressCount = new System.Windows.Forms.ToolStripProgressBar();
            this.pnlTouchScreen = new System.Windows.Forms.TableLayoutPanel();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.sectionsControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.pnlTouchScreen.SuspendLayout();
            this.SuspendLayout();
            // 
            // sectionsControl
            // 
            this.sectionsControl.Controls.Add(this.tabPage1);
            this.sectionsControl.Controls.Add(this.tabPage2);
            this.sectionsControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sectionsControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sectionsControl.Location = new System.Drawing.Point(0, 0);
            this.sectionsControl.Name = "sectionsControl";
            this.sectionsControl.SelectedIndex = 0;
            this.sectionsControl.Size = new System.Drawing.Size(866, 418);
            this.sectionsControl.TabIndex = 0;
            this.sectionsControl.SelectedIndexChanged += new System.EventHandler(this.SectionsControl_SelectedIndexChanged);
            this.sectionsControl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tableLayoutPanel1);
            this.tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.Location = new System.Drawing.Point(4, 33);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(858, 381);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.checkBox1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(852, 34);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox1.AutoSize = true;
            this.checkBox1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.Location = new System.Drawing.Point(793, 3);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(56, 28);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Text = "Set";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 3);
            this.label3.Margin = new System.Windows.Forms.Padding(3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "Parking Brake";
            // 
            // tabPage2
            // 
            this.tabPage2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage2.Location = new System.Drawing.Point(4, 33);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(858, 381);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnPrevCheck,
            this.btnNextChecklist,
            this.toolStripSeparator3,
            this.toolStripSeparator2,
            this.btnComplete,
            this.btnSettings,
            this.toolStripSeparator1,
            this.btnResetAll,
            this.btnResetCurrent,
            this.separatorCount,
            this.lblCount,
            this.progressCount});
            this.toolStrip1.Location = new System.Drawing.Point(0, 418);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(866, 32);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnPrevCheck
            // 
            this.btnPrevCheck.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnPrevCheck.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.btnPrevCheck.Image = ((System.Drawing.Image)(resources.GetObject("btnPrevCheck.Image")));
            this.btnPrevCheck.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrevCheck.Name = "btnPrevCheck";
            this.btnPrevCheck.Size = new System.Drawing.Size(133, 29);
            this.btnPrevCheck.Text = "Prev Checklist";
            this.btnPrevCheck.Click += new System.EventHandler(this.BtnPrevCheck_Click);
            // 
            // btnNextChecklist
            // 
            this.btnNextChecklist.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnNextChecklist.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnNextChecklist.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.btnNextChecklist.Image = ((System.Drawing.Image)(resources.GetObject("btnNextChecklist.Image")));
            this.btnNextChecklist.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNextChecklist.Name = "btnNextChecklist";
            this.btnNextChecklist.Size = new System.Drawing.Size(135, 29);
            this.btnNextChecklist.Text = "Next Checklist";
            this.btnNextChecklist.Click += new System.EventHandler(this.BtnNextChecklist_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 32);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 32);
            // 
            // btnComplete
            // 
            this.btnComplete.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnComplete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnComplete.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.btnComplete.Image = ((System.Drawing.Image)(resources.GetObject("btnComplete.Image")));
            this.btnComplete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnComplete.Name = "btnComplete";
            this.btnComplete.Size = new System.Drawing.Size(164, 29);
            this.btnComplete.Text = "Complete Section";
            this.btnComplete.Click += new System.EventHandler(this.BtnComplete_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSettings.Image = global::Checklist.Properties.Resources.settings;
            this.btnSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(23, 29);
            this.btnSettings.Text = "Settings";
            this.btnSettings.Click += new System.EventHandler(this.BtnSettings_Click);
            // 
            // btnResetAll
            // 
            this.btnResetAll.BackColor = System.Drawing.Color.Maroon;
            this.btnResetAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnResetAll.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.btnResetAll.ForeColor = System.Drawing.SystemColors.Control;
            this.btnResetAll.Image = ((System.Drawing.Image)(resources.GetObject("btnResetAll.Image")));
            this.btnResetAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnResetAll.Name = "btnResetAll";
            this.btnResetAll.Size = new System.Drawing.Size(87, 29);
            this.btnResetAll.Text = "Reset All";
            this.btnResetAll.ToolTipText = "ResetAll";
            this.btnResetAll.Click += new System.EventHandler(this.BtnResetAll_Click);
            // 
            // btnResetCurrent
            // 
            this.btnResetCurrent.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnResetCurrent.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.btnResetCurrent.Image = ((System.Drawing.Image)(resources.GetObject("btnResetCurrent.Image")));
            this.btnResetCurrent.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnResetCurrent.Name = "btnResetCurrent";
            this.btnResetCurrent.Size = new System.Drawing.Size(129, 29);
            this.btnResetCurrent.Text = "Reset Current";
            this.btnResetCurrent.Click += new System.EventHandler(this.BtnResetCurrent_Click);
            // 
            // separatorCount
            // 
            this.separatorCount.Name = "separatorCount";
            this.separatorCount.Size = new System.Drawing.Size(6, 32);
            // 
            // lblCount
            // 
            this.lblCount.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(39, 29);
            this.lblCount.Text = "0/0";
            this.lblCount.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            // 
            // progressCount
            // 
            this.progressCount.Name = "progressCount";
            this.progressCount.Size = new System.Drawing.Size(100, 29);
            // 
            // pnlTouchScreen
            // 
            this.pnlTouchScreen.ColumnCount = 1;
            this.pnlTouchScreen.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.pnlTouchScreen.Controls.Add(this.btnUp, 0, 0);
            this.pnlTouchScreen.Controls.Add(this.btnSelect, 0, 1);
            this.pnlTouchScreen.Controls.Add(this.btnDown, 0, 2);
            this.pnlTouchScreen.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlTouchScreen.Location = new System.Drawing.Point(866, 0);
            this.pnlTouchScreen.Name = "pnlTouchScreen";
            this.pnlTouchScreen.RowCount = 3;
            this.pnlTouchScreen.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.pnlTouchScreen.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.pnlTouchScreen.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.pnlTouchScreen.Size = new System.Drawing.Size(75, 450);
            this.pnlTouchScreen.TabIndex = 4;
            // 
            // btnUp
            // 
            this.btnUp.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnUp.BackgroundImage")));
            this.btnUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnUp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnUp.Location = new System.Drawing.Point(3, 3);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(75, 144);
            this.btnUp.TabIndex = 0;
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.BtnUp_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.BackgroundImage = global::Checklist.Properties.Resources.dash;
            this.btnSelect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSelect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSelect.Location = new System.Drawing.Point(3, 153);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(75, 144);
            this.btnSelect.TabIndex = 1;
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.BtnSelect_Click);
            // 
            // btnDown
            // 
            this.btnDown.BackgroundImage = global::Checklist.Properties.Resources.down;
            this.btnDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDown.Location = new System.Drawing.Point(3, 303);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(75, 144);
            this.btnDown.TabIndex = 2;
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.BtnDown_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 32);
            // 
            // ChecklistForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(941, 450);
            this.Controls.Add(this.sectionsControl);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.pnlTouchScreen);
            this.Name = "ChecklistForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Checklist";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
            this.sectionsControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.pnlTouchScreen.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl sectionsControl;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnPrevCheck;
        private System.Windows.Forms.ToolStripButton btnNextChecklist;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel lblCount;
        private System.Windows.Forms.ToolStripProgressBar progressCount;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnComplete;
        private System.Windows.Forms.ToolStripSeparator separatorCount;
        private System.Windows.Forms.ToolStripButton btnResetAll;
        private System.Windows.Forms.ToolStripButton btnResetCurrent;
        private System.Windows.Forms.TableLayoutPanel pnlTouchScreen;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.ToolStripButton btnSettings;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    }
}