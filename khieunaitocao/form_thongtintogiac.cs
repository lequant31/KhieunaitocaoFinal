using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace khieunaitocao
{
    public partial class form_thongtintogiac : DevExpress.XtraEditors.XtraForm
    {
        public form_thongtintogiac()
        {
            InitializeComponent();
        }

        public string madontogiac { get; set; }
        public bool bool_sua = false;
        public int id_thongtintogiac;
        public bool bool_chuyen = false;
        public string ngaysua = "";
        private bool Re_sua = true;
        private bool Re_xoa = true;
        private string forwarded;
        private bool ketthucdon = false;
        private int donvixuly = 0;
        private khieunaitocaoContextDataContext _khieunaitocaoContext = new khieunaitocaoContextDataContext();
        private tb_thongtintogiac objTC;
        private relation_donvi_thongtintogiac Relation_Donvi_Thongtintogiac = new relation_donvi_thongtintogiac();
        private Random random = new Random();

        public int? _madonvinhan;

        private void form_thongtintocao_Load(object sender, EventArgs e)
        {
            var listdonvinhan = _khieunaitocaoContext.list_donvi();
            search_donvinhan.Properties.DataSource = listdonvinhan;
            search_donvinhan.Properties.DisplayMember = "ten_donvi";
            search_donvinhan.Properties.ValueMember = "ma_donvi";

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
            objTC = new tb_thongtintogiac();
            bool_sua = false;
            if (rdb_dieukien_xuly.SelectedIndex != 0)
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
            memo_tomtat_togiac.Text = null;
            memo_ykien_chidao.Text = null;
            memo_ghichu.Text = null;
            combo_lydokhongdudieukien_xuly.EditValue = null;
            btn_taikieudinhkem.Text = null;
            com_xulydon.Text = null;
            search_donvinhan.EditValue = null;
            date_ngay_chuyendon.EditValue = null;
            txt_socv_thongbao_chuyendon.Text = null;
            date_ngay_thongbao_chuyendon.EditValue = null;
            txt_songay_giaiquyet.Text = null;
            date_tungay_giaiquyet.EditValue = null;
            date_denngay_giaiquyet.EditValue = null;
            memo_tomtat_noidung_ketluan_tocao.Text = null;
            date_ngay_ketthuc.EditValue = null;
            grc_nhatky_guidon_togiac.DataSource = null;
            //grv_toxacminh.OptionsBehavior.ReadOnly = true;
            search_donvinhan.ReadOnly = true;
            date_ngay_chuyendon.ReadOnly = true;
        }

        private void thongtin_addnew()
        {
            madontogiac = dinhdanh.kyhieu_donvi + DateTime.Now.Year.ToString() + random.Next(1, 10000).ToString();
            txt_ma_togiac.Text = madontogiac;
            objTC = new tb_thongtintogiac();
            grc_bidon.DataSource = objTC.tb_bidon_togiacs;
            grv_bidon.BestFitColumns();
            grc_nhatky_guidon_togiac.DataSource = objTC.tb_nhatky_guidon_togiacs;
            grv_nhatky_guidon_tocao.BestFitColumns();
        }

        private void thongtin_edit()
        {
            var _list_thongtintocao = _khieunaitocaoContext.xem_thongtintogiac(id_thongtintogiac).SingleOrDefault();

            txt_ma_togiac.Text = _list_thongtintocao.ma_donthu_togiac;
            madontogiac = txt_ma_togiac.Text;
            if (rdb_dieukien_xuly.SelectedIndex == 0)
            {
                combo_lydokhongdudieukien_xuly.EditValue = null;
                combo_lydokhongdudieukien_xuly.ReadOnly = true;
            }
            if (rdb_dieukien_xuly.SelectedIndex == 1)
            {
                combo_lydokhongdudieukien_xuly.ReadOnly = false;
            }
            switch (_list_thongtintocao.nacdanh_codanh_maodanh)
            {
                case "Có danh":
                    radio_loaidanh.SelectedIndex = 0;
                    break;
                case "Nặc danh":
                    radio_loaidanh.SelectedIndex = 1;
                    break;
                case "Mạo danh":
                    radio_loaidanh.SelectedIndex = 2;
                    break;
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
            combo_loaidontogiac.EditValue = _list_thongtintocao.loai_don_togiac;
            rdb_dieukien_xuly.EditValue = _list_thongtintocao.dieukien_xuly_du_hoackhong;
            btn_taikieudinhkem.EditValue = _list_thongtintocao.tailieu_dinhkem;
            combo_lydokhongdudieukien_xuly.EditValue = _list_thongtintocao.lydo_khongdu_dieukien;
            memo_tomtat_togiac.EditValue = _list_thongtintocao.tomtat_noidung;
            memo_ykien_chidao.EditValue = _list_thongtintocao.ykien_chidao;
            memo_ghichu.EditValue = _list_thongtintocao.ghi_chu;
            if (_list_thongtintocao.forward == "Đã chuyển" && madontogiac.Substring(0, 4) != dinhdanh.kyhieu_donvi)
            {
                com_xulydon.ReadOnly = true;
                search_donvinhan.ReadOnly = true;
                date_ngay_chuyendon.ReadOnly = true;
            }
            if (_list_thongtintocao.forward == "Đã chuyển" && madontogiac.Substring(0, 4) == dinhdanh.kyhieu_donvi)
            {
                com_xulydon.ReadOnly = true;
                search_donvinhan.ReadOnly = true;
                date_ngay_chuyendon.ReadOnly = true;
            }
            com_xulydon.EditValue = _list_thongtintocao.xulydon;
            search_donvinhan.EditValue = _list_thongtintocao.donvinhan;
            date_ngay_chuyendon.EditValue = _list_thongtintocao.ngay_chuyendon;
            txt_socv_thongbao_chuyendon.EditValue = _list_thongtintocao.socv_thongbao_chuyendon;
            date_ngay_thongbao_chuyendon.EditValue = _list_thongtintocao.ngay_thongbao_chuyendon;
            txt_songay_giaiquyet.EditValue = _list_thongtintocao.songay_giaiquyet;
            date_tungay_giaiquyet.EditValue = _list_thongtintocao.tungay_giaiquyet;
            date_denngay_giaiquyet.EditValue = _list_thongtintocao.denngay_giaiquyet;
            memo_tomtat_noidung_ketluan_tocao.EditValue = _list_thongtintocao.tomtat_noidung_ketluan_togiac;
            date_ngay_ketthuc.EditValue = _list_thongtintocao.ngay_ketthuc;
            forwarded = _list_thongtintocao.forward;
            ngaysua = _list_thongtintocao.ngaygio_sua + " " + dinhdanh.sohieu_cand + " " + DateTime.Now.ToString();
            objTC = _khieunaitocaoContext.tb_thongtintogiacs.Single(p => p.id_thongtintogiac == id_thongtintogiac);
            grc_bidon.DataSource = objTC.tb_bidon_togiacs;
            grc_nhatky_guidon_togiac.DataSource = objTC.tb_nhatky_guidon_togiacs;
            grv_bidon.RefreshData();
            grv_nhatky_guidon_tocao.RefreshData();
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

            if (txt_ma_togiac.Text.Substring(0, 4) != dinhdanh.kyhieu_donvi)
            {
                XtraMessageBox.Show("Không được quyền xóa");
                return;
            }

            #endregion check permission

            try
            {
                var del = _khieunaitocaoContext.tb_thongtintogiacs.Single(p => p.id_thongtintogiac == id_thongtintogiac);
                if (MessageBox.Show("Bạn có muốn xóa thông tin?", "Confirmation", MessageBoxButtons.YesNo) !=
                 DialogResult.Yes)
                    return;
                _khieunaitocaoContext.tb_thongtintogiacs.DeleteOnSubmit(del);
                _khieunaitocaoContext.SubmitChanges();
                MessageBox.Show("Xóa thông tin thành công");
            }
            catch (Exception)
            {
                MessageBox.Show("Xóa thông tin thất bại");
                throw;
            }
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

                if (string.IsNullOrEmpty(txt_ma_togiac.Text) || string.IsNullOrWhiteSpace(txt_ma_togiac.Text))
                {
                    XtraMessageBox.Show("Vui lòng nhập đơn khiếu nại");
                    txt_ma_togiac.Focus();
                    return;
                }

                if (dinhdanh.quyenhan == 2)
                {
                    XtraMessageBox.Show("Tài khoản chỉ có quyền xem.\n Không được phép thay đổi");
                    return;
                }

                if (combo_loaidontogiac.EditValue == null)
                {
                    XtraMessageBox.Show("Vui lòng chọn loại đơn khiếu nại");
                    combo_loaidontogiac.Focus();
                    return;
                }

                if (bool_sua == false)
                {
                    //var _lst = _khieunaitocaoContext.tb_thongtinkhieunais.Where(p => p.ma_donthu_khieunai == txt_madonthu.Text.Trim()).FirstOrDefault();
                    int _lst = _khieunaitocaoContext.check_matogiac(dinhdanh.madonvi, madontogiac);
                    if (_lst == 1)
                    {
                        XtraMessageBox.Show("Mã đơn thư tố cáo đã tồn tại");
                        txt_ma_togiac.Focus();
                        return;
                    }
                }
                if (bool_sua == true)
                {
                    using (khieunaitocaoContextDataContext khieunaitocaoContext = new khieunaitocaoContextDataContext())
                    {
                        var checksua = khieunaitocaoContext.check_suatogiac(id_thongtintogiac, dinhdanh.madonvi).SingleOrDefault();
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
                    objTC = _khieunaitocaoContext.tb_thongtintogiacs.Where(a => a.id_thongtintogiac == id_thongtintogiac).SingleOrDefault();
                    var relation = objTC.relation_donvi_thongtintogiacs.Single(x => x.id_thongtintogiac == id_thongtintogiac && x.id_donvi == dinhdanh.madonvi);
                    relation.sua = Re_sua;
                    relation.xoa = Re_xoa;
                }
                switch (radio_loaidanh.SelectedIndex)
                {
                    case 0:
                        objTC.nacdanh_codanh_maodanh = "Có danh";
                        break;
                    case 1:
                        objTC.nacdanh_codanh_maodanh = "Nặc danh";
                        break;
                    case 2:
                        objTC.nacdanh_codanh_maodanh = "Mạo danh";
                        break;
                }
                
                objTC.ten_canhan_tochuc = txt_hoten_canhan.Text;
                objTC.sdt = txt_sodienthoai_canhan.Text;
                objTC.email = txt_email_canhan.Text;
                objTC.so_cmnd = txt_cmnd_canhan.Text;
                objTC.ngaycap_cmnd = (DateTime?)txt_ngaycap_cmnd.EditValue;
                objTC.noicap_cmnd = txt_noicap_cmnd.Text;
                objTC.dia_chi = txt_diachi_canhan.Text;
                objTC.ten_cqdv_canhan = txt_coquan_donvi_canhan.Text;
                objTC.dieukien_xuly_du_hoackhong = (bool)rdb_dieukien_xuly.EditValue;
                objTC.lydo_khongdu_dieukien = combo_lydokhongdudieukien_xuly.Text;
                objTC.tailieu_dinhkem = btn_taikieudinhkem.Text;
                objTC.tomtat_noidung = memo_tomtat_togiac.Text;
                objTC.ykien_chidao = memo_ykien_chidao.Text;
                objTC.ghi_chu = memo_ghichu.Text;
                objTC.xulydon = com_xulydon.Text;
                objTC.songay_giaiquyet = txt_songay_giaiquyet.Text;
                objTC.tungay_giaiquyet = (DateTime?)date_tungay_giaiquyet.EditValue;
                objTC.denngay_giaiquyet = (DateTime?)date_denngay_giaiquyet.EditValue;
                
                objTC.tomtat_noidung_ketluan_togiac = memo_tomtat_noidung_ketluan_tocao.Text;
               
                objTC.ngay_ketthuc = (DateTime?)date_ngay_ketthuc.EditValue;

                if (madontogiac.Substring(0, 4) == dinhdanh.kyhieu_donvi)
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
                    Relation_Donvi_Thongtintogiac.id_donvi = dinhdanh.madonvi;
                    Relation_Donvi_Thongtintogiac.hinhthucxuly = "Main";
                    Relation_Donvi_Thongtintogiac.sua = Re_sua;
                    Relation_Donvi_Thongtintogiac.xoa = Re_xoa;
                    Relation_Donvi_Thongtintogiac.tb_thongtintogiac = objTC;
                    objTC.ma_donthu_togiac = madontogiac;
                    _khieunaitocaoContext.tb_thongtintogiacs.InsertOnSubmit(objTC);
                }
                _khieunaitocaoContext.SubmitChanges();
                /////////////////////////////////////////////////////////
                XtraMessageBox.Show("Đã lưu được");
                thongtin_load();
                thongtin_addnew();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Thông báo lỗi ", ex.Message);
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
                txt_socv_thongbao_chuyendon.ReadOnly = true;
                date_ngay_thongbao_chuyendon.ReadOnly = true;
            }
            if (com_xulydon.Text == "Chuyển đơn vị khác")
            {
                Re_sua = false;
                forwarded = "Chưa chuyển";
                search_donvinhan.ReadOnly = false;
                date_ngay_chuyendon.ReadOnly = false;
                txt_socv_thongbao_chuyendon.ReadOnly = false;
                date_ngay_thongbao_chuyendon.ReadOnly = false;
            }
            if (com_xulydon.Text == "Chuyển đơn vị ngoài CAND")
            {
                Re_sua = false;
                forwarded = "Đã chuyển";
                search_donvinhan.ReadOnly = false;
                date_ngay_chuyendon.ReadOnly = false;
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
                Re_xoa = true;
                XtraMessageBox.Show("Không thể sửa xóa khi đã kết thúc");
            }
        }

        private void txt_songay_giaiquyet_EditValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_songay_giaiquyet.Text) && date_tungay_giaiquyet.EditValue != null)
            {
                date_denngay_giaiquyet.EditValue = date_tungay_giaiquyet.EditValue;
                DateTime dateTime = (DateTime)date_tungay_giaiquyet.EditValue;
                date_denngay_giaiquyet.EditValue = dateTime.AddDays(int.Parse(txt_songay_giaiquyet.Text));
            }
        }

        private void date_tungay_giaiquyet_EditValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_songay_giaiquyet.Text) && date_tungay_giaiquyet.EditValue != null)
            {
                date_denngay_giaiquyet.EditValue = date_tungay_giaiquyet.EditValue;
                DateTime dateTime = (DateTime)date_tungay_giaiquyet.EditValue;
                date_denngay_giaiquyet.EditValue = dateTime.AddDays(int.Parse(txt_songay_giaiquyet.Text));
            }
        }

        private void btn_xoa_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa thông tin?", "Confirmation", MessageBoxButtons.YesNo) !=
                 DialogResult.Yes)
                return;
            grv_bidon.DeleteSelectedRows();
        }
    }
}