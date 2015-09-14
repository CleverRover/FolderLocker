namespace folderlocker
{
    partial class pwdbx
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(pwdbx));
            this.label1 = new System.Windows.Forms.Label();
            this.pwdbox1 = new System.Windows.Forms.TextBox();
            this.okbut = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(-1, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Password :";
            // 
            // pwdbox1
            // 
            this.pwdbox1.Location = new System.Drawing.Point(85, 32);
            this.pwdbox1.Name = "pwdbox1";
            this.pwdbox1.Size = new System.Drawing.Size(249, 23);
            this.pwdbox1.TabIndex = 1;
            this.pwdbox1.UseSystemPasswordChar = true;
            this.pwdbox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.pwdbox1_KeyDown);
            // 
            // okbut
            // 
            this.okbut.Location = new System.Drawing.Point(120, 81);
            this.okbut.Name = "okbut";
            this.okbut.Size = new System.Drawing.Size(101, 29);
            this.okbut.TabIndex = 2;
            this.okbut.Text = "OK";
            this.okbut.UseVisualStyleBackColor = true;
            this.okbut.Click += new System.EventHandler(this.okbut_Click);
            // 
            // pwdbx
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(346, 122);
            this.Controls.Add(this.okbut);
            this.Controls.Add(this.pwdbox1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "pwdbx";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Folder Locker - Enter Password";
            this.Load += new System.EventHandler(this.pwdbx_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox pwdbox1;
        private System.Windows.Forms.Button okbut;
    }
}