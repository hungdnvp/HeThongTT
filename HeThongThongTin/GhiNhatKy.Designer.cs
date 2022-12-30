namespace HeThongThongTin
{
    partial class GhiNhatKy
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
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.lableDonVi = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.comboBox = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnGhiNhatKy = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(162, 64);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(375, 133);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // lableDonVi
            // 
            this.lableDonVi.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lableDonVi.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lableDonVi.ForeColor = System.Drawing.Color.Black;
            this.lableDonVi.Location = new System.Drawing.Point(12, 95);
            this.lableDonVi.Name = "lableDonVi";
            this.lableDonVi.Size = new System.Drawing.Size(133, 26);
            this.lableDonVi.TabIndex = 13;
            this.lableDonVi.Text = "TRẠNG THÁI";
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(26, 255);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(98, 26);
            this.guna2HtmlLabel1.TabIndex = 14;
            this.guna2HtmlLabel1.Text = "KẾT QUẢ";
            // 
            // comboBox
            // 
            this.comboBox.BackColor = System.Drawing.Color.Transparent;
            this.comboBox.BorderRadius = 4;
            this.comboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.comboBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.comboBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.comboBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.comboBox.ItemHeight = 30;
            this.comboBox.Location = new System.Drawing.Point(162, 255);
            this.comboBox.Name = "comboBox";
            this.comboBox.Size = new System.Drawing.Size(375, 36);
            this.comboBox.TabIndex = 15;
            // 
            // btnGhiNhatKy
            // 
            this.btnGhiNhatKy.BorderRadius = 4;
            this.btnGhiNhatKy.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnGhiNhatKy.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnGhiNhatKy.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnGhiNhatKy.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnGhiNhatKy.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGhiNhatKy.ForeColor = System.Drawing.Color.White;
            this.btnGhiNhatKy.Location = new System.Drawing.Point(241, 355);
            this.btnGhiNhatKy.Name = "btnGhiNhatKy";
            this.btnGhiNhatKy.Size = new System.Drawing.Size(180, 45);
            this.btnGhiNhatKy.TabIndex = 16;
            this.btnGhiNhatKy.Text = "Ghi Nhật Ký";
            this.btnGhiNhatKy.Click += new System.EventHandler(this.btnGhiNhatKy_Click);
            // 
            // GhiNhatKy
            // 
            this.AcceptButton = this.btnGhiNhatKy;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(567, 446);
            this.Controls.Add(this.btnGhiNhatKy);
            this.Controls.Add(this.comboBox);
            this.Controls.Add(this.guna2HtmlLabel1);
            this.Controls.Add(this.lableDonVi);
            this.Controls.Add(this.richTextBox1);
            this.Name = "GhiNhatKy";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GhiNhatKy";
            this.Load += new System.EventHandler(this.GhiNhatKy_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private Guna.UI2.WinForms.Guna2HtmlLabel lableDonVi;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2ComboBox comboBox;
        private Guna.UI2.WinForms.Guna2Button btnGhiNhatKy;
    }
}