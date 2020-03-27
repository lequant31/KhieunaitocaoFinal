using DevExpress.XtraEditors;
using System;
using System.Linq;

namespace khieunaitocao
{
    public partial class form_quatrinhgiaiquyetkhieunai : DevExpress.XtraEditors.XtraForm
    {
        public form_quatrinhgiaiquyetkhieunai()
        {
            InitializeComponent();
        }

        public bool bool_sua = false;
        public int id_quatrinhgiaiquyetkhieunai;
        public int _id_thongtinkhieunai;
        private khieunaitocaoContextDataContext _khieunaitocaoContext;
        public string trangthaigiaiquyet;
        public string status;
        public string checkxoasua;
        public int hinhthucxuly;

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

        private void Fun_null()
        {
            bool_sua = false;
            txt_madonthukhieunai.Text = null;
            txt_lankhieunaithu.Text = null;
            com_hinhthucxuly.Text = null;
            look_donvinhan.EditValue = null;
            date_ngaychuyen.EditValue = null;
            com_capgiaiquyet.EditValue = null;
            com_dvchiutrachnhiem.EditValue = null;
            mem_noidungdonthu.EditValue = null;
            txt_socongvan.Text = null;
            date_ngay_socongvan.EditValue = null;
            txt_songaygiaiquyet.Text = null;
            date_ngaygiaiquyet_tungay.EditValue = null;
            date_ngaygiaiquyet_denngay.EditValue = null;
            txt_so_kehoachxacminh.Text = null;
            date_ngay_kehoachxacminh.EditValue = null;
            txt_so_quyetdinhthanhlap.Text = null;
            date_ngay_quyetdinhthanhlap.EditValue = null;
            txt_so_ngayxacminh.Text = null;
            date_tungay_xacminh.EditValue = null;
            date_denngay_xacminh.EditValue = null;
            txt_ten_totruong.Text = null;
            com_capbac.EditValue = null;
            com_chucvu.EditValue = null;
            mem_thanhvientrongdoan.EditValue = null;
            txt_ten_cabothuly.Text = null;
            txt_lanhdaophutrach.Text = null;
            com_ketquaxacminh.EditValue = null;
            date_ngayrut.EditValue = null;
            mem_tomtatketqua_giaiquyet.EditValue = null;
            txt_khongxetthidua.EditValue = null;
            txt_bikiemdiem.Text = null;
            txt_bikhientrach.Text = null;
            txt_bicanhcao.Text = null;
            txt_bigiancap_haluong.Text = null;
            txt_bicachchuc.Text = null;
            txt_xulyhinhsu.Text = null;
            txt_tuocdanhhieu.Text = null;
            txt_taptheduocminhoan.Text = null;
            txt_canhanduocminhoan.Text = null;
            txt_khoiphucloiich.Text = null;
            txt_thuhoitaisan.Text = null;
        }

        private void Fun_save()
        {
            using (_khieunaitocaoContext = new khieunaitocaoContextDataContext())
            {
                #region check dieu kien

                if (dinhdanh.quyenhan == 2)
                {
                    XtraMessageBox.Show("Không được quyền thay đổi");
                    return;
                }
                if (string.IsNullOrEmpty(com_hinhthucxuly.Text))
                {
                    XtraMessageBox.Show("Chưa chọn hình thức xử lý");
                    return;
                }
                if (bool_sua == false)
                {
                    var solan = _khieunaitocaoContext.check_solangiaiquyet(dinhdanh.madonvi,txt_madonthukhieunai.Text.Trim(), txt_lankhieunaithu.Text.Trim()).ToList();
                    if (txt_lankhieunaithu.Text.Trim() != "1" && txt_lankhieunaithu.Text.Trim() != "2")
                    {
                        XtraMessageBox.Show("Vui lòng chỉ nhập số 1 cho lần đầu.\n Số 2 cho lần giải quyết tiếp theo.");
                        txt_lankhieunaithu.Text = null;
                        txt_lankhieunaithu.Focus();
                        return;
                    }
                    if (solan.Count() == 1 || solan.Count() == 2)
                    {
                        XtraMessageBox.Show("Đã khởi tạo quá trình giải quyết.");
                        return;
                    }

                }
                if (bool_sua == true)
                {
                    var _check = _khieunaitocaoContext.check_ketthucgiaiquyet(id_quatrinhgiaiquyetkhieunai).SingleOrDefault();
                    if (_check.ketthucgiaiquyet == "Lock")
                    {
                        XtraMessageBox.Show("Đã kết thúc quá trình giải quyết.\n Không thể thay đổi được.");
                        return;
                    }
                   
                }
                if (txt_madonthukhieunai.Text.Substring(0, 4) != dinhdanh.kyhieu_donvi && com_hinhthucxuly.Text.Trim()== "Chuyển đơn vị khác")
                {
                    XtraMessageBox.Show("Đơn thư không được chuyển cho đơn vị khác");
                    return;
                }
                #endregion check dieu kien
                #region check so lan khieu nai

                if (txt_lankhieunaithu.Text.Trim() != "1" && txt_lankhieunaithu.Text.Trim() != "2")
                {
                    XtraMessageBox.Show("Vui lòng chỉ nhập số 1 cho lần đầu.\n Số 2 cho lần giải quyết tiếp theo.");
                    txt_lankhieunaithu.Text = null;
                    txt_lankhieunaithu.Focus();
                    return;
                }
                if (checkxoasua == "Finish")
                {
                    XtraMessageBox.Show("Đã kết thúc giải quyết không được phép sửa");
                    return;
                }
                #endregion check so lan khieu nai
                var id_thongtinkhieunai = _khieunaitocaoContext.xem_id_thongtinkhieunai(txt_madonthukhieunai.Text.Trim(), dinhdanh.madonvi).SingleOrDefault();
                int _ID = id_thongtinkhieunai.id_thongtinhieunai;
                int? _id_ma_quatrinhgiaiquyet_guiden = id_thongtinkhieunai.ma_quatrinhgiaiquyet_donvichuyenden;
                if (com_hinhthucxuly.Text == "Không xử lý")
                {
                    status = "Finish";
                    trangthaigiaiquyet = "Lock";
                }
                if (com_hinhthucxuly.Text == "Chuyển đơn vị khác")
                {
                    status = "Finish";
                    trangthaigiaiquyet = "Lock";
                    if (date_ngaychuyen.Text == null)
                    {
                        XtraMessageBox.Show("Vui lòng chọn ngày chuyển");
                        return;
                    }
                }
                if (com_hinhthucxuly.Text == "Trực tiếp xử lý")
                {
                    if (date_ngaygiaiquyet_tungay.EditValue == null)
                    {
                        status = "No process";
                        trangthaigiaiquyet = "Unlock";
                    }
                    if (date_ngaygiaiquyet_denngay.EditValue != null && date_ngayketthuc.EditValue == null)
                    {
                        status = "Processing";
                        trangthaigiaiquyet = "Unlock";
                    }
                    if (date_ngaygiaiquyet_denngay.EditValue != null && date_ngayketthuc.EditValue != null)
                    {
                        TimeSpan timeSpan = (DateTime)date_ngayketthuc.EditValue - (DateTime)date_ngaygiaiquyet_denngay.EditValue;
                        int songay = timeSpan.Days;
                        if (songay > 0)
                        {
                            status = "Out of date";
                            trangthaigiaiquyet = "Unlock";
                        }
                        else
                        {
                            status = "Finish";
                            trangthaigiaiquyet = "Lock";
                        }
                    }
                }
                if (bool_sua == false)
                {
                    _khieunaitocaoContext.them_quatrinhgiaiquyetkhieunai_linq(_ID, txt_lankhieunaithu.Text, com_hinhthucxuly.Text, Convert.ToInt16(look_donvinhan.EditValue), look_donvinhan.Text, (DateTime?)date_ngaychuyen.EditValue, com_capgiaiquyet.Text, mem_noidungdonthu.Text, com_dvchiutrachnhiem.Text, txt_socongvan.Text, (DateTime?)date_ngay_socongvan.EditValue, txt_songaygiaiquyet.Text,
                                                                                                               (DateTime?)date_ngaygiaiquyet_tungay.EditValue, (DateTime?)date_ngaygiaiquyet_denngay.EditValue, (bool)rdb_hinhthucxacminh.EditValue, txt_so_kehoachxacminh.Text, (DateTime?)date_ngay_kehoachxacminh.EditValue, txt_so_quyetdinhthanhlap.Text, (DateTime?)date_ngay_quyetdinhthanhlap.EditValue,
                                                                                                               txt_so_ngayxacminh.Text, (DateTime?)date_tungay_xacminh.EditValue, (DateTime?)date_denngay_xacminh.EditValue, txt_ten_totruong.Text, com_capbac.Text, com_chucvu.Text, mem_thanhvientrongdoan.Text,
                                                                                                               txt_ten_cabothuly.Text, txt_lanhdaophutrach.Text, com_ketquaxacminh.Text, (DateTime?)date_ngayrut.EditValue, mem_tomtatketqua_giaiquyet.Text, (DateTime?)date_ngayketthuc.EditValue, (bool)rdb_danhgiaviec_giaiquyet.EditValue, (bool)rdb_bidon_dongy_hoac_khong.EditValue,
                                                                                                              Convert.ToInt32(txt_khongxetthidua.Text), Convert.ToInt32(txt_bikiemdiem.Text), Convert.ToInt32(txt_bikhientrach.Text), Convert.ToInt32(txt_bicanhcao.Text), Convert.ToInt32(txt_bicachchuc.Text), Convert.ToInt32(txt_bigiancap_haluong.Text), Convert.ToInt32(txt_tuocdanhhieu.Text), Convert.ToInt32(txt_xulyhinhsu.Text),
                                                                                                              Convert.ToInt32(txt_taptheduocminhoan.Text), Convert.ToInt32(txt_canhanduocminhoan.Text), txt_khoiphucloiich.Text, txt_thuhoitaisan.Text, trangthaigiaiquyet, status, DateTime.Now, "Not delivered");
                    //if (_id_ma_quatrinhgiaiquyet_guiden != null)
                    //{
                    //    _khieunaitocaoContext.sua_quatrinhgiaiquyetkhieunai_guiden_linq(_id_ma_quatrinhgiaiquyet_guiden, txt_lankhieunaithu.Text, com_capgiaiquyet.Text, mem_noidungdonthu.Text, com_dvchiutrachnhiem.Text, txt_socongvan.Text, (DateTime?)date_ngay_socongvan.EditValue, txt_songaygiaiquyet.Text,
                    //                                                                                           (DateTime?)date_ngaygiaiquyet_tungay.EditValue, (DateTime?)date_ngaygiaiquyet_denngay.EditValue, (bool)rdb_hinhthucxacminh.EditValue, txt_so_kehoachxacminh.Text, (DateTime?)date_ngay_kehoachxacminh.EditValue, txt_so_quyetdinhthanhlap.Text, (DateTime?)date_ngay_quyetdinhthanhlap.EditValue,
                    //                                                                                           txt_so_ngayxacminh.Text, (DateTime?)date_tungay_xacminh.EditValue, (DateTime?)date_denngay_xacminh.EditValue, txt_ten_totruong.Text, com_capbac.Text, com_chucvu.Text, mem_thanhvientrongdoan.Text,
                    //                                                                                           txt_ten_cabothuly.Text, txt_lanhdaophutrach.Text, com_ketquaxacminh.Text, (DateTime?)date_ngayrut.EditValue, mem_tomtatketqua_giaiquyet.Text, (DateTime?)date_ngayketthuc.EditValue, (bool)rdb_danhgiaviec_giaiquyet.EditValue, (bool)rdb_bidon_dongy_hoac_khong.EditValue,
                    //                                                                                           Convert.ToInt32(txt_khongxetthidua.Text), Convert.ToInt32(txt_bikiemdiem.Text), Convert.ToInt32(txt_bikhientrach.Text), Convert.ToInt32(txt_bicanhcao.Text), Convert.ToInt32(txt_bicachchuc.Text), Convert.ToInt32(txt_bigiancap_haluong.Text), Convert.ToInt32(txt_tuocdanhhieu.Text), Convert.ToInt32(txt_xulyhinhsu.Text),
                    //                                                                                           Convert.ToInt32(txt_taptheduocminhoan.Text), Convert.ToInt32(txt_canhanduocminhoan.Text), txt_khoiphucloiich.Text, txt_thuhoitaisan.Text);
                    //}

                    XtraMessageBox.Show("Thêm thông tin thành công");
                    Fun_null();
                }
                else
                {
                    _khieunaitocaoContext.sua_quatrinhgiaiquyetkhieunai_linq(id_quatrinhgiaiquyetkhieunai, _id_thongtinkhieunai, txt_lankhieunaithu.Text, com_hinhthucxuly.Text, Convert.ToInt16(look_donvinhan.EditValue), look_donvinhan.Text, (DateTime?)date_ngaychuyen.EditValue, com_capgiaiquyet.Text, mem_noidungdonthu.Text, com_dvchiutrachnhiem.Text, txt_socongvan.Text, (DateTime?)date_ngay_socongvan.EditValue, txt_songaygiaiquyet.Text,
                                                                                                               (DateTime?)date_ngaygiaiquyet_tungay.EditValue, (DateTime?)date_ngaygiaiquyet_denngay.EditValue, (bool)rdb_hinhthucxacminh.EditValue, txt_so_kehoachxacminh.Text, (DateTime?)date_ngay_kehoachxacminh.EditValue, txt_so_quyetdinhthanhlap.Text, (DateTime?)date_ngay_quyetdinhthanhlap.EditValue,
                                                                                                               txt_so_ngayxacminh.Text, (DateTime?)date_tungay_xacminh.EditValue, (DateTime?)date_denngay_xacminh.EditValue, txt_ten_totruong.Text, com_capbac.Text, com_chucvu.Text, mem_thanhvientrongdoan.Text,
                                                                                                               txt_ten_cabothuly.Text, txt_lanhdaophutrach.Text, com_ketquaxacminh.Text, (DateTime?)date_ngayrut.EditValue, mem_tomtatketqua_giaiquyet.Text, (DateTime?)date_ngayketthuc.EditValue, (bool)rdb_danhgiaviec_giaiquyet.EditValue, (bool)rdb_bidon_dongy_hoac_khong.EditValue,
                                                                                                               Convert.ToInt32(txt_khongxetthidua.Text), Convert.ToInt32(txt_bikiemdiem.Text), Convert.ToInt32(txt_bikhientrach.Text), Convert.ToInt32(txt_bicanhcao.Text), Convert.ToInt32(txt_bicachchuc.Text), Convert.ToInt32(txt_bigiancap_haluong.Text), Convert.ToInt32(txt_tuocdanhhieu.Text), Convert.ToInt32(txt_xulyhinhsu.Text),
                                                                                                               Convert.ToInt32(txt_taptheduocminhoan.Text), Convert.ToInt32(txt_canhanduocminhoan.Text), txt_khoiphucloiich.Text, txt_thuhoitaisan.Text, trangthaigiaiquyet, status, "Not delivered");
                    //if (_id_ma_quatrinhgiaiquyet_guiden != null)
                    //{
                    //    _khieunaitocaoContext.sua_quatrinhgiaiquyetkhieunai_guiden_linq(_id_ma_quatrinhgiaiquyet_guiden, txt_lankhieunaithu.Text, com_capgiaiquyet.Text, mem_noidungdonthu.Text, com_dvchiutrachnhiem.Text, txt_socongvan.Text, (DateTime?)date_ngay_socongvan.EditValue, txt_songaygiaiquyet.Text,
                    //                                                                                           (DateTime?)date_ngaygiaiquyet_tungay.EditValue, (DateTime?)date_ngaygiaiquyet_denngay.EditValue, (bool)rdb_hinhthucxacminh.EditValue, txt_so_kehoachxacminh.Text, (DateTime?)date_ngay_kehoachxacminh.EditValue, txt_so_quyetdinhthanhlap.Text, (DateTime?)date_ngay_quyetdinhthanhlap.EditValue,
                    //                                                                                           txt_so_ngayxacminh.Text, (DateTime?)date_tungay_xacminh.EditValue, (DateTime?)date_denngay_xacminh.EditValue, txt_ten_totruong.Text, com_capbac.Text, com_chucvu.Text, mem_thanhvientrongdoan.Text,
                    //                                                                                           txt_ten_cabothuly.Text, txt_lanhdaophutrach.Text, com_ketquaxacminh.Text, (DateTime?)date_ngayrut.EditValue, mem_tomtatketqua_giaiquyet.Text, (DateTime?)date_ngayketthuc.EditValue, (bool)rdb_danhgiaviec_giaiquyet.EditValue, (bool)rdb_bidon_dongy_hoac_khong.EditValue,
                    //                                                                                           Convert.ToInt32(txt_khongxetthidua.Text), Convert.ToInt32(txt_bikiemdiem.Text), Convert.ToInt32(txt_bikhientrach.Text), Convert.ToInt32(txt_bicanhcao.Text), Convert.ToInt32(txt_bicachchuc.Text), Convert.ToInt32(txt_bigiancap_haluong.Text), Convert.ToInt32(txt_tuocdanhhieu.Text), Convert.ToInt32(txt_xulyhinhsu.Text),
                    //                                                                                           Convert.ToInt32(txt_taptheduocminhoan.Text), Convert.ToInt32(txt_canhanduocminhoan.Text), txt_khoiphucloiich.Text, txt_thuhoitaisan.Text);
                    //}

                    XtraMessageBox.Show("Sửa thông tin thành công");
                    Fun_null();
                }
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

        private void form_quatrinhgiaiquyetkhieunai_Load(object sender, EventArgs e)
        {
            load_items_donvi();
            if (bool_sua == true)
            {
                load_sua();
            }
        }

        private void bar_luu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                Fun_save();
               
            }
            catch (Exception)
            {
                XtraMessageBox.Show("Kiểm tra lại thông tin");
            }
        }

        private void bar_xoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            #region check dieukien

            if (dinhdanh.quyenhan == 2)
            {
                XtraMessageBox.Show("Không có quyền xóa");
                return;
            }
            if (checkxoasua == "Finish")
            {
                XtraMessageBox.Show("Đã kết thúc giải quyết không được phép xóa");
                return;
            }
            if (check_quatrinhgiaiquyet.Caption == "Kết thúc quá trình giải quyết")
            {
                XtraMessageBox.Show("Đã kết thúc giải quyết không được phép xóa");
                return;
            }
           
            #endregion check dieukien

            try
            {
                using (_khieunaitocaoContext = new khieunaitocaoContextDataContext())
                {
                    _khieunaitocaoContext.xoa_quatrinhgiaiquyet(id_quatrinhgiaiquyetkhieunai);
                }
                XtraMessageBox.Show("Xóa thông tin thành công");
            }
            catch (Exception)
            {
                XtraMessageBox.Show("Vui lòng chọn thông tin cần xóa");
            }
        }

        private void bar_lammoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Fun_null();
        }

        private void txt_madonthukhieunai_Leave(object sender, EventArgs e)
        {
            using (_khieunaitocaoContext = new khieunaitocaoContextDataContext())
            {
                #region check donvi

                int? i;
                i = _khieunaitocaoContext.check_madonthu_linq(dinhdanh.madonvi, txt_madonthukhieunai.Text.Trim());
                if (i == 0)
                {
                    XtraMessageBox.Show("Đơn thư không tồn tại");
                    txt_madonthukhieunai.Focus();
                    mem_noidungdonthu.Text = null;
                    return;
                }

                #endregion check donvi

                var tomtatnoidung = _khieunaitocaoContext.tomtatnoidungdongthu(txt_madonthukhieunai.Text.Trim(), dinhdanh.madonvi).SingleOrDefault();
                mem_noidungdonthu.EditValue = tomtatnoidung.tomtat_noidung;
            }
        }


        private void com_hinhthucxuly_Leave(object sender, EventArgs e)
        {
            #region check hinh thuc xu ly

            if (com_hinhthucxuly.Text == "Chuyển đơn vị khác")
            {
                look_donvinhan.Text = null;
                date_ngaychuyen.EditValue = null;
                look_donvinhan.Properties.ReadOnly = false;
                date_ngaychuyen.Properties.ReadOnly = false;
                look_donvinhan.Text = null;
                date_ngaychuyen.EditValue = null;
                return;
            }
            if (com_hinhthucxuly.Text == "Trực tiếp xử lý")
            {
                look_donvinhan.Text = null;
                date_ngaychuyen.EditValue = null;
                look_donvinhan.Properties.ReadOnly = true;
                date_ngaychuyen.Properties.ReadOnly = true;
                return;
            }
            if (com_hinhthucxuly.Text == "Không xử lý")
            {
                look_donvinhan.Text = null;
                date_ngaychuyen.EditValue = null;
                look_donvinhan.Properties.ReadOnly = true;
                date_ngaychuyen.Properties.ReadOnly = true;

                return;
            }

            #endregion check hinh thuc xu ly
        }

        private void txt_songaygiaiquyet_Leave(object sender, EventArgs e)
        {
        }

        private void date_ngaygiaiquyet_tungay_Leave(object sender, EventArgs e)
        {
            if (txt_songaygiaiquyet.Text.Trim() != "")
            {
                int songay = Convert.ToInt32(txt_songaygiaiquyet.Text.Trim());
                DateTime dt = new DateTime();
                dt = (DateTime)date_ngaygiaiquyet_tungay.EditValue;
                date_ngaygiaiquyet_denngay.EditValue = dt.AddDays(songay);
            }
            else return;
        }

        private void com_ketquaxacminh_Leave(object sender, EventArgs e)
        {
            if (com_ketquaxacminh.Text != "Rút khiếu nại, tố cáo")
            {
                date_ngayrut.Properties.ReadOnly = false;
            }
            else
            {
                date_ngayrut.Properties.ReadOnly = true;
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

        private void check_quatrinhgiaiquyet_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (check_quatrinhgiaiquyet.Checked)
            {
                XtraMessageBox.Show("Không thể sửa, xóa sau khi chọn kết thúc giải quyết");
            }
        }

        private void look_donvinhan_EditValueChanged(object sender, EventArgs e)
        {
        }
    }
}