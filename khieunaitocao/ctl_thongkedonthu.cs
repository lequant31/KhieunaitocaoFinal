using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace khieunaitocao
{
    public partial class ctl_thongkedonthu : DevExpress.XtraEditors.XtraUserControl
    {
        khieunaitocaoContextDataContext khieunaitocaoContextDataContext;
        public ctl_thongkedonthu()
        {
            InitializeComponent();
        }

        private void ctl_thongkedonthu_Load(object sender, EventArgs e)
        {
            
        }
        private void fun_load()
        {
            using (khieunaitocaoContextDataContext = new khieunaitocaoContextDataContext())
            {
                var list=khieunaitocaoContextDataContext.thongketonghop_khieunai(date_tungay.DateTime,date_denngay.DateTime,dinhdanh.madonvi).ToList();
                grc_thongkedonthu.DataSource = list;
            }
        }

        private void date_denngay_EditValueChanged(object sender, EventArgs e)
        {
            fun_load();
        }

        private void date_tungay_EditValueChanged(object sender, EventArgs e)
        {
            fun_load();
        }
    }
}
