namespace khieunaitocao
{
    partial class ctlmanagedonthu
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctlmanagedonthu));
            this.grc_quanlydonthukhieunai = new DevExpress.XtraGrid.GridControl();
            this.grv_quanlydonthukhieunai = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.bar_them = new DevExpress.XtraBars.BarButtonItem();
            this.bar_btn_sua = new DevExpress.XtraBars.BarButtonItem();
            this.bar_btn_refresh = new DevExpress.XtraBars.BarButtonItem();
            this.bar_xoa = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem5 = new DevExpress.XtraBars.BarButtonItem();
            this.bar_year = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemComboBox2 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.repositoryItemMemoEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            ((System.ComponentModel.ISupportInitialize)(this.grc_quanlydonthukhieunai)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grv_quanlydonthukhieunai)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit2)).BeginInit();
            this.SuspendLayout();
            // 
            // grc_quanlydonthukhieunai
            // 
            this.grc_quanlydonthukhieunai.Location = new System.Drawing.Point(4, 4);
            this.grc_quanlydonthukhieunai.MainView = this.grv_quanlydonthukhieunai;
            this.grc_quanlydonthukhieunai.MenuManager = this.barManager1;
            this.grc_quanlydonthukhieunai.Name = "grc_quanlydonthukhieunai";
            this.grc_quanlydonthukhieunai.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMemoEdit1,
            this.repositoryItemMemoEdit2});
            this.grc_quanlydonthukhieunai.Size = new System.Drawing.Size(1269, 431);
            this.grc_quanlydonthukhieunai.TabIndex = 4;
            this.grc_quanlydonthukhieunai.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grv_quanlydonthukhieunai});
            // 
            // grv_quanlydonthukhieunai
            // 
            this.grv_quanlydonthukhieunai.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn6,
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn7});
            this.grv_quanlydonthukhieunai.GridControl = this.grc_quanlydonthukhieunai;
            this.grv_quanlydonthukhieunai.GroupPanelText = "Kéo thả vào đây để nhóm cột theo ý muốn";
            this.grv_quanlydonthukhieunai.IndicatorWidth = 30;
            this.grv_quanlydonthukhieunai.Name = "grv_quanlydonthukhieunai";
            this.grv_quanlydonthukhieunai.OptionsView.ColumnAutoWidth = false;
            this.grv_quanlydonthukhieunai.OptionsView.RowAutoHeight = true;
            this.grv_quanlydonthukhieunai.OptionsView.ShowAutoFilterRow = true;
            this.grv_quanlydonthukhieunai.ViewCaption = "Đơn thư khiếu nại";
            this.grv_quanlydonthukhieunai.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.grv_quanlydonthukhieunai_CustomDrawRowIndicator);
            this.grv_quanlydonthukhieunai.DoubleClick += new System.EventHandler(this.grv_quanlydonthukhieunai_DoubleClick);
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "gridColumn6";
            this.gridColumn6.FieldName = "id_thongtinkhieunai";
            this.gridColumn6.Name = "gridColumn6";
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Mã đơn thư";
            this.gridColumn1.FieldName = "ma_donthu_khieunai";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 80;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Tên cá nhân/Tổ chức gửi đơn";
            this.gridColumn2.FieldName = "ten_canhan_tochuc";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 178;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Tóm tắt nội dung đơn thư";
            this.gridColumn3.ColumnEdit = this.repositoryItemMemoEdit1;
            this.gridColumn3.FieldName = "tomtat_noidung";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 3;
            this.gridColumn3.Width = 379;
            // 
            // repositoryItemMemoEdit1
            // 
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Loại đơn";
            this.gridColumn4.FieldName = "loai_don";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 2;
            this.gridColumn4.Width = 229;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Điều kiện xử lý";
            this.gridColumn5.FieldName = "dieukien_xuly_du_hoackhong";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 5;
            this.gridColumn5.Width = 84;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Ghi chú";
            this.gridColumn7.ColumnEdit = this.repositoryItemMemoEdit2;
            this.gridColumn7.FieldName = "ghi_chu";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 4;
            this.gridColumn7.Width = 328;
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.bar_btn_refresh,
            this.bar_them,
            this.bar_btn_sua,
            this.bar_xoa,
            this.barButtonItem5,
            this.bar_year});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 8;
            this.barManager1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemComboBox1,
            this.repositoryItemComboBox2});
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bar_them, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bar_btn_sua, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bar_btn_refresh, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bar_xoa, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem5, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(this.bar_year)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // bar_them
            // 
            this.bar_them.Caption = "Thêm";
            this.bar_them.Id = 1;
            this.bar_them.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bar_them.ImageOptions.Image")));
            this.bar_them.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bar_them.ImageOptions.LargeImage")));
            this.bar_them.Name = "bar_them";
            this.bar_them.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bar_them_ItemClick);
            // 
            // bar_btn_sua
            // 
            this.bar_btn_sua.Caption = "Sửa";
            this.bar_btn_sua.Id = 2;
            this.bar_btn_sua.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bar_btn_sua.ImageOptions.Image")));
            this.bar_btn_sua.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bar_btn_sua.ImageOptions.LargeImage")));
            this.bar_btn_sua.Name = "bar_btn_sua";
            this.bar_btn_sua.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bar_btn_sua_ItemClick);
            // 
            // bar_btn_refresh
            // 
            this.bar_btn_refresh.Caption = "Làm mới";
            this.bar_btn_refresh.Id = 0;
            this.bar_btn_refresh.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bar_btn_refresh.ImageOptions.Image")));
            this.bar_btn_refresh.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bar_btn_refresh.ImageOptions.LargeImage")));
            this.bar_btn_refresh.Name = "bar_btn_refresh";
            this.bar_btn_refresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bar_btn_refresh_ItemClick);
            // 
            // bar_xoa
            // 
            this.bar_xoa.Caption = "Xóa";
            this.bar_xoa.Id = 3;
            this.bar_xoa.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bar_xoa.ImageOptions.Image")));
            this.bar_xoa.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bar_xoa.ImageOptions.LargeImage")));
            this.bar_xoa.Name = "bar_xoa";
            this.bar_xoa.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bar_xoa_ItemClick);
            // 
            // barButtonItem5
            // 
            this.barButtonItem5.Caption = "Tải tài liệu đính kèm";
            this.barButtonItem5.Id = 5;
            this.barButtonItem5.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem5.ImageOptions.Image")));
            this.barButtonItem5.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem5.ImageOptions.LargeImage")));
            this.barButtonItem5.Name = "barButtonItem5";
            // 
            // bar_year
            // 
            this.bar_year.Caption = "Chọn năm";
            this.bar_year.Edit = this.repositoryItemComboBox2;
            this.bar_year.Hint = "Chọn năm";
            this.bar_year.Id = 7;
            this.bar_year.Name = "bar_year";
            this.bar_year.EditValueChanged += new System.EventHandler(this.bar_year_EditValueChanged);
            // 
            // repositoryItemComboBox2
            // 
            this.repositoryItemComboBox2.AutoHeight = false;
            this.repositoryItemComboBox2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox2.Items.AddRange(new object[] {
            "2020",
            "2021",
            "2022",
            "2023",
            "2024",
            "2025",
            "2026",
            "2027",
            "2028",
            "2029",
            "2030",
            "2031"});
            this.repositoryItemComboBox2.Name = "repositoryItemComboBox2";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(1277, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 463);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1277, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 439);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1277, 24);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 439);
            // 
            // repositoryItemComboBox1
            // 
            this.repositoryItemComboBox1.AutoHeight = false;
            this.repositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.grc_quanlydonthukhieunai);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 24);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1277, 439);
            this.layoutControl1.TabIndex = 4;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlGroup1.Size = new System.Drawing.Size(1277, 439);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grc_quanlydonthukhieunai;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1273, 435);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // repositoryItemMemoEdit2
            // 
            this.repositoryItemMemoEdit2.Name = "repositoryItemMemoEdit2";
            // 
            // ctlmanagedonthu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "ctlmanagedonthu";
            this.Size = new System.Drawing.Size(1277, 463);
            this.Load += new System.EventHandler(this.ctlmanagedonthu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grc_quanlydonthukhieunai)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grv_quanlydonthukhieunai)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem bar_btn_refresh;
        private DevExpress.XtraBars.BarButtonItem bar_them;
        private DevExpress.XtraBars.BarButtonItem bar_btn_sua;
        private DevExpress.XtraBars.BarButtonItem bar_xoa;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraGrid.GridControl grc_quanlydonthukhieunai;
        private DevExpress.XtraGrid.Views.Grid.GridView grv_quanlydonthukhieunai;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1;
        private DevExpress.XtraBars.BarEditItem bar_year;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox2;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit2;
    }
}
