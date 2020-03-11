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
                var _list = _khieunaitocaoContext.list_thongtintocao_linq(dinhdanh.madonvi, year).ToList();

                grd_thongtintocao.DataSource = _list;
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
            int a = (int)grv_thongtintocao.GetFocusedRowCellValue("id_thongtintocao1");
            string matocao = grv_thongtintocao.GetFocusedRowCellValue("ma_donthu_tocao").ToString();
            #region check permission

            if (dinhdanh.quyenhan == 2)
            {
                XtraMessageBox.Show("Tài khoản chỉ có quyền xem.\n Không được phép xóa");
                return;
            }
            using (_khieunaitocaoContext = new khieunaitocaoContextDataContext())
            {
                var _edit = _khieunaitocaoContext.check_xoatocao(a).ToList();
                if (_edit.Count() != 0)
                {
                    XtraMessageBox.Show("Không được xóa đơn thư này");
                    return;
                }
            }
            if (matocao.Substring(0, 4) != dinhdanh.kyhieu_donvi)
            {
                XtraMessageBox.Show("Không được quyền xóa");
                return;
            }
            #endregion check permission

            var indexs = grv_thongtintocao.GetSelectedRows();
            if (indexs.Length < 0)
            {
                MessageBox.Show("Vui lòng chọn thông tin cần xóa");
                return;
            }
            try
            {
                using (_khieunaitocaoContext = new khieunaitocaoContextDataContext())
                {
                    var del = _khieunaitocaoContext.tb_thongtintocaos.Single(p => p.id_thongtintocao1 == a);
                    if (MessageBox.Show("Bạn có muốn xóa thông tin?", "Confirmation", MessageBoxButtons.YesNo) !=
                     DialogResult.Yes)
                        return;
                    _khieunaitocaoContext.tb_thongtintocaos.DeleteOnSubmit(del);
                    _khieunaitocaoContext.SubmitChanges();
                    grv_thongtintocao.DeleteSelectedRows();
                    MessageBox.Show("Xóa thông tin thành công");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Xóa thông tin thất bại");
                //throw;
            }
        }

        private void bar_sua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            form_thongtintocao f = new form_thongtintocao
            {
                bool_sua = true
            };
            try
            {
                var y = grv_thongtintocao.GetFocusedRowCellValue("id_thongtintocao1");
                int i = (int)grv_thongtintocao.GetFocusedRowCellValue("id_thongtintocao1");
                f.id_thongtintocao = i;
                f.ShowDialog();
            }
            catch (Exception)
            {
                XtraMessageBox.Show("Vui lòng chọn đơn thư cần sửa");
            }
        }

        private void grv_thongtintocao_DoubleClick(object sender, EventArgs e)
        {
            form_thongtintocao f = new form_thongtintocao
            {
                bool_sua = true
            };
            try
            {
                int i = (int)grv_thongtintocao.GetFocusedRowCellValue("id_thongtintocao1");
                f.id_thongtintocao = i;
                f.ShowDialog();
            }
            catch (Exception)
            {
                XtraMessageBox.Show("Vui lòng chọn đơn thư cần sửa");
            }
        }

        private void bar_year_EditValueChanged(object sender, EventArgs e)
        {
            year = Convert.ToInt32(bar_year.EditValue);
            tocao_load();
        }
    }
}