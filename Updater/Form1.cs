using ICSharpCode.SharpZipLib.Zip;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Updater
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string NewVersion = "";

        void RepairUpdater()
        {
            string PathFile = Application.StartupPath + "\\uninsep.bat";
            string[] cmdLines = {":Repeat",
                "del \"" + Application.StartupPath + "\\updater.exe\"",
                "if exist \"" + Application.StartupPath + "\\updater.exe\" goto Repeat ",
                "rename \"" + Application.StartupPath + "\\updaternew.exe\" \"updater.exe\"",
                "del \"" + PathFile +  "\";" };

            System.IO.FileStream stream = System.IO.File.Create(PathFile);
            stream.Close();
            System.IO.File.WriteAllLines(PathFile, cmdLines);
            Process pLS = new Process();
            pLS.StartInfo.FileName = PathFile;
            pLS.StartInfo.CreateNoWindow = true;
            pLS.StartInfo.UseShellExecute = false;
            try
            {
                pLS.Start();
            }
            catch
            {
            }
        }

        private void Permission()
        {
            string User = System.Environment.UserDomainName + "\\" + Environment.UserName;
            DirectoryInfo myDirectoryInfo = new DirectoryInfo(Application.StartupPath);
            DirectorySecurity myDirectorySecurity = myDirectoryInfo.GetAccessControl();
            myDirectorySecurity.AddAccessRule(new FileSystemAccessRule(User,
                FileSystemRights.FullControl,
                InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit,
                PropagationFlags.None,
                AccessControlType.Allow));
            myDirectoryInfo.SetAccessControl(myDirectorySecurity);
            myDirectoryInfo = null;
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                Permission();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bạn cần thiết lập quyền ghi tập tin cho thư mục cài đặt trước khi cập nhật phiên bản.\n "
                        + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Process.Start(Application.StartupPath);
                this.Close();
                return;
            }

            try
            {
                lblStatus.Text = "Đang tìm kiếm bản cập nhật mới";
                this.Update();

                System.Net.WebClient client = new System.Net.WebClient();
                NewVersion = client.DownloadString("http://18.220.41.128/Version.txt");

                var oldVersion = "";
                try
                {
                    oldVersion = System.IO.File.ReadAllText(Application.StartupPath + "\\Version.txt").Replace("\r\n", "");
                }
                catch { }

                if (NewVersion == oldVersion)
                {
                    lblStatus.Text = "Không có bản cập nhật mới";
                    btn_cancel.Text = "Thoát";
                    return;
                }

                foreach (Process p in Process.GetProcesses())
                {
                    if ((p.ProcessName.ToLower() == "khieunaitocao"))
                        p.Kill();
                }

                client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
                client.DownloadDataCompleted += new DownloadDataCompletedEventHandler(client_DownloadDataCompleted);
                client.DownloadDataAsync(new Uri("http://18.220.41.128/Version.zip"));
            }
            catch
            {
                lblStatus.Text = "Không tìm thấy phiên bản mới";
                btn_cancel.Text = "Thoát";
            }
        }
        void client_DownloadDataCompleted(object sender, DownloadDataCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                lblStatus.Text = "Đang cài đặt..";
                progress.Position = 0;
                progress.Properties.Step = 1;

                ZipInputStream zipIn = new ZipInputStream(new MemoryStream(e.Result));
                ZipEntry entry;

                int fileCount = 0;
                while ((entry = zipIn.GetNextEntry()) != null)
                {
                    fileCount++;
                }
                progress.Properties.Maximum = fileCount;

                zipIn = new ZipInputStream(new MemoryStream(e.Result));
                while ((entry = zipIn.GetNextEntry()) != null)
                {
                    progress.PerformStep();
                    this.Update();

                    string path = Application.StartupPath + "\\" + (entry.Name.ToLower() != "updater.exe" ? entry.Name : "updaternew.exe");

                    if (entry.IsDirectory)
                    {
                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                        }
                        continue;
                    }

                    //File.Delete(AppDir + entry.Name);
                    FileStream streamWriter = File.Create(path);
                    long size = entry.Size;
                    byte[] data = new byte[size];
                    while (true)
                    {
                        size = zipIn.Read(data, 0, data.Length);
                        if (size > 0) streamWriter.Write(data, 0, (int)size);
                        else break;
                    }
                    streamWriter.Close();

                    if (entry.Name.ToLower() == "updater.exe")
                        RepairUpdater();
                }

                //Luu ver
                string pathVersion = Application.StartupPath + "\\Version.txt";
                StreamWriter sw = new StreamWriter(pathVersion);
                sw.WriteLine(NewVersion);
                sw.Close();
                //
                lblStatus.Text = "Cài đặt hoàn tất";
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Đã xảy ra lỗi trong quá trình tải xuống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            lblStatus.Text = string.Format("Đang tải: {0:#,0} byte / {1:#,0} byte", e.BytesReceived, e.TotalBytesToReceive);

            double Position = Convert.ToDouble(e.BytesReceived) / Convert.ToDouble(e.TotalBytesToReceive) * 100;
            progress.Position = Convert.ToInt32(Math.Round(Position, 0));
            progress.Update();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                Process.Start(Application.StartupPath + "\\khieunaitocao.exe");
        }
    }
}
