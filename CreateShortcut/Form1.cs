using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CreateShortcut
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            try
            {
                // Create shortcut on Desktop
                if (check_Desktop.Checked == true)
                {
                    if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Desktop).Trim() + "\\khieunaitocao.exe") == false)
                    {
                        File.Move(Application.StartupPath + "\\khieunaitocao.exe", Environment.GetFolderPath(Environment.SpecialFolder.Desktop).Trim() + "\\Shortcut to Test.lnk");
                    }
                }

                // Create shortcut in programs menu.
                if (check_StartMenu.Checked == true)
                {
                    if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Programs).Trim() + "\\khieunaitocao.exe") == false)
                    {
                        File.Move(Application.StartupPath + "\\khieunaitocao.exe", Environment.GetFolderPath(Environment.SpecialFolder.Programs).Trim() + "\\khieunaitocao.exe");
                    }
                }

                // Create shortcut in Quick Launch Toolbar
                //if (cbQuickLaunch.Checked == true)
                //{
                //    if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Microsoft\\Internet Explorer\\Quick Launch\\Test.lnk") == false)
                //    {
                //        File.Move(Application.StartupPath + "\\Test2.lnk", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Microsoft\\Internet Explorer\\Quick Launch\\Test.lnk");
                //    }
                //}
                //btnNext.Enabled=false;
                //btnCancel.Enabled=true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Desktop).Trim() + "\\Shortcut to Test.lnk") == true)
                {
                    File.Move(Environment.GetFolderPath(Environment.SpecialFolder.Desktop).Trim() + "\\Shortcut to Test.lnk", Application.StartupPath + "\\Shortcut to Test.lnk");
                }
                if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Programs).Trim() + "\\Test.lnk") == true)
                {
                    File.Move(Environment.GetFolderPath(Environment.SpecialFolder.Programs).Trim() + "\\Test.lnk", Application.StartupPath + "\\Test1.lnk");
                }
                if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Microsoft\\Internet Explorer\\Quick Launch\\Test.lnk") == true)
                {
                    File.Move(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Microsoft\\Internet Explorer\\Quick Launch\\Test.lnk", Application.StartupPath + "\\Test2.lnk");
                }
                //btnNext.Enabled=true;
                //btnCancel.Enabled=false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
