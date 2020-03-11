namespace khieunaitocao
{
    partial class test
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
            this.buttonEdit1 = new DevExpress.XtraEditors.ButtonEdit();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.checkup = new DevExpress.XtraEditors.CheckEdit();
            this.checkdown = new DevExpress.XtraEditors.CheckEdit();
            this.textBox4 = new DevExpress.XtraEditors.TextEdit();
            this.textBox1 = new DevExpress.XtraEditors.TextEdit();
            this.textBox2 = new DevExpress.XtraEditors.TextEdit();
            this.button1 = new DevExpress.XtraEditors.SimpleButton();
            this.label4 = new DevExpress.XtraEditors.LabelControl();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.label5 = new DevExpress.XtraEditors.LabelControl();
            this.textBox3 = new DevExpress.XtraEditors.TextEdit();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkup.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkdown.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox4.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox3.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonEdit1
            // 
            this.buttonEdit1.EditValue = "";
            this.buttonEdit1.Location = new System.Drawing.Point(30, 56);
            this.buttonEdit1.Name = "buttonEdit1";
            this.buttonEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.buttonEdit1.Size = new System.Drawing.Size(173, 20);
            this.buttonEdit1.TabIndex = 0;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // checkup
            // 
            this.checkup.Location = new System.Drawing.Point(30, 103);
            this.checkup.Name = "checkup";
            this.checkup.Properties.Caption = "checkEdit1";
            this.checkup.Size = new System.Drawing.Size(75, 19);
            this.checkup.TabIndex = 1;
            this.checkup.CheckedChanged += new System.EventHandler(this.checkup_CheckedChanged);
            // 
            // checkdown
            // 
            this.checkdown.Location = new System.Drawing.Point(30, 129);
            this.checkdown.Name = "checkdown";
            this.checkdown.Properties.Caption = "checkEdit2";
            this.checkdown.Size = new System.Drawing.Size(75, 19);
            this.checkdown.TabIndex = 2;
            this.checkdown.CheckedChanged += new System.EventHandler(this.checkdown_CheckedChanged);
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(30, 164);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(236, 20);
            this.textBox4.TabIndex = 3;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(30, 223);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 4;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(224, 226);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(128, 194);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "simpleButton1";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(337, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "labelControl1";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(299, 183);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(173, 23);
            this.progressBar1.TabIndex = 9;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(156, 298);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 23);
            this.simpleButton1.TabIndex = 10;
            this.simpleButton1.Text = "simpleButton1";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(155, 132);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "labelControl1";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(103, 12);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 12;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // simpleButton2
            // 
            this.simpleButton2.Location = new System.Drawing.Point(324, 297);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(75, 23);
            this.simpleButton2.TabIndex = 13;
            this.simpleButton2.Text = "simpleButton2";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1013, 473);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.checkdown);
            this.Controls.Add(this.checkup);
            this.Controls.Add(this.buttonEdit1);
            this.Name = "test";
            this.Text = "test";
            this.Load += new System.EventHandler(this.test_Load);
            ((System.ComponentModel.ISupportInitialize)(this.buttonEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkup.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkdown.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox4.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox3.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.ButtonEdit buttonEdit1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private DevExpress.XtraEditors.CheckEdit checkup;
        private DevExpress.XtraEditors.CheckEdit checkdown;
        private DevExpress.XtraEditors.TextEdit textBox4;
        private DevExpress.XtraEditors.TextEdit textBox1;
        private DevExpress.XtraEditors.TextEdit textBox2;
        private DevExpress.XtraEditors.SimpleButton button1;
        private DevExpress.XtraEditors.LabelControl label4;
        private System.Windows.Forms.ProgressBar progressBar1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.LabelControl label5;
        private DevExpress.XtraEditors.TextEdit textBox3;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
    }
}