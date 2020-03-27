using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace khieunaitocao
{
    public partial class form_thongtintocao : DevExpress.XtraEditors.XtraForm
    {
        public form_thongtintocao()
        {
            InitializeComponent();
        }
        public bool bool_sua = false;
        public int id_thongtintocao;        
        public string ngaysua = "";
        khieunaitocaoContextDataContext _khieunaitocaoContext = new khieunaitocaoContextDataContext();
        tb_thongtintocao objTC;
        private void form_thongtintocao_Load(object sender, EventArgs e)
        {
            var list = _khieunaitocaoContext.list_phanloai_tocao();
            treeListLookUp_hinhthuctocao.Properties.DataSource = list;
            treeListLookUp_hinhthuctocao.Properties.DisplayMember = "phanloai_tocao";
            treeListLookUp_hinhthuctocao.Properties.ValueMember = "ma_tocao";

            if (bool_sua==false)
            {
                thongtin_addnew();
            }
            if (bool_sua == true)
            {
                thongtin_edit();
            }
        }
        private void thongtin_load()
        {
            objTC = new tb_thongtintocao();
            bool_sua = false;
            txt_hoten_canhan.Text = null;
            txt_cmnd_canhan.Text = null;
            txt_diachi_canhan.Text = null;
            txt_sodienthoai_canhan.Text = null;
            txt_email_canhan.Text = null;
            txt_ngaycap_cmnd.Text = null;
            txt_noicap_cmnd.Text = null;
            txt_coquan_donvi_canhan.Text = null;
            txt_tencoquan_donvi_tochuc.Text = null;
            txt_diachi_tochuc.Text = null;
            txt_sodienthoaitochuc.Text = null;
            txt_email_tochuc.Text = null;
            txt_nguoikytrongdon.Text = null;
            memo_tomtat_tocao.Text = null;
            combo_lydokhongdudieukien_xuly.EditValue = null;
            btn_taikieudinhkem.Text = null;
            combo_xuly_tocao_khongthuoc_thamquyen.EditValue = null;
            txt_chuyendonvingoai.Text = null;
            check_duocbaove.Checked = false;
            check_duocnhanketqua.Checked = false;
            memo_yeucaukhac.Text = null;
            memo_ghichu.Text = null;
            
        }
        private void thongtin_addnew()
        {
            objTC = new tb_thongtintocao();
            grc_bidon_tocao.DataSource = objTC.tb_bidon_tocaos;
            grc_nhatky_guidon_tocao.DataSource = objTC.tb_nhatky_guidon_tocaos;
        }
        private void thongtin_edit()
        {
            var _list_thongtintocao = _khieunaitocaoContext.xem_thongtintocao_linq(id_thongtintocao).SingleOrDefault();

            txt_ma_tocao.Text = _list_thongtintocao.ma_donthu_tocao;
            rdb_tochuc_canhan.EditValue = _list_thongtintocao.tochuc_canhan;
            if ((bool)rdb_tochuc_canhan.EditValue == true)
            {
                txt_hoten_canhan.EditValue = _list_thongtintocao.ten_canhan_tochuc;
                txt_sodienthoai_canhan.EditValue = _list_thongtintocao.sdt;
                txt_email_canhan.EditValue = _list_thongtintocao.email;
                txt_cmnd_canhan.EditValue = _list_thongtintocao.so_cmnd;
                txt_ngaycap_cmnd.EditValue = _list_thongtintocao.ngaycap_cmnd;
                txt_noicap_cmnd.EditValue = _list_thongtintocao.noicap_cmnd;
                txt_diachi_canhan.EditValue = _list_thongtintocao.dia_chi;
                txt_coquan_donvi_canhan.EditValue = _list_thongtintocao.ten_cqdv_canhan;
            }
            if ((bool)rdb_tochuc_canhan.EditValue == false)
            {
                txt_tencoquan_donvi_tochuc.EditValue = _list_thongtintocao.ten_canhan_tochuc;
                txt_diachi_tochuc.EditValue = _list_thongtintocao.dia_chi;
                txt_nguoikytrongdon.EditValue = _list_thongtintocao.nguoi_ky_trong_don;
                txt_sodienthoaitochuc.EditValue = _list_thongtintocao.sdt;
                txt_email_tochuc.EditValue = _list_thongtintocao.email;
            }
            rdb_loaihinh_tocao.EditValue = _list_thongtintocao.nacdanh_codanh;
            combo_hinhthuc_tocao.EditValue = _list_thongtintocao.hinhthuc_tocao;
            memo_tomtat_tocao.EditValue = _list_thongtintocao.tomtat_noidung;
            rdb_dieukien_xuly.EditValue = _list_thongtintocao.dieukien_xuly_du_hoackhong;
            rdb_tinhchat.EditValue = _list_thongtintocao.tinhchat_vuviec_phuctap_dongian;
            treeListLookUp_hinhthuctocao.EditValue = _list_thongtintocao.ma_tocao;
            rdb_lienquan_dennhieu_cand.EditValue = _list_thongtintocao.tocao_lienquanden_thamquyen_nhieucand_co_khong;
            rdb_cokhieunai.EditValue = _list_thongtintocao.tocao_conoidung_khieunai;
            combo_lydokhongdudieukien_xuly.EditValue = _list_thongtintocao.lydo_khongdu_dieukien;
            combo_xuly_tocao_khongthuoc_thamquyen.EditValue = _list_thongtintocao.xuly_tocao_khongthuoc_thamquyen;
            txt_chuyendonvingoai.EditValue = _list_thongtintocao.chuyentocao_chodonvingoai;
            memo_ghichu.EditValue = _list_thongtintocao.ghi_chu;
            if (_list_thongtintocao.duoc_baove == 1)
            {
                check_duocbaove.Checked = true;
            }
            else
            {
                check_duocbaove.Checked = false;
            }
            if (_list_thongtintocao.duoc_nhanketqua == 1)
            {
                check_duocnhanketqua.Checked = true;
            }
            else
            {
                check_duocnhanketqua.Checked = false;
            }
            memo_yeucaukhac.Text = _list_thongtintocao.yeucaukhac;
            btn_taikieudinhkem.EditValue = _list_thongtintocao.tailieu_dinhkem;
            ngaysua = _list_thongtintocao.ngaygio_sua + "\n" + DateTime.Now.ToString();

            objTC = _khieunaitocaoContext.tb_thongtintocaos.Single(p => p.id_thongtintocao1 == id_thongtintocao);
            grc_bidon_tocao.DataSource = objTC.tb_bidon_tocaos;
            grc_nhatky_guidon_tocao.DataSource = objTC.tb_nhatky_guidon_tocaos;
            
        }
        private void xtraTab_canhan_tochuc_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (xtraTab_canhan_tochuc.SelectedTabPageIndex == 0)
            {
                rdb_tochuc_canhan.EditValue = 0;
            }
            else
            {
                rdb_tochuc_canhan.EditValue = 1;
            }
        }
        private void rdb_tochuc_canhan_EditValueChanged(object sender, EventArgs e)
        {
            if (rdb_tochuc_canhan.SelectedIndex == 0)
            {
                xtraTab_canhan_tochuc.SelectedTabPage = xtraTab_canhan_tochuc.TabPages[0];
                layoutControl_canhan.Enabled = true;
                layoutContro_tochuc.Enabled = false;
            }
            if (rdb_tochuc_canhan.SelectedIndex == 1)
            {
                xtraTab_canhan_tochuc.SelectedTabPage = xtraTab_canhan_tochuc.TabPages[1];
                layoutControl_canhan.Enabled = false;
                layoutContro_tochuc.Enabled = true;
            }
        }
        private void bar_lammoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            thongtin_load();
        }
        private void bar_xoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            #region check permission
            if (dinhdanh.quyenhan == 2)
            {
                XtraMessageBox.Show("Tài khoản chỉ có quyền xem.\n Không được phép xóa");
                return;
            }
            using (_khieunaitocaoContext = new khieunaitocaoContextDataContext())
            {
                var _edit = _khieunaitocaoContext.check_xoatocao(id_thongtintocao).ToList();
                if (_edit.Count() != 0)
                {
                    XtraMessageBox.Show("Không được xóa đơn thư này");
                    return;
                }
            }
            if (txt_ma_tocao.Text.Substring(0, 4) != dinhdanh.kyhieu_donvi)
            {
                XtraMessageBox.Show("Không được quyền xóa");
                return;
            }
            #endregion
            try
            {
                   var del = _khieunaitocaoContext.tb_thongtintocaos.Single(p => p.id_thongtintocao1 == id_thongtintocao);
                    if (MessageBox.Show("Bạn có muốn xóa thông tin?", "Confirmation", MessageBoxButtons.YesNo) !=
                     DialogResult.Yes)
                        return;
                    _khieunaitocaoContext.tb_thongtintocaos.DeleteOnSubmit(del);
                    _khieunaitocaoContext.SubmitChanges();
                    MessageBox.Show("Xóa thông tin thành công");
            }
            catch (Exception)
            {
                MessageBox.Show("Xóa thông tin thất bại");
                throw;
            }
        }
        private void repository_xoa_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa thông tin?", "Confirmation", MessageBoxButtons.YesNo) !=
               DialogResult.Yes)
                return;
            grv_bidon_tocao.DeleteSelectedRows();
        }
        private void repository_xoa_nhatky_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa thông tin?", "Confirmation", MessageBoxButtons.YesNo) !=
               DialogResult.Yes)
                return;
            grv_nhatky_guidon_tocao.DeleteSelectedRows();
        }
        private void bar_luu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                #region kiemtra
                if (dinhdanh.quyenhan == 2)
                {
                    XtraMessageBox.Show("Tài khoản chỉ có quyền xem.\n Không được phép thay đổi");
                    return;
                }

                if (string.IsNullOrEmpty(combo_hinhthuc_tocao.Text.Trim()) || string.IsNullOrWhiteSpace(combo_hinhthuc_tocao.Text.Trim()))
                {
                    XtraMessageBox.Show("Vui lòng chọn loại đơn khiếu nại");
                    combo_hinhthuc_tocao.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(treeListLookUp_hinhthuctocao.Text.Trim()) || string.IsNullOrWhiteSpace(treeListLookUp_hinhthuctocao.Text.Trim()))
                {
                    XtraMessageBox.Show("Vui lòng chọn loại đơn khiếu nại");
                    treeListLookUp_hinhthuctocao.Focus();
                    return;
                }
                if (rdb_tochuc_canhan.SelectedIndex == 0)
                {
                    if (txt_hoten_canhan.Text.Trim() == null)
                    {
                        XtraMessageBox.Show("Vui lòng nhập tên cá nhân đứng đơn");
                        txt_hoten_canhan.Focus();
                        return;
                    }
                }
                if (rdb_tochuc_canhan.SelectedIndex == 1)
                {
                    if (txt_tencoquan_donvi_tochuc.Text.Trim() == null)
                    {
                        XtraMessageBox.Show("Vui lòng nhập tên tổ chức đứng đơn");
                        txt_tencoquan_donvi_tochuc.Focus();
                        return;
                    }
                }
                if (bool_sua == false)
                {
                    //var _lst = _khieunaitocaoContext.tb_thongtinkhieunais.Where(p => p.ma_donthu_khieunai == txt_madonthu.Text.Trim()).FirstOrDefault();
                    int _lst = _khieunaitocaoContext.check_matocao_linq(dinhdanh.madonvi, dinhdanh.kyhieu_donvi + DateTime.Now.Year.ToString() + txt_ma_tocao.Text.Trim());
                    if (_lst == 1)
                    {
                        XtraMessageBox.Show("Mã đơn thư tố cáo đã tồn tại");
                        txt_ma_tocao.Focus();
                        return;
                    }
                }
                if (bool_sua == true)
                {
                    if (txt_ma_tocao.Text.Substring(0, 4) != dinhdanh.kyhieu_donvi)
                    {
                        XtraMessageBox.Show("Không được quyền sửa");
                        return;
                    }
                    using (khieunaitocaoContextDataContext khieunaitocaoContext = new khieunaitocaoContextDataContext())
                    {
                        var checksua = khieunaitocaoContext.check_suatocao(id_thongtintocao).ToList();
                        if (checksua.Count > 1)
                        {
                            XtraMessageBox.Show("Không được quyền sửa");
                            return;
                           
                         
                        }
                        if (checksua.Count == 1)
                        {
                           
                            if (checksua[0].statuss == "Finish")
                            {
                                XtraMessageBox.Show("Không được quyền sửa");
                                return;
                            }

                        }
                    }
                }
                #endregion
                if (bool_sua == true)
                {
                    objTC = _khieunaitocaoContext.tb_thongtintocaos.Where(a => a.ma_donthu_tocao == txt_ma_tocao.Text).SingleOrDefault();
                }
                objTC.ma_donvi = dinhdanh.madonvi;

                objTC.ma_canbo_nhapdulieu = dinhdanh.ma_canbo;
                objTC.tochuc_canhan = (bool)rdb_tochuc_canhan.EditValue;
                objTC.nacdanh_codanh = (bool)rdb_loaihinh_tocao.EditValue;
                if ((bool)rdb_tochuc_canhan.EditValue == true)
                {
                    objTC.ten_canhan_tochuc = txt_hoten_canhan.Text;
                    objTC.sdt = txt_sodienthoai_canhan.Text;
                    objTC.email = txt_email_canhan.Text;
                    objTC.so_cmnd = txt_cmnd_canhan.Text;
                    objTC.ngaycap_cmnd = (DateTime?)txt_ngaycap_cmnd.EditValue;
                    objTC.noicap_cmnd = txt_noicap_cmnd.Text;
                    objTC.dia_chi = txt_diachi_canhan.Text;
                    objTC.ten_cqdv_canhan = txt_coquan_donvi_canhan.Text;
                    objTC.nguoi_ky_trong_don = null;
                }
                else
                {
                    objTC.ten_canhan_tochuc = txt_tencoquan_donvi_tochuc.Text;
                    objTC.sdt = txt_sodienthoaitochuc.Text;
                    objTC.email = txt_email_tochuc.Text;
                    objTC.so_cmnd = null;
                    objTC.ngaycap_cmnd = null;
                    objTC.noicap_cmnd = null;
                    objTC.dia_chi = txt_diachi_tochuc.Text;
                    objTC.ten_cqdv_canhan = null;
                    objTC.nguoi_ky_trong_don = txt_nguoikytrongdon.Text;
                }
                objTC.hinhthuc_tocao = combo_hinhthuc_tocao.Text;
                objTC.ma_tocao = treeListLookUp_hinhthuctocao.EditValue.ToString();
                objTC.tomtat_noidung = memo_tomtat_tocao.Text;
                objTC.tinhchat_vuviec_phuctap_dongian = (bool)rdb_tinhchat.EditValue;
                objTC.dieukien_xuly_du_hoackhong = (bool)rdb_dieukien_xuly.EditValue;
                objTC.tailieu_dinhkem = btn_taikieudinhkem.Text;
                objTC.lydo_khongdu_dieukien = combo_lydokhongdudieukien_xuly.Text;
                objTC.xuly_tocao_khongthuoc_thamquyen = combo_xuly_tocao_khongthuoc_thamquyen.Text;
                objTC.tocao_lienquanden_thamquyen_nhieucand_co_khong = (bool)rdb_lienquan_dennhieu_cand.EditValue;
                objTC.chuyentocao_chodonvingoai = txt_chuyendonvingoai.Text;
                objTC.ngaygio_nhap = DateTime.Now;
                objTC.ngaygio_sua = ngaysua;
                objTC.ghi_chu = memo_ghichu.Text;
                if (check_duocnhanketqua.Checked == true)
                {
                    objTC.duoc_nhanketqua = 1;
                }
                else
                {
                    objTC.duoc_nhanketqua = 0;
                }
                if (check_duocbaove.Checked == true)
                {
                    objTC.duoc_baove = 1;
                }
                else
                {
                    objTC.duoc_baove = 0;
                }
                objTC.yeucaukhac = memo_yeucaukhac.Text;
                if (bool_sua == false)
                {
                    objTC.ma_donthu_tocao = dinhdanh.kyhieu_donvi + DateTime.Now.Year + txt_ma_tocao.Text.Trim();
                    _khieunaitocaoContext.tb_thongtintocaos.InsertOnSubmit(objTC);
                }
                _khieunaitocaoContext.SubmitChanges();
                /////////////////////////////////////////////////////////
                XtraMessageBox.Show("Đã lưu được");
                thongtin_load();
            }
            catch (Exception)
            {

                throw;
            }
         
        }
    }
}