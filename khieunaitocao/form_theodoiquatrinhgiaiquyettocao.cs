using DevExpress.XtraEditors;
using System;
using System.Linq;

namespace khieunaitocao
{
    public partial class form_theodoiquatrinhgiaiquyettocao : DevExpress.XtraEditors.XtraForm
    {
        public form_theodoiquatrinhgiaiquyettocao()
        {
            InitializeComponent();
        }

        public int id_quatrinhgiaiquyettocao;
        private khieunaitocaoContextDataContext _khieunaitocaoContext;
        private tb_giaiquyettocao objTC = new tb_giaiquyettocao();

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

        private void form_quatrinhgiaiquyettocao_Load(object sender, EventArgs e)
        {
            load_items_donvi();

            fun_edit();
        }
    }
}