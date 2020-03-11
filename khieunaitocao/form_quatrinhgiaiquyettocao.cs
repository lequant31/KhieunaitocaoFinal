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
    public partial class form_quatrinhgiaiquyettocao : DevExpress.XtraEditors.XtraForm
    {
        public form_quatrinhgiaiquyettocao()
        {
            InitializeComponent();
        }
        public bool bool_sua = false;
        public int id_quatrinhgiaiquyettocao;
        public int _id_thongtintocao;
        public int hinhthucxuly;
        public string statuss;
        khieunaitocaoContextDataContext _khieunaitocaoContext;
        tb_giaiquyettocao objTC = new tb_giaiquyettocao();
        public string trangthaigiaiquyet;
        private void load_items_donvi()
        {
            try
            {
                using (_khieunaitocaoContext = new khieunaitocaoContextDataContext())
                {
                    var look = _khieunaitocaoContext.list_donvi().ToList();
                    combo_donvinhan.Properties.DataSource = look;
                    combo_donvinhan.Properties.DisplayMember = "ten_donvi";
                    combo_donvinhan.Properties.ValueMember = "ma_donvi";
                }
                    
            }
            catch (Exception)
            {
                //throw;
                XtraMessageBox.Show("Vui lòng kiểm tra lại kết nối mạng");
            }
        }
        private void fun_null()
        {
            txt_ma_donthu_tocao = null;
            txt_solangiaiquyet = null;
            combo_hinhthuc_xuly = null;
            combo_donvinhan = null;
            date_ngaynhan = null;
            combo_capgiaiquyet = null;
            combo_donvichiu_trachnhiem_giaiquyet = null;
            memo_tomtatnoidung = null;
            txt_sothongbao_chonoigui = null;
            date_ngaygui_thongbao = null;
            txt_songay_giaiquyet = null;
            date_tungay_giaiquyet = null;
            date_denngay_giaiquyet = null;
            txt_so_quyetdinh_thuly = null;
            date_ngay_thuly = null;
            combo_hinhthuc_xacminh = null;
            txt_so_quyetdinh_thanhlap = null;
            date_ngay_thanhlap_quyetdinh = null;
            txt_hoten_totruong = null;
            combo_capbac_totruong = null;
            combo_chucvu_totruong = null;
            memo_thanhvien_trongdoan = null;
            so_kehoach_xacminh = null;
            date_tungay_xacminh = null;
            date_denngay_xacminh = null;
            combo_ketqua_xacminh = null;
            date_ngaayrut_tocao = null;
            memo_lydorut_tocao = null;
            txt_so_baocao_ketqua_xacminh = null;
            date_baocao_ketqua_xacminh = null;
            memo_tomtat_ketqua_xuly = null;
            txt_so_ketluan_noidung_tocao = null;
            date_ngay_ketluan_noidung_tocao = null;
            txt_nguoiky_ketluan_noidung_tocao = null;
            txt_chucvu_nguoiky_ketluan_noidung_tocao = null;
            date_ngay_congkhai_ketluan = null;
            txt_khongxet_thidua = null;
            txt_bikiemdiem = null;
            txt_bicanhcao = null;
            txt_bikhientrach = null;
            txt_bigiangchuc = null;
            txt_bigiangcap = null;
            txt_xuly_hinhsu = null;
            txt_tuocgianhhieu_cand = null;
            txt_tapthe_duoc_minhoan = null;
            txt_canhan_duoc_minhoan = null;
            txt_khoiphuc_loiich = null;
            txt_thuhoi_taisan = null;
            date_ngaynop_luu_hoso = null;
            txt_canbo_thuly = null;
            txt_lanhdao_phutrach = null;
        }
        private void fun_save()
        {
            using (_khieunaitocaoContext = new khieunaitocaoContextDataContext())
            {
                #region check dieu kien
                if (dinhdanh.quyenhan == 2)
                {
                    XtraMessageBox.Show("Không được quyền thay đổi");
                    return;
                }
                if (bool_sua == true)
                {
                    var _check = _khieunaitocaoContext.check_ketthucgiaiquyettocao(id_quatrinhgiaiquyettocao).SingleOrDefault();
                    if (_check.ketthucgiaiquyet == "Lock")
                    {
                        XtraMessageBox.Show("Đã kết thúc quá trình giải quyết.\n Không thể thay đổi được.");
                        return;
                    }
                }               
                #endregion

                var id_thongtintocao = _khieunaitocaoContext.xem_id_thongtintocao(txt_ma_donthu_tocao.Text.Trim(),dinhdanh.madonvi).SingleOrDefault();
                int _ID = id_thongtintocao.id_thongtintocao1;
                int? id_quatrinhgiaiquyettocao_guiden = id_thongtintocao.ma_quatrinhgiaiquyet_donvichuyenden;
                if (combo_hinhthuc_xuly.Text == "Không xử lý")
                {
                    statuss = "Finish";
                    trangthaigiaiquyet = "Lock";
                }
                if (combo_hinhthuc_xuly.Text == "Chuyển đơn vị khác")
                {
                    statuss = "Finish";
                    trangthaigiaiquyet = "Lock";
                    if (date_ngaynhan.Text == null)
                    {
                        XtraMessageBox.Show("Vui lòng chọn ngày chuyển");
                        return;
                    }
                }
                if(combo_hinhthuc_xuly.Text=="Trực tiếp xử lý")
                {
                    if (date_tungay_giaiquyet.EditValue == null)
                    {
                        statuss = "No process";
                        trangthaigiaiquyet = "Unlock";
                    }
                    if (date_denngay_giaiquyet.EditValue != null && date_ngayketthuc.EditValue == null)
                    {
                        statuss ="Processing";
                        trangthaigiaiquyet = "Unlock";
                    }
                    if (date_denngay_giaiquyet.EditValue != null && date_ngayketthuc.EditValue != null)
                    {
                        TimeSpan timeSpan = (DateTime)date_ngayketthuc.EditValue - (DateTime)date_denngay_giaiquyet.EditValue;
                        int songay = timeSpan.Days;
                        if (songay > 0)
                        {
                            statuss = "Out of date";
                            trangthaigiaiquyet = "Unlock";
                        }
                        else
                        {
                            statuss = "Finish";
                            trangthaigiaiquyet = "Lock";
                        }
                    }
                }
                if (bool_sua == false)
                {
                    _khieunaitocaoContext.them_quatrinhgiaiquyettocao_linq(_ID, txt_solangiaiquyet.Text, hinhthucxuly, Convert.ToInt32(combo_donvinhan.EditValue), (DateTime?)date_ngaynhan.EditValue, combo_capgiaiquyet.Text, memo_tomtatnoidung.Text, combo_donvichiu_trachnhiem_giaiquyet.Text, txt_sothongbao_chonoigui.Text, (DateTime?)date_ngaygui_thongbao.EditValue, txt_songay_giaiquyet.Text.Trim(), (DateTime?)date_tungay_giaiquyet.EditValue, (DateTime?)date_denngay_giaiquyet.EditValue,
                    txt_so_quyetdinh_thuly.Text, (DateTime?)date_ngay_thuly.EditValue, combo_hinhthuc_xacminh.Text, txt_so_quyetdinh_thanhlap.Text, (DateTime?)date_ngay_thanhlap_quyetdinh.EditValue, txt_hoten_totruong.Text, combo_capbac_totruong.Text, combo_chucvu_totruong.Text, memo_thanhvien_trongdoan.Text, so_kehoach_xacminh.Text, (DateTime?)date_tungay_xacminh.EditValue, (DateTime?)date_denngay_xacminh.EditValue, combo_ketqua_xacminh.Text,
                    (DateTime?)date_ngaayrut_tocao.EditValue, memo_lydorut_tocao.Text, txt_so_baocao_ketqua_xacminh.Text, (DateTime?)date_baocao_ketqua_xacminh.EditValue, memo_tomtat_ketqua_xuly.Text, txt_so_ketluan_noidung_tocao.Text, (DateTime?)date_ngay_ketluan_noidung_tocao.EditValue, txt_nguoiky_ketluan_noidung_tocao.Text, txt_chucvu_nguoiky_ketluan_noidung_tocao.Text, (DateTime?)date_ngay_congkhai_ketluan.EditValue, Convert.ToInt32(txt_khongxet_thidua.Text), Convert.ToInt32(txt_bikiemdiem.Text),
                    Convert.ToInt32(txt_bicanhcao.Text), Convert.ToInt32(txt_bikhientrach.Text), Convert.ToInt32(txt_bigiangchuc.Text), Convert.ToInt32(txt_bigiangcap.Text), Convert.ToInt32(txt_xuly_hinhsu.Text), Convert.ToInt32(txt_tuocgianhhieu_cand.Text), Convert.ToInt32(txt_tapthe_duoc_minhoan.Text), Convert.ToInt32(txt_canhan_duoc_minhoan.Text), txt_khoiphuc_loiich.Text, txt_thuhoi_taisan.Text, (DateTime?)date_ngaynop_luu_hoso.EditValue, txt_canbo_thuly.Text, txt_lanhdao_phutrach.Text, trangthaigiaiquyet,statuss,DateTime.Now, (DateTime?)date_ngayketthuc.EditValue, "Not delivered");
                    //if (id_quatrinhgiaiquyettocao_guiden !=null)
                    //{
                    //    _khieunaitocaoContext.sua_quatrinhgiaiquyettocao_guiden_linq(id_quatrinhgiaiquyettocao_guiden, txt_solangiaiquyet.Text, combo_capgiaiquyet.Text, memo_tomtatnoidung.Text, combo_donvichiu_trachnhiem_giaiquyet.Text, txt_sothongbao_chonoigui.Text, (DateTime?)date_ngaygui_thongbao.EditValue, txt_songay_giaiquyet.Text.Trim(), (DateTime?)date_tungay_giaiquyet.EditValue, (DateTime?)date_denngay_giaiquyet.EditValue,
                    //                       txt_so_quyetdinh_thuly.Text, (DateTime?)date_ngay_thuly.EditValue, combo_hinhthuc_xacminh.Text, txt_so_quyetdinh_thanhlap.Text, (DateTime?)date_ngay_thanhlap_quyetdinh.EditValue, txt_hoten_totruong.Text, combo_capbac_totruong.Text, combo_chucvu_totruong.Text, memo_thanhvien_trongdoan.Text, so_kehoach_xacminh.Text, (DateTime?)date_tungay_xacminh.EditValue, (DateTime?)date_denngay_xacminh.EditValue, combo_ketqua_xacminh.Text,
                    //                       (DateTime?)date_ngaayrut_tocao.EditValue, memo_lydorut_tocao.Text, txt_so_baocao_ketqua_xacminh.Text, (DateTime?)date_baocao_ketqua_xacminh.EditValue, memo_tomtat_ketqua_xuly.Text, txt_so_ketluan_noidung_tocao.Text, (DateTime?)date_ngay_ketluan_noidung_tocao.EditValue, txt_nguoiky_ketluan_noidung_tocao.Text, txt_chucvu_nguoiky_ketluan_noidung_tocao.Text, (DateTime?)date_ngay_congkhai_ketluan.EditValue, Convert.ToInt32(txt_khongxet_thidua.Text), Convert.ToInt32(txt_bikiemdiem.Text),
                    //                       Convert.ToInt32(txt_bicanhcao.Text), Convert.ToInt32(txt_bikhientrach.Text), Convert.ToInt32(txt_bigiangchuc.Text), Convert.ToInt32(txt_bigiangcap.Text), Convert.ToInt32(txt_xuly_hinhsu.Text), Convert.ToInt32(txt_tuocgianhhieu_cand.Text), Convert.ToInt32(txt_tapthe_duoc_minhoan.Text), Convert.ToInt32(txt_canhan_duoc_minhoan.Text), txt_khoiphuc_loiich.Text, txt_thuhoi_taisan.Text, (DateTime?)date_ngaynop_luu_hoso.EditValue, txt_canbo_thuly.Text, txt_lanhdao_phutrach.Text, (DateTime?)date_ngayketthuc.EditValue);
                    //}
                   
                    XtraMessageBox.Show("Thêm thông tin thành công");
                }
                if (bool_sua == true)
                {
                    _khieunaitocaoContext.sua_quatrinhgiaiquyettocao_linq(id_quatrinhgiaiquyettocao, _id_thongtintocao, txt_solangiaiquyet.Text, hinhthucxuly, Convert.ToInt32(combo_donvinhan.EditValue), (DateTime?)date_ngaynhan.EditValue, combo_capgiaiquyet.Text, memo_tomtatnoidung.Text, combo_donvichiu_trachnhiem_giaiquyet.Text, txt_sothongbao_chonoigui.Text, (DateTime?)date_ngaygui_thongbao.EditValue,txt_songay_giaiquyet.Text.Trim(), (DateTime?)date_tungay_giaiquyet.EditValue, (DateTime?)date_denngay_giaiquyet.EditValue,
                    txt_so_quyetdinh_thuly.Text, (DateTime?)date_ngay_thuly.EditValue, combo_hinhthuc_xacminh.Text, txt_so_quyetdinh_thanhlap.Text, (DateTime?)date_ngay_thanhlap_quyetdinh.EditValue, txt_hoten_totruong.Text, combo_capbac_totruong.Text, combo_chucvu_totruong.Text, memo_thanhvien_trongdoan.Text, so_kehoach_xacminh.Text, (DateTime?)date_tungay_xacminh.EditValue, (DateTime?)date_denngay_xacminh.EditValue, combo_ketqua_xacminh.Text,
                    (DateTime?)date_ngaayrut_tocao.EditValue, memo_lydorut_tocao.Text, txt_so_baocao_ketqua_xacminh.Text, (DateTime?)date_baocao_ketqua_xacminh.EditValue, memo_tomtat_ketqua_xuly.Text, txt_so_ketluan_noidung_tocao.Text, (DateTime?)date_ngay_ketluan_noidung_tocao.EditValue, txt_nguoiky_ketluan_noidung_tocao.Text, txt_chucvu_nguoiky_ketluan_noidung_tocao.Text, (DateTime?)date_ngay_congkhai_ketluan.EditValue, Convert.ToInt32(txt_khongxet_thidua.Text), Convert.ToInt32(txt_bikiemdiem.Text),
                    Convert.ToInt32(txt_bicanhcao.Text), Convert.ToInt32(txt_bikhientrach.Text), Convert.ToInt32(txt_bigiangchuc.Text), Convert.ToInt32(txt_bigiangcap.Text), Convert.ToInt32(txt_xuly_hinhsu.Text), Convert.ToInt32(txt_tuocgianhhieu_cand.Text), Convert.ToInt32(txt_tapthe_duoc_minhoan.Text), Convert.ToInt32(txt_canhan_duoc_minhoan.Text), txt_khoiphuc_loiich.Text,txt_thuhoi_taisan.Text, (DateTime?)date_ngaynop_luu_hoso.EditValue, txt_canbo_thuly.Text, txt_lanhdao_phutrach.Text, trangthaigiaiquyet,statuss,(DateTime?)date_ngayketthuc.EditValue, "Not delivered");

                    //if (id_quatrinhgiaiquyettocao_guiden != null)
                    //{
                    //    _khieunaitocaoContext.sua_quatrinhgiaiquyettocao_guiden_linq(id_quatrinhgiaiquyettocao_guiden, txt_solangiaiquyet.Text, combo_capgiaiquyet.Text, memo_tomtatnoidung.Text, combo_donvichiu_trachnhiem_giaiquyet.Text, txt_sothongbao_chonoigui.Text, (DateTime?)date_ngaygui_thongbao.EditValue, txt_songay_giaiquyet.Text.Trim(), (DateTime?)date_tungay_giaiquyet.EditValue, (DateTime?)date_denngay_giaiquyet.EditValue,
                    //                       txt_so_quyetdinh_thuly.Text, (DateTime?)date_ngay_thuly.EditValue, combo_hinhthuc_xacminh.Text, txt_so_quyetdinh_thanhlap.Text, (DateTime?)date_ngay_thanhlap_quyetdinh.EditValue, txt_hoten_totruong.Text, combo_capbac_totruong.Text, combo_chucvu_totruong.Text, memo_thanhvien_trongdoan.Text, so_kehoach_xacminh.Text, (DateTime?)date_tungay_xacminh.EditValue, (DateTime?)date_denngay_xacminh.EditValue, combo_ketqua_xacminh.Text,
                    //                       (DateTime?)date_ngaayrut_tocao.EditValue, memo_lydorut_tocao.Text, txt_so_baocao_ketqua_xacminh.Text, (DateTime?)date_baocao_ketqua_xacminh.EditValue, memo_tomtat_ketqua_xuly.Text, txt_so_ketluan_noidung_tocao.Text, (DateTime?)date_ngay_ketluan_noidung_tocao.EditValue, txt_nguoiky_ketluan_noidung_tocao.Text, txt_chucvu_nguoiky_ketluan_noidung_tocao.Text, (DateTime?)date_ngay_congkhai_ketluan.EditValue, Convert.ToInt32(txt_khongxet_thidua.Text), Convert.ToInt32(txt_bikiemdiem.Text),
                    //                       Convert.ToInt32(txt_bicanhcao.Text), Convert.ToInt32(txt_bikhientrach.Text), Convert.ToInt32(txt_bigiangchuc.Text), Convert.ToInt32(txt_bigiangcap.Text), Convert.ToInt32(txt_xuly_hinhsu.Text), Convert.ToInt32(txt_tuocgianhhieu_cand.Text), Convert.ToInt32(txt_tapthe_duoc_minhoan.Text), Convert.ToInt32(txt_canhan_duoc_minhoan.Text), txt_khoiphuc_loiich.Text, txt_thuhoi_taisan.Text, (DateTime?)date_ngaynop_luu_hoso.EditValue, txt_canbo_thuly.Text, txt_lanhdao_phutrach.Text, (DateTime?)date_ngayketthuc.EditValue);
                    //}
                    XtraMessageBox.Show("Sửa thông tin thành công");
                }
            }
        }
        private void fun_edit()
        {
            using (_khieunaitocaoContext = new khieunaitocaoContextDataContext())
            {
                var _sua = _khieunaitocaoContext.xem_thongtin_quatrinhgiaiquyettocao(id_quatrinhgiaiquyettocao).SingleOrDefault();
                txt_ma_donthu_tocao.Text = _sua.ma_donthu_tocao;
                txt_solangiaiquyet.Text = _sua.sola_tocao;

                if (_sua.hinhthuc_xuly == "Chuyển đơn vị khác")
                {
                    combo_donvinhan.Properties.ReadOnly = false;
                    date_ngaynhan.Properties.ReadOnly = false;

                }
                if (_sua.hinhthuc_xuly == "Trực tiếp xử lý")
                {
                    combo_donvinhan.Properties.ReadOnly = true;
                    date_ngaynhan.Properties.ReadOnly = true;
                }
                if (_sua.hinhthuc_xuly == "Không xử lý")
                {
                    
                    combo_donvinhan.Properties.ReadOnly = true;
                    date_ngaynhan.Properties.ReadOnly = true;
                }
                combo_hinhthuc_xuly.Text = _sua.hinhthuc_xuly;
                combo_donvinhan.EditValue = _sua.donvinhan;
                date_ngaynhan.EditValue = _sua.ngaynhan;
                combo_capgiaiquyet.Text = _sua.capgiaiquyet;
                combo_donvichiu_trachnhiem_giaiquyet.Text = _sua.noidungtocao;
                memo_tomtatnoidung.Text = _sua.dv_chiutrachnhiem_giaiquyet;
                txt_sothongbao_chonoigui.Text = _sua.sothongbao_chonoigui;
                date_ngaygui_thongbao.EditValue = _sua.ngaygui_thongbao;
                txt_songay_giaiquyet.EditValue = _sua.songay_giaiquyet;
                date_tungay_giaiquyet.EditValue = _sua.ngaybatdau_giaiquyet;
                date_denngay_giaiquyet.EditValue = _sua.ngayketthuc_giaiquyet;
                txt_so_quyetdinh_thuly.Text = _sua.so_quyetdinh_thuly;
                date_ngay_thuly.EditValue = _sua.ngay_thuly;
                combo_hinhthuc_xacminh.Text = _sua.hinhthuc_xacminh;
                txt_so_quyetdinh_thanhlap.Text = _sua.so_quyetdinh_thanhlap;
                date_ngay_thanhlap_quyetdinh.EditValue = _sua.ngay_thanhlap_quyetdinh;
                txt_hoten_totruong.Text = _sua.hoten_totruong;
                combo_capbac_totruong.Text = _sua.capbac_totruong;
                combo_chucvu_totruong.Text = _sua.chuvu_totruong;
                memo_thanhvien_trongdoan.Text = _sua.thanhvien_trongdoan;
                so_kehoach_xacminh.Text = _sua.so_kehoach_xacminh;
                date_tungay_xacminh.EditValue = _sua.ngay_batdauxacminh;
                date_denngay_xacminh.EditValue = _sua.ngay_ketthucxacminh;
                combo_ketqua_xacminh.Text = _sua.ketqua_xacminh;
                date_ngaayrut_tocao.EditValue = _sua.ngayrut_tocao;
                memo_lydorut_tocao.Text = _sua.lydorut_tocao;
                txt_so_baocao_ketqua_xacminh.Text = _sua.so_baocao_ketqua_xacminh;
                date_baocao_ketqua_xacminh.EditValue = _sua.ngay_baocao_ketqua_xacminh;
                memo_tomtat_ketqua_xuly.Text = _sua.tomtat_ketqua_xuly;
                txt_so_ketluan_noidung_tocao.Text = _sua.so_ketluan_noidung_tocao;
                date_ngay_ketluan_noidung_tocao.EditValue = _sua.ngay_ketluan_noidung_tocao;
                txt_nguoiky_ketluan_noidung_tocao.Text = _sua.nguoiky_ketluan_noidung_tocao;
                txt_chucvu_nguoiky_ketluan_noidung_tocao.Text = _sua.chucvu_nguoiky_ketluan_noidung_tocao;
                date_ngay_congkhai_ketluan.EditValue = _sua.ngay_congkhai_ketluan;
                txt_khongxet_thidua.EditValue = _sua.so_cb_khongduoc_xetthidua;
                txt_bikiemdiem.EditValue = _sua.so_cb_bikiemdiem;
                txt_bicanhcao.EditValue = _sua.so_cb_bicanhcao;
                txt_bikhientrach.EditValue = _sua.so_cb_bikhientrach;
                txt_bigiangchuc.EditValue = _sua.so_cb_bigiangchuc;
                txt_bigiangcap.EditValue = _sua.so_cb_bigiangcap;
                txt_xuly_hinhsu.EditValue = _sua.so_cb_xuly_hinhsu;
                txt_tuocgianhhieu_cand.EditValue = _sua.so_cb_bituocdanhhieu;
                txt_tapthe_duoc_minhoan.EditValue = _sua.so_tapthe_duocminhoan;
                txt_canhan_duoc_minhoan.EditValue = _sua.so_canhan_duocminhoan;
                txt_khoiphuc_loiich.Text = _sua.khoiphuc_loiich;
                txt_thuhoi_taisan.Text = _sua.thuhoi_taisan;
                date_ngaynop_luu_hoso.EditValue = _sua.ngaynop_luu_hoso;
                txt_canbo_thuly.Text = _sua.cabo_thuly;
                txt_lanhdao_phutrach.Text = _sua.lanhdao_phutrach;
                if (_sua.ketthucgiaiquyet == "Lock")
                {
                    check_quatrinhgiaiquyet.Checked = true;
                }
                else
                {
                    check_quatrinhgiaiquyet.Checked = false;
                }

            }
        }
        private void check_quatrinhgiaiquyet_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (check_quatrinhgiaiquyet.Checked)
            {
                check_quatrinhgiaiquyet.Caption = "Kết thúc quá trình giải quyết";
                trangthaigiaiquyet = "Lock";
            }
            else
            {
                check_quatrinhgiaiquyet.Caption = "Đang trong quá trình giải quyết";
                trangthaigiaiquyet = "Unlock";
            }
        }
        private void bar_save_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                fun_save();
                fun_null();
            }
            catch (Exception)
            {
                throw;
                //XtraMessageBox.Show("Kiểm tra lại thông tin");
            }
        }
        private void bar_refresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            fun_null();
        }
        private void bar_delete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            #region check dieukien
            if (dinhdanh.quyenhan == 2)
            {
                XtraMessageBox.Show("Không có quyền xóa");
                return;
            }

            if (check_quatrinhgiaiquyet.Caption == "Kết thúc quá trình giải quyết")
            {
                XtraMessageBox.Show("Đã kết thúc giải quyết không được phép xóa");
                return;
            }
            if(txt_ma_donthu_tocao.Text.Substring(0,4) != dinhdanh.kyhieu_donvi)
            {
                XtraMessageBox.Show("Không được xóa đơn thư tố cáo chuyển đến");
                return;
            }
            #endregion
            try
            {

                using (_khieunaitocaoContext = new khieunaitocaoContextDataContext())
                {
                    _khieunaitocaoContext.xoa_quatrinhgiaiquyettocao(id_quatrinhgiaiquyettocao);
                }
                XtraMessageBox.Show("Xóa thông tin thành công");

            }
            catch (Exception)
            {
                XtraMessageBox.Show("Vui lòng chọn thông tin cần xóa");
            }
        }
        private void form_quatrinhgiaiquyettocao_Load(object sender, EventArgs e)
        {
            load_items_donvi();
            if (bool_sua == true)
            {
                fun_edit();
            }
        }
        private void txt_ma_donthu_tocao_Leave(object sender, EventArgs e)
        {
            using (_khieunaitocaoContext = new khieunaitocaoContextDataContext())
            {
                #region check donvi
                int? i;
                i = _khieunaitocaoContext.check_madonthutocao_linq(dinhdanh.madonvi, txt_ma_donthu_tocao.Text.Trim());
                if (i == 0)
                {
                    XtraMessageBox.Show("Đơn thư không tồn tại");
                    txt_ma_donthu_tocao.Focus();
                    memo_tomtatnoidung.Text = null;
                    return;
                }
                #endregion
                var tomtatnoidung = _khieunaitocaoContext.tomtatnoidungtocao(txt_ma_donthu_tocao.Text.Trim(),dinhdanh.madonvi).SingleOrDefault();
                memo_tomtatnoidung.EditValue = tomtatnoidung.tomtat_noidung;
            }
        }
        private void combo_hinhthuc_xuly_Leave(object sender, EventArgs e)
        {
            #region check hinh thuc xu ly
            if (combo_hinhthuc_xuly.Text == "Không xử lý")
            {
                combo_donvinhan.Properties.ReadOnly = true;
                date_ngaynhan.Properties.ReadOnly = true;
                combo_donvinhan.Text = null;
                date_ngaynhan.EditValue = null;
                hinhthucxuly = 2;
                return;
            }
            if(combo_hinhthuc_xuly.Text=="Trực tiếp xử lý")
            {
                combo_donvinhan.Properties.ReadOnly = true;
                date_ngaynhan.Properties.ReadOnly = true;
                combo_donvinhan.Text = null;
                date_ngaynhan.EditValue = null;
                hinhthucxuly = 0;
                return;
            }
            if(combo_hinhthuc_xuly.Text=="Chuyển đơn vị khác")
            {
                combo_donvinhan.Properties.ReadOnly = false;
                date_ngaynhan.Properties.ReadOnly = false;
                hinhthucxuly = 1;
            }
            #endregion
        }
        private void date_tungay_giaiquyet_Leave(object sender, EventArgs e)
        {
            if (txt_songay_giaiquyet.Text != "")
            {
                int songay = Convert.ToInt32(txt_songay_giaiquyet.Text.Trim());
                DateTime dt = new DateTime();
                dt = (DateTime)date_tungay_giaiquyet.EditValue;
                date_denngay_giaiquyet.EditValue = dt.AddDays(songay);
            }
            else
            {
                return;
            }
        }

    }
}