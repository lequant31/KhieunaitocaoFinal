using DevExpress.Export;
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace khieunaitocao
{
    public partial class ctlthongtintocaoAllPX05 : DevExpress.XtraEditors.XtraUserControl
    {
        public ctlthongtintocaoAllPX05()
        {
            InitializeComponent();
        }

        private khieunaitocaoContextDataContext _khieunaitocaoContext;
        private int year = DateTime.Now.Year;

        private void tocao_load()
        {
            using (_khieunaitocaoContext = new khieunaitocaoContextDataContext())
            {
                var list = _khieunaitocaoContext.ListThongTinToCaoALLPX05(dinhdanh.madonvi).ToList();
                grd_thongtintocao.DataSource = list;
            }
        }

        private void ctlthongtintocao_Load(object sender, EventArgs e)
        {
            try
            {
                tocao_load();
            }
            catch (Exception)
            {
                // XtraMessageBox.Show("Có lỗi xảy ra");
                throw;
            }
        }

        private void bar_lammoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tocao_load();
        }

        private void bar_year_EditValueChanged(object sender, EventArgs e)
        {
            //year = Convert.ToInt32(bar_year.EditValue);
            //tocao_load();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!grd_thongtintocao.IsPrintingAvailable)
            {
                XtraMessageBox.Show("The 'DevExpress.XtraPrinting' library is not found", "Error");
                return;
            }

            // Open the Preview window. 
            grd_thongtintocao.ShowPrintPreview();
        }

        private void grv_thongtintocao_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            e.Value = grv_thongtintocao.GetRowHandle(e.ListSourceRowIndex) + 1;
        }

        private void grv_thongtintocao_PrintInitialize(object sender, DevExpress.XtraGrid.Views.Base.PrintInitializeEventArgs e)
        {
            PrintingSystemBase pb = e.PrintingSystem as PrintingSystemBase;
            pb.PageSettings.Landscape = true;
        }
        private void ExportExcel(string filename)
        {
            try
            {
                if (grv_thongtintocao.FocusedRowHandle < 0)
                {
                    XtraMessageBox.Show("Di chuyển chuột xuống các dòng khác");
                }
                else
                {
                    var dialog = new SaveFileDialog();
                    dialog.Title = @"Export file excel";
                    dialog.FileName = filename;
                    dialog.Filter = @"Microsoft Excel|*.xlsx*";
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        grv_thongtintocao.ColumnPanelRowHeight = 50;
                        grv_thongtintocao.OptionsPrint.AutoWidth = AutoSize;
                        grv_thongtintocao.OptionsPrint.ShowPrintExportProgress = true;
                        XlsxExportOptions options = new XlsxExportOptions();
                        options.TextExportMode = TextExportMode.Text;
                        options.ExportMode = XlsxExportMode.SingleFile;
                        options.SheetName = @"Sheet1";
                        
                        ExportSettings.DefaultExportType = ExportType.Default;
                        grv_thongtintocao.ExportToXlsx(dialog.FileName, options);
                        XtraMessageBox.Show("Export thành công", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show("Lỗi: " + ex, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnExportExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ExportExcel("");
        }

        private void grv_thongtintocao_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                var priority = grv_thongtintocao.GetRowCellDisplayText(e.RowHandle, grv_thongtintocao.Columns["ketthucdon"]);
                var date_denngay_giaiquyet = grv_thongtintocao.GetRowCellValue(e.RowHandle, grv_thongtintocao.Columns["denngay_giaiquyet"]);
                var date_ngay_ketthuc = grv_thongtintocao.GetRowCellValue(e.RowHandle, grv_thongtintocao.Columns["ngay_kethuc"]);

                if (priority == "Checked")
                {
                    if (date_denngay_giaiquyet == null)
                    {
                        e.Appearance.BackColor = Color.Goldenrod;
                        e.HighPriority = true;
                    }
                    else
                    {
                        TimeSpan timeSpan = Convert.ToDateTime(date_ngay_ketthuc) - Convert.ToDateTime(date_denngay_giaiquyet);
                        if (timeSpan.Days <= 0)
                        {
                            e.Appearance.BackColor = Color.BlueViolet;
                            e.HighPriority = true;
                        }
                        else
                        {
                            e.Appearance.BackColor = Color.PaleVioletRed;
                            e.HighPriority = true;
                        }
                    }
                }
                if (priority == "Uncheck")
                {
                    if (date_denngay_giaiquyet == null)
                    {
                        e.Appearance.BackColor = Color.Goldenrod;
                        e.HighPriority = true;
                    }
                    else
                    {
                        TimeSpan timeSpan = DateTime.Now - Convert.ToDateTime(date_denngay_giaiquyet);
                        if (timeSpan.Days > 0)
                        {
                            e.Appearance.BackColor = Color.BlueViolet;
                            e.HighPriority = true;
                        }
                    }
                }
            }
        }
    }
}