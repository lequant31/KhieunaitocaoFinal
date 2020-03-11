using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace khieunaitocao
{
    public partial class ctl_thongketocao : UserControl
    {
        khieunaitocaoContextDataContext khieunaitocaoContextDataContext;
        public ctl_thongketocao()
        {
            InitializeComponent();
        }
        private void fun_load()
        {
            using (khieunaitocaoContextDataContext = new khieunaitocaoContextDataContext())
            {
                var list = khieunaitocaoContextDataContext.thongketonghop_tocao(date_tungay.DateTime, date_denngay.DateTime, dinhdanh.madonvi).ToList();
                grc_thongketocao.DataSource = list;
            }
        }

        private void date_tungay_EditValueChanged(object sender, EventArgs e)
        {
            fun_load();
        }

        private void date_denngay_EditValueChanged(object sender, EventArgs e)
        {
            fun_load();
        }
    }

}
