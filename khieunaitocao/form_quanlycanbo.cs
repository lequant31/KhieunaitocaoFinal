using DevExpress.XtraEditors;
using System;
using System.Linq;

namespace khieunaitocao
{
    public partial class form_quanlycanbo : DevExpress.XtraEditors.XtraForm
    {
        public form_quanlycanbo()
        {
            InitializeComponent();
        }

        private khieunaitocaoContextDataContext _khieunaitocaoContext;
        private tb_canbochiensy _tbcanbochiensy = new tb_canbochiensy();
        private mahoa mh = new mahoa();
        public bool bool_sua = false;
        public int _macanbo;
        private int quyen_han = 0;
        private string tenquyenhan = "";
        private void fun_null()
        {
            bool_sua = false;
            txt_hoten.EditValue = null;
            txt_tendangnhap.EditValue = null;
            txt_matkhau.EditValue = null;
            com_capbac.EditValue = null;
            com_chucvu.EditValue = null;
            radio_quyenhan.SelectedIndex = 0;
            txt_sohieuCAND.EditValue = null;
        }

        private void fun_save()
        {
            #region check permission

            if (dinhdanh.quyenhan != 0)
            {
                XtraMessageBox.Show("Bạn không có quyền sửa");
                return;
            }

            #endregion check permission

            using (_khieunaitocaoContext = new khieunaitocaoContextDataContext())
            {
                try
                {
                    #region rangbuoc

                    if (txt_hoten.Text.Trim() == "")
                    {
                        XtraMessageBox.Show("Vui lòng nhập họ tên chính xác");
                        txt_hoten.Focus();
                        return;
                    }
                    if (txt_sohieuCAND.Text.Trim() == "")
                    {
                        XtraMessageBox.Show("Vui lòng nhập số hiệu CAND");
                        txt_sohieuCAND.Focus();
                        return;
                    }
                    if (txt_tendangnhap.Text.Trim() == "")
                    {
                        XtraMessageBox.Show("Vui lòng nhập tên đăng nhập");
                        txt_tendangnhap.Focus();
                        return;
                    }
                    if (com_capbac.Text.Trim() == "")
                    {
                        XtraMessageBox.Show("Vui lòng chọn cấp bậc");
                        com_capbac.Focus();
                        return;
                    }
                    if (com_chucvu.Text.Trim() == "")
                    {
                        XtraMessageBox.Show("Vui lòng chọn chức vụ");
                        com_chucvu.Focus();
                        return;
                    }
                    if (txt_matkhau.Text.Trim() == "")
                    {
                        XtraMessageBox.Show("Vui lòng nhập mật khẩu");
                        txt_matkhau.Focus();
                        return;
                    }
                    if (radio_quyenhan.SelectedIndex != 0 && radio_quyenhan.SelectedIndex != 1)
                    {
                        XtraMessageBox.Show("Vui lòng chọn quyền hạn tài khoản");
                        radio_quyenhan.Focus();
                        return;
                    }

                    #endregion rangbuoc

                    var _mk = mh.EncryptString(txt_matkhau.Text, "lamgico");
                    int _madonvi = Convert.ToInt16(search_coquandonvi.EditValue);
                    if(com_chucvu.Text=="Trưởng phòng" || com_chucvu.Text=="Phó trưởng phòng")
                    {
                        tenquyenhan = "Boss";
                    }
                    else
                    {
                        tenquyenhan = "Staff";
                    }
                    if (radio_quyenhan.SelectedIndex == 0)
                    {
                        quyen_han = 2;
                    }
                    if (radio_quyenhan.SelectedIndex == 1)
                    {
                        quyen_han = 1;
                    }
                    if (bool_sua == false)
                    {
                        _khieunaitocaoContext.them_canbo(_madonvi, Int32.Parse(txt_sohieuCAND.Text), txt_hoten.Text, txt_tendangnhap.Text, _mk, com_capbac.Text, com_chucvu.Text,tenquyenhan, quyen_han,(bool)radiotrangthai.EditValue);
                    }
                    else
                    {
                        _khieunaitocaoContext.sua_canbo(_madonvi, _macanbo, txt_sohieuCAND.Text, txt_hoten.Text, txt_tendangnhap.Text, _mk, com_capbac.Text, com_chucvu.Text,tenquyenhan, quyen_han, (bool)radiotrangthai.EditValue);
                    }
                    XtraMessageBox.Show("Lưu thông tin thành công");
                }
                catch (Exception)
                {
                    XtraMessageBox.Show("Vui lòng kiểm tra lại thông tin nhập vào.\n Không để trống các trường bắt buộc phải có.");
                }
            }
        }

        private void loaditems()
        {
            using (_khieunaitocaoContext = new khieunaitocaoContextDataContext())
            {
                try
                {
                    var look = _khieunaitocaoContext.list_donvi().ToList();
                    search_coquandonvi.Properties.DataSource = look;
                    search_coquandonvi.Properties.DisplayMember = "ten_donvi";
                    search_coquandonvi.Properties.ValueMember = "ma_donvi";
                }
                catch (Exception)
                {
                    XtraMessageBox.Show("Vui lòng kiểm tra lại kết nối mạng");
                }
            }
        }

        private void load_sua()
        {
            using (_khieunaitocaoContext = new khieunaitocaoContextDataContext())
            {
                var sua = _khieunaitocaoContext.load_sua_canbo(_macanbo).SingleOrDefault();
                loaditems();
                search_coquandonvi.EditValue = sua.ma_donvi;
                txt_hoten.Text = sua.hoten_chiensy;
                txt_sohieuCAND.EditValue = sua.sohieu_cand;
                txt_tendangnhap.Text = sua.ten_dangnhap;
                txt_tendangnhap.ReadOnly = true;
                txt_matkhau.Text = mh.Decrypt(sua.matkhau_dangnhap, "lamgico");
                com_capbac.Text = sua.capbac;
                com_chucvu.Text = sua.chucvu;
                if (sua.quyenhan == 1)
                {
                    radio_quyenhan.SelectedIndex = 1;
                }
                if (sua.quyenhan == 2)
                {
                    radio_quyenhan.SelectedIndex = 0;
                }
                if (sua.trangthai == true)
                {
                    radiotrangthai.SelectedIndex = 0;
                }
                else radiotrangthai.SelectedIndex = 1;
            }
        }

        private void form_quanlycanbo_Load(object sender, EventArgs e)
        {
            if (bool_sua == false)
            {
                loaditems();
            }
            if (bool_sua == true)
            {
                load_sua();
            }
        }

        private void btn_luu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int? i;
            using (_khieunaitocaoContext = new khieunaitocaoContextDataContext())
            {
                i = _khieunaitocaoContext.check_update_insert_lnq(Convert.ToInt16(search_coquandonvi.EditValue), txt_tendangnhap.Text);
                if (i == 0 || bool_sua == true)
                {
                    fun_save();
                    fun_null();
                }
                else
                {
                    XtraMessageBox.Show("Tên đăng nhập đã bị tồn tại");
                }
            }
        }

        private void btn_lammoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
        }
    }
}