using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Security;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Reflection;
using Microsoft.Win32;

namespace folderlocker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public bool ch = true;
        public String n = "";
        public String foldnam = "";

        #region password pane

        private void pwdbox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                passwordset();
            }
        }

        private void passwordset()
        {
            bool issuccess = false;
            try
            {
                issuccess = pwdcheck(passwordbox.Text.Trim());
                if (issuccess)
                {
                    MessageBox.Show("Welcome " + usernamebox.Text + " !", "Folder Locker", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    mainpane.Visible = true;
                    lockbut.Enabled = true;
                    unlockbut.Enabled = false;
                    loginpane.Visible = false;
                    removebut.Enabled = false;
                    filllistview();
                }
                else
                {
                    if (folderlocker.Properties.Settings.Default.mp == "")
                    {
                        folderlocker.Properties.Settings.Default.mp = passwordbox.Text;
                        folderlocker.Properties.Settings.Default.Save();
                    }
                    else
                    {
                        MessageBox.Show("Wrong Password.", "Folder Locker");
                    }
                }
                passwordbox.Text = "";
            }
            catch { }
        }

        private bool pwdcheck(String password)
        {
            
            if (folderlocker.Properties.Settings.Default.mp==password)
                return true;
            else
                return false;
        }

        #endregion

        #region load/closing

        public bool isadmin()
        {
            WindowsIdentity user = WindowsIdentity.GetCurrent();
            WindowsPrincipal us = new WindowsPrincipal(user);
            try
            {
                return us.IsInRole(WindowsBuiltInRole.Administrator);
            }
            catch (UnauthorizedAccessException)
            {
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (isadmin())
            {
                mainpane.Visible = false;
                WindowsIdentity user = WindowsIdentity.GetCurrent();
                n=user.Name;
                usernamebox.Text = n.Substring(n.IndexOf('\\')+1);
                namebox.Text ="Welcome " + usernamebox.Text +" !";
                RegistryKey rkApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                if (rkApp.GetValue("Folder Locker") == null)
                {
                    // The value doesn't exist, the application is not set to run at startup
                    folderlocker.Properties.Settings.Default.startupcheck = false;
                }
                else
                {
                    // The value exists, the application is set to run at startup
                    folderlocker.Properties.Settings.Default.startupcheck = true;
                }
                folderlocker.Properties.Settings.Default.Save();
            }
            else
            {
                this.WindowState = FormWindowState.Minimized;
                Application.Exit();
                ProcessStartInfo pi = new ProcessStartInfo();
                pi.FileName = Application.ExecutablePath;
                pi.UseShellExecute = true;
                pi.Verb = "runas";
                Process.Start(pi);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.WindowState != FormWindowState.Minimized)
            {
                e.Cancel = true;
                this.WindowState = FormWindowState.Minimized;
                this.Hide();
            }
        }

        #endregion

        #region lock/unlock functions

        public void locking()
        {
            if (!(folderlocker.Properties.Settings.Default.foldnam.Contains(foldnam)))
            {
                try
                {
                    DirectoryInfo di = new DirectoryInfo(foldnam);
                    if (di.Exists)
                    {
                        di.Attributes |= FileAttributes.System;
                        di.Attributes |= FileAttributes.Hidden;
                        DirectorySecurity ds = di.GetAccessControl();
                        AuthorizationRuleCollection rules = ds.GetAccessRules(true, true, typeof(NTAccount));
                        foreach (AuthorizationRule rule in rules)
                        {
                            if (rule is FileSystemAccessRule)
                            {
                                ds.RemoveAccessRule((FileSystemAccessRule)rule);
                            }
                        }
                        ds.AddAccessRule(new FileSystemAccessRule(@"Administrators", FileSystemRights.FullControl, AccessControlType.Deny));
                        ds.AddAccessRule(new FileSystemAccessRule(@"Users", FileSystemRights.ReadAndExecute, AccessControlType.Deny));
                        ds.AddAccessRule(new FileSystemAccessRule(@"System", FileSystemRights.FullControl, AccessControlType.Deny));
                        di.SetAccessControl(ds);
                        folderlocker.Properties.Settings.Default.foldnam.Add(foldnam);
                        if (folderlocker.Properties.Settings.Default.unlockedfoldnam.Contains(foldnam))
                        {
                            folderlocker.Properties.Settings.Default.dateunlocked.RemoveAt(folderlocker.Properties.Settings.Default.unlockedfoldnam.IndexOf(foldnam));
                            folderlocker.Properties.Settings.Default.unlockedfoldnam.Remove(foldnam);
                        }
                        folderlocker.Properties.Settings.Default.datelocked.Add(System.DateTime.Now.ToString());
                        folderlocker.Properties.Settings.Default.Save();
                        filllistview();
                        MessageBox.Show("Locked", "Folder Locker");
                        lockbut.Enabled = false;
                        unlockbut.Enabled = false;
                        removebut.Enabled = false;
                    }
                }
                catch (Exception e1)
                {
                    MessageBox.Show(e1.Message, "Folder Locker");
                }
            }
            else
            {
                MessageBox.Show("Folder already locked.", "Folder Locker");
            }
            foldnam = "";
            lvfolders.SelectedIndices.Clear();
        }

        public void unlocking()
        {
            try
            {
                using (var user = WindowsIdentity.GetCurrent())
                {
                    var ownerSecurity = new DirectorySecurity();
                    ownerSecurity.SetOwner(user.User);
                    var accessSecurity = new DirectorySecurity();
                    accessSecurity.AddAccessRule(new FileSystemAccessRule(user.User, FileSystemRights.FullControl, InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit, PropagationFlags.InheritOnly, AccessControlType.Allow));
                    Directory.SetAccessControl(foldnam, accessSecurity);
                }
                DirectoryInfo di = new DirectoryInfo(foldnam);
                di.Attributes = FileAttributes.Normal;
                DirectorySecurity ds1 = di.GetAccessControl();
                ds1.SetOwner(WindowsIdentity.GetCurrent().User);
                Directory.SetAccessControl(foldnam, ds1);
                AuthorizationRuleCollection rules = ds1.GetAccessRules(true, true, typeof(NTAccount));
                foreach (AuthorizationRule rule in rules)
                {
                    if (rule is FileSystemAccessRule)
                    {
                        ds1.RemoveAccessRule((FileSystemAccessRule)rule);
                    }
                }
                ds1.AddAccessRule(new FileSystemAccessRule(@"Administrators", FileSystemRights.FullControl, InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit, PropagationFlags.InheritOnly, AccessControlType.Allow));
                ds1.AddAccessRule(new FileSystemAccessRule(@"Users", FileSystemRights.FullControl, InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit, PropagationFlags.InheritOnly, AccessControlType.Allow));
                ds1.AddAccessRule(new FileSystemAccessRule(@"System", FileSystemRights.FullControl, InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit, PropagationFlags.InheritOnly, AccessControlType.Allow));
                di.SetAccessControl(ds1);
                folderlocker.Properties.Settings.Default.datelocked.RemoveAt(folderlocker.Properties.Settings.Default.foldnam.IndexOf(foldnam));
                folderlocker.Properties.Settings.Default.foldnam.Remove(foldnam);
                folderlocker.Properties.Settings.Default.unlockedfoldnam.Add(foldnam);
                folderlocker.Properties.Settings.Default.dateunlocked.Add(System.DateTime.Now.ToString());
                folderlocker.Properties.Settings.Default.Save();
                filllistview();
                MessageBox.Show("Unlocked", "Folder Locker");
                lockbut.Enabled = false;
                unlockbut.Enabled = false;
                removebut.Enabled = false;
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message, "Folder Locker");
            }
            foldnam = "";
            lvfolders.SelectedIndices.Clear();
        }

        #endregion

        #region notifyicon
        private void taskrestore_Click(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void taskexit_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            this.Close();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                this.Hide();
            }
        }

        private void locktask_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }
        #endregion

        #region fill list view
        private void filllistview()
        {
            int i = 0;
            lvfolders.Items.Clear();
            ListViewItem li;
            String[] a = new String[folderlocker.Properties.Settings.Default.foldnam.Count];
            folderlocker.Properties.Settings.Default.foldnam.CopyTo(a, 0);
            if (folderlocker.Properties.Settings.Default.foldnam.Count > 0)
            {
                for (i = 1; i < a.Length; i++)
                {
                    if (!lvfolders.Items.ContainsKey(a[i]) && a[i] != "" && a[i] != " ")
                    {
                        li = lvfolders.Items.Add(a[i], a[i], -1);
                        li.SubItems.AddRange(new string[] { " "," " });
                        li.SubItems[1].Text = "Locked";
                        li.SubItems[2].Text = folderlocker.Properties.Settings.Default.datelocked[i].ToString();
                    }
                    else
                    {
                        li=lvfolders.Items[a[i]];
                        li.SubItems.AddRange(new string[] {" "," "});
                        li.SubItems[1].Text="Locked";
                        li.SubItems[2].Text = folderlocker.Properties.Settings.Default.datelocked[i].ToString();
                    }
                }
            }
            i = 0;
            String[] a2 = new String[folderlocker.Properties.Settings.Default.unlockedfoldnam.Count];
            folderlocker.Properties.Settings.Default.unlockedfoldnam.CopyTo(a2, 0);
            if (folderlocker.Properties.Settings.Default.unlockedfoldnam.Count > 0)
            {
                for (i = 1; i < a2.Length; i++)
                {
                    if (a2[i] != "" && a2[i] != " ")
                    {
                        DirectoryInfo di = new DirectoryInfo(a2[i]);
                        if (di.Exists)
                        {
                            if (!lvfolders.Items.ContainsKey(a2[i]))
                            {
                                li = lvfolders.Items.Add(a2[i], a2[i], -1);
                                li.SubItems.AddRange(new string[] { " "," " });
                                li.SubItems[1].Text = "Unlocked";
                                li.SubItems[2].Text = folderlocker.Properties.Settings.Default.dateunlocked[i].ToString();
                            }
                            else if (lvfolders.Items.ContainsKey(a2[i]))
                            {
                                li = lvfolders.Items[a2[i]];
                                li.SubItems.AddRange(new string[] { " "," " });
                                li.SubItems[1].Text = "Unlocked";
                                li.SubItems[2].Text = folderlocker.Properties.Settings.Default.dateunlocked[i].ToString();
                            }
                        }
                    }
                }
            }
        }
        #endregion

        #region listview event handlers

        private void lvfolders_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvfolders.SelectedIndices.Count > 0)
            {
                if (folderlocker.Properties.Settings.Default.foldnam.Contains(lvfolders.SelectedItems[0].Text))
                {
                    lockToolStripMenuItem.Visible = false;
                    removeToolStripMenuItem.Visible = false;
                    unlockToolStripMenuItem.Visible = true;
                    unlockbut.Enabled = true;
                    lockbut.Enabled = false;
                    removebut.Enabled = false;
                    foldnam = lvfolders.SelectedItems[0].Text;
                }
                else
                {
                    lockToolStripMenuItem.Visible = true;
                    removeToolStripMenuItem.Visible = true;
                    unlockToolStripMenuItem.Visible = false;
                    unlockbut.Enabled = false;
                    lockbut.Enabled = true;
                    removebut.Enabled = true;
                    foldnam = lvfolders.SelectedItems[0].Text;
                }
            }
            else
            {
                lockToolStripMenuItem.Visible = false;
                removeToolStripMenuItem.Visible = false;
                unlockToolStripMenuItem.Visible = false;
                unlockbut.Enabled = false;
                lockbut.Enabled = false;
                removebut.Enabled = false;
                foldnam = "";
            }
        }

        private void lockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (foldnam != "")
            {
                pwdbx sd = new pwdbx();
                sd.ShowDialog();
                if (folderlocker.Properties.Settings.Default.passcheck)
                    locking();
                else
                {
                    MessageBox.Show("Wrong Password.", "Folder Locker");
                }
                foldnam = "";
                lvfolders.SelectedIndices.Clear();
                lockToolStripMenuItem.Visible = false;
                removeToolStripMenuItem.Visible = false;
                unlockToolStripMenuItem.Visible = false;
            }
        }

        private void unlockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (foldnam != "")
            {
                pwdbx sd = new pwdbx();
                sd.ShowDialog();
                if (folderlocker.Properties.Settings.Default.passcheck)
                    unlocking();
                else
                {
                    MessageBox.Show("Wrong Password.", "Folder Locker");
                }
                foldnam = "";
                lvfolders.SelectedIndices.Clear();
                lockToolStripMenuItem.Visible = false;
                removeToolStripMenuItem.Visible = false;
                unlockToolStripMenuItem.Visible = false;
            }
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (folderlocker.Properties.Settings.Default.unlockedfoldnam.Contains(foldnam))
            {
                folderlocker.Properties.Settings.Default.dateunlocked.RemoveAt(folderlocker.Properties.Settings.Default.unlockedfoldnam.IndexOf(foldnam));
                folderlocker.Properties.Settings.Default.unlockedfoldnam.Remove(foldnam);
                folderlocker.Properties.Settings.Default.Save();
                lvfolders.SelectedIndices.Clear();
                filllistview();
                foldnam = "";
                removebut.Enabled = false;
            }
            else
            {
                MessageBox.Show("Can not remove this folder.", "Folder Locker");
            }
        }

        #endregion

        #region buttonsclick

        private void loginbut_Click(object sender, EventArgs e)
        {
            passwordset();
        }

        private void lockbut_Click_1(object sender, EventArgs e)
        {
            if (foldnam=="")
            {
                FolderBrowserDialog a = new FolderBrowserDialog();
                a.ShowDialog();
                foldnam = a.SelectedPath;
            }
            removebut.Enabled = false;
            unlockbut.Enabled = false;
            if (foldnam != "")
            {
                pwdbx sd = new pwdbx();
                sd.ShowDialog();
                if (folderlocker.Properties.Settings.Default.passcheck)
                    locking();
                else
                {
                    MessageBox.Show("Wrong Password.", "Folder Locker");
                }
                lvfolders.SelectedIndices.Clear();
                lockToolStripMenuItem.Visible = false;
                foldnam = "";
                removeToolStripMenuItem.Visible = false;
                unlockToolStripMenuItem.Visible = false;
            }
        }

        private void unlockbut_Click_1(object sender, EventArgs e)
        {
            if (foldnam != "")
            {
                pwdbx sd = new pwdbx();
                sd.ShowDialog();
                if (folderlocker.Properties.Settings.Default.passcheck)
                    unlocking();
                else
                {
                    MessageBox.Show("Wrong Password.", "Folder Locker");
                }
                lvfolders.SelectedIndices.Clear();
                lockToolStripMenuItem.Visible = false;
                removeToolStripMenuItem.Visible = false;
                foldnam = "";
                unlockToolStripMenuItem.Visible = false;
            }
        }

        private void removebut_Click(object sender, EventArgs e)
        {
            if (folderlocker.Properties.Settings.Default.unlockedfoldnam.Contains(lvfolders.SelectedItems[0].Name))
            {
                folderlocker.Properties.Settings.Default.dateunlocked.RemoveAt(folderlocker.Properties.Settings.Default.unlockedfoldnam.IndexOf(foldnam));
                folderlocker.Properties.Settings.Default.unlockedfoldnam.Remove(foldnam);
                folderlocker.Properties.Settings.Default.Save();
                lvfolders.SelectedIndices.Clear();
                filllistview();
                removebut.Enabled = false;
            }
            else
            {
                MessageBox.Show("Can not remove this folder.", "Folder Locker");
            }
        }

        private void aboutbut_Click(object sender, EventArgs e)
        {
            aboutfolderlocker a = new aboutfolderlocker();
            a.ShowDialog();
        }

        private void optionsbut_Click(object sender, EventArgs e)
        {
            options aas = new options();
            aas.ShowDialog();
        }

        #endregion

    }
}
