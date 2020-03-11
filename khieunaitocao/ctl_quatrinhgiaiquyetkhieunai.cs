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
    public partial class ctl_quatrinhgiaiquyetkhieunai : DevExpress.XtraEditors.XtraUserControl
    {
        public ctl_quatrinhgiaiquyetkhieunai()
        {
            InitializeComponent();
        }
        khieunaitocaoContextDataContext _khieunaitocaoContext;
        private int year = DateTime.Now.Year;
        public void funload()
        {
            using (_khieunaitocaoContext = new khieunaitocaoContextDataContext())
            {
                var _list = _khieunaitocaoContext.list_quatrinhgiaiquyet(dinhdanh.madonvi, year).ToList();
                grc_quatrinhgiaiquyet.DataSource = _list;
            }
        }
        private void bar_them_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            form_quatrinhgiaiquyetkhieunai f = new form_quatrinhgiaiquyetkhieunai();
            f.ShowDialog();
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
            form_quatrinhgiaiquyetkhieunai f = new form_quatrinhgiaiquyetkhieunai
            {
                bool_sua = true
            };
            try
            {
                int i = (int)grv_quatrinhgiaiquyet.GetFocusedRowCellValue("id_quatrinhgiaiquyetkhieunai");
                int y = (int)grv_quatrinhgiaiquyet.GetFocusedRowCellValue("id_thongtinkhieunai");
                f.id_quatrinhgiaiquyetkhieunai = i;
                f._id_thongtinkhieunai = y;
                f.ShowDialog();
            }
            catch (Exception)
            {
                XtraMessageBox.Show("Vui lòng chọn đơn thư cần sửa");
            }
        }

        private void grv_quatrinhgiaiquyet_DoubleClick(object sender, EventArgs e)
        {
            form_quatrinhgiaiquyetkhieunai f = new form_quatrinhgiaiquyetkhieunai
            {
                bool_sua = true
            };
            try
            {
                int i = (int)grv_quatrinhgiaiquyet.GetFocusedRowCellValue("id_quatrinhgiaiquyetkhieunai");
                int y = (int)grv_quatrinhgiaiquyet.GetFocusedRowCellValue("id_thongtinkhieunai");
                f.id_quatrinhgiaiquyetkhieunai = i;
                f._id_thongtinkhieunai = y;
                f.ShowDialog();
            }
            catch (Exception)
            {
                XtraMessageBox.Show("Vui lòng chọn đơn thư cần sửa");
            }
        }

        private void bar_xoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            #region check dieukien
            if (dinhdanh.quyenhan == 2)
            {
                XtraMessageBox.Show("Không có quyền xóa");
                return;
            }
            string _ketthucgiaiquyet = grv_quatrinhgiaiquyet.GetFocusedRowCellValue("statuss").ToString();
            if (_ketthucgiaiquyet == "Finish")
            {
                XtraMessageBox.Show("Đã kết thúc giải quyết không được phép xóa");
                return;
            }
            #endregion
            try
            {
                int i = (int)grv_quatrinhgiaiquyet.GetFocusedRowCellValue("id_quatrinhgiaiquyetkhieunai");
                using (_khieunaitocaoContext = new khieunaitocaoContextDataContext())
                {
                    _khieunaitocaoContext.xoa_quatrinhgiaiquyet(i);
                }
                XtraMessageBox.Show("Xóa thông tin thành công");
                
            }
            catch (Exception)
            {
                XtraMessageBox.Show("Vui lòng chọn thông tin cần xóa");
            }
        }

        private void bar_chuyendonvikhac_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int i = (int)grv_quatrinhgiaiquyet.GetFocusedRowCellValue("id_thongtinkhieunai");
            int y = (int)grv_quatrinhgiaiquyet.GetFocusedRowCellValue("id_quatrinhgiaiquyetkhieunai");
          
            try
            {
                using (_khieunaitocaoContext = new khieunaitocaoContextDataContext())
                {

                    var _chuyen = _khieunaitocaoContext.check_chuyendonthu(y).SingleOrDefault() ;
                    #region check dieukien
                    if (dinhdanh.quyenhan == 2)
                    {
                        XtraMessageBox.Show("Không có quyền hạn");
                        return;
                    }
                    if (_chuyen.forward.Trim() == "Delivered")
                    {
                        XtraMessageBox.Show("Đơn thư đã được chuyển đi");
                        return;
                    }
                    if (_chuyen.hinhthuc_xuly != "Chuyển đơn vị khác")
                    {
                        XtraMessageBox.Show("Chưa chọn đơn vị nhận");
                        return;
                    }
                    #endregion

                    var _sua = _khieunaitocaoContext.xem_thongtin_quatrinhgiaiquyet_linq(y).SingleOrDefault();
                    _khieunaitocaoContext.chuyendonthukhieunai_temp(i, (int?)_sua.donvinhan, dinhdanh.madonvi, y);
                    _khieunaitocaoContext.update_trangthaichuyedonthu(y, "Delivered");
                    XtraMessageBox.Show("Chuyển thông tin thành công");
                }
            }
            catch (Exception)
            {
                XtraMessageBox.Show("Chuyển thông tin không thành công");
                //throw;
            }
            funload();
        }

        private void grv_quatrinhgiaiquyet_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            if(e.RowHandle >= 0)
            {
                string priority = grv_quatrinhgiaiquyet.GetRowCellDisplayText(e.RowHandle, grv_quatrinhgiaiquyet.Columns["statuss"]);
                if(priority=="Finish")
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
