namespace khieunaitocao
{
    partial class ctl_thongkedonthu
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
            this.grc_thongkedonthu = new DevExpress.XtraGrid.GridControl();
            this.grv_thongkedonthu = new DevExpress.XtraGrid.Views.Grid.GridView();
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
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.date_tungay = new DevExpress.XtraEditors.DateEdit();
            this.date_denngay = new DevExpress.XtraEditors.DateEdit();
            ((System.ComponentModel.ISupportInitialize)(this.grc_thongkedonthu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grv_thongkedonthu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_tungay.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_tungay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_denngay.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_denngay.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // grc_thongkedonthu
            // 
            this.grc_thongkedonthu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grc_thongkedonthu.Location = new System.Drawing.Point(0, 0);
            this.grc_thongkedonthu.MainView = this.grv_thongkedonthu;
            this.grc_thongkedonthu.Name = "grc_thongkedonthu";
            this.grc_thongkedonthu.Size = new System.Drawing.Size(1241, 354);
            this.grc_thongkedonthu.TabIndex = 0;
            this.grc_thongkedonthu.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grv_thongkedonthu});
            // 
            // grv_thongkedonthu
            // 
            this.grv_thongkedonthu.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
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
            this.gridColumn14,
            this.gridColumn15});
            this.grv_thongkedonthu.GridControl = this.grc_thongkedonthu;
            this.grv_thongkedonthu.Name = "grv_thongkedonthu";
            this.grv_thongkedonthu.OptionsView.ColumnAutoWidth = false;
            this.grv_thongkedonthu.OptionsView.ShowAutoFilterRow = true;
            this.grv_thongkedonthu.OptionsView.ShowFooter = true;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Mã đơn";
            this.gridColumn1.FieldName = "ma_donthu_khieunai";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Loại khiếu nại";
            this.gridColumn2.FieldName = "phanloai_khieunai";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 2;
            this.gridColumn2.Width = 94;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Bị đơn";
            this.gridColumn3.FieldName = "canhan_tochuc";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 3;
            this.gridColumn3.Width = 94;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Thuộc khối lực lượng";
            this.gridColumn4.FieldName = "thuoclucluong";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 4;
            this.gridColumn4.Width = 127;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Nguồn đơn";
            this.gridColumn5.FieldName = "nguondon_bandau";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 5;
            this.gridColumn5.Width = 96;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Status";
            this.gridColumn6.FieldName = "statuss";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 6;
            this.gridColumn6.Width = 89;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Không xét thi đua";
            this.gridColumn7.FieldName = "so_cb_khongduoc_xetthidua";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 7;
            this.gridColumn7.Width = 89;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Kiểm điểm";
            this.gridColumn8.FieldName = "so_cb_bikiemdiem";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 8;
            this.gridColumn8.Width = 89;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Khiển trách";
            this.gridColumn9.FieldName = "so_cb_bikhientrach";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowEdit = false;
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 9;
            this.gridColumn9.Width = 89;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "cảnh cáo";
            this.gridColumn10.FieldName = "so_cb_bicanhcao";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.AllowEdit = false;
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 10;
            this.gridColumn10.Width = 57;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Giáng chức, cách chức";
            this.gridColumn11.FieldName = "so_cb_bigiangchuc";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.OptionsColumn.AllowEdit = false;
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 11;
            this.gridColumn11.Width = 122;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "Giáng cấp, hạ lương";
            this.gridColumn12.FieldName = "so_cb_giangcap";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.OptionsColumn.AllowEdit = false;
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 12;
            this.gridColumn12.Width = 60;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "Tước danh hiệu CAND";
            this.gridColumn13.FieldName = "so_cb_bituocdanhhieu";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.OptionsColumn.AllowEdit = false;
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 13;
            this.gridColumn13.Width = 60;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "Xử lý hình sự";
            this.gridColumn14.FieldName = "so_cb_xulyhinhsu";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.OptionsColumn.AllowEdit = false;
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 14;
            this.gridColumn14.Width = 82;
            // 
            // gridColumn15
            // 
            this.gridColumn15.Caption = "Cá nhân/ tổ chức đứng đơn";
            this.gridColumn15.FieldName = "ten_canhan_tochuc";
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.OptionsColumn.AllowEdit = false;
            this.gridColumn15.Visible = true;
            this.gridColumn15.VisibleIndex = 1;
            // 
            // date_tungay
            // 
            this.date_tungay.EditValue = null;
            this.date_tungay.Location = new System.Drawing.Point(374, 3);
            this.date_tungay.Name = "date_tungay";
            this.date_tungay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.date_tungay.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.date_tungay.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.date_tungay.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.date_tungay.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.date_tungay.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.date_tungay.Properties.NullText = "Từ ngày";
            this.date_tungay.Size = new System.Drawing.Size(128, 20);
            this.date_tungay.TabIndex = 1;
            this.date_tungay.EditValueChanged += new System.EventHandler(this.date_tungay_EditValueChanged);
            // 
            // date_denngay
            // 
            this.date_denngay.EditValue = null;
            this.date_denngay.Location = new System.Drawing.Point(537, 3);
            this.date_denngay.Name = "date_denngay";
            this.date_denngay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.date_denngay.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.date_denngay.Properties.NullText = "Đến ngày";
            this.date_denngay.Size = new System.Drawing.Size(128, 20);
            this.date_denngay.TabIndex = 2;
            this.date_denngay.EditValueChanged += new System.EventHandler(this.date_denngay_EditValueChanged);
            // 
            // ctl_thongkedonthu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.date_denngay);
            this.Controls.Add(this.date_tungay);
            this.Controls.Add(this.grc_thongkedonthu);
            this.Name = "ctl_thongkedonthu";
            this.Size = new System.Drawing.Size(1241, 354);
            this.Load += new System.EventHandler(this.ctl_thongkedonthu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grc_thongkedonthu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grv_thongkedonthu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_tungay.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_tungay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_denngay.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_denngay.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grc_thongkedonthu;
        private DevExpress.XtraGrid.Views.Grid.GridView grv_thongkedonthu;
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
        private DevExpress.XtraEditors.DateEdit date_tungay;
        private DevExpress.XtraEditors.DateEdit date_denngay;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
    }
}
