using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace folderlocker
{
    public partial class pwdbx : Form
    {
        public pwdbx()
        {
            InitializeComponent();
        }

        private void okbut_Click(object sender, EventArgs e)
        {
            if (folderlocker.Properties.Settings.Default.mp.Equals(pwdbox1.Text))
            {
                folderlocker.Properties.Settings.Default.passcheck = true;
                folderlocker.Properties.Settings.Default.Save();
                pwdbox1.Text = "";
                this.Close();
            }
            else
            {
                folderlocker.Properties.Settings.Default.passcheck = false;
                folderlocker.Properties.Settings.Default.Save();
                pwdbox1.Text = "";
                this.Close();
            }
        }

        private void pwdbx_Load(object sender, EventArgs e)
        {
            folderlocker.Properties.Settings.Default.passcheck = false;
        }

        private void pwdbox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                e.SuppressKeyPress = true;
                if (folderlocker.Properties.Settings.Default.mp.Equals(pwdbox1.Text))
                {
                    folderlocker.Properties.Settings.Default.passcheck = true;
                    folderlocker.Properties.Settings.Default.Save();
                    pwdbox1.Text = "";
                    this.Close();
                }
                else
                {
                    folderlocker.Properties.Settings.Default.passcheck = false;
                    folderlocker.Properties.Settings.Default.Save();
                    pwdbox1.Text = "";
                    this.Close();
                }
            }
        }

    }
}
