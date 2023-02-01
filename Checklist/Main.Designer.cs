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
            this.btn738 = new System.Windows.Forms.Button();
            this.btnA32NX = new System.Windows.Forms.Button();
            this.btnKingAir = new System.Windows.Forms.Button();
            this.lblMaker = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn738
            // 
            this.btn738.Location = new System.Drawing.Point(16, 16);
            this.btn738.Name = "btn738";
            this.btn738.Size = new System.Drawing.Size(120, 56);
            this.btn738.TabIndex = 0;
            this.btn738.Tag = "0";
            this.btn738.Text = "737-800";
            this.btn738.UseVisualStyleBackColor = true;
            this.btn738.Click += new System.EventHandler(this.openChecklist);
            // 
            // btnA32NX
            // 
            this.btnA32NX.Location = new System.Drawing.Point(152, 16);
            this.btnA32NX.Name = "btnA32NX";
            this.btnA32NX.Size = new System.Drawing.Size(120, 56);
            this.btnA32NX.TabIndex = 1;
            this.btnA32NX.Tag = "1";
            this.btnA32NX.Text = "A32NX";
            this.btnA32NX.UseVisualStyleBackColor = true;
            this.btnA32NX.Click += new System.EventHandler(this.openChecklist);
            // 
            // btnKingAir
            // 
            this.btnKingAir.Location = new System.Drawing.Point(288, 16);
            this.btnKingAir.Name = "btnKingAir";
            this.btnKingAir.Size = new System.Drawing.Size(120, 56);
            this.btnKingAir.TabIndex = 2;
            this.btnKingAir.Tag = "2";
            this.btnKingAir.Text = "Analog King Air";
            this.btnKingAir.UseVisualStyleBackColor = true;
            this.btnKingAir.Click += new System.EventHandler(this.openChecklist);
            // 
            // lblMaker
            // 
            this.lblMaker.AutoSize = true;
            this.lblMaker.Location = new System.Drawing.Point(16, 88);
            this.lblMaker.Name = "lblMaker";
            this.lblMaker.Size = new System.Drawing.Size(201, 13);
            this.lblMaker.TabIndex = 3;
            this.lblMaker.Text = "Interactive Checklist by Yonathan Irawan";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 107);
            this.Controls.Add(this.lblMaker);
            this.Controls.Add(this.btnKingAir);
            this.Controls.Add(this.btnA32NX);
            this.Controls.Add(this.btn738);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Main";
            this.Text = "Interactive Checklists";
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn738;
        private System.Windows.Forms.Button btnA32NX;
        private System.Windows.Forms.Button btnKingAir;
        private System.Windows.Forms.Label lblMaker;
    }
}

