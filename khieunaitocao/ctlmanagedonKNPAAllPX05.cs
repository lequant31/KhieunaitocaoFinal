using DevExpress.Export;
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace khieunaitocao
{
    public partial class ctlmanagedonKNPAAllPX05 : DevExpress.XtraEditors.XtraUserControl
    {
        //quanlythongtin ql = new quanlythongtin();
        public ctlmanagedonKNPAAllPX05()
        {
            InitializeComponent();
        }

        private int year = DateTime.Now.Year;
        private khieunaitocaoContextDataContext _khieunaitocaoContext;

        private void donthu_load()
        {
            using (_khieunaitocaoContext = new khieunaitocaoContextDataContext())
            {
                var list = _khieunaitocaoContext.ListThongTinKNPAALLPX05(dinhdanh.madonvi).ToList();
                grc_quanlydonthukhieunai.DataSource = list;
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
            grv_quanlydonthukhieunai.IndicatorWidth = 40;
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
            if (!grc_quanlydonthukhieunai.IsPrintingAvailable)
            {
                XtraMessageBox.Show("The 'DevExpress.XtraPrinting' library is not found", "Error");
                return;
            }

            // Open the Preview window.
            grc_quanlydonthukhieunai.ShowPrintPreview();
        }

        private void grv_quanlydonthukhieunai_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            e.Value = grv_quanlydonthukhieunai.GetRowHandle(e.ListSourceRowIndex) + 1;
        }

        private void ExportExcel(string filename)
        {
            try
            {
                if (grv_quanlydonthukhieunai.FocusedRowHandle < 0)
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
                        grv_quanlydonthukhieunai.ColumnPanelRowHeight = 50;
                        grv_quanlydonthukhieunai.OptionsPrint.AutoWidth = AutoSize;
                        grv_quanlydonthukhieunai.OptionsPrint.ShowPrintExportProgress = true;
                        XlsxExportOptions options = new XlsxExportOptions();
                        options.TextExportMode = TextExportMode.Text;
                        options.ExportMode = XlsxExportMode.SingleFile;
                        options.SheetName = @"Sheet1";
                        ExportSettings.DefaultExportType = ExportType.Default;
                        grv_quanlydonthukhieunai.ExportToXlsx(dialog.FileName, options);
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

        private void grv_quanlydonthukhieunai_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                var priority = grv_quanlydonthukhieunai.GetRowCellDisplayText(e.RowHandle, grv_quanlydonthukhieunai.Columns["ketthucdonthu"]);
                var date_denngay_giaiquyet = grv_quanlydonthukhieunai.GetRowCellValue(e.RowHandle, grv_quanlydonthukhieunai.Columns["denngay_giaiquyet"]);
                var date_ngay_ketthuc = grv_quanlydonthukhieunai.GetRowCellValue(e.RowHandle, grv_quanlydonthukhieunai.Columns["ngaykethuc"]);

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