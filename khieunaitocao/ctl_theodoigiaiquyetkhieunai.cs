using DevExpress.XtraEditors;
using System;
using System.Drawing;
using System.Linq;

namespace khieunaitocao
{
    public partial class ctl_theodoigiaiquyetkhieunai : DevExpress.XtraEditors.XtraUserControl
    {
        public ctl_theodoigiaiquyetkhieunai()
        {
            InitializeComponent();
        }

        private khieunaitocaoContextDataContext _khieunaitocaoContext;
        private int year = DateTime.Now.Year;

        public void funload()
        {
            using (_khieunaitocaoContext = new khieunaitocaoContextDataContext())
            {
                var _list = _khieunaitocaoContext.List_theodoi_giaiquyetkhieunai(dinhdanh.madonvi, dinhdanh.kyhieu_donvi + "%").ToList();
                grc_quatrinhgiaiquyet.DataSource = _list;
            }
        }

        private void ctl_quatrinhgiaiquyetkhieunai_Load(object sender, EventArgs e)
        {
            funload();
        }

        private void bar_lammoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            funload();
        }

        private void bar_sua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var str = grv_quatrinhgiaiquyet.GetFocusedRowCellValue("id_quatrinhgiaiquyetkhieunai");
            #region check Null
            if (str==null)
            {
                XtraMessageBox.Show("Quá trình giải quyết chưa được khởi tạo");
                return;
            }
            #endregion
            try
            {
                form_theodoiquatrinhgiaiquyetkhieunai f = new form_theodoiquatrinhgiaiquyetkhieunai();

                int i = Convert.ToInt32(str);
                f.id_quatrinhgiaiquyetkhieunai = i;
                f.ShowDialog();
            }
            catch (Exception)
            {
                XtraMessageBox.Show("Vui lòng chọn quá trình giải quyết cần xem.");
            }
        }

        private void grv_quatrinhgiaiquyet_DoubleClick(object sender, EventArgs e)
        {
            var str = grv_quatrinhgiaiquyet.GetFocusedRowCellValue("id_quatrinhgiaiquyetkhieunai");
            #region check Null
            if (str == null)
            {
                XtraMessageBox.Show("Quá trình giải quyết chưa được khởi tạo");
                return;
            }
            #endregion
            try
            {
                form_theodoiquatrinhgiaiquyetkhieunai f = new form_theodoiquatrinhgiaiquyetkhieunai();

                int i = Convert.ToInt32(str);
                f.id_quatrinhgiaiquyetkhieunai = i;
                f.ShowDialog();
            }
            catch (Exception)
            {
                XtraMessageBox.Show("Vui lòng chọn quá trình giải quyết cần xem.");
            }
        }

        private void grv_quatrinhgiaiquyet_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                string priority = grv_quatrinhgiaiquyet.GetRowCellDisplayText(e.RowHandle, grv_quatrinhgiaiquyet.Columns["statuss"]);
                if (priority == "Finish")
                {
                    e.Appearance.BackColor = Color.Green;
                    //e.Appearance.BackColor2 = Color.White;
                }
                if (priority == "Out of date")
                {
                    e.Appearance.BackColor = Color.Red;
                    //e.Appearance.BackColor2 = Color.White;
                }
                if (priority == "Processing")
                {
                    e.Appearance.BackColor = Color.Yellow;
                    //e.Appearance.BackColor2 = Color.White;
                }
                if (priority == "No process")
                {
                    e.Appearance.BackColor = Color.White;
                    //e.Appearance.BackColor2 = Color.White;
                }
            }
        }

        private void bar_year_EditValueChanged(object sender, EventArgs e)
        {
            year = Convert.ToInt32(bar_year.EditValue);
            funload();
        }
    }
}