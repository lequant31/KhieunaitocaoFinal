using DevExpress.XtraEditors;
using System;
using System.Linq;
using System.Windows.Forms;

namespace khieunaitocao
{
    public partial class ctlthongtintocao : DevExpress.XtraEditors.XtraUserControl
    {
        public ctlthongtintocao()
        {
            InitializeComponent();
        }

        private khieunaitocaoContextDataContext _khieunaitocaoContext;
        private int year = DateTime.Now.Year;

        private void tocao_load()
        {
            using (_khieunaitocaoContext = new khieunaitocaoContextDataContext())
            {
                if (dinhdanh.tenquyenhan == "Staff")
                {
                    var list = _khieunaitocaoContext.ListThongTinToCao(dinhdanh.madonvi, dinhdanh.ma_canbo, dinhdanh.ma_canbo).ToList();
                    grd_thongtintocao.DataSource = list;
                }
                if (dinhdanh.tenquyenhan == "Boss")
                {
                    var list = _khieunaitocaoContext.ListThongTinToCaoBoss(dinhdanh.madonvi).ToList();
                    grd_thongtintocao.DataSource = list;
                }
            }
        }

        private void bar_them_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            form_thongtintocao f = new form_thongtintocao();
            f.ShowDialog();
        }

        private void ctlthongtintocao_Load(object sender, EventArgs e)
        {
            tocao_load();
        }

        private void bar_lammoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tocao_load();
        }

        private void bar_xoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            #region check permission

            var indexs = grv_thongtintocao.GetSelectedRows();
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
            int i = (int)grv_thongtintocao.GetFocusedRowCellValue("id_thongtintocao");
            string madongthu = grv_thongtintocao.GetFocusedRowCellValue("ma_donthu_tocao").ToString();

            if (madongthu.Substring(0, 4) != dinhdanh.kyhieu_donvi)
            {
                XtraMessageBox.Show("Không được quyền xóa");
                return;
            }

            #endregion check permission

            try
            {
                int a = (int)grv_thongtintocao.GetFocusedRowCellValue("id_thongtintocao");
                using (_khieunaitocaoContext = new khieunaitocaoContextDataContext())
                {
                    if (XtraMessageBox.Show("Bạn có muốn xóa thông tin?", "Confirmation", MessageBoxButtons.YesNo) !=
                     DialogResult.Yes)
                        return;
                    _khieunaitocaoContext.XoaThongTinTocao(a, dinhdanh.madonvi);

                    grv_thongtintocao.DeleteSelectedRows();
                    XtraMessageBox.Show("Xóa thông tin thành công");
                }
            }
            catch (Exception)
            {
                XtraMessageBox.Show("Xóa thông tin thất bại");
            }
        }

        private void bar_sua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                int i = (int)grv_thongtintocao.GetFocusedRowCellValue("id_thongtintocao");

                form_thongtintocao f = new form_thongtintocao
                {
                    bool_sua = true,

                    id_thongtintocao = i
                };
                f.ShowDialog();
            }
            catch (Exception)
            {
                XtraMessageBox.Show("Vui lòng chọn đơn tố cáo cần sửa");
            }
        }

        private void grv_thongtintocao_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                int i = (int)grv_thongtintocao.GetFocusedRowCellValue("id_thongtintocao");

                form_thongtintocao f = new form_thongtintocao
                {
                    bool_sua = true,

                    id_thongtintocao = i
                };
                f.ShowDialog();
            }
            catch (Exception)
            {
                XtraMessageBox.Show("Vui lòng chọn đơn tố cáo cần sửa");
            }
        }

        private void bar_year_EditValueChanged(object sender, EventArgs e)
        {
            //year = Convert.ToInt32(bar_year.EditValue);
            //tocao_load();
        }

        private void btn_chuyendon_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                int a1 = (int)grv_thongtintocao.GetFocusedRowCellValue("id_thongtintocao");
                int a2 = (int)grv_thongtintocao.GetFocusedRowCellValue("donvinhan");
                string a = grv_thongtintocao.GetFocusedRowCellValue("xulydon").ToString();
                string b = grv_thongtintocao.GetFocusedRowCellValue("forward").ToString();
                string c = grv_thongtintocao.GetFocusedRowCellValue("ma_donthu_tocao").ToString().Substring(0, 4);
                bool d = (bool)grv_thongtintocao.GetFocusedRowCellValue("ketthucdon");
                if (a == "Chuyển đơn vị khác" & b == "Chưa chuyển" & c == dinhdanh.kyhieu_donvi & a2 != 0 & d == false)
                {
                    using (_khieunaitocaoContext = new khieunaitocaoContextDataContext())
                    {
                        _khieunaitocaoContext.ChuyenThongTinToCao(a1, dinhdanh.madonvi, a2, "Sub");
                    }
                    XtraMessageBox.Show("Chuyển đơn tố cáo thành công.");
                    tocao_load();
                }
                else
                {
                    XtraMessageBox.Show("Đơn tố cáo không thể chuyển cho đơn vị khác.");
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Thông báo lỗi", ex.Message);
            }
        }
    }
}