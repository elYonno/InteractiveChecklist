namespace Checklist
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.btn738 = new System.Windows.Forms.Button();
            this.btnA32NX = new System.Windows.Forms.Button();
            this.btnKingAir = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.btnToggleMode = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.toolStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn738
            // 
            this.btn738.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn738.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn738.Location = new System.Drawing.Point(3, 3);
            this.btn738.Name = "btn738";
            this.btn738.Size = new System.Drawing.Size(186, 58);
            this.btn738.TabIndex = 0;
            this.btn738.Tag = "0";
            this.btn738.Text = "737-800";
            this.btn738.UseVisualStyleBackColor = true;
            this.btn738.Click += new System.EventHandler(this.openChecklist);
            // 
            // btnA32NX
            // 
            this.btnA32NX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnA32NX.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnA32NX.Location = new System.Drawing.Point(195, 3);
            this.btnA32NX.Name = "btnA32NX";
            this.btnA32NX.Size = new System.Drawing.Size(186, 58);
            this.btnA32NX.TabIndex = 1;
            this.btnA32NX.Tag = "1";
            this.btnA32NX.Text = "A32NX";
            this.btnA32NX.UseVisualStyleBackColor = true;
            this.btnA32NX.Click += new System.EventHandler(this.openChecklist);
            // 
            // btnKingAir
            // 
            this.btnKingAir.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnKingAir.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKingAir.Location = new System.Drawing.Point(3, 67);
            this.btnKingAir.Name = "btnKingAir";
            this.btnKingAir.Size = new System.Drawing.Size(186, 59);
            this.btnKingAir.TabIndex = 2;
            this.btnKingAir.Tag = "2";
            this.btnKingAir.Text = "Analog King Air";
            this.btnKingAir.UseVisualStyleBackColor = true;
            this.btnKingAir.Click += new System.EventHandler(this.openChecklist);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.btnToggleMode});
            this.toolStrip1.Location = new System.Drawing.Point(0, 129);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(384, 32);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(220, 29);
            this.toolStripLabel1.Text = "Interactive Checklist by Yonathan Irawan";
            // 
            // btnToggleMode
            // 
            this.btnToggleMode.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnToggleMode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnToggleMode.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.btnToggleMode.Image = ((System.Drawing.Image)(resources.GetObject("btnToggleMode.Image")));
            this.btnToggleMode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnToggleMode.Name = "btnToggleMode";
            this.btnToggleMode.Size = new System.Drawing.Size(120, 29);
            this.btnToggleMode.Text = "Tablet Mode";
            this.btnToggleMode.Click += new System.EventHandler(this.ToggleMode);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.btn738, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnA32NX, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnKingAir, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(384, 129);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 161);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Main";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Interactive Checklist";
            this.Load += new System.EventHandler(this.Main_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn738;
        private System.Windows.Forms.Button btnA32NX;
        private System.Windows.Forms.Button btnKingAir;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton btnToggleMode;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}

