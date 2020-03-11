using DevExpress.LookAndFeel;
using DevExpress.XtraEditors;
using System;
using System.Linq;
using System.Windows.Forms;

namespace khieunaitocao
{
	public partial class frm_dangnhap : DevExpress.XtraEditors.XtraForm
	{
		public frm_dangnhap()
		{
			InitializeComponent();
		}

		private khieunaitocaoContextDataContext _khieunaitocaoContext;

		private void load_items_donvi()
		{
			try
			{
				using (_khieunaitocaoContext = new khieunaitocaoContextDataContext())
				{
					var look = _khieunaitocaoContext.list_donvi().ToList();
					com_tendonvi.Properties.DataSource = look;
					com_tendonvi.Properties.DisplayMember = "ten_donvi";
					com_tendonvi.Properties.ValueMember = "ma_donvi";
				}
			}
			catch (Exception)
			{
				//throw;
				XtraMessageBox.Show("Vui lòng kiểm tra lại kết nối mạng");
			}
		}

		private void _dangnhap()
		{
			mahoa mh = new mahoa();
			string matkhau = mh.EncryptString(txt_matkhaudangnhap.Text, "lamgico");
			try
			{
				using (_khieunaitocaoContext = new khieunaitocaoContextDataContext())
				{
					int? status = _khieunaitocaoContext.login_canbo_linq(Convert.ToInt16(com_tendonvi.EditValue), txt_tendangnhap.Text, matkhau);
					if (status == 1)
					{
						this.DialogResult = DialogResult.OK;
						var _dinhdanh_canbo = _khieunaitocaoContext.dinhdanh_canbo(Convert.ToInt16(com_tendonvi.EditValue), txt_tendangnhap.Text).SingleOrDefault();
						dinhdanh.madonvi = _dinhdanh_canbo.ma_donvi;
						dinhdanh.ma_canbo = _dinhdanh_canbo.ma_canbo;
						dinhdanh.sohieu_cand = _dinhdanh_canbo.sohieu_cand;
						dinhdanh.quyenhan = _dinhdanh_canbo.quyenhan;
						dinhdanh.kyhieu_donvi = _dinhdanh_canbo.kyhieu_donvi.Trim();
						dinhdanh.tencanbo = _dinhdanh_canbo.hoten_chiensy;
						dinhdanh.password = _dinhdanh_canbo.matkhau_dangnhap;
						this.Close();
					}

					if (status == 0)
					{
						XtraMessageBox.Show("Sai thông tin đăng nhập");
					}
				}
			}
			catch (Exception)
			{
				XtraMessageBox.Show("Kiểm tra lại kết nối");
			}
			SaveSetting();
		}

		private void frm_dangnhap_Load(object sender, EventArgs e)
		{
			load_items_donvi();
			ReadingSetting();
		}

		private void btn_dangnhap_Click(object sender, EventArgs e)
		{
			_dangnhap();
		}

		private void btn_huydangnhap_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void ReadingSetting()
		{
			UserLookAndFeel.Default.SkinName = Properties.Settings.Default.skin;
			if (Properties.Settings.Default.RememberMe == "true")
			{
				txt_tendangnhap.Text = Properties.Settings.Default.Username;
				txt_matkhaudangnhap.Text = Properties.Settings.Default.Password;
				com_tendonvi.EditValue = Properties.Settings.Default.donvi;
				check_rememberme.Checked = true;
			}
			else
			{
				txt_tendangnhap.Text = "";
				txt_matkhaudangnhap.Text = "";
				com_tendonvi.Text = "";
				check_rememberme.Checked = false;
			}
		}

		private void SaveSetting()
		{
			if (check_rememberme.Checked)
			{
				Properties.Settings.Default.Username = txt_tendangnhap.Text;
				Properties.Settings.Default.Password = txt_matkhaudangnhap.Text;
				Properties.Settings.Default.donvi = Convert.ToInt16(com_tendonvi.EditValue);
				Properties.Settings.Default.RememberMe = "true";
				Properties.Settings.Default.Save();
			}
			else
			{
				Properties.Settings.Default.Username = "";
				Properties.Settings.Default.Password = "";
				Properties.Settings.Default.donvi = 0;
				Properties.Settings.Default.RememberMe = "false";
				Properties.Settings.Default.Save();
			}
		}
	}
}