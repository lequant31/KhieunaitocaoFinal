using DevExpress.Export;
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace khieunaitocao
{
    public partial class ctlmanagedonthutogiacPX05 : DevExpress.XtraEditors.XtraUserControl
    {
        //quanlythongtin ql = new quanlythongtin();
        public ctlmanagedonthutogiacPX05()
        {
            InitializeComponent();
        }

        private int year = DateTime.Now.Year;
        private khieunaitocaoContextDataContext _khieunaitocaoContext;

        private void donthu_load()
        {
            using (_khieunaitocaoContext = new khieunaitocaoContextDataContext())
            {
                var list = _khieunaitocaoContext.ListThongTinToGiacALLPX05(dinhdanh.madonvi).ToList();
                grc_quanlydontogiac.DataSource = list;
            }
        }

        private void ctlmanagedonthu_Load(object sender, EventArgs e)
        {
            try
            {
                donthu_load();
            }
            catch (Exception)
            {
                // XtraMessageBox.Show("Có lỗi xảy ra");
                throw;
            }
        }

        private void bar_btn_refresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            donthu_load();
        }

        private void grv_quanlydonthukhieunai_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            grv_quanlydontogiac.IndicatorWidth = 40;
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void bar_year_EditValueChanged(object sender, EventArgs e)
        {
            //year = Convert.ToInt32(bar_year.EditValue);
            //donthu_load();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!grc_quanlydontogiac.IsPrintingAvailable)
            {
                XtraMessageBox.Show("The 'DevExpress.XtraPrinting' library is not found", "Error");
                return;
            }

            // Open the Preview window. 
            grc_quanlydontogiac.ShowPrintPreview();
        }

        private void grv_quanlydontogiac_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            e.Value = grv_quanlydontogiac.GetRowHandle(e.ListSourceRowIndex) + 1;
        }
        private void ExportExcel(string filename)
        {
            try
            {
                if (grv_quanlydontogiac.FocusedRowHandle < 0)
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
                        grv_quanlydontogiac.ColumnPanelRowHeight = 50;
                        grv_quanlydontogiac.OptionsPrint.AutoWidth = AutoSize;
                        grv_quanlydontogiac.OptionsPrint.ShowPrintExportProgress = true;
                        XlsxExportOptions options = new XlsxExportOptions();
                        options.TextExportMode = TextExportMode.Text;
                        options.ExportMode = XlsxExportMode.SingleFile;
                        options.SheetName = @"Sheet1";
                        ExportSettings.DefaultExportType = ExportType.Default;
                        grv_quanlydontogiac.ExportToXlsx(dialog.FileName, options);
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

        private void grv_quanlydontogiac_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                var priority = grv_quanlydontogiac.GetRowCellDisplayText(e.RowHandle, grv_quanlydontogiac.Columns["ketthucdon"]);
                var date_denngay_giaiquyet = grv_quanlydontogiac.GetRowCellValue(e.RowHandle, grv_quanlydontogiac.Columns["denngay_giaiquyet"]);
                var date_ngay_ketthuc = grv_quanlydontogiac.GetRowCellValue(e.RowHandle, grv_quanlydontogiac.Columns["ngay_kethuc"]);

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