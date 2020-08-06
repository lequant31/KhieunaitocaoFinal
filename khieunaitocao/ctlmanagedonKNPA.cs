using DevExpress.XtraEditors;
using System;
using System.Linq;
using System.Windows.Forms;

namespace khieunaitocao
{
    public partial class ctlmanagedonKNPA : DevExpress.XtraEditors.XtraUserControl
    {
        //quanlythongtin ql = new quanlythongtin();
        public ctlmanagedonKNPA()
        {
            InitializeComponent();
        }

        private int year = DateTime.Now.Year;
        private khieunaitocaoContextDataContext _khieunaitocaoContext;

        private void donthu_load()
        {
            using (_khieunaitocaoContext = new khieunaitocaoContextDataContext())
            {
                if (dinhdanh.tenquyenhan == "Staff")
                {
                    var list = _khieunaitocaoContext.ListThongTinKNPA(dinhdanh.madonvi, dinhdanh.ma_canbo, dinhdanh.ma_canbo).ToList();
                    grc_quanlydonthukhieunai.DataSource = list;
                }
                if (dinhdanh.tenquyenhan == "Boss")
                {
                    var list = _khieunaitocaoContext.ListThongTinKNPABoss(dinhdanh.madonvi).ToList();
                    grc_quanlydonthukhieunai.DataSource = list;
                }
            }
        }

        private void bar_them_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            form_thongtinkiennghiphananh f = new form_thongtinkiennghiphananh();
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
                int i = (int)grv_quanlydonthukhieunai.GetFocusedRowCellValue("id_thongtinKNPA");

                form_thongtinkiennghiphananh f = new form_thongtinkiennghiphananh
                {
                    bool_sua = true,

                    id_thongtinKNPA = i
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
            form_thongtinkiennghiphananh f = new form_thongtinkiennghiphananh
            {
                bool_sua = true
            };
            try
            {
                int i = (int)grv_quanlydonthukhieunai.GetFocusedRowCellValue("id_thongtinKNPA");
                f.id_thongtinKNPA = i;
                f.ShowDialog();
            }
            catch (Exception)
            {
                //throw;
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

            if (dinhdanh.quyenhan == 2)
            {
                XtraMessageBox.Show("Tài khoản chỉ có quyền xem.\n Không được phép xóa");
                return;
            }
            int i = (int)grv_quanlydonthukhieunai.GetFocusedRowCellValue("id_thongtinKNPA");
            string madongthu = grv_quanlydonthukhieunai.GetFocusedRowCellValue("ma_donthu_KNPA").ToString();

            if (madongthu.Substring(0, 4) != dinhdanh.kyhieu_donvi)
            {
                XtraMessageBox.Show("Không được quyền xóa");
                return;
            }

            #endregion check permission

            try
            {
                int a = (int)grv_quanlydonthukhieunai.GetFocusedRowCellValue("id_thongtinKNPA");
                using (_khieunaitocaoContext = new khieunaitocaoContextDataContext())
                {
                    if (XtraMessageBox.Show("Bạn có muốn xóa thông tin?", "Confirmation", MessageBoxButtons.YesNo) !=
                     DialogResult.Yes)
                        return;
                    _khieunaitocaoContext.XoaThongTinKNPA(a, dinhdanh.madonvi);

                    grv_quanlydonthukhieunai.DeleteSelectedRows();
                    XtraMessageBox.Show("Xóa thông tin thành công");
                }
            }
            catch (Exception)
            {
                XtraMessageBox.Show("Xóa thông tin thất bại");
            }
        }

        private void grv_quanlydonthukhieunai_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            grv_quanlydonthukhieunai.IndicatorWidth = 40;
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void bar_year_EditValueChanged(object sender, EventArgs e)
        {
            //year = Convert.ToInt32(bar_year.EditValue);
            //donthu_load();
        }

        private void btn_chuyendon_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                int a1 = (int)grv_quanlydonthukhieunai.GetFocusedRowCellValue("id_thongtinKNPA");
                int a2 = (int)grv_quanlydonthukhieunai.GetFocusedRowCellValue("donvinhan");
                string a = grv_quanlydonthukhieunai.GetFocusedRowCellValue("hinhthuc_xuly").ToString();
                string b = grv_quanlydonthukhieunai.GetFocusedRowCellValue("forward").ToString();
                string c = grv_quanlydonthukhieunai.GetFocusedRowCellValue("ma_donthu_KNPA").ToString().Substring(0, 4);
                bool d = (bool)grv_quanlydonthukhieunai.GetFocusedRowCellValue("ketthucdonthu");
                if (a == "Chuyển đơn vị khác" & b == "Chưa chuyển" & c == dinhdanh.kyhieu_donvi & a2 != 0 & d == false)
                {
                    using (_khieunaitocaoContext = new khieunaitocaoContextDataContext())
                    {
                        _khieunaitocaoContext.ChuyenThongTinKNPA(a1, dinhdanh.madonvi, a2, "Sub");
                    }
                    XtraMessageBox.Show("Chuyển đơn thư thành công.");
                    donthu_load();
                }
                else
                {
                    XtraMessageBox.Show("Đơn thư không thể chuyển cho đơn vị khác.");
                }
                
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Thông báo lỗi", ex.Message);
            }
        }
    }
}