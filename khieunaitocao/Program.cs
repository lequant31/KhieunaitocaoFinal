using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace khieunaitocao
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            DevExpress.UserSkins.BonusSkins.Register();
            DevExpress.Skins.SkinManager.EnableFormSkins();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //#region Kiem tra version
            //try
            //{
            //    //System.Net.WebClient client = new System.Net.WebClient();
            //    //var Version = client.DownloadString("http://18.220.41.128/Version.txt").Trim();
            //    ////string str = "1.0.0.1";
            //    ////var Version = str.Trim();
            //    //if (Version != Properties.Settings.Default.Version)
            //    //{
            //    //    if (MessageBox.Show("Đã có phiên bản mới. Bạn có muốn cập nhật không?", "Confirmation", MessageBoxButtons.YesNo) ==
            //    //     DialogResult.Yes)
            //    //    {
            //    //        System.Diagnostics.Process.Start(Application.StartupPath + "\\updater.exe");
            //    //        Properties.Settings.Default.Version = Version.Trim();
            //    //        Properties.Settings.Default.Save();
            //    //        return;
            //    //    }
            //    //}
            //    System.Net.WebClient client = new System.Net.WebClient();
            //    string Version = client.DownloadString("http://18.220.41.128/Version.txt").Trim();
            //    var oldVersion = "";
            //    try
            //    {
            //        oldVersion = System.IO.File.ReadAllText(Application.StartupPath + "\\Version.txt").Replace("\r\n", "");
            //    }
            //    catch { }
            //    if (Version != oldVersion)
            //    {
            //        System.Diagnostics.Process.Start(Application.StartupPath + "\\updater.exe");
            //        //Properties.Settings.Default.Version = Version.Trim();
            //        //Properties.Settings.Default.Save();
            //        return;
            //    }
            //}
            //catch { }
            //#endregion

            #region login
            var _dangnhap = new frm_dangnhap();
            _dangnhap.ShowDialog();
            if (_dangnhap.DialogResult != DialogResult.OK)
            {
                return;
            }
            #endregion
            Application.Run(new quanlythongtin());
        }
    }
}
