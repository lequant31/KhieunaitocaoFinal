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
    public partial class ctlquatrinhgiaiquyettocao : DevExpress.XtraEditors.XtraUserControl
    {
        public ctlquatrinhgiaiquyettocao()
        {
            InitializeComponent();
        }
        khieunaitocaoContextDataContext _khieunaitocaoContext;
        private int year = DateTime.Now.Year;
        public void funload()
        {
            using (_khieunaitocaoContext = new khieunaitocaoContextDataContext())
            {
                var _list = _khieunaitocaoContext.list_quatrinhgiaiquyettocao(dinhdanh.madonvi, year).ToList();
                grd_quatrinhgiaiquyet_tocao.DataSource = _list;
            }
        }
        private void bar_them_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            form_quatrinhgiaiquyettocao f = new form_quatrinhgiaiquyettocao();
            f.ShowDialog();
        }

        private void bar_sua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            form_quatrinhgiaiquyettocao f = new form_quatrinhgiaiquyettocao
            {
                bool_sua = true
            };
            try
            {
                int i = (int)grv_quatrinhgiaiquyet_tocao.GetFocusedRowCellValue("id_quatrinhgiaiquyettocao");
                int y = (int)grv_quatrinhgiaiquyet_tocao.GetFocusedRowCellValue("id_thongtintocao");
                f.id_quatrinhgiaiquyettocao = i;
                f._id_thongtintocao = y;
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
            string _ketthucgiaiquyet = grv_quatrinhgiaiquyet_tocao.GetFocusedRowCellValue("ketthucgiaiquyet").ToString();
            if (_ketthucgiaiquyet == "Lock")
            {
                XtraMessageBox.Show("Đã kết thúc giải quyết không được phép xóa");
                return;
            }
            #endregion
            try
            {
                int i = (int)grv_quatrinhgiaiquyet_tocao.GetFocusedRowCellValue("id_quatrinhgiaiquyettocao");
                using (_khieunaitocaoContext = new khieunaitocaoContextDataContext())
                {
                    _khieunaitocaoContext.xoa_quatrinhgiaiquyettocao(i);
                }
                XtraMessageBox.Show("Xóa thông tin thành công");

            }
            catch (Exception)
            {
                XtraMessageBox.Show("Vui lòng chọn thông tin cần xóa");
            }
        }

        private void grv_quatrinhgiaiquyet_tocao_DoubleClick(object sender, EventArgs e)
        {
            form_quatrinhgiaiquyettocao f = new form_quatrinhgiaiquyettocao
            {
                bool_sua = true
            };
            try
            {
                int i = (int)grv_quatrinhgiaiquyet_tocao.GetFocusedRowCellValue("id_quatrinhgiaiquyettocao");
                int y = (int)grv_quatrinhgiaiquyet_tocao.GetFocusedRowCellValue("id_thongtintocao");
                f.id_quatrinhgiaiquyettocao = i;
                f._id_thongtintocao = y;
                f.ShowDialog();
            }
            catch (Exception)
            {
                XtraMessageBox.Show("Vui lòng chọn đơn thư cần sửa");
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

        private void bar_chuyendontocao_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            #region check dieukien
            if (dinhdanh.quyenhan == 2)
            {
                XtraMessageBox.Show("Không có quyền hạn");
                return;
            }
            #endregion
            int i = (int)grv_quatrinhgiaiquyet_tocao.GetFocusedRowCellValue("id_thongtintocao");
            int y = (int)grv_quatrinhgiaiquyet_tocao.GetFocusedRowCellValue("id_quatrinhgiaiquyettocao");
            try
            {
                using (_khieunaitocaoContext = new khieunaitocaoContextDataContext())
                {
                    var _chuyen = _khieunaitocaoContext.check_chuyentocao(y).SingleOrDefault();
                    #region check da chuyen
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
                    var _sua = _khieunaitocaoContext.xem_thongtin_quatrinhgiaiquyettocao(y).SingleOrDefault();
                    _khieunaitocaoContext.chuyendonthutocao_temp(i, (int?)_sua.donvinhan, dinhdanh.madonvi, y);
                    _khieunaitocaoContext.update_trangthaichuyentocao(y, "Delivered");
                    XtraMessageBox.Show("Chuyển thông tin thành công");
                }
            }
            catch (Exception)
            {
                XtraMessageBox.Show("Chuyển thông tin không thành công");
            }
            funload();
        }

        private void bar_year_EditValueChanged(object sender, EventArgs e)
        {
            year = Convert.ToInt32(bar_year.EditValue);
            funload();
        }
    }
}
