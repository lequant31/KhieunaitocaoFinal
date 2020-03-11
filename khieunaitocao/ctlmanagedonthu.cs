using DevExpress.XtraEditors;
using System;
using System.Linq;
using System.Windows.Forms;

namespace khieunaitocao
{
    public partial class ctlmanagedonthu : DevExpress.XtraEditors.XtraUserControl
    {
        //quanlythongtin ql = new quanlythongtin();
        public ctlmanagedonthu()
        {
            InitializeComponent();
        }

        private int year = DateTime.Now.Year;
        private khieunaitocaoContextDataContext _khieunaitocaoContext;

        private void donthu_load()
        {
            using (_khieunaitocaoContext = new khieunaitocaoContextDataContext())
            {
                var listtest = _khieunaitocaoContext.listtbthongtinkhieunai(dinhdanh.madonvi, year).ToList();

                grc_quanlydonthukhieunai.DataSource = listtest;
            }
        }

        private void bar_them_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            thongtindonthucanhan f = new thongtindonthucanhan();
            f.ShowDialog();
        }

        private void ctlmanagedonthu_Load(object sender, EventArgs e)
        {
            try
            {
                donthu_load();
            }
            catch (Exception)
            {
                // XtraMessageBox.Show("Có lỗi xảy ra");
                throw;
            }
        }

        private void bar_btn_sua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                int i = (int)grv_quanlydonthukhieunai.GetFocusedRowCellValue("id_thongtinhieunai");

                #region check edit

                using (_khieunaitocaoContext = new khieunaitocaoContextDataContext())
                {
                    var _edit = _khieunaitocaoContext.check_xoadonthu(i).ToList();
                    if (_edit.Count() != 0)
                    {
                        XtraMessageBox.Show("Không được sửa nội dung đơn thư này");
                    }
                }

                #endregion check edit

                thongtindonthucanhan f = new thongtindonthucanhan
                {
                    bool_sua = true,

                    id_thongtinKN = i
                };
                f.ShowDialog();
            }
            catch (Exception)
            {
                XtraMessageBox.Show("Vui lòng chọn đơn thư cần sửa");
            }
        }

        private void grv_quanlydonthukhieunai_DoubleClick(object sender, EventArgs e)
        {
            thongtindonthucanhan f = new thongtindonthucanhan
            {
                bool_sua = true
            };
            try
            {
                int i = (int)grv_quanlydonthukhieunai.GetFocusedRowCellValue("id_thongtinhieunai");
                f.id_thongtinKN = i;
                f.ShowDialog();
            }
            catch (Exception)
            {
                XtraMessageBox.Show("Vui lòng chọn đơn thư cần sửa");
            }
        }

        private void bar_btn_refresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            donthu_load();
        }

        private void bar_xoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            #region check permission

            if (dinhdanh.quyenhan == 2)
            {
                XtraMessageBox.Show("Tài khoản chỉ có quyền xem.\n Không được phép xóa");
                return;
            }
            int i = (int)grv_quanlydonthukhieunai.GetFocusedRowCellValue("id_thongtinhieunai");
            string madongthu= grv_quanlydonthukhieunai.GetFocusedRowCellValue("ma_donthu_khieunai").ToString();
            using (_khieunaitocaoContext = new khieunaitocaoContextDataContext())
            {
                var _edit = _khieunaitocaoContext.check_xoadonthu(i).ToList();
                if (_edit.Count() != 0)
                {
                    XtraMessageBox.Show("Không được xóa đơn thư này");
                    return;
                }
            }
            if (madongthu.Substring(0, 4) != dinhdanh.kyhieu_donvi)
            {
                XtraMessageBox.Show("Không được quyền xóa");
                return;
            }
            #endregion check permission

            try
            {
                var indexs = grv_quanlydonthukhieunai.GetSelectedRows();
                if (indexs[0] < 0)
                {
                    MessageBox.Show("Đây là thanh tìm kiếm. Không thể xóa được");
                    return;
                }
                if (indexs.Length < 0)
                {
                    MessageBox.Show("Vui lòng chọn thông tin cần xóa");
                    return;
                }
                int a = (int)grv_quanlydonthukhieunai.GetFocusedRowCellValue("id_thongtinhieunai");
                using (_khieunaitocaoContext = new khieunaitocaoContextDataContext())
                {
                    var del = _khieunaitocaoContext.tb_thongtinkhieunais.Single(p => p.id_thongtinhieunai == a);
                    if (MessageBox.Show("Bạn có muốn xóa thông tin?", "Confirmation", MessageBoxButtons.YesNo) !=
                     DialogResult.Yes)
                        return;
                    _khieunaitocaoContext.tb_thongtinkhieunais.DeleteOnSubmit(del);
                    _khieunaitocaoContext.SubmitChanges();
                    grv_quanlydonthukhieunai.DeleteSelectedRows();
                    MessageBox.Show("Xóa thông tin thành công");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Xóa thông tin thất bại");
                //throw;
            }
        }

        private void bar_quatrinhgiaiquyet_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            thongtindonthucanhan f = new thongtindonthucanhan();
            try
            {
                int i = (int)grv_quanlydonthukhieunai.GetFocusedRowCellValue("id_thongtinhieunai");
                f.bool_chuyen = true;
                f.id_thongtinKN = i;
                f.ShowDialog();
            }
            catch (Exception)
            {
                throw;
                //XtraMessageBox.Show("Vui lòng chọn đơn thư cần chuyển");
            }
        }

        private void grv_quanlydonthukhieunai_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void bar_year_EditValueChanged(object sender, EventArgs e)
        {
            year = Convert.ToInt32(bar_year.EditValue);
            donthu_load();
        }
    }
}