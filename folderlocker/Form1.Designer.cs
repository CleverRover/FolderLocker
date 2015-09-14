namespace folderlocker
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.listcontext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.lockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unlockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.locktask = new System.Windows.Forms.NotifyIcon(this.components);
            this.taskcontext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.taskrestore = new System.Windows.Forms.ToolStripMenuItem();
            this.taskexit = new System.Windows.Forms.ToolStripMenuItem();
            this.loginpane = new System.Windows.Forms.Panel();
            this.usernamebox = new System.Windows.Forms.Label();
            this.loginbut = new System.Windows.Forms.Button();
            this.passwordbox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.mainpane = new System.Windows.Forms.Panel();
            this.namebox = new System.Windows.Forms.Label();
            this.unlockbut = new System.Windows.Forms.Button();
            this.optionsbut = new System.Windows.Forms.Button();
            this.aboutbut = new System.Windows.Forms.Button();
            this.removebut = new System.Windows.Forms.Button();
            this.lockbut = new System.Windows.Forms.Button();
            this.lvfolders = new System.Windows.Forms.ListView();
            this.listcontext.SuspendLayout();
            this.taskcontext.SuspendLayout();
            this.loginpane.SuspendLayout();
            this.mainpane.SuspendLayout();
            this.SuspendLayout();
            // 
            // listcontext
            // 
            this.listcontext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lockToolStripMenuItem,
            this.unlockToolStripMenuItem,
            this.removeToolStripMenuItem});
            this.listcontext.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Table;
            this.listcontext.Name = "listcontext";
            this.listcontext.ShowImageMargin = false;
            this.listcontext.Size = new System.Drawing.Size(93, 70);
            // 
            // lockToolStripMenuItem
            // 
            this.lockToolStripMenuItem.Name = "lockToolStripMenuItem";
            this.lockToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.lockToolStripMenuItem.Text = "Lock";
            this.lockToolStripMenuItem.Visible = false;
            this.lockToolStripMenuItem.Click += new System.EventHandler(this.lockToolStripMenuItem_Click);
            // 
            // unlockToolStripMenuItem
            // 
            this.unlockToolStripMenuItem.Name = "unlockToolStripMenuItem";
            this.unlockToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.unlockToolStripMenuItem.Text = "Unlock";
            this.unlockToolStripMenuItem.Visible = false;
            this.unlockToolStripMenuItem.Click += new System.EventHandler(this.unlockToolStripMenuItem_Click);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.removeToolStripMenuItem.Text = "Remove";
            this.removeToolStripMenuItem.Visible = false;
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 23);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 23);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 6);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(23, 23);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 6);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(23, 23);
            // 
            // locktask
            // 
            this.locktask.ContextMenuStrip = this.taskcontext;
            this.locktask.Icon = ((System.Drawing.Icon)(resources.GetObject("locktask.Icon")));
            this.locktask.Text = "Folder Locker";
            this.locktask.Visible = true;
            this.locktask.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.locktask_MouseDoubleClick);
            // 
            // taskcontext
            // 
            this.taskcontext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.taskrestore,
            this.taskexit});
            this.taskcontext.Name = "taskcontext";
            this.taskcontext.Size = new System.Drawing.Size(114, 48);
            // 
            // taskrestore
            // 
            this.taskrestore.Name = "taskrestore";
            this.taskrestore.Size = new System.Drawing.Size(113, 22);
            this.taskrestore.Text = "Restore";
            this.taskrestore.Click += new System.EventHandler(this.taskrestore_Click);
            // 
            // taskexit
            // 
            this.taskexit.Name = "taskexit";
            this.taskexit.Size = new System.Drawing.Size(113, 22);
            this.taskexit.Text = "Exit";
            this.taskexit.Click += new System.EventHandler(this.taskexit_Click);
            // 
            // loginpane
            // 
            this.loginpane.BackColor = System.Drawing.Color.FloralWhite;
            this.loginpane.Controls.Add(this.usernamebox);
            this.loginpane.Controls.Add(this.loginbut);
            this.loginpane.Controls.Add(this.passwordbox);
            this.loginpane.Controls.Add(this.label2);
            this.loginpane.Controls.Add(this.label1);
            this.loginpane.Dock = System.Windows.Forms.DockStyle.Fill;
            this.loginpane.ForeColor = System.Drawing.Color.Black;
            this.loginpane.Location = new System.Drawing.Point(0, 0);
            this.loginpane.Name = "loginpane";
            this.loginpane.Size = new System.Drawing.Size(312, 429);
            this.loginpane.TabIndex = 2;
            // 
            // usernamebox
            // 
            this.usernamebox.AutoSize = true;
            this.usernamebox.Location = new System.Drawing.Point(88, 110);
            this.usernamebox.Name = "usernamebox";
            this.usernamebox.Size = new System.Drawing.Size(38, 15);
            this.usernamebox.TabIndex = 7;
            this.usernamebox.Text = "label3";
            // 
            // loginbut
            // 
            this.loginbut.Location = new System.Drawing.Point(91, 285);
            this.loginbut.Name = "loginbut";
            this.loginbut.Size = new System.Drawing.Size(75, 23);
            this.loginbut.TabIndex = 6;
            this.loginbut.Text = "Login";
            this.loginbut.UseVisualStyleBackColor = true;
            this.loginbut.Click += new System.EventHandler(this.loginbut_Click);
            // 
            // passwordbox
            // 
            this.passwordbox.Location = new System.Drawing.Point(84, 188);
            this.passwordbox.Name = "passwordbox";
            this.passwordbox.Size = new System.Drawing.Size(216, 23);
            this.passwordbox.TabIndex = 4;
            this.passwordbox.UseSystemPasswordChar = true;
            this.passwordbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.pwdbox1_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 191);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Username :";
            // 
            // mainpane
            // 
            this.mainpane.BackColor = System.Drawing.Color.FloralWhite;
            this.mainpane.Controls.Add(this.namebox);
            this.mainpane.Controls.Add(this.unlockbut);
            this.mainpane.Controls.Add(this.optionsbut);
            this.mainpane.Controls.Add(this.aboutbut);
            this.mainpane.Controls.Add(this.removebut);
            this.mainpane.Controls.Add(this.lockbut);
            this.mainpane.Controls.Add(this.lvfolders);
            this.mainpane.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainpane.Location = new System.Drawing.Point(0, 0);
            this.mainpane.Name = "mainpane";
            this.mainpane.Size = new System.Drawing.Size(312, 429);
            this.mainpane.TabIndex = 3;
            // 
            // namebox
            // 
            this.namebox.AutoSize = true;
            this.namebox.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.namebox.ForeColor = System.Drawing.Color.DarkRed;
            this.namebox.Location = new System.Drawing.Point(160, 10);
            this.namebox.Name = "namebox";
            this.namebox.Size = new System.Drawing.Size(57, 15);
            this.namebox.TabIndex = 7;
            this.namebox.Text = "Welcome ";
            // 
            // unlockbut
            // 
            this.unlockbut.Location = new System.Drawing.Point(115, 394);
            this.unlockbut.Name = "unlockbut";
            this.unlockbut.Size = new System.Drawing.Size(51, 23);
            this.unlockbut.TabIndex = 6;
            this.unlockbut.Text = "Unlock";
            this.unlockbut.UseVisualStyleBackColor = true;
            this.unlockbut.Click += new System.EventHandler(this.unlockbut_Click_1);
            // 
            // optionsbut
            // 
            this.optionsbut.Location = new System.Drawing.Point(6, 6);
            this.optionsbut.Name = "optionsbut";
            this.optionsbut.Size = new System.Drawing.Size(67, 23);
            this.optionsbut.TabIndex = 5;
            this.optionsbut.Text = "Options";
            this.optionsbut.UseVisualStyleBackColor = true;
            this.optionsbut.Click += new System.EventHandler(this.optionsbut_Click);
            // 
            // aboutbut
            // 
            this.aboutbut.Location = new System.Drawing.Point(84, 6);
            this.aboutbut.Name = "aboutbut";
            this.aboutbut.Size = new System.Drawing.Size(57, 23);
            this.aboutbut.TabIndex = 4;
            this.aboutbut.Text = "About";
            this.aboutbut.UseVisualStyleBackColor = true;
            this.aboutbut.Click += new System.EventHandler(this.aboutbut_Click);
            // 
            // removebut
            // 
            this.removebut.Location = new System.Drawing.Point(231, 394);
            this.removebut.Name = "removebut";
            this.removebut.Size = new System.Drawing.Size(62, 23);
            this.removebut.TabIndex = 3;
            this.removebut.Text = "Remove";
            this.removebut.UseVisualStyleBackColor = true;
            this.removebut.Click += new System.EventHandler(this.removebut_Click);
            // 
            // lockbut
            // 
            this.lockbut.Location = new System.Drawing.Point(13, 394);
            this.lockbut.Name = "lockbut";
            this.lockbut.Size = new System.Drawing.Size(43, 23);
            this.lockbut.TabIndex = 1;
            this.lockbut.Text = "Lock";
            this.lockbut.UseVisualStyleBackColor = true;
            this.lockbut.Click += new System.EventHandler(this.lockbut_Click_1);
            // 
            // lvfolders
            // 
            this.lvfolders.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvfolders.ContextMenuStrip = this.listcontext;
            this.lvfolders.Location = new System.Drawing.Point(0, 35);
            this.lvfolders.Name = "lvfolders";
            this.lvfolders.Size = new System.Drawing.Size(311, 341);
            this.lvfolders.TabIndex = 0;
            this.lvfolders.UseCompatibleStateImageBehavior = false;
            this.lvfolders.View = System.Windows.Forms.View.List;
            this.lvfolders.SelectedIndexChanged += new System.EventHandler(this.lvfolders_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(312, 429);
            this.Controls.Add(this.mainpane);
            this.Controls.Add(this.loginpane);
            this.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Folder Locker";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.listcontext.ResumeLayout(false);
            this.taskcontext.ResumeLayout(false);
            this.loginpane.ResumeLayout(false);
            this.loginpane.PerformLayout();
            this.mainpane.ResumeLayout(false);
            this.mainpane.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon locktask;
        private System.Windows.Forms.ContextMenuStrip taskcontext;
        private System.Windows.Forms.ToolStripMenuItem taskrestore;
        private System.Windows.Forms.ToolStripMenuItem taskexit;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ContextMenuStrip listcontext;
        private System.Windows.Forms.ToolStripMenuItem lockToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unlockToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.Panel loginpane;
        private System.Windows.Forms.Button loginbut;
        private System.Windows.Forms.TextBox passwordbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel mainpane;
        private System.Windows.Forms.Button optionsbut;
        private System.Windows.Forms.Button aboutbut;
        private System.Windows.Forms.Button removebut;
        private System.Windows.Forms.Button lockbut;
        private System.Windows.Forms.ListView lvfolders;
        private System.Windows.Forms.Button unlockbut;
        private System.Windows.Forms.Label usernamebox;
        private System.Windows.Forms.Label namebox;
    }
}

