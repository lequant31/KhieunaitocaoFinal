using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace khieunaitocao
{
    public partial class test : DevExpress.XtraEditors.XtraForm
    {
        public string Username;
        public string Filename;
        public string Fullname;
        public string Server;
        public string Password;
        public string path;
        public string localdest;
        private khieunaitocaoContextDataContext _khieunaitocaoContext;

        public test()
        {
            InitializeComponent();
            if (checkdown.Checked == true)
            {
                checkup.Enabled = false;
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            if (checkdown.Checked == true)
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(new Uri(string.Format("{0}/{1}", Server, Filename)));

                request.Credentials = new NetworkCredential(Username, Password);
                request.Method = WebRequestMethods.Ftp.DownloadFile;  //Download Method

                //Get some data form the source file like the zise and the TimeStamp. every data you request need to be a different request and response
                FtpWebRequest request1 = (FtpWebRequest)WebRequest.Create(new Uri(string.Format("{0}/{1}", Server, Filename)));
                request1.Credentials = new NetworkCredential(Username, Password);
                request1.Method = WebRequestMethods.Ftp.GetFileSize;  //GetFileze Method
                FtpWebResponse response = (FtpWebResponse)request1.GetResponse();
                double total = response.ContentLength;
                response.Close();

                FtpWebRequest request2 = (FtpWebRequest)WebRequest.Create(new Uri(string.Format("{0}/{1}", Server, Filename)));
                request2.Credentials = new NetworkCredential(Username, Password);
                request2.Method = WebRequestMethods.Ftp.GetDateTimestamp; //GetTimestamp Method
                FtpWebResponse response2 = (FtpWebResponse)request2.GetResponse();
                DateTime modify = response2.LastModified;
                response2.Close();

                Stream ftpstream = request.GetResponse().GetResponseStream();
                FileStream fs = new FileStream(localdest, FileMode.Create);

                // Method to calculate and show the progress.
                byte[] buffer = new byte[1024];
                int byteRead = 0;
                double read = 0;
                do
                {
                    byteRead = ftpstream.Read(buffer, 0, 1024);
                    fs.Write(buffer, 0, byteRead);
                    read += (double)byteRead;
                    double percentage = read / total * 100;
                    backgroundWorker1.ReportProgress((int)percentage);
                }
                while (byteRead != 0);
                ftpstream.Close();
                fs.Close();
            }
            else
            {
                //Upload Method.
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(new Uri(string.Format("{0}/{1}", Server, Filename)));
                request.Method = WebRequestMethods.Ftp.UploadFile;
                request.Credentials = new NetworkCredential(Username, Password);
                Stream ftpstream = request.GetRequestStream();
                FileStream fs = File.OpenRead(Fullname);

                // Method to calculate and show the progress.
                byte[] buffer = new byte[1024];
                double total = (double)fs.Length;
                int byteRead = 0;
                double read = 0;
                do
                {
                    byteRead = fs.Read(buffer, 0, 1024);
                    ftpstream.Write(buffer, 0, byteRead);
                    read += (double)byteRead;
                    double percentage = read / total * 100;
                    backgroundWorker1.ReportProgress((int)percentage);
                }
                while (byteRead != 0);
                fs.Close();
                ftpstream.Close();
            }
        }

        //Background
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (checkdown.Checked == true)
            {
                label4.Text = $"Downloaded {e.ProgressPercentage}%";
                label4.Update();
                progressBar1.Value = e.ProgressPercentage;
                progressBar1.Update();
            }

            if (checkup.Checked == true)
            {
                label4.Text = $"Uploaded {e.ProgressPercentage}%";
                label4.Update();
                progressBar1.Value = e.ProgressPercentage;
                progressBar1.Update();
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (checkdown.Checked == true)
            {
                label4.Text = "Download Complete!";
                MessageBox.Show("Download Complete!");
            }

            if (checkup.Checked == true)
            {
                label4.Text = "Upload Complete!";
                MessageBox.Show("Upload Complete!");
            }
        }

        private void test_Load(object sender, EventArgs e)
        {
            //var list = _khieunaitocaoContext.list_phanloai_khieunai();
            //treeListLookUpEdit1.Properties.DataSource = list;
            //var aa = buttonEdit1.Text;
            DateTime dt = new DateTime();
            dt = DateTime.Now;
            //dateEdit1.EditValue =dt.AddDays(5);
        }

        private void checkup_CheckedChanged(object sender, EventArgs e)
        {
            if (checkdown.Checked == false)
            {
                checkup.Enabled = true;
                checkup.Checked = true;
                button1.Text = @"Upload";
                label5.Enabled = false;
                textBox4.Enabled = false;
                checkdown.Enabled = false;
                label4.Text = @"Uploaded 0%";
            }
        }

        private void checkdown_CheckedChanged(object sender, EventArgs e)
        {
            if (checkup.Checked == false)
            {
                checkdown.Enabled = true;
                checkdown.Checked = true;
                button1.Text = @"Download";
                label5.Enabled = true;
                textBox4.Enabled = true;
                checkup.Enabled = false;
                label4.Text = @"Downloaded 0%";
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkup.Checked == true)
            {
                using (OpenFileDialog ofd = new OpenFileDialog() { Multiselect = true, ValidateNames = true, Filter = "All Files|*.*" })
                {
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        FileInfo fi = new FileInfo(ofd.FileName);
                        Username = "ftpserver";
                        Password = "1234567890aA@";
                        Server = "ftp://18.220.41.128";
                        Filename = fi.Name;
                        Fullname = fi.FullName;
                    }
                }
            }

            if (checkdown.Checked == true)
            {
                Username = "ftpserver";
                Password = "1234567890aA@";
                Server = "ftp://18.220.41.128";
                Filename = "khieunaitocao.vshost.exe.manifest";
                path = @"C:\Websiteupdate\UploadFile\";
                localdest = path + @"" + Filename;
                Fullname = Server + @"/" + Filename;
            }

            //Start the Background and wait a little to start it.
            Thread.Sleep(1000);
            backgroundWorker1.RunWorkerAsync();  //the most important command to start the background worker
            Thread.Sleep(1000);
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Username = "administrator";
            Password = "1234567890aA@";
            Server = "ftp://192.168.99.22";
            string pa = Server + "/" + "---[HD] [Kara] [Vietsub]-When you tell me that you love me-Westlife feat Diana Ross.mp4";
            FtpWebRequest request1 = (FtpWebRequest)FtpWebRequest.Create(new Uri(pa));

            // Step 2 - Configure the connection request
            request1.Credentials = new NetworkCredential(Username, Password);
            request1.UsePassive = true;
            request1.UseBinary = true;
            request1.KeepAlive = false;
            // tạo folder
            //request1.Method = WebRequestMethods.Ftp.MakeDirectory;

            // Step 3 - Call GetResponse() method to actually attempt to create the directory
            //FtpWebResponse makeDirectoryResponse = (FtpWebResponse)request1.GetResponse();

            // delete folder
            request1.Method = WebRequestMethods.Ftp.RemoveDirectory;
            request1.GetResponse();

            //delete file
            request1.Method = WebRequestMethods.Ftp.DeleteFile;
            request1.GetResponse();
        }
    }
}