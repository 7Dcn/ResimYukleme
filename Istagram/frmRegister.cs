using Istagram.Entities;
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
    public partial class frmRegister : Form
    {
        public frmRegister()
        {
            InitializeComponent();
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            IstagramDbContext dbContext = new IstagramDbContext();

            User u = new User()
            {
                UserName = txtUserName.Text,
                Password = txtPassword.Text,
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                EmailAddress = txtEmail.Text
            };

            dbContext.Users.Add(u);
            dbContext.SaveChanges();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
