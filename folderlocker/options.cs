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
    public partial class options : Form
    {
        public options()
        {
            InitializeComponent();
        }

        #region change password

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text==folderlocker.Properties.Settings.Default.mp)
            {
                if(textBox2.Text!="")
                {
                    folderlocker.Properties.Settings.Default.mp = textBox2.Text;
                    folderlocker.Properties.Settings.Default.Save();
                    MessageBox.Show("Password changed.", "Folder Locker", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("New Password cannot be blank.", "Folder Locker", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Wrong Password", "Folder Locker", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            textBox2.Text = "";
            textBox1.Text = "";
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                if (textBox1.Text == folderlocker.Properties.Settings.Default.mp)
                {
                    if (textBox2.Text != "")
                    {
                        folderlocker.Properties.Settings.Default.mp = textBox2.Text;
                        folderlocker.Properties.Settings.Default.Save();
                        MessageBox.Show("Password changed.", "Folder Locker", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("New Password cannot be blank.", "Folder Locker", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Wrong Password", "Folder Locker", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                textBox2.Text = "";
                textBox1.Text = "";
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                if (textBox1.Text == folderlocker.Properties.Settings.Default.mp)
                {
                    if (textBox2.Text != "")
                    {
                        folderlocker.Properties.Settings.Default.mp = textBox2.Text;
                        folderlocker.Properties.Settings.Default.Save();
                        MessageBox.Show("Password changed.", "Folder Locker", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("New Password cannot be blank.", "Folder Locker", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Wrong Password", "Folder Locker", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                textBox2.Text = "";
                textBox1.Text = "";
            }
        }

        #endregion

        #region load

        private void options_Load(object sender, EventArgs e)
        {
            if(folderlocker.Properties.Settings.Default.startupcheck)
            {
                checkBox1.CheckState = CheckState.Checked;
            }
            else
            {
                checkBox1.CheckState = CheckState.Unchecked;
            }
        }

        #endregion

        #region startup

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.CheckState == CheckState.Checked)
            {
                startup(true);
            }
            else if (checkBox1.CheckState == CheckState.Unchecked)
            {
                startup(false);
            }
        }

        public static void startup(bool chk)
        {
            String destination = Application.ExecutablePath.ToString();
            try
            {
                RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                if (chk)
                {
                    if (registryKey.GetValue("Folder Locker") == null)
                    {
                        registryKey.SetValue("Folder Locker", destination);
                    }
                }
                else
                {
                    registryKey.SetValue("Folder Locker", null);
                }
                registryKey.Close();//dispose of the Key
            }
            catch (Exception e1)
            {
                Console.WriteLine(e1.Message);
            }
        }
        #endregion   

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
