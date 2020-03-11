namespace khieunaitocao
{
    partial class ctl_quanlycanbo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctl_quanlycanbo));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.grd_thongtincanbo = new DevExpress.XtraGrid.GridControl();
            this.grv_thongtincanbo = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.bar_themcanbo = new DevExpress.XtraBars.BarButtonItem();
            this.bar_suacanbo = new DevExpress.XtraBars.BarButtonItem();
            this.bar_xoacanbo = new DevExpress.XtraBars.BarButtonItem();
            this.bar_reload = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd_thongtincanbo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grv_thongtincanbo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.grd_thongtincanbo);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 24);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(970, 442);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // grd_thongtincanbo
            // 
            this.grd_thongtincanbo.Location = new System.Drawing.Point(12, 12);
            this.grd_thongtincanbo.MainView = this.grv_thongtincanbo;
            this.grd_thongtincanbo.MenuManager = this.barManager1;
            this.grd_thongtincanbo.Name = "grd_thongtincanbo";
            this.grd_thongtincanbo.Size = new System.Drawing.Size(946, 418);
            this.grd_thongtincanbo.TabIndex = 4;
            this.grd_thongtincanbo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grv_thongtincanbo});
            // 
            // grv_thongtincanbo
            // 
            this.grv_thongtincanbo.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7});
            this.grv_thongtincanbo.GridControl = this.grd_thongtincanbo;
            this.grv_thongtincanbo.Name = "grv_thongtincanbo";
            this.grv_thongtincanbo.OptionsView.ShowGroupPanel = false;
            this.grv_thongtincanbo.DoubleClick += new System.EventHandler(this.grv_thongtincanbo_DoubleClick);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Họ tên";
            this.gridColumn1.FieldName = "hoten_chiensy";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 112;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Tên đăng nhập";
            this.gridColumn2.FieldName = "ten_dangnhap";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 121;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Cấp bậc";
            this.gridColumn3.FieldName = "capbac";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 3;
            this.gridColumn3.Width = 97;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Chức vụ";
            this.gridColumn4.FieldName = "chucvu";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 4;
            this.gridColumn4.Width = 96;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Cơ quan đơn vị";
            this.gridColumn5.FieldName = "ten_donvi";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 6;
            this.gridColumn5.Width = 226;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Quyền hạn";
            this.gridColumn6.FieldName = "quyenhan";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 5;
            this.gridColumn6.Width = 143;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Số hiệu CAND";
            this.gridColumn7.FieldName = "sohieu_cand";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 2;
            this.gridColumn7.Width = 133;
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
            this.bar_themcanbo,
            this.bar_suacanbo,
            this.bar_xoacanbo,
            this.barButtonItem4,
            this.bar_reload});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 5;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bar_themcanbo, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bar_suacanbo, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bar_xoacanbo, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bar_reload, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // bar_themcanbo
            // 
            this.bar_themcanbo.Caption = "Thêm";
            this.bar_themcanbo.Id = 0;
            this.bar_themcanbo.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bar_themcanbo.ImageOptions.Image")));
            this.bar_themcanbo.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bar_themcanbo.ImageOptions.LargeImage")));
            this.bar_themcanbo.Name = "bar_themcanbo";
            this.bar_themcanbo.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bar_themcanbo_ItemClick);
            // 
            // bar_suacanbo
            // 
            this.bar_suacanbo.Caption = "Sửa";
            this.bar_suacanbo.Id = 1;
            this.bar_suacanbo.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bar_suacanbo.ImageOptions.Image")));
            this.bar_suacanbo.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bar_suacanbo.ImageOptions.LargeImage")));
            this.bar_suacanbo.Name = "bar_suacanbo";
            this.bar_suacanbo.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bar_suacanbo_ItemClick);
            // 
            // bar_xoacanbo
            // 
            this.bar_xoacanbo.Caption = "Xóa";
            this.bar_xoacanbo.Id = 2;
            this.bar_xoacanbo.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bar_xoacanbo.ImageOptions.Image")));
            this.bar_xoacanbo.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bar_xoacanbo.ImageOptions.LargeImage")));
            this.bar_xoacanbo.Name = "bar_xoacanbo";
            this.bar_xoacanbo.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bar_xoacanbo_ItemClick);
            // 
            // bar_reload
            // 
            this.bar_reload.Caption = "Làm mới";
            this.bar_reload.Id = 4;
            this.bar_reload.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bar_reload.ImageOptions.Image")));
            this.bar_reload.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bar_reload.ImageOptions.LargeImage")));
            this.bar_reload.Name = "bar_reload";
            this.bar_reload.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bar_reload_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(970, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 466);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(970, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 442);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(970, 24);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 442);
            // 
            // barButtonItem4
            // 
            this.barButtonItem4.Caption = "Tải lại";
            this.barButtonItem4.Id = 3;
            this.barButtonItem4.Name = "barButtonItem4";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(970, 442);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grd_thongtincanbo;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(950, 422);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // ctl_quanlycanbo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "ctl_quanlycanbo";
            this.Size = new System.Drawing.Size(970, 466);
            this.Load += new System.EventHandler(this.ctl_quanlycanbo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd_thongtincanbo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grv_thongtincanbo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl grd_thongtincanbo;
        private DevExpress.XtraGrid.Views.Grid.GridView grv_thongtincanbo;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem bar_themcanbo;
        private DevExpress.XtraBars.BarButtonItem bar_suacanbo;
        private DevExpress.XtraBars.BarButtonItem bar_xoacanbo;
        private DevExpress.XtraBars.BarButtonItem bar_reload;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
    }
}
