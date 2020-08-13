using DevExpress.XtraEditors;
using System;
using System.Linq;
using System.Windows.Forms;

namespace khieunaitocao
{
    public partial class form_thongtinkiennghiphananh : DevExpress.XtraEditors.XtraForm
    {
        public form_thongtinkiennghiphananh()
        {
            InitializeComponent();
        }

        public string madonthu { get; set; }
        public bool bool_sua = false;
        public int id_thongtinKNPA;
        public bool bool_chuyen = false;
        public string ngaysua = "";
        private bool Re_sua = true;
        private bool Re_xoa = true;
        private string forwarded;
        private bool ketthucdon = false;
        private int donvixuly = 0;
        private khieunaitocaoContextDataContext _khieunaitocaoContext = new khieunaitocaoContextDataContext();
        private tb_thongtinKNPA objKN;
        private relation_donvi_thongtinKNPA Relation_Donvi_ThongtinKNPA = new relation_donvi_thongtinKNPA();

        //private tb_toxacminh tb_Toxacminh;
        private Random random = new Random();

        public int? _madonvinhan;
        private bool canhan_tochuc = true;

        private void thongtindonthucanhan_Load(object sender, EventArgs e)
        {
            var listdonvinhan = _khieunaitocaoContext.list_donvi();
            search_donvinhan.Properties.DataSource = listdonvinhan;
            search_donvinhan.Properties.DisplayMember = "ten_donvi";
            search_donvinhan.Properties.ValueMember = "ma_donvi";
            var listthanhvien = _khieunaitocaoContext.search_thanhvien(dinhdanh.madonvi);
            repositoryItemLookUpEdit1.DataSource = listthanhvien;
            repositoryItemLookUpEdit1.DisplayMember = "ma_canbo";
            repositoryItemLookUpEdit1.ValueMember = "ma_canbo";
            gridColumn18.ColumnEdit = repositoryItemLookUpEdit1;
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
            /////////////////////////////////////////
            objKN = new tb_thongtinKNPA();
            bool_sua = false;

            if (rdb_dieukienxuly.SelectedIndex != 0)
            {
                com_lydokhongdudkxl.EditValue = null;
                com_lydokhongdudkxl.ReadOnly = true;
            }
            bool_chuyen = false;
            memo_tomtatnoidung.EditValue = null;
            btn_dinhkem.Text = "Tài liệu đính kèm";
            madonthu.DefaultIfEmpty();
            txt_hoten_canhan.Text = null;
            txt_tencoquan_tochuc.Text = null;
            txt_sdt_canhan.Text = null;
            txt_sdt_tochuc.Text = null;
            txt_emailcanhan.Text = null;
            txt_email_tochuc.Text = null;
            txt_diachi_canhan.Text = null;
            txt_diachi_tochuc.Text = null;
            txt_coquan_lamviec.Text = null;
            txt_nguokytrongdon.Text = null;
            txt_noicap_cmnd.Text = null;
            txt_socmnd_canhan.Text = null;
            txt_ngaycap_cmnd.EditValue = null;
            txt_coquan_lamviec.Text = null;
            memo_ykienchidao.Text = null;
            memo_ghichu.Text = null;
            com_hinhthucxuly.Text = null;
            search_donvinhan.EditValue = null;
            txt_sophieuchuyen.Text = null;
            date_ngaychuyendon.EditValue = null;
            socv_thongbao_chuyendon.Text = null;
            date_ngay_thongbao_chuyendon.EditValue = null;
            treelook_phanloai_khieunai.EditValue = null;
            com_lydokhongdudkxl.Text = "Lý do không đủ ĐKXL";
            grc_bidon.DataSource = null;
            grc_nhatkyguidon.DataSource = null;
            grc_bidon.DataSource = objKN.tb_bidonKNPAs;
            grc_nhatkyguidon.DataSource = objKN.tb_nhatky_guidonKNPAs;
            Grc_toxacminh.DataSource = objKN.tb_toxacminhKNPAs;
            txt_madonthu.Text = null;
            Grv_toxacminh.OptionsBehavior.ReadOnly = true;
            com_hinhthucxuly.ReadOnly = true;
            search_donvinhan.ReadOnly = true;
            date_ngaychuyendon.ReadOnly = true;
            date_ketthuc.EditValue = null;
            txt_songay_giaiquyet.Text = null;
            date_tungay_giaiquyet.Text = null;
            date_denngay_giaiquyet.Text = null;
            txt_so_tiepnhan_giaiquyet.Text = null;
            date_ngay_tiepnhan_giaiquyet.Text = null;
            txt_so_kehoach_xacminh.Text = null;
            txt_nguoi_pheduyet_kehoach_xacminh.Text = null;           
            txt_nguoiky_kehoach_xacminh.Text = null;
            txt_songay_kehoach_xacminh.Text = null;
            date_tungay_kehoach_xacminh.EditValue = null;
            date_denngay_kehoach_xacminh.EditValue = null;
            memo_tomtat_ketqua.Text = null;
            memo_ykien_lanhdao_ketqua.Text = null;
            date_ngay_rutdon.EditValue = null;
            memo_lydo_rutdon.Text = null;
            com_danhgia_giaiquyet.Text = null;
        }

        private void thongtin_addnew()
        {
            madonthu = dinhdanh.kyhieu_donvi + DateTime.Now.Year.ToString() + random.Next(1, 10000).ToString();
            txt_madonthu.Text = madonthu;
            objKN = new tb_thongtinKNPA();
            grc_bidon.DataSource = objKN.tb_bidonKNPAs;
            grv_bidon.BestFitColumns();
            grc_nhatkyguidon.DataSource = objKN.tb_nhatky_guidonKNPAs;
            grv_nhatkyguidon.BestFitColumns();
            Grc_toxacminh.DataSource = objKN.tb_toxacminhKNPAs;
            Grv_toxacminh.BestFitColumns();
        }

        private void thongtin_edit()
        {
            var _list_thongtindonthu = _khieunaitocaoContext.xem_thongtindonKNPA(id_thongtinKNPA).SingleOrDefault();
            txt_madonthu.Text = _list_thongtindonthu.ma_donthu_KNPA;
            madonthu = txt_madonthu.Text;
            txt_madonthu.ReadOnly = true;

            if (_list_thongtindonthu.forward == "Đã chuyển" && madonthu.Substring(0, 4) != dinhdanh.kyhieu_donvi)
            {
                com_hinhthucxuly.ReadOnly = true;
                search_donvinhan.ReadOnly = true;
                date_ngaychuyendon.ReadOnly = true;
                txt_sophieuchuyen.ReadOnly = true;
            }
            if (_list_thongtindonthu.forward == "Đã chuyển" && madonthu.Substring(0, 4) == dinhdanh.kyhieu_donvi)
            {
                Grv_toxacminh.OptionsBehavior.ReadOnly = true;
                com_hinhthucxuly.ReadOnly = true;
                search_donvinhan.ReadOnly = true;
                date_ngaychuyendon.ReadOnly = true;
                txt_sophieuchuyen.ReadOnly = true;
            }
            if (rdb_dieukienxuly.SelectedIndex == 0)
            {
                com_lydokhongdudkxl.EditValue = null;
                com_lydokhongdudkxl.ReadOnly = true;
            }
            if (rdb_dieukienxuly.SelectedIndex == 1)
            {
                com_lydokhongdudkxl.ReadOnly = false;
            }
            canhan_tochuc = (bool)_list_thongtindonthu.tochuc_canhan;
            if (canhan_tochuc == true)
            {
                txt_hoten_canhan.EditValue = _list_thongtindonthu.ten_canhan_tochuc;
                txt_sdt_canhan.EditValue = _list_thongtindonthu.sdt;
                txt_emailcanhan.EditValue = _list_thongtindonthu.email;
                txt_socmnd_canhan.EditValue = _list_thongtindonthu.so_cmnd;
                txt_ngaycap_cmnd.EditValue = _list_thongtindonthu.ngaycap_cmnd;
                txt_noicap_cmnd.EditValue = _list_thongtindonthu.noicap_cmnd;
                txt_diachi_canhan.EditValue = _list_thongtindonthu.dia_chi;
                txt_coquan_lamviec.EditValue = _list_thongtindonthu.ten_cqdv_canhan;
            }
            if (canhan_tochuc == false)
            {
                txt_tencoquan_tochuc.EditValue = _list_thongtindonthu.ten_canhan_tochuc;
                txt_diachi_tochuc.EditValue = _list_thongtindonthu.dia_chi;
                txt_nguokytrongdon.EditValue = _list_thongtindonthu.nguoi_ky_trong_don;
                txt_sdt_tochuc.EditValue = _list_thongtindonthu.sdt;
                txt_email_tochuc.EditValue = _list_thongtindonthu.email;
            }
            treelook_phanloai_khieunai.EditValue = _list_thongtindonthu.loai_don;
            memo_tomtatnoidung.EditValue = _list_thongtindonthu.tomtat_noidung;
            memo_ykienchidao.EditValue = _list_thongtindonthu.ykien_chidao;
            memo_ghichu.EditValue = _list_thongtindonthu.ghi_chu;
            rdb_dieukienxuly.EditValue = _list_thongtindonthu.dieukien_xuly_du_hoackhong;
            com_lydokhongdudkxl.EditValue = _list_thongtindonthu.lydo_khongdu_dieukien;
            com_hinhthucxuly.EditValue = _list_thongtindonthu.hinhthuc_xuly;
            btn_dinhkem.EditValue = _list_thongtindonthu.tailieu_dinhkem;
            ngaysua = _list_thongtindonthu.ngaygio_sua + " " + dinhdanh.sohieu_cand + " " + DateTime.Now.ToString();
            search_donvinhan.EditValue = _list_thongtindonthu.donvinhan;
            txt_sophieuchuyen.EditValue = _list_thongtindonthu.so_phieuchuyen;
            date_ngaychuyendon.EditValue = _list_thongtindonthu.ngay_chuyendon;
            socv_thongbao_chuyendon.EditValue = _list_thongtindonthu.socv_thongbao_chuyendon;
            date_ngay_thongbao_chuyendon.EditValue = _list_thongtindonthu.ngay_thongbao_chuyendon;
            txt_songay_giaiquyet.EditValue = _list_thongtindonthu.songay_giaiquyet;
            date_tungay_giaiquyet.EditValue = _list_thongtindonthu.tungay_giaiquyet;
            date_denngay_giaiquyet.EditValue = _list_thongtindonthu.denngay_giaiquyet;
            txt_so_tiepnhan_giaiquyet.EditValue = _list_thongtindonthu.so_thongbao_tiepnhan;
            date_ngay_tiepnhan_giaiquyet.EditValue = _list_thongtindonthu.ngay_thongbao_tiepnhan;
            txt_so_kehoach_xacminh.EditValue = _list_thongtindonthu.so_kehoach_xacminh;
            txt_nguoiky_kehoach_xacminh.EditValue = _list_thongtindonthu.nguoi_ky_kehoach_xacminh;
            txt_nguoi_pheduyet_kehoach_xacminh.EditValue = _list_thongtindonthu.nguoi_pheduyet_kehoach_xacminh;
            txt_songay_kehoach_xacminh.EditValue = _list_thongtindonthu.songay_xacminh;
            date_tungay_kehoach_xacminh.EditValue = _list_thongtindonthu.tungay_xacminh;
            date_denngay_kehoach_xacminh.EditValue = _list_thongtindonthu.denngay_xacminh;
            memo_tomtat_ketqua.EditValue = _list_thongtindonthu.tomtat_ketqua;
            memo_ykien_lanhdao_ketqua.EditValue = _list_thongtindonthu.ykien_ketqua_lanhdao;
            date_ngay_rutdon.EditValue = _list_thongtindonthu.ngay_rutdon;
            memo_lydo_rutdon.EditValue = _list_thongtindonthu.lydo_rutdon;
            com_danhgia_giaiquyet.EditValue = _list_thongtindonthu.danhgia_giaiquyet;
            date_ketthuc.EditValue = _list_thongtindonthu.ngaykethuc;
            memo_tomtat_ketqua.EditValue = _list_thongtindonthu.tomtat_ketqua;
            forwarded = _list_thongtindonthu.forward;
            objKN = _khieunaitocaoContext.tb_thongtinKNPAs.Single(p => p.id_thongtinKNPA == id_thongtinKNPA);
            grc_bidon.DataSource = objKN.tb_bidonKNPAs;
            grc_nhatkyguidon.DataSource = objKN.tb_nhatky_guidonKNPAs;
            Grc_toxacminh.DataSource = objKN.tb_toxacminhKNPAs;
            grv_bidon.RefreshData();
            grv_nhatkyguidon.RefreshData();
            Grv_toxacminh.RefreshData();
        }

        private void xtraTab_canhan_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (xtraTab_canhan.SelectedTabPageIndex == 0)
            {
                canhan_tochuc = true;
            }
            else
            {
                canhan_tochuc = false;
            }
        }

        private void btn_dinhkem_Leave(object sender, EventArgs e)
        {
            if (btn_dinhkem.Text.Trim() == "")
            {
                btn_dinhkem.Text = "Tài liệu đính kèm";
            }
        }

        private void btn_dinhkem_Enter(object sender, EventArgs e)
        {
            if (btn_dinhkem.Text.Trim() == "Tài liệu đính kèm")
            {
                btn_dinhkem.Text = "";
            }
        }

        private void bar_btn_save_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                #region kiemtra

                if (string.IsNullOrEmpty(txt_madonthu.Text) || string.IsNullOrWhiteSpace(txt_madonthu.Text))
                {
                    XtraMessageBox.Show("Vui lòng nhập đơn khiếu nại");
                    txt_madonthu.Focus();
                    return;
                }

                if (dinhdanh.quyenhan == 2)
                {
                    XtraMessageBox.Show("Tài khoản chỉ có quyền xem.\n Không được thay đổi");
                    return;
                }

                if (treelook_phanloai_khieunai.EditValue == null)
                {
                    XtraMessageBox.Show("Vui lòng chọn loại đơn khiếu nại");
                    treelook_phanloai_khieunai.Focus();
                    return;
                }

                if (bool_sua == false)
                {
                    //var _lst = _khieunaitocaoContext.tb_thongtinkhieunais.Where(p => p.ma_donthu_khieunai == txt_madonthu.Text.Trim()).FirstOrDefault();
                    int _lst = _khieunaitocaoContext.check_maKNPA(dinhdanh.madonvi, madonthu);
                    if (_lst == 1)
                    {
                        XtraMessageBox.Show("Mã đơn thư khiếu nại đã tồn tại");
                        txt_madonthu.Focus();
                        return;
                    }
                }
                if (bool_sua == true)
                {
                    using (khieunaitocaoContextDataContext khieunaitocaoContext = new khieunaitocaoContextDataContext())
                    {
                        var checksua = khieunaitocaoContext.check_suadonKNPA(id_thongtinKNPA, dinhdanh.madonvi).SingleOrDefault();

                        if (checksua.sua == false || checksua.ketthucdonthu == true)
                        {
                            XtraMessageBox.Show("Không được quyền sửa");
                            return;
                        }
                    }
                }

                #endregion kiemtra

                if (bool_sua == true)
                {
                    objKN = _khieunaitocaoContext.tb_thongtinKNPAs.Where(a => a.id_thongtinKNPA == id_thongtinKNPA).SingleOrDefault();
                    var relation = objKN.relation_donvi_thongtinKNPAs.Single(x => x.id_thongtinKNPA == id_thongtinKNPA && x.id_donvi == dinhdanh.madonvi);
                    relation.sua = Re_sua;
                    relation.xoa = Re_xoa;
                    objKN.ngaygio_sua = ngaysua + " " + dinhdanh.sohieu_cand;
                }

                objKN.tochuc_canhan = canhan_tochuc;
                objKN.tomtat_noidung = memo_tomtatnoidung.Text;
                objKN.ykien_chidao = memo_ykienchidao.Text;
                objKN.hinhthuc_xuly = com_hinhthucxuly.Text;
                objKN.ghi_chu = memo_ghichu.Text;
                objKN.dieukien_xuly_du_hoackhong = (bool)rdb_dieukienxuly.EditValue;
                objKN.lydo_khongdu_dieukien = com_lydokhongdudkxl.Text;
                objKN.loai_don = treelook_phanloai_khieunai.EditValue.ToString();
                objKN.tailieu_dinhkem = btn_dinhkem.Text;
                objKN.songay_giaiquyet = txt_songay_giaiquyet.Text;
                objKN.tungay_giaiquyet = (DateTime?)date_tungay_giaiquyet.EditValue;
                objKN.denngay_giaiquyet = (DateTime?)date_denngay_giaiquyet.EditValue;
                objKN.so_thongbao_tiepnhan = txt_so_tiepnhan_giaiquyet.Text;
                objKN.ngay_thongbao_tiepnhan = (DateTime?)date_ngay_tiepnhan_giaiquyet.EditValue;

                objKN.so_kehoach_xacminh = txt_so_kehoach_xacminh.Text;
                objKN.nguoi_pheduyet_kehoach_xacminh = txt_nguoi_pheduyet_kehoach_xacminh.Text;
                objKN.nguoi_ky_kehoach_xacminh = txt_nguoiky_kehoach_xacminh.Text;
                objKN.songay_xacminh = txt_songay_kehoach_xacminh.Text;
                objKN.tungay_xacminh = (DateTime?)date_tungay_kehoach_xacminh.EditValue;
                objKN.denngay_xacminh = (DateTime?)date_denngay_kehoach_xacminh.EditValue;
                objKN.tomtat_ketqua = memo_tomtat_ketqua.Text;
                objKN.ykien_ketqua_lanhdao = memo_ykien_lanhdao_ketqua.Text;
                objKN.ngay_rutdon = (DateTime?)date_ngay_rutdon.EditValue;
                objKN.lydo_rutdon = memo_lydo_rutdon.Text;
                objKN.danhgia_giaiquyet = com_danhgia_giaiquyet.Text;
                objKN.ngaykethuc = (DateTime?)date_ketthuc.EditValue;
                objKN.ngaygio_nhap = DateTime.Now;

                if (madonthu.Substring(0, 4) == dinhdanh.kyhieu_donvi)
                {
                    objKN.forward = forwarded;
                    if (search_donvinhan.EditValue != null)
                    {
                        objKN.donvinhan = (int)search_donvinhan.EditValue;
                    }
                    else
                    {
                        objKN.donvinhan = donvixuly;
                    }
                    objKN.so_phieuchuyen = txt_sophieuchuyen.Text;
                    objKN.socv_thongbao_chuyendon = socv_thongbao_chuyendon.Text;
                    objKN.ngay_thongbao_chuyendon = (DateTime?)date_ngay_thongbao_chuyendon.EditValue;
                    objKN.ngay_chuyendon = (DateTime?)date_ngaychuyendon.EditValue;
                }

                if (canhan_tochuc == true)
                {
                    objKN.ten_canhan_tochuc = txt_hoten_canhan.Text;
                    objKN.sdt = txt_sdt_canhan.Text;
                    objKN.email = txt_emailcanhan.Text;
                    objKN.so_cmnd = txt_socmnd_canhan.Text;
                    objKN.ngaycap_cmnd = (DateTime?)txt_ngaycap_cmnd.EditValue;
                    objKN.noicap_cmnd = txt_noicap_cmnd.Text;
                    objKN.dia_chi = txt_diachi_canhan.Text;
                    objKN.ten_cqdv_canhan = txt_coquan_lamviec.Text;
                    objKN.nguoi_ky_trong_don = null;
                }
                if (canhan_tochuc == false)
                {
                    objKN.ten_canhan_tochuc = txt_tencoquan_tochuc.Text;
                    objKN.sdt = txt_sdt_tochuc.Text;
                    objKN.email = txt_email_tochuc.Text;
                    objKN.so_cmnd = null;
                    objKN.ngaycap_cmnd = null;
                    objKN.noicap_cmnd = null;
                    objKN.dia_chi = txt_diachi_tochuc.Text;
                    objKN.ten_cqdv_canhan = null;
                    objKN.nguoi_ky_trong_don = txt_nguokytrongdon.Text;
                }
                if (date_ketthuc.EditValue != null)
                {
                    ketthucdon = true;
                }
                objKN.ketthucdonthu = ketthucdon;
                if (bool_sua == false)
                {
                    objKN.ma_canbo_nhapdulieu = dinhdanh.ma_canbo;
                    Relation_Donvi_ThongtinKNPA.id_donvi = dinhdanh.madonvi;
                    Relation_Donvi_ThongtinKNPA.hinhthucxuly = "Main";
                    Relation_Donvi_ThongtinKNPA.sua = Re_sua;
                    Relation_Donvi_ThongtinKNPA.xoa = Re_xoa;
                    Relation_Donvi_ThongtinKNPA.tb_thongtinKNPA = objKN;
                    objKN.ma_donthu_KNPA= madonthu;
                    _khieunaitocaoContext.tb_thongtinKNPAs.InsertOnSubmit(objKN);
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
                //XtraMessageBox.Show("Không được sửa mã đơn thư");
            }
        }

        private void grv_bidon_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            //var bidon_tochuc_canhan = grv_bidon.GetRowCellValue(e.RowHandle,"bidon_tochuc_canhan").ToString().Trim();
            //var hoten_canhan = grv_bidon.GetRowCellValue(e.RowHandle, "hoten_canhan").ToString().Trim();
            //var dia_chi = grv_bidon.GetRowCellValue(e.RowHandle, "dia_chi").ToString().Trim();
            //var sohieu_cand = grv_bidon.GetRowCellValue(e.RowHandle, "sohieu_cand").ToString().Trim();
            //var capbac = grv_bidon.GetRowCellValue(e.RowHandle, "capbac").ToString().Trim();
            //var chucvu = grv_bidon.GetRowCellValue(e.RowHandle, "chucvu").ToString().Trim();
            //var nghe_nghiep = grv_bidon.GetRowCellValue(e.RowHandle, "nghe_nghiep").ToString().Trim();
            //var ten_coquandonvi = grv_bidon.GetRowCellValue(e.RowHandle, "ten_coquandonvi").ToString().Trim();
            //var thuoc_lucluong = grv_bidon.GetRowCellValue(e.RowHandle, "thuoc_lucluong").ToString().Trim();
            //if (bidon_tochuc_canhan == "")
            //{
            //    e.ErrorText = "Vui lòng không để trống";
            //    e.Valid = false;
            //    return;
            //}
            //if (hoten_canhan == "")
            //{
            //    e.ErrorText = "Vui lòng nhập tên cá nhân hoặc tổ chức";
            //    e.Valid = false;
            //    return;
            //}
            //if (grv_bidon.IsNewItemRow(e.RowHandle))
            //{
            //    //_khieunaitocaoEntities.them_bidon(txt_madonthu,grv_bidon.GetRowCellValue(e.RowHandle,grv_bidon.Columns[1]).ToString());
            //}
        }

        private void grv_bidon_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && e.Modifiers == Keys.Control)
            {
                if (MessageBox.Show("Bạn có muốn xóa thông tin?", "Confirmation", MessageBoxButtons.YesNo) !=
                    DialogResult.Yes)
                    return;
                grv_bidon.DeleteRow(grv_bidon.FocusedRowHandle);
            }
        }

        private void repository_btn_xoa_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa thông tin?", "Confirmation", MessageBoxButtons.YesNo) !=
                  DialogResult.Yes)
                return;
            grv_bidon.DeleteSelectedRows();
        }

        private void repositoryItem_capbac_EditValueChanged(object sender, EventArgs e)
        {
            grv_bidon.SetFocusedRowCellValue("capbac", ((ComboBoxEdit)sender).EditValue);
        }

        private void repository_btn_xoa_nhatky_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa thông tin?", "Confirmation", MessageBoxButtons.YesNo) !=
                DialogResult.Yes)
                return;
            grv_nhatkyguidon.DeleteSelectedRows();
        }

        private void bar_btn_lammoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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
            
            if (txt_madonthu.Text.Substring(0, 4) != dinhdanh.kyhieu_donvi)
            {
                XtraMessageBox.Show("Không được quyền xóa");
                return;
            }

            #endregion check permission

            try

            {
                using (_khieunaitocaoContext = new khieunaitocaoContextDataContext())
                {
                    if (MessageBox.Show("Bạn có muốn xóa thông tin?", "Confirmation", MessageBoxButtons.YesNo) !=
                     DialogResult.Yes)
                        return;
                    _khieunaitocaoContext.XoaThongTinKNPA(id_thongtinKNPA, dinhdanh.madonvi);
                    MessageBox.Show("Xóa thông tin thành công");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Xóa thông tin thất bại");
            }
        }

        private void Grv_toxacmin_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "id_canbochiensy")
            {
                var value = Grv_toxacminh.GetRowCellValue(e.RowHandle, e.Column);
                var ls = _khieunaitocaoContext.tb_canbochiensies.FirstOrDefault(x => x.ma_canbo == (int)value);
                if (ls != null)
                {
                    Grv_toxacminh.SetRowCellValue(e.RowHandle, "hotentxm", ls.hoten_chiensy);
                    Grv_toxacminh.SetRowCellValue(e.RowHandle, "sohieu_candtxm", ls.sohieu_cand);
                    Grv_toxacminh.SetRowCellValue(e.RowHandle, "capbactxm", ls.capbac);
                    Grv_toxacminh.SetRowCellValue(e.RowHandle, "chucvutxm", ls.chucvu);
                }
            }
        }

        private void com_hinhthucxuly_SelectedValueChanged(object sender, EventArgs e)
        {
            if (com_hinhthucxuly.Text != "Chuyển đơn vị khác" || com_hinhthucxuly.Text != "Chuyển đơn vị ngoài CAND")
            {
                Re_sua = true;
                forwarded = "";
                search_donvinhan.ReadOnly = true;
                date_ngaychuyendon.ReadOnly = true;
                txt_sophieuchuyen.ReadOnly = true;
                socv_thongbao_chuyendon.ReadOnly = true;
                date_ngay_thongbao_chuyendon.ReadOnly = true;
            }
            if (com_hinhthucxuly.Text == "Chuyển đơn vị khác")
            {
                Re_sua = false;
                forwarded = "Chưa chuyển";
                search_donvinhan.ReadOnly = false;
                date_ngaychuyendon.ReadOnly = false;
                txt_sophieuchuyen.ReadOnly = false;
                socv_thongbao_chuyendon.ReadOnly = false;
                date_ngay_thongbao_chuyendon.ReadOnly = false;
            }
            if (com_hinhthucxuly.Text == "Chuyển đơn vị ngoài CAND")
            {
                Re_sua = false;
                forwarded = "Đã chuyển";
                search_donvinhan.ReadOnly = false;
                date_ngaychuyendon.ReadOnly = false;
                txt_sophieuchuyen.ReadOnly = false;
                socv_thongbao_chuyendon.ReadOnly = false;
                date_ngay_thongbao_chuyendon.ReadOnly = false;
            }
            if (com_hinhthucxuly.Text == "Trực tiếp xử lý")
            {
                donvixuly = dinhdanh.madonvi;
            }
            //hinhthucxuly = com_hinhthucxuly.Text;
        }

        private void date_ketthuc_EditValueChanged(object sender, EventArgs e)
        {
            if (date_ketthuc.EditValue != null)
            {
                Re_sua = false;
                Re_xoa = true;
                XtraMessageBox.Show("Không thể sửa xóa khi đã kết thúc");
            }
        }

        private void btn_xoa_toxacminh_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa thông tin?", "Confirmation", MessageBoxButtons.YesNo) !=
                 DialogResult.Yes)
                return;
            Grv_toxacminh.DeleteSelectedRows();
        }

        private void rdb_dieukienxuly_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rdb_dieukienxuly.SelectedIndex == 0)
            {
                com_lydokhongdudkxl.Text = null;
                com_lydokhongdudkxl.ReadOnly = true;
            }
            if (rdb_dieukienxuly.SelectedIndex == 1)
            {
                com_lydokhongdudkxl.ReadOnly = false;
            }
        }

        private void txt_songay_kehoach_xacminh_EditValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_songay_kehoach_xacminh.Text) && date_tungay_kehoach_xacminh.EditValue != null)
            {
                date_denngay_giaiquyet.EditValue = date_tungay_kehoach_xacminh.EditValue;
                DateTime dateTime = (DateTime)date_tungay_kehoach_xacminh.EditValue;
                date_denngay_kehoach_xacminh.EditValue = dateTime.AddDays(int.Parse(date_tungay_kehoach_xacminh.Text));
            }
        }

        private void date_tungay_kehoach_xacminh_EditValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_songay_kehoach_xacminh.Text) && date_tungay_kehoach_xacminh.EditValue != null)
            {
                date_denngay_giaiquyet.EditValue = date_tungay_kehoach_xacminh.EditValue;
                DateTime dateTime = (DateTime)date_tungay_kehoach_xacminh.EditValue;
                date_denngay_kehoach_xacminh.EditValue = dateTime.AddDays(int.Parse(date_tungay_kehoach_xacminh.Text));
            }
        }
    }
}