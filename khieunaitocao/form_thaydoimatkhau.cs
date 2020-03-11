using DevExpress.XtraEditors;
using System;

namespace khieunaitocao
{
    public partial class form_thaydoimatkhau : DevExpress.XtraEditors.XtraForm
    {
        public form_thaydoimatkhau()
        {
            InitializeComponent();
        }

 

        private void bar_save_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            mahoa mahoa = new mahoa();
            string pass = mahoa.EncryptString(passold.Text, "lamgico");
            #region check password old
            if (passnewagain.Text != passnew.Text)
            {
                XtraMessageBox.Show("Mật khẩu nhập lại không đúng");
                return;
            }
            if (pass != dinhdanh.password)
            {
                XtraMessageBox.Show("Mật khẩu cũ không đúng");
                return;
            }
            #endregion
            try
            {
                string passnew = mahoa.EncryptString(passnewagain.Text, "lamgico");
                using (khieunaitocaoContextDataContext khieunaitocaoContext = new khieunaitocaoContextDataContext())
                {
                    khieunaitocaoContext.UpdatePassword(dinhdanh.ma_canbo, passnew);
                    XtraMessageBox.Show("Đổi mật khẩu thành công");
                }
            }
            catch (Exception)
            {
                XtraMessageBox.Show("Đổi mật khẩu không thành công");
                //throw;
            }
        }

        private void bar_cancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

       
    }
}