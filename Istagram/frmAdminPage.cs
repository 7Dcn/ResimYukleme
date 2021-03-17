using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Istagram
{
    public partial class frmAdminPage : Form
    {
        public frmAdminPage()
        {
            InitializeComponent();
        }

        private void frmAdminPage_Load(object sender, EventArgs e)
        {
            IstagramDbContext dbContext = new IstagramDbContext();
            var list = dbContext.Logs.ToList();
            lstLogs.Items.Clear();
            foreach (var item in list)
            {
                lstLogs.Items.Add(item);
            }
        }
    }
}
