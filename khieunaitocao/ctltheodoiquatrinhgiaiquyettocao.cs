using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace khieunaitocao
{
    public partial class ctltheodoiquatrinhgiaiquyettocao : DevExpress.XtraEditors.XtraUserControl
    {
        public ctltheodoiquatrinhgiaiquyettocao()
        {
            InitializeComponent();
        }
        khieunaitocaoContextDataContext _khieunaitocaoContext;
        private int year = DateTime.Now.Year;
        public void funload()
        {
            using (_khieunaitocaoContext = new khieunaitocaoContextDataContext())
            {
                var _list = _khieunaitocaoContext.List_theodoi_giaiquyettocao(dinhdanh.madonvi,dinhdanh.kyhieu_donvi +"%").ToList();
                grd_quatrinhgiaiquyet_tocao.DataSource = _list;
            }
        }
        private void bar_them_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var str = grv_quatrinhgiaiquyet_tocao.GetFocusedRowCellValue("id_quatrinhgiaiquyettocao");
            #region check Null
            if (str == null)
            {
                XtraMessageBox.Show("Quá trình giải quyết chưa được khởi tạo");
                return;
            }
            #endregion
            try
            {
                form_theodoiquatrinhgiaiquyettocao f = new form_theodoiquatrinhgiaiquyettocao();

                int i = Convert.ToInt32(str);
                f.id_quatrinhgiaiquyettocao = i;
                f.ShowDialog();
            }
            catch (Exception)
            {
                XtraMessageBox.Show("Vui lòng chọn quá trình giải quyết cần xem.");
            }
        }

        private void grv_quatrinhgiaiquyet_tocao_DoubleClick(object sender, EventArgs e)
        {

            var str = grv_quatrinhgiaiquyet_tocao.GetFocusedRowCellValue("id_quatrinhgiaiquyettocao");
            #region check Null
            if (str == null)
            {
                XtraMessageBox.Show("Quá trình giải quyết chưa được khởi tạo");
                return;
            }
            #endregion
            try
            {
                form_theodoiquatrinhgiaiquyettocao f = new form_theodoiquatrinhgiaiquyettocao();

                int i = Convert.ToInt32(str);
                f.id_quatrinhgiaiquyettocao = i;
                f.ShowDialog();
            }
            catch (Exception)
            {
                XtraMessageBox.Show("Vui lòng chọn quá trình giải quyết cần xem.");
            }
        }

        private void ctlquatrinhgiaiquyettocao_Load(object sender, EventArgs e)
        {
            funload();
        }

        private void bar_lammoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            funload();
        }

        private void grv_quatrinhgiaiquyet_tocao_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                string priority = grv_quatrinhgiaiquyet_tocao.GetRowCellDisplayText(e.RowHandle, grv_quatrinhgiaiquyet_tocao.Columns["statuss"]);
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
