namespace khieunaitocao
{
    partial class ctl_thongketocao
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.date_denngay = new DevExpress.XtraEditors.DateEdit();
            this.date_tungay = new DevExpress.XtraEditors.DateEdit();
            this.grc_thongketocao = new DevExpress.XtraGrid.GridControl();
            this.grv_thongketocao = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.date_denngay.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_denngay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_tungay.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_tungay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grc_thongketocao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grv_thongketocao)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.date_denngay);
            this.panelControl1.Controls.Add(this.date_tungay);
            this.panelControl1.Controls.Add(this.grc_thongketocao);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(952, 500);
            this.panelControl1.TabIndex = 0;
            // 
            // date_denngay
            // 
            this.date_denngay.EditValue = null;
            this.date_denngay.Location = new System.Drawing.Point(575, 6);
            this.date_denngay.Name = "date_denngay";
            this.date_denngay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.date_denngay.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.date_denngay.Properties.NullText = "Từ ngày";
            this.date_denngay.Size = new System.Drawing.Size(137, 20);
            this.date_denngay.TabIndex = 2;
            this.date_denngay.EditValueChanged += new System.EventHandler(this.date_denngay_EditValueChanged);
            // 
            // date_tungay
            // 
            this.date_tungay.EditValue = "";
            this.date_tungay.Location = new System.Drawing.Point(360, 6);
            this.date_tungay.Name = "date_tungay";
            this.date_tungay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.date_tungay.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.date_tungay.Properties.NullDate = "";
            this.date_tungay.Properties.NullText = "Từ ngày";
            this.date_tungay.Size = new System.Drawing.Size(136, 20);
            this.date_tungay.TabIndex = 1;
            this.date_tungay.EditValueChanged += new System.EventHandler(this.date_tungay_EditValueChanged);
            // 
            // grc_thongketocao
            // 
            this.grc_thongketocao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grc_thongketocao.Location = new System.Drawing.Point(2, 2);
            this.grc_thongketocao.MainView = this.grv_thongketocao;
            this.grc_thongketocao.Name = "grc_thongketocao";
            this.grc_thongketocao.Size = new System.Drawing.Size(948, 496);
            this.grc_thongketocao.TabIndex = 0;
            this.grc_thongketocao.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grv_thongketocao});
            // 
            // grv_thongketocao
            // 
            this.grv_thongketocao.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn11,
            this.gridColumn12,
            this.gridColumn13,
            this.gridColumn14});
            this.grv_thongketocao.GridControl = this.grc_thongketocao;
            this.grv_thongketocao.Name = "grv_thongketocao";
            this.grv_thongketocao.OptionsView.ColumnAutoWidth = false;
            this.grv_thongketocao.OptionsView.ShowAutoFilterRow = true;
            this.grv_thongketocao.OptionsView.ShowFooter = true;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Mã tố cáo";
            this.gridColumn1.FieldName = "ma_donthu_tocao";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Loại tố cáo";
            this.gridColumn2.FieldName = "phanloai_tocao";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Bị đơn";
            this.gridColumn3.FieldName = "canhan_tochuc";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Thuộc khối lực lượng";
            this.gridColumn4.FieldName = "thuoclucluong";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Nguồn đơn";
            this.gridColumn5.FieldName = "nguondon_bandau";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Status";
            this.gridColumn6.FieldName = "statuss";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 5;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Không xét thi đua";
            this.gridColumn7.FieldName = "so_cb_khongduoc_xetthidua";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 6;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Kiểm điểm";
            this.gridColumn8.FieldName = "so_cb_bikiemdiem";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 7;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Cảnh cáo";
            this.gridColumn9.FieldName = "so_cb_bicanhcao";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 8;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Khiển trách";
            this.gridColumn10.FieldName = "so_cb_bikhientrach";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 9;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Hình sự";
            this.gridColumn11.FieldName = "so_cb_xuly_hinhsu";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 10;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "Giáng chức, cách chức";
            this.gridColumn12.FieldName = "so_cb_bigiangchuc";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 11;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "Giáng cấp, hạ lương";
            this.gridColumn13.FieldName = "so_cb_bigiangcap";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 12;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "Tước danh hiệu CAND";
            this.gridColumn14.FieldName = "so_cb_bituocdanhhieu";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 13;
            // 
            // ctl_thongketocao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl1);
            this.Name = "ctl_thongketocao";
            this.Size = new System.Drawing.Size(952, 500);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.date_denngay.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_denngay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_tungay.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_tungay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grc_thongketocao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grv_thongketocao)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.DateEdit date_denngay;
        private DevExpress.XtraEditors.DateEdit date_tungay;
        private DevExpress.XtraGrid.GridControl grc_thongketocao;
        private DevExpress.XtraGrid.Views.Grid.GridView grv_thongketocao;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
    }
}
