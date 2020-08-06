using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using System;
using System.Linq;
using System.Windows.Forms;

namespace khieunaitocao
{
    public partial class ctlPhanTichThongKeKNPA : UserControl
    {
        public ctlPhanTichThongKeKNPA()
        {
            InitializeComponent();
        }
        khieunaitocaoContextDataContext khieunaitocaoContextDataContext;
        private void ctlPhanTichThongKeKhieuNai_Load(object sender, EventArgs e)
        {
            if(dinhdanh.kyhieu_donvi == "PX05")
            {
                btn_LoadAll.Visibility = BarItemVisibility.Always;
            }

        }
        private void loaddata()
        {
            #region check đầu vào
            if (date_tungay.EditValue == null)
            {
                XtraMessageBox.Show("Chưa nhập dữ liệu");
                date_tungay.Focus();
            }
            if (date_denngay.EditValue == null)
            {
                XtraMessageBox.Show("Chưa nhập dữ liệu");
                date_denngay.Focus();
            }
            #endregion
            using (khieunaitocaoContextDataContext = new khieunaitocaoContextDataContext())
            {

                var _list = khieunaitocaoContextDataContext.PhanTichThongKeKNPA(dinhdanh.madonvi, (DateTime)date_tungay.EditValue, (DateTime)date_denngay.EditValue).ToList();
                grc_thongke.DataSource = _list;
            }
        }

        private void btn_Refresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            loaddata();
        }

        private void PrinterPreview_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btn_LoadAll_ItemClick(object sender, ItemClickEventArgs e)
        {
            #region check đầu vào
            if (date_tungay.EditValue == null)
            {
                XtraMessageBox.Show("Chưa nhập dữ liệu");
                date_tungay.Focus();
            }
            if (date_denngay.EditValue == null)
            {
                XtraMessageBox.Show("Chưa nhập dữ liệu");
                date_denngay.Focus();
            }
            #endregion
            using (khieunaitocaoContextDataContext = new khieunaitocaoContextDataContext())
            {

                var _list = khieunaitocaoContextDataContext.PhanTichThongKeKNPAPX05((DateTime)date_tungay.EditValue, (DateTime)date_denngay.EditValue).ToList();
                grc_thongke.DataSource = _list;
            }
        }
    }
}
