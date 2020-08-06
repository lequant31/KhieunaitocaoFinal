namespace khieunaitocao
{
    partial class frm_dangnhap
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_dangnhap));
            this.panel1 = new System.Windows.Forms.Panel();
            this.check_rememberme = new DevExpress.XtraEditors.CheckEdit();
            this.btn_huydangnhap = new DevExpress.XtraEditors.SimpleButton();
            this.btn_dangnhap = new DevExpress.XtraEditors.SimpleButton();
            this.txt_matkhaudangnhap = new DevExpress.XtraEditors.TextEdit();
            this.txt_tendangnhap = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.com_tendonvi = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.check_rememberme.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_matkhaudangnhap.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_tendangnhap.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.com_tendonvi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.check_rememberme);
            this.panel1.Controls.Add(this.btn_huydangnhap);
            this.panel1.Controls.Add(this.btn_dangnhap);
            this.panel1.Controls.Add(this.txt_matkhaudangnhap);
            this.panel1.Controls.Add(this.txt_tendangnhap);
            this.panel1.Controls.Add(this.labelControl3);
            this.panel1.Controls.Add(this.labelControl2);
            this.panel1.Controls.Add(this.labelControl1);
            this.panel1.Controls.Add(this.com_tendonvi);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(345, 173);
            this.panel1.TabIndex = 0;
            // 
            // check_rememberme
            // 
            this.check_rememberme.Location = new System.Drawing.Point(103, 100);
            this.check_rememberme.Name = "check_rememberme";
            this.check_rememberme.Properties.Caption = "Ghi nhớ";
            this.check_rememberme.Size = new System.Drawing.Size(101, 20);
            this.check_rememberme.TabIndex = 8;
            // 
            // btn_huydangnhap
            // 
            this.btn_huydangnhap.Location = new System.Drawing.Point(199, 128);
            this.btn_huydangnhap.Name = "btn_huydangnhap";
            this.btn_huydangnhap.Size = new System.Drawing.Size(75, 23);
            this.btn_huydangnhap.TabIndex = 7;
            this.btn_huydangnhap.Text = "Hủy";
            this.btn_huydangnhap.Click += new System.EventHandler(this.btn_huydangnhap_Click);
            // 
            // btn_dangnhap
            // 
            this.btn_dangnhap.Location = new System.Drawing.Point(103, 128);
            this.btn_dangnhap.Name = "btn_dangnhap";
            this.btn_dangnhap.Size = new System.Drawing.Size(75, 23);
            this.btn_dangnhap.TabIndex = 6;
            this.btn_dangnhap.Text = "Đăng nhập";
            this.btn_dangnhap.Click += new System.EventHandler(this.btn_dangnhap_Click);
            // 
            // txt_matkhaudangnhap
            // 
            this.txt_matkhaudangnhap.Location = new System.Drawing.Point(103, 74);
            this.txt_matkhaudangnhap.Name = "txt_matkhaudangnhap";
            this.txt_matkhaudangnhap.Properties.PasswordChar = '*';
            this.txt_matkhaudangnhap.Size = new System.Drawing.Size(224, 20);
            this.txt_matkhaudangnhap.TabIndex = 5;
            // 
            // txt_tendangnhap
            // 
            this.txt_tendangnhap.Location = new System.Drawing.Point(103, 42);
            this.txt_tendangnhap.Name = "txt_tendangnhap";
            this.txt_tendangnhap.Size = new System.Drawing.Size(224, 20);
            this.txt_tendangnhap.TabIndex = 4;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(13, 82);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(44, 13);
            this.labelControl3.TabIndex = 3;
            this.labelControl3.Text = "Mật khẩu";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(13, 50);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(72, 13);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Tên đăng nhập";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(13, 15);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(31, 13);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Đơn vị";
            // 
            // com_tendonvi
            // 
            this.com_tendonvi.Location = new System.Drawing.Point(103, 12);
            this.com_tendonvi.Name = "com_tendonvi";
            this.com_tendonvi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.com_tendonvi.Properties.NullText = "";
            this.com_tendonvi.Properties.PopupSizeable = false;
            this.com_tendonvi.Properties.PopupView = this.searchLookUpEdit1View;
            this.com_tendonvi.Size = new System.Drawing.Size(225, 20);
            this.com_tendonvi.TabIndex = 0;
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2});
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Ký hiệu";
            this.gridColumn1.FieldName = "kyhieu_donvi";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Tên cơ quan đơn vị";
            this.gridColumn2.FieldName = "ten_donvi";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // frm_dangnhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 173);
            this.Controls.Add(this.panel1);
            this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("frm_dangnhap.IconOptions.Icon")));
            this.Name = "frm_dangnhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập";
            this.Load += new System.EventHandler(this.frm_dangnhap_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.check_rememberme.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_matkhaudangnhap.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_tendangnhap.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.com_tendonvi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.SimpleButton btn_huydangnhap;
        private DevExpress.XtraEditors.SimpleButton btn_dangnhap;
        private DevExpress.XtraEditors.TextEdit txt_matkhaudangnhap;
        private DevExpress.XtraEditors.TextEdit txt_tendangnhap;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SearchLookUpEdit com_tendonvi;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraEditors.CheckEdit check_rememberme;
    }
}