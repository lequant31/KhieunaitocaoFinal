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
using DevExpress.XtraBars;

namespace khieunaitocao
{
    public partial class ctl_quanlycanbo : DevExpress.XtraEditors.XtraUserControl
    {
        khieunaitocaoContextDataContext _khieunaitocaoContext;
        public ctl_quanlycanbo()
        {
            InitializeComponent();
        }
        private void fun_reload()
        {
            _khieunaitocaoContext = new khieunaitocaoContextDataContext();
            //
            if (dinhdanh.quyenhan == 0)
            {
                var thongtin = _khieunaitocaoContext.xemcanbo().ToList();
                grd_thongtincanbo.DataSource = thongtin;
            }
            else
            {
                var thongtin = _khieunaitocaoContext.list_thongtincanbo_linq(dinhdanh.madonvi).ToList();
                grd_thongtincanbo.DataSource = thongtin;
            }

        }

        private void bar_reload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            fun_reload();
        }

        private void ctl_quanlycanbo_Load(object sender, EventArgs e)
        {
            if (dinhdanh.quyenhan !=0)
            {
                bar_suacanbo.Visibility = BarItemVisibility.Never;
                bar_themcanbo.Visibility = BarItemVisibility.Never;
                bar_xoacanbo.Visibility = BarItemVisibility.Never;
            }
            fun_reload();
        }
        private void bar_suacanbo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           
            form_quanlycanbo f = new form_quanlycanbo();
            f.bool_sua = true;
            try
            {
                int i = (int)grv_thongtincanbo.GetFocusedRowCellValue("ma_canbo");
                f._macanbo = i;
                f.ShowDialog();                
            }
            catch (Exception)
            {
                XtraMessageBox.Show("Vui lòng chọn thông tin cần sửa");
            }
           
        }
        private void bar_xoacanbo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                _khieunaitocaoContext = new khieunaitocaoContextDataContext();
                int i =(int)grv_thongtincanbo.GetFocusedRowCellValue("ma_canbo");
                _khieunaitocaoContext.xoacanbo(i);
                fun_reload();
                XtraMessageBox.Show("Xóa thông tin thành công");
            }
            catch (Exception)
            {
                XtraMessageBox.Show("Vui lòng chọn thông tin cần xóa");
            }
        }
        private void grv_thongtincanbo_DoubleClick(object sender, EventArgs e)
        {
            #region checkquyen
            if (dinhdanh.quyenhan !=0)
            {
                return;
            }
            #endregion
            form_quanlycanbo f = new form_quanlycanbo();
            f.bool_sua = true;
            try
            {
                int i = (int)grv_thongtincanbo.GetFocusedRowCellValue("ma_canbo");
                f._macanbo = i;
                f.ShowDialog();
            }
            catch (Exception)
            {
                XtraMessageBox.Show("Vui lòng chọn thông tin cần sửa");
            }
        }
        private void bar_themcanbo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            form_quanlycanbo f = new form_quanlycanbo();
            f.ShowDialog();
        }
    }
}
