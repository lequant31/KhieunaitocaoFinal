using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Filtering.Templates;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace khieunaitocao
{
    public partial class form_thongtintocao : DevExpress.XtraEditors.XtraForm
    {
        public form_thongtintocao()
        {
            InitializeComponent();
        }

        public string madontocao { get; set; }
        public bool bool_sua = false;
        public int id_thongtintocao;
        public bool bool_chuyen = false;
        public string ngaysua = "";
        private bool Re_sua = true;
        private bool Re_xoa = true;
        private string forwarded;
        private bool ketthucdon = false;
        private int donvixuly = 0;
        private khieunaitocaoContextDataContext _khieunaitocaoContext = new khieunaitocaoContextDataContext();
        private tb_thongtintocao objTC;
        private relation_donvi_thongtintocao Relation_Donvi_Thongtintocao = new relation_donvi_thongtintocao();
        private Random random = new Random();

        public int? _madonvinhan;

        private void form_thongtintocao_Load(object sender, EventArgs e)
        {
            if (rdb_dieukien_xuly.SelectedIndex == 0)
            {
                combo_lydokhongdudieukien_xuly.EditValue = null;
                combo_lydokhongdudieukien_xuly.ReadOnly = true;
            }
            var list = _khieunaitocaoContext.list_phanloai_tocao();
            treeListLookUp_loaidontocao.Properties.DataSource = list;
            treeListLookUp_loaidontocao.Properties.DisplayMember = "phanloai_tocao";
            treeListLookUp_loaidontocao.Properties.ValueMember = "ma_tocao";
            var listdonvinhan = _khieunaitocaoContext.list_donvi();
            search_donvinhan.Properties.DataSource = listdonvinhan;
            search_donvinhan.Properties.DisplayMember = "ten_donvi";
            search_donvinhan.Properties.ValueMember = "ma_donvi";
            var listthanhvien = _khieunaitocaoContext.search_thanhvien(dinhdanh.madonvi);
            lookup_macanbo.DataSource = listthanhvien;
            lookup_macanbo.DisplayMember = "ma_canbo";
            lookup_macanbo.ValueMember = "ma_canbo";
            gridColumn24.ColumnEdit = lookup_macanbo;
            if (bool_sua == false)
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
            if (rdb_dieukien_xuly.SelectedIndex == 0)
            {
                combo_lydokhongdudieukien_xuly.EditValue = null;
                combo_lydokhongdudieukien_xuly.ReadOnly = true;
            }
            txt_hoten_canhan.Text = null;
            txt_cmnd_canhan.Text = null;
            txt_diachi_canhan.Text = null;
            txt_sodienthoai_canhan.Text = null;
            txt_email_canhan.Text = null;
            txt_ngaycap_cmnd.Text = null;
            txt_noicap_cmnd.Text = null;
            txt_coquan_donvi_canhan.Text = null;

            memo_tomtat_tocao.Text = null;
            memo_ykien_chidao.Text = null;
            memo_ghichu.Text = null;
            check_duocbaove.Checked = false;
            check_duocnhanketqua.Checked = false;
            memo_yeucaukhac.Text = null;
            combo_lydokhongdudieukien_xuly.EditValue = null;
            btn_taikieudinhkem.Text = null;
            com_xulydon.Text = null;
            search_donvinhan.EditValue = null;
            txt_so_phieuchuyen.Text = null;
            date_ngay_chuyendon.EditValue = null;
            txt_socv_thongbao_chuyendon.Text = null;
            date_ngay_thongbao_chuyendon.EditValue = null;
            txt_songay_giaiquyet.Text = null;
            date_tungay_giaiquyet.EditValue = null;
            date_denngay_giaiquyet.EditValue = null;
            txt_so_quyetdinh_thuly.Text = null;
            date_ngay_thuly.EditValue = null;
            txt_donvi_thuly.Text = null;
            date_tungay_thuly.EditValue = null;
            date_denngay_thuly.EditValue = null;
            txt_so_quyetdinh_xacminh_noidung.Text = null;
            date_ngay_quyetdinh_xacminh_noidung.EditValue = null;
            date_tungay_quyetdinh_xacminh_noidung.EditValue = null;
            date_ngay_quyetdinh_xacminh_noidung.EditValue = null;
            txt_so_quyetdinh_giahan.Text = null;
            date_tungay_quyetdinh_giahan.EditValue = null;
            date_denngay_quyetdinh_giahan.EditValue = null;
            txt_so_kehoach_xacminh_noidung.Text = null;
            txt_nguoi_pheduyet_kehoach_xacminh_noidung.Text = null;
            txt_nguoi_ky_kehoach_xacminh_noidung.Text = null;
            txt_so_baocao_ketqua_xacminh.Text = null;
            date_ngay_baocao_ketqua_xacminh.EditValue = null;
            txt_nguoi_ky_baocao_ketqua_xacminh.Text = null;
            txt_so_ketluan_noidung_tocao.Text = null;
            date_ngay_ketluan_noidung_tocao.Text = null;
            com_ketqua_ketluan_noidung_tocao.Text = null;
            txt_nguoi_ky_ketluan_noidung_tocao.Text = null;
            memo_tomtat_noidung_ketluan_tocao.Text = null;
            com_danhgia_viec_giaiquyet.Text = null;
            date_ngay_rutdon.EditValue = null;
            memo_lydo_rutdon.Text = null;
            memo_khacphuc_hauqua.Text = null;
            date_ngay_ketthuc.EditValue = null;
            grc_bidon_tocao.DataSource = null;
            grc_nhatky_guidon_tocao.DataSource = null;
            grc_toxacminh.DataSource = null;
            grc_bidon_tocao.DataSource = objTC.tb_bidon_tocaos;
            grc_nhatky_guidon_tocao.DataSource = objTC.tb_nhatky_guidon_tocaos;
            grc_toxacminh.DataSource = objTC.tb_toxacminh_tocaos;
            //grv_toxacminh.OptionsBehavior.ReadOnly = true;
            search_donvinhan.ReadOnly = true;
            date_ngay_chuyendon.ReadOnly = true;
        }

        private void thongtin_addnew()
        {
            madontocao = dinhdanh.kyhieu_donvi + DateTime.Now.Year.ToString() + random.Next(1, 10000).ToString();
            txt_ma_tocao.Text = madontocao;
            objTC = new tb_thongtintocao();
            grc_bidon_tocao.DataSource = objTC.tb_bidon_tocaos;
            grv_bidon_tocao.BestFitColumns();
            grc_nhatky_guidon_tocao.DataSource = objTC.tb_nhatky_guidon_tocaos;
            grv_nhatky_guidon_tocao.BestFitColumns();
            grc_toxacminh.DataSource = objTC.tb_toxacminh_tocaos;
            grv_toxacminh.BestFitColumns();
        }

        private void thongtin_edit()
        {
            var _list_thongtintocao = _khieunaitocaoContext.xem_thongtintocao_linq(id_thongtintocao).SingleOrDefault();

            txt_ma_tocao.Text = _list_thongtintocao.ma_donthu_tocao;
            madontocao = txt_ma_tocao.Text;
            if (rdb_dieukien_xuly.SelectedIndex == 0)
            {
                combo_lydokhongdudieukien_xuly.EditValue = null;
                combo_lydokhongdudieukien_xuly.ReadOnly = true;
            }
            if (rdb_dieukien_xuly.SelectedIndex == 1)
            {
                combo_lydokhongdudieukien_xuly.ReadOnly = false;
            }
            txt_hoten_canhan.EditValue = _list_thongtintocao.ten_canhan_tochuc;
            txt_sodienthoai_canhan.EditValue = _list_thongtintocao.sdt;
            txt_email_canhan.EditValue = _list_thongtintocao.email;
            txt_cmnd_canhan.EditValue = _list_thongtintocao.so_cmnd;
            txt_ngaycap_cmnd.EditValue = _list_thongtintocao.ngaycap_cmnd;
            txt_noicap_cmnd.EditValue = _list_thongtintocao.noicap_cmnd;
            txt_diachi_canhan.EditValue = _list_thongtintocao.dia_chi;
            txt_coquan_donvi_canhan.EditValue = _list_thongtintocao.ten_cqdv_canhan;
            radio_loaidanh.EditValue = _list_thongtintocao.nacdanh_codanh_maodanh;
            treeListLookUp_loaidontocao.EditValue = _list_thongtintocao.ma_tocao;
            rdb_dieukien_xuly.EditValue = _list_thongtintocao.dieukien_xuly_du_hoackhong;
            btn_taikieudinhkem.EditValue = _list_thongtintocao.tailieu_dinhkem;
            combo_lydokhongdudieukien_xuly.EditValue = _list_thongtintocao.lydo_khongdu_dieukien;
            memo_tomtat_tocao.EditValue = _list_thongtintocao.tomtat_noidung;
            memo_ykien_chidao.EditValue = _list_thongtintocao.ykien_chidao;
            memo_ghichu.EditValue = _list_thongtintocao.ghi_chu;
            check_duocbaove.Checked = (bool)_list_thongtintocao.duoc_baove;
            check_duocnhanketqua.Checked = (bool)_list_thongtintocao.duoc_nhanketqua;
            memo_yeucaukhac.Text = _list_thongtintocao.yeucaukhac;
            if (_list_thongtintocao.forward == "Đã chuyển" && madontocao.Substring(0, 4) != dinhdanh.kyhieu_donvi)
            {
                com_xulydon.ReadOnly = true;
                search_donvinhan.ReadOnly = true;
                date_ngay_chuyendon.ReadOnly = true;
                txt_so_phieuchuyen.ReadOnly = true;
            }
            if (_list_thongtintocao.forward == "Đã chuyển" && madontocao.Substring(0, 4) == dinhdanh.kyhieu_donvi)
            {
                grv_toxacminh.OptionsBehavior.ReadOnly = true;
                com_xulydon.ReadOnly = true;
                search_donvinhan.ReadOnly = true;
                date_ngay_chuyendon.ReadOnly = true;
                txt_so_phieuchuyen.ReadOnly = true;
            }
            com_xulydon.EditValue = _list_thongtintocao.xulydon;
            search_donvinhan.EditValue = _list_thongtintocao.donvinhan;
            txt_so_phieuchuyen.EditValue = _list_thongtintocao.so_phieuchuyen;
            date_ngay_chuyendon.EditValue = _list_thongtintocao.ngay_chuyendon;
            txt_socv_thongbao_chuyendon.EditValue = _list_thongtintocao.socv_thongbao_chuyendon;
            date_ngay_thongbao_chuyendon.EditValue = _list_thongtintocao.ngay_thongbao_chuyendon;
            txt_songay_giaiquyet.EditValue = _list_thongtintocao.songay_giaiquyet;
            date_tungay_giaiquyet.EditValue = _list_thongtintocao.tungay_giaiquyet;
            date_denngay_giaiquyet.EditValue = _list_thongtintocao.denngay_giaiquyet;
            txt_so_quyetdinh_thuly.EditValue = _list_thongtintocao.so_quyetdinh_thuly;
            date_ngay_thuly.EditValue = _list_thongtintocao.ngay_thuly;
            txt_donvi_thuly.EditValue = _list_thongtintocao.donvi_thuly;
            date_tungay_thuly.EditValue = _list_thongtintocao.tungay_thuly;
            date_denngay_thuly.EditValue = _list_thongtintocao.denngay_thuly;
            txt_so_quyetdinh_xacminh_noidung.EditValue = _list_thongtintocao.so_quyetdinh_xacminh_noidung;
            date_ngay_quyetdinh_xacminh_noidung.EditValue = _list_thongtintocao.ngay_quyetdinh_xacminh_noidung;
            date_tungay_quyetdinh_xacminh_noidung.EditValue = _list_thongtintocao.tungay_quyetdinh_xacminh_noidung;
            date_denngay_quyetdinh_xacminh_noidung.EditValue = _list_thongtintocao.denngay_quyetdinh_xacminh_noidung;
            txt_so_quyetdinh_giahan.EditValue = _list_thongtintocao.so_quyetdinh_giahan;
            date_tungay_quyetdinh_giahan.EditValue = _list_thongtintocao.tungay_quyetdinh_giahan;
            date_denngay_quyetdinh_giahan.EditValue = _list_thongtintocao.denngay_quyetdinh_giahan;
            txt_so_kehoach_xacminh_noidung.EditValue = _list_thongtintocao.so_kehoach_xacminh_noidung;
            txt_nguoi_pheduyet_kehoach_xacminh_noidung.EditValue = _list_thongtintocao.nguoi_pheduyet_kehoach_xacminh_noidung;
            txt_nguoi_ky_kehoach_xacminh_noidung.EditValue = _list_thongtintocao.nguoi_ky_kehoach_xacminh_noidung;
            txt_so_baocao_ketqua_xacminh.EditValue = _list_thongtintocao.so_baocao_ketqua_xacminh;
            date_ngay_baocao_ketqua_xacminh.EditValue = _list_thongtintocao.ngay_baocao_ketqua_xacminh;
            txt_nguoi_ky_baocao_ketqua_xacminh.EditValue = _list_thongtintocao.nguoi_ky_baocao_ketqua_xacminh;
            txt_so_ketluan_noidung_tocao.EditValue = _list_thongtintocao.so_ketluan_noidung_tocao;
            date_ngay_ketluan_noidung_tocao.EditValue = _list_thongtintocao.ngay_ketluan_noidung_tocao;
            com_ketqua_ketluan_noidung_tocao.EditValue = _list_thongtintocao.ketqua_ketluan_noidung_tocao;
            txt_nguoi_ky_ketluan_noidung_tocao.EditValue = _list_thongtintocao.nguoi_ky_ketluan_noidung_tocao;
            memo_tomtat_noidung_ketluan_tocao.EditValue = _list_thongtintocao.tomtat_noidung_ketluan_tocao;
            com_danhgia_viec_giaiquyet.EditValue = _list_thongtintocao.danhgia_viec_giaiquyet;
            date_ngay_rutdon.EditValue = _list_thongtintocao.ngay_rutdon;
            memo_lydo_rutdon.EditValue = _list_thongtintocao.lydo_rutdon;
            memo_khacphuc_hauqua.EditValue = _list_thongtintocao.khacphuc_hauqua;
            date_ngay_ketthuc.EditValue = _list_thongtintocao.ngay_ketthuc;
            forwarded = _list_thongtintocao.forward;
            ngaysua = _list_thongtintocao.ngaygio_sua + " "+ dinhdanh.sohieu_cand+" " + DateTime.Now.ToString();
            objTC = _khieunaitocaoContext.tb_thongtintocaos.Single(p => p.id_thongtintocao == id_thongtintocao);
            grc_bidon_tocao.DataSource = objTC.tb_bidon_tocaos;
            grc_nhatky_guidon_tocao.DataSource = objTC.tb_nhatky_guidon_tocaos;
            grc_toxacminh.DataSource = objTC.tb_toxacminh_tocaos;
            grv_bidon_tocao.RefreshData();
            grv_nhatky_guidon_tocao.RefreshData();
            grv_toxacminh.RefreshData();
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
           
            if (txt_ma_tocao.Text.Substring(0, 4) != dinhdanh.kyhieu_donvi)
            {
                XtraMessageBox.Show("Không được quyền xóa");
                return;
            }

            #endregion check permission

            try
            {
                var del = _khieunaitocaoContext.tb_thongtintocaos.Single(p => p.id_thongtintocao == id_thongtintocao);
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

                if (string.IsNullOrEmpty(txt_ma_tocao.Text) || string.IsNullOrWhiteSpace(txt_ma_tocao.Text))
                {
                    XtraMessageBox.Show("Vui lòng nhập đơn khiếu nại");
                    txt_ma_tocao.Focus();
                    return;
                }

                if (dinhdanh.quyenhan == 2)
                {
                    XtraMessageBox.Show("Tài khoản chỉ có quyền xem.\n Không được phép thay đổi");
                    return;
                }

                if (treeListLookUp_loaidontocao.EditValue == null)
                {
                    XtraMessageBox.Show("Vui lòng chọn loại đơn khiếu nại");
                    treeListLookUp_loaidontocao.Focus();
                    return;
                }

                if (bool_sua == false)
                {
                    //var _lst = _khieunaitocaoContext.tb_thongtinkhieunais.Where(p => p.ma_donthu_khieunai == txt_madonthu.Text.Trim()).FirstOrDefault();
                    int _lst = _khieunaitocaoContext.check_matocao(dinhdanh.madonvi, madontocao);
                    if (_lst == 1)
                    {
                        XtraMessageBox.Show("Mã đơn thư tố cáo đã tồn tại");
                        txt_ma_tocao.Focus();
                        return;
                    }
                }
                if (bool_sua == true)
                {
                    using (khieunaitocaoContextDataContext khieunaitocaoContext = new khieunaitocaoContextDataContext())
                    {
                        var checksua = khieunaitocaoContext.check_suatocao(id_thongtintocao, dinhdanh.madonvi).SingleOrDefault();
                        if (checksua.sua == false || checksua.ketthucdon == true)
                        {
                            XtraMessageBox.Show("Không được quyền sửa");
                            return;
                        }
                    }
                }

                #endregion kiemtra

                if (bool_sua == true)
                {
                    objTC = _khieunaitocaoContext.tb_thongtintocaos.Where(a => a.id_thongtintocao == id_thongtintocao).SingleOrDefault();
                    var relation = objTC.relation_donvi_thongtintocaos.Single(x => x.id_thongtintocao == id_thongtintocao && x.id_donvi == dinhdanh.madonvi);
                    relation.sua = Re_sua;
                    relation.xoa = Re_xoa;
                }

                objTC.ten_canhan_tochuc = txt_hoten_canhan.Text;
                objTC.sdt = txt_sodienthoai_canhan.Text;
                objTC.email = txt_email_canhan.Text;
                objTC.so_cmnd = txt_cmnd_canhan.Text;
                objTC.ngaycap_cmnd = (DateTime?)txt_ngaycap_cmnd.EditValue;
                objTC.noicap_cmnd = txt_noicap_cmnd.Text;
                objTC.dia_chi = txt_diachi_canhan.Text;
                objTC.ten_cqdv_canhan = txt_coquan_donvi_canhan.Text;
                objTC.ma_tocao = treeListLookUp_loaidontocao.EditValue.ToString();
                objTC.nacdanh_codanh_maodanh = (byte)radio_loaidanh.SelectedIndex;
                objTC.dieukien_xuly_du_hoackhong = (bool)rdb_dieukien_xuly.EditValue;
                objTC.lydo_khongdu_dieukien = combo_lydokhongdudieukien_xuly.Text;
                objTC.tailieu_dinhkem = btn_taikieudinhkem.Text;
                objTC.tomtat_noidung = memo_tomtat_tocao.Text;
                objTC.ykien_chidao = memo_ykien_chidao.Text;
                objTC.ghi_chu = memo_ghichu.Text;
                objTC.duoc_nhanketqua = check_duocnhanketqua.Checked;
                objTC.duoc_baove = check_duocbaove.Checked;
                objTC.yeucaukhac = memo_yeucaukhac.Text;
                objTC.xulydon = com_xulydon.Text;
                objTC.songay_giaiquyet = txt_songay_giaiquyet.Text;
                objTC.tungay_giaiquyet = (DateTime?)date_tungay_giaiquyet.EditValue;
                objTC.denngay_giaiquyet = (DateTime?)date_denngay_giaiquyet.EditValue;
                objTC.so_quyetdinh_thuly = txt_so_quyetdinh_thuly.Text;
                objTC.ngay_thuly = (DateTime?)date_ngay_thuly.EditValue;
                objTC.donvi_thuly = txt_donvi_thuly.Text;
                objTC.tungay_thuly = (DateTime?)date_tungay_thuly.EditValue;
                objTC.denngay_thuly = (DateTime?)date_denngay_thuly.EditValue;
                objTC.so_quyetdinh_xacminh_noidung = txt_so_quyetdinh_xacminh_noidung.Text;
                objTC.ngay_quyetdinh_xacminh_noidung = (DateTime?)date_ngay_quyetdinh_xacminh_noidung.EditValue;
                objTC.tungay_quyetdinh_xacminh_noidung = (DateTime?)date_tungay_quyetdinh_xacminh_noidung.EditValue;
                objTC.denngay_quyetdinh_xacminh_noidung = (DateTime?)date_denngay_quyetdinh_xacminh_noidung.EditValue;
                objTC.so_quyetdinh_giahan = txt_so_quyetdinh_giahan.Text;
                objTC.tungay_quyetdinh_giahan = (DateTime?)date_tungay_quyetdinh_giahan.EditValue;
                objTC.denngay_quyetdinh_giahan = (DateTime?)date_denngay_quyetdinh_giahan.EditValue;
                objTC.so_kehoach_xacminh_noidung = txt_so_kehoach_xacminh_noidung.Text;
                objTC.nguoi_pheduyet_kehoach_xacminh_noidung = txt_nguoi_pheduyet_kehoach_xacminh_noidung.Text;
                objTC.nguoi_ky_kehoach_xacminh_noidung = txt_nguoi_ky_kehoach_xacminh_noidung.Text;
                objTC.so_baocao_ketqua_xacminh = txt_so_baocao_ketqua_xacminh.Text;
                objTC.ngay_baocao_ketqua_xacminh = (DateTime?)date_ngay_baocao_ketqua_xacminh.EditValue;
                objTC.nguoi_ky_baocao_ketqua_xacminh = txt_nguoi_ky_baocao_ketqua_xacminh.Text;
                objTC.so_ketluan_noidung_tocao = txt_so_ketluan_noidung_tocao.Text;
                objTC.ngay_ketluan_noidung_tocao = (DateTime?)date_ngay_ketluan_noidung_tocao.EditValue;
                objTC.ketqua_ketluan_noidung_tocao = com_ketqua_ketluan_noidung_tocao.Text;
                objTC.nguoi_ky_ketluan_noidung_tocao = txt_nguoi_ky_ketluan_noidung_tocao.Text;
                objTC.tomtat_noidung_ketluan_tocao = memo_tomtat_noidung_ketluan_tocao.Text;
                objTC.danhgia_viec_giaiquyet = com_danhgia_viec_giaiquyet.Text;
                objTC.ngay_rutdon = (DateTime?)date_ngay_rutdon.EditValue;
                objTC.lydo_rutdon = memo_lydo_rutdon.Text;
                objTC.khacphuc_hauqua = memo_khacphuc_hauqua.Text;
                objTC.ngay_ketthuc = (DateTime?)date_ngay_ketthuc.EditValue;

                if (madontocao.Substring(0, 4) == dinhdanh.kyhieu_donvi)
                {
                    objTC.forward = forwarded;
                    if (search_donvinhan.EditValue != null)
                    {
                        objTC.donvinhan = (int)search_donvinhan.EditValue;
                    }
                    else
                    {
                        objTC.donvinhan = donvixuly;
                    }
                    objTC.so_phieuchuyen = txt_so_phieuchuyen.Text;
                    objTC.socv_thongbao_chuyendon = txt_socv_thongbao_chuyendon.Text;
                    objTC.ngay_thongbao_chuyendon = (DateTime?)date_ngay_thongbao_chuyendon.EditValue;
                    objTC.ngay_chuyendon = (DateTime?)date_ngay_chuyendon.EditValue;
                }

                objTC.ngaygio_nhap = DateTime.Now;
                objTC.ngaygio_sua = ngaysua + " " + dinhdanh.sohieu_cand;
                if (date_ngay_ketthuc.EditValue != null)
                {
                    ketthucdon = true;
                }
                objTC.ketthucdon = ketthucdon;
                if (bool_sua == false)
                {
                    objTC.ma_canbo_nhapdulieu = dinhdanh.ma_canbo;
                    Relation_Donvi_Thongtintocao.id_donvi = dinhdanh.madonvi;
                    Relation_Donvi_Thongtintocao.hinhthucxuly = "Main";
                    Relation_Donvi_Thongtintocao.sua = Re_sua;
                    Relation_Donvi_Thongtintocao.xoa = Re_xoa;
                    Relation_Donvi_Thongtintocao.tb_thongtintocao = objTC;
                    objTC.ma_donthu_tocao = madontocao;
                    _khieunaitocaoContext.tb_thongtintocaos.InsertOnSubmit(objTC);
                }
                _khieunaitocaoContext.SubmitChanges();
                /////////////////////////////////////////////////////////
                XtraMessageBox.Show("Đã lưu được");
                thongtin_load();
                thongtin_addnew();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Thông báo lỗi ",ex.Message) ;
            }
        }

        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa thông tin?", "Confirmation", MessageBoxButtons.YesNo) !=
               DialogResult.Yes)
                return;
            grv_toxacminh.DeleteSelectedRows();
        }

        private void grv_toxacminh_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "id_canbochiensy")
            {
                var value = grv_toxacminh.GetRowCellValue(e.RowHandle, e.Column);
                var ls = _khieunaitocaoContext.tb_canbochiensies.FirstOrDefault(x => x.ma_canbo == (int)value);
                if (ls != null)
                {
                    grv_toxacminh.SetRowCellValue(e.RowHandle, "hotentxm", ls.hoten_chiensy);
                    grv_toxacminh.SetRowCellValue(e.RowHandle, "sohieu_candtxm", ls.sohieu_cand);
                    grv_toxacminh.SetRowCellValue(e.RowHandle, "capbactxm", ls.capbac);
                    grv_toxacminh.SetRowCellValue(e.RowHandle, "chucvutxm", ls.chucvu);
                }
            }
        }

        private void com_xulydon_SelectedValueChanged(object sender, EventArgs e)
        {
            if (com_xulydon.Text != "Chuyển đơn vị khác" || com_xulydon.Text != "Chuyển đơn vị ngoài CAND")
            {
                Re_sua = true;
                forwarded = "";
                search_donvinhan.ReadOnly = true;
                date_ngay_chuyendon.ReadOnly = true;
                txt_so_phieuchuyen.ReadOnly = true;
                txt_socv_thongbao_chuyendon.ReadOnly = true;
                date_ngay_thongbao_chuyendon.ReadOnly = true;
            }
            if (com_xulydon.Text == "Chuyển đơn vị khác")
            {
                Re_sua = false;
                forwarded = "Chưa chuyển";
                search_donvinhan.ReadOnly = false;
                date_ngay_chuyendon.ReadOnly = false;
                txt_so_phieuchuyen.ReadOnly = false;
                txt_socv_thongbao_chuyendon.ReadOnly = false;
                date_ngay_thongbao_chuyendon.ReadOnly = false;
            }
            if (com_xulydon.Text == "Chuyển đơn vị ngoài CAND")
            {
                Re_sua = false;
                forwarded = "Đã chuyển";
                search_donvinhan.ReadOnly = false;
                date_ngay_chuyendon.ReadOnly = false;
                txt_so_phieuchuyen.ReadOnly = false;
                txt_socv_thongbao_chuyendon.ReadOnly = false;
                date_ngay_thongbao_chuyendon.ReadOnly = false;
            }
            if (com_xulydon.Text == "Trực tiếp xử lý")
            {
                donvixuly = dinhdanh.madonvi;
            }
        }

        private void date_ngay_ketthuc_EditValueChanged(object sender, EventArgs e)
        {
            if (date_ngay_ketthuc.EditValue != null)
            {
                Re_sua = false;
                //Re_xoa = false;
                XtraMessageBox.Show("Không thể sửa xóa khi đã kết thúc");
            }
        }

        private void rdb_dieukien_xuly_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(rdb_dieukien_xuly.SelectedIndex == 0)
            {
                combo_lydokhongdudieukien_xuly.Text = null;
                combo_lydokhongdudieukien_xuly.ReadOnly = true;
            }
            if (rdb_dieukien_xuly.SelectedIndex == 1)
            {
                combo_lydokhongdudieukien_xuly.ReadOnly = false;
            }
        }
    }
}