namespace CreateShortcut
{
    partial class Form1
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
            this.check_Desktop = new DevExpress.XtraEditors.CheckEdit();
            this.check_StartMenu = new DevExpress.XtraEditors.CheckEdit();
            this.checkEdit3 = new DevExpress.XtraEditors.CheckEdit();
            this.btn_ok = new DevExpress.XtraEditors.SimpleButton();
            this.btn_cancel = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.check_Desktop.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.check_StartMenu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit3.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // check_Desktop
            // 
            this.check_Desktop.Location = new System.Drawing.Point(71, 68);
            this.check_Desktop.Name = "check_Desktop";
            this.check_Desktop.Properties.Caption = "checkEdit1";
            this.check_Desktop.Size = new System.Drawing.Size(75, 19);
            this.check_Desktop.TabIndex = 0;
            // 
            // check_StartMenu
            // 
            this.check_StartMenu.Location = new System.Drawing.Point(71, 93);
            this.check_StartMenu.Name = "check_StartMenu";
            this.check_StartMenu.Properties.Caption = "checkEdit2";
            this.check_StartMenu.Size = new System.Drawing.Size(75, 19);
            this.check_StartMenu.TabIndex = 1;
            // 
            // checkEdit3
            // 
            this.checkEdit3.Location = new System.Drawing.Point(71, 118);
            this.checkEdit3.Name = "checkEdit3";
            this.checkEdit3.Properties.Caption = "checkEdit3";
            this.checkEdit3.Size = new System.Drawing.Size(75, 19);
            this.checkEdit3.TabIndex = 2;
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(261, 158);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(75, 23);
            this.btn_ok.TabIndex = 3;
            this.btn_ok.Text = "OK";
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(400, 157);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_cancel.TabIndex = 4;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 217);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.checkEdit3);
            this.Controls.Add(this.check_StartMenu);
            this.Controls.Add(this.check_Desktop);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.check_Desktop.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.check_StartMenu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit3.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.CheckEdit check_Desktop;
        private DevExpress.XtraEditors.CheckEdit check_StartMenu;
        private DevExpress.XtraEditors.CheckEdit checkEdit3;
        private DevExpress.XtraEditors.SimpleButton btn_ok;
        private DevExpress.XtraEditors.SimpleButton btn_cancel;
    }
}

