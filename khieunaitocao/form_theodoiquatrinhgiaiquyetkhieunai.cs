using DevExpress.XtraEditors;
using System;
using System.Linq;

namespace khieunaitocao
{
    public partial class form_theodoiquatrinhgiaiquyetkhieunai : DevExpress.XtraEditors.XtraForm
    {
        public form_theodoiquatrinhgiaiquyetkhieunai()
        {
            InitializeComponent();
        }

        public int id_quatrinhgiaiquyetkhieunai;
        private khieunaitocaoContextDataContext _khieunaitocaoContext;

        private void load_items_donvi()
        {
            try
            {
                using (_khieunaitocaoContext = new khieunaitocaoContextDataContext())
                {
                    var look = _khieunaitocaoContext.list_donvi().ToList();
                    look_donvinhan.Properties.DataSource = look;
                    look_donvinhan.Properties.DisplayMember = "ten_donvi";
                    look_donvinhan.Properties.ValueMember = "ma_donvi";
                }
            }
            catch (Exception)
            {
                //throw;
                XtraMessageBox.Show("Vui lòng kiểm tra lại kết nối mạng");
            }
        }

        private void load_sua()
        {
            using (_khieunaitocaoContext = new khieunaitocaoContextDataContext())
            {
                var _sua = _khieunaitocaoContext.xem_thongtin_quatrinhgiaiquyet_linq(id_quatrinhgiaiquyetkhieunai).SingleOrDefault();
                txt_madonthukhieunai.Text = _sua.ma_donthu_khieunai;
                txt_lankhieunaithu.Text = _sua.solan_khieunai;
                if (_sua.hinhthuc_xuly == "Chuyển đơn vị khác")
                {
                    com_hinhthucxuly.Text = "Chuyển đơn vị khác";
                    look_donvinhan.Properties.ReadOnly = false;
                    date_ngaychuyen.Properties.ReadOnly = false;
                }
                if (_sua.hinhthuc_xuly == "Trực tiếp xử lý")
                {
                    com_hinhthucxuly.Text = "Trực tiếp xử lý";
                    look_donvinhan.Properties.ReadOnly = true;
                    date_ngaychuyen.Properties.ReadOnly = true;
                }
                if (_sua.hinhthuc_xuly == "Không xử lý")
                {
                    com_hinhthucxuly.Text = "Không xử lý";
                    look_donvinhan.Properties.ReadOnly = true;
                    date_ngaychuyen.Properties.ReadOnly = true;
                }
                look_donvinhan.EditValue = _sua.donvinhan;
                date_ngaychuyen.EditValue = _sua.ngaynhan;
                com_capgiaiquyet.EditValue = _sua.capgiaiquyet;
                com_dvchiutrachnhiem.EditValue = _sua.dv_chiutrachnhiem_giaiquyet;
                mem_noidungdonthu.EditValue = _sua.noidungdonthu;
                txt_socongvan.Text = _sua.so_congvan;
                date_ngay_socongvan.EditValue = _sua.ngaytao_congvan;
                txt_songaygiaiquyet.Text = _sua.songay_giaiquyet;
                date_ngaygiaiquyet_tungay.EditValue = _sua.ngaybatdau_giaiquyet;
                date_ngaygiaiquyet_denngay.EditValue = _sua.ngayketthuc_giaiquyet;
                rdb_hinhthucxacminh.EditValue = _sua.hinhthuc_xacminh;
                txt_so_kehoachxacminh.Text = _sua.so_kehoach_xacminh;
                date_ngay_kehoachxacminh.EditValue = _sua.ngaylap_kehoachxacminh;
                txt_so_quyetdinhthanhlap.Text = _sua.so_quyetdinh_thanhlap;
                date_ngay_quyetdinhthanhlap.EditValue = _sua.ngaylap_quyetdinh_thanhlap;
                txt_so_ngayxacminh.Text = _sua.so_ngayxacminh;
                date_tungay_xacminh.EditValue = _sua.ngay_batdauxacminh;
                date_denngay_xacminh.EditValue = _sua.ngay_ketthucxacminh;
                txt_ten_totruong.Text = _sua.totruong_xacminh;
                com_capbac.EditValue = _sua.capbac_totruong;
                com_chucvu.EditValue = _sua.chuvu_totruong;
                mem_thanhvientrongdoan.EditValue = _sua.thanhvien_trongdoan;
                txt_ten_cabothuly.Text = _sua.cabo_thuly;
                txt_lanhdaophutrach.Text = _sua.lanhdao_phutrach;
                com_ketquaxacminh.EditValue = _sua.ketqua_xacminh;
                date_ngayrut.EditValue = _sua.ngayrut_khieunai;
                rdb_danhgiaviec_giaiquyet.EditValue = _sua.danhgia_viec_giaiquyet;
                rdb_bidon_dongy_hoac_khong.EditValue = _sua.bidon_co_dongy_ketqua;
                mem_tomtatketqua_giaiquyet.EditValue = _sua.tomtat_ketqua_giaiquyet;
                txt_khongxetthidua.EditValue = _sua.so_cb_khongduoc_xetthidua;
                txt_bikiemdiem.EditValue = _sua.so_cb_bikiemdiem;
                txt_bikhientrach.EditValue = _sua.so_cb_bikhientrach;
                txt_bicanhcao.EditValue = _sua.so_cb_bicanhcao;
                txt_bigiancap_haluong.EditValue = _sua.so_cb_bigiangcap;
                txt_bicachchuc.EditValue = _sua.so_cb_bigiangchuc;
                txt_xulyhinhsu.EditValue = _sua.so_cb_xuly_hinhsu;
                txt_tuocdanhhieu.EditValue = _sua.so_cb_bituocdanhhieu;
                txt_taptheduocminhoan.EditValue = _sua.so_tapthe_duocminhoan;
                txt_canhanduocminhoan.EditValue = _sua.so_canhan_duocminhoan;
                txt_khoiphucloiich.Text = _sua.khoiphuc_loiich_nhandan;
                txt_thuhoitaisan.Text = _sua.thuhoi_taisan;
            }
        }

        private void form_quatrinhgiaiquyetkhieunai_Load(object sender, EventArgs e)
        {
            load_items_donvi();

            load_sua();
        }
    }
}