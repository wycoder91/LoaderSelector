namespace LoaderCodeSelector
{
    partial class FrmAuthority
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
            this.tbAuthorAccountIn = new System.Windows.Forms.TextBox();
            this.tbAuthorPwd = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAuthorClose = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAuthory = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbAuthorAccountIn
            // 
            this.tbAuthorAccountIn.Location = new System.Drawing.Point(126, 63);
            this.tbAuthorAccountIn.Name = "tbAuthorAccountIn";
            this.tbAuthorAccountIn.Size = new System.Drawing.Size(154, 21);
            this.tbAuthorAccountIn.TabIndex = 0;
            // 
            // tbAuthorPwd
            // 
            this.tbAuthorPwd.Location = new System.Drawing.Point(126, 122);
            this.tbAuthorPwd.Name = "tbAuthorPwd";
            this.tbAuthorPwd.Size = new System.Drawing.Size(154, 21);
            this.tbAuthorPwd.TabIndex = 0;
            this.tbAuthorPwd.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "管理员用户名：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "密码：";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(84)))), ((int)(((byte)(205)))));
            this.panel1.Controls.Add(this.btnAuthorClose);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(0, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(343, 35);
            this.panel1.TabIndex = 3;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.EasyMove_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.EasyMove_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.EasyMove_MouseUp);
            // 
            // btnAuthorClose
            // 
            this.btnAuthorClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(84)))), ((int)(((byte)(205)))));
            this.btnAuthorClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(84)))), ((int)(((byte)(205)))));
            this.btnAuthorClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAuthorClose.Location = new System.Drawing.Point(312, 0);
            this.btnAuthorClose.Name = "btnAuthorClose";
            this.btnAuthorClose.Size = new System.Drawing.Size(29, 23);
            this.btnAuthorClose.TabIndex = 7;
            this.btnAuthorClose.Text = "×";
            this.btnAuthorClose.UseVisualStyleBackColor = false;
            this.btnAuthorClose.Click += new System.EventHandler(this.btnAuthorClose_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(4, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 19);
            this.label3.TabIndex = 0;
            this.label3.Text = "增 加 条 项 授 权";
            // 
            // btnAuthory
            // 
            this.btnAuthory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(84)))), ((int)(((byte)(205)))));
            this.btnAuthory.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnAuthory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAuthory.Location = new System.Drawing.Point(126, 163);
            this.btnAuthory.Name = "btnAuthory";
            this.btnAuthory.Size = new System.Drawing.Size(75, 23);
            this.btnAuthory.TabIndex = 6;
            this.btnAuthory.Text = "授权";
            this.btnAuthory.UseVisualStyleBackColor = false;
            this.btnAuthory.Click += new System.EventHandler(this.btnAuthory_Click);
            // 
            // FrmAuthority
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(213)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(341, 241);
            this.Controls.Add(this.btnAuthory);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbAuthorPwd);
            this.Controls.Add(this.tbAuthorAccountIn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmAuthority";
            this.Text = "FrmAuthority";
            this.Load += new System.EventHandler(this.FrmAuthority_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbAuthorAccountIn;
        private System.Windows.Forms.TextBox tbAuthorPwd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAuthory;
        private System.Windows.Forms.Button btnAuthorClose;
    }
}