using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting;
using DevExpress.Export;

namespace khieunaitocao
{
    public partial class ctlDanhMucDonThuKhieuNai : UserControl
    {
        public ctlDanhMucDonThuKhieuNai()
        {
            InitializeComponent();
        }
        khieunaitocaoContextDataContext khieunaitocaoContextDataContext;
        private void btn_loaddata_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            loaddata();
        }

        private void btn_loaddataall_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            #region check đầu vào
            if (date_tungay.EditValue == null)
            {
                XtraMessageBox.Show("Chưa nhập dữ liệu");
                date_tungay.Focus();
            }
            if (date_denngay.EditValue == null)
            {
                XtraMessageBox.Show("Chưa nhập dữ liệu");
                date_denngay.Focus();
            }
            #endregion
            using (khieunaitocaoContextDataContext = new khieunaitocaoContextDataContext())
            {

                var _list = khieunaitocaoContextDataContext.PrinterPreviewDonKhieuNaiPX05((DateTime)date_tungay.EditValue, (DateTime)date_denngay.EditValue).ToList();
                grc_danhmuckhieunai.DataSource = _list;
            }
        }

        private void btn_printerpreview_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!grc_danhmuckhieunai.IsPrintingAvailable)
            {
                MessageBox.Show("The 'DevExpress.XtraPrinting' library is not found", "Error");
                return;
            }

            // Open the Preview window. 
            grc_danhmuckhieunai.ShowPrintPreview();
        }

        private void ctlDanhMucDonThuKhieuNai_Load(object sender, EventArgs e)
        {
            if (dinhdanh.kyhieu_donvi == "PX05")
            {
                btn_loaddataall.Visibility = BarItemVisibility.Always;
            }
        }
        private void loaddata()
        {
            #region check đầu vào
            if (date_tungay.EditValue == null)
            {
                XtraMessageBox.Show("Chưa nhập dữ liệu");
                date_tungay.Focus();
            }
            if (date_denngay.EditValue == null)
            {
                XtraMessageBox.Show("Chưa nhập dữ liệu");
                date_denngay.Focus();
            }
            #endregion
            using (khieunaitocaoContextDataContext = new khieunaitocaoContextDataContext())
            {
                
                var _list = khieunaitocaoContextDataContext.PrinterPreviewDonKhieuNai(dinhdanh.madonvi, (DateTime)date_tungay.EditValue, (DateTime)date_denngay.EditValue).ToList();
                grc_danhmuckhieunai.DataSource = _list;
                stt.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
                stt.VisibleIndex = 0;
                grv_danhmuckhieunai.CustomUnboundColumnData += grv_danhmuckhieunai_CustomUnboundColumnData;
            }

        }

        private void grv_danhmuckhieunai_PrintInitialize(object sender, DevExpress.XtraGrid.Views.Base.PrintInitializeEventArgs e)
        {
            PrintingSystemBase pb = e.PrintingSystem as PrintingSystemBase;
            pb.PageSettings.Landscape = true;
            
        }

        private void grv_danhmuckhieunai_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void grv_danhmuckhieunai_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            e.Value = grv_danhmuckhieunai.GetRowHandle(e.ListSourceRowIndex) + 1;
        }

        private void btn_export_excel_ItemClick(object sender, ItemClickEventArgs e)
        {
            ExportExcel("");
        }
        private void ExportExcel(string filename )
        {
            try
            {
                if (grv_danhmuckhieunai.FocusedRowHandle < 0)
                {
                    XtraMessageBox.Show("Di chuyển chuột xuống các dòng khác");
                }
                else
                {
                    var dialog = new SaveFileDialog();
                    dialog.Title = @"Export file excel";
                    dialog.FileName = filename;
                    dialog.Filter = @"Microsoft Excel|*.xlsx*";
                    if (dialog.ShowDialog()==DialogResult.OK)
                    {
                        grv_danhmuckhieunai.ColumnPanelRowHeight = 50;
                        grv_danhmuckhieunai.OptionsPrint.AutoWidth = AutoSize;
                        grv_danhmuckhieunai.OptionsPrint.ShowPrintExportProgress = true;
                        XlsxExportOptions options = new XlsxExportOptions();
                        options.TextExportMode = TextExportMode.Text;
                        options.ExportMode = XlsxExportMode.SingleFile;
                        options.SheetName = @"Sheet1";
                        ExportSettings.DefaultExportType = ExportType.Default;
                        grv_danhmuckhieunai.ExportToXlsx(dialog.FileName,options);
                        XtraMessageBox.Show("Export thành công", "Message", MessageBoxButtons.OK,MessageBoxIcon.Information);
                    }
                   
                }
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show("Lỗi: "+ex, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
