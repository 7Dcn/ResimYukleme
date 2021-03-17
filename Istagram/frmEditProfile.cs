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
    public partial class frmEditProfile : Form
    {
        public frmEditProfile()
        {
            InitializeComponent();
        }

        private void frmEditProfile_Load(object sender, EventArgs e)
        {
            IstagramDbContext dbContext = new IstagramDbContext();
            User u = dbContext.Users.FirstOrDefault(x => x.UserID == LoginInfo.UserInfo.UserID);
            txtUserName.Text = u.UserName;
            txtPassword.Text = u.Password;
            txtFirstName.Text = u.FirstName;
            txtLastName.Text = u.LastName;
            txtEmail.Text = u.EmailAddress;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            IstagramDbContext dbContext = new IstagramDbContext();
            User u = dbContext.Users.FirstOrDefault(x => x.UserID == LoginInfo.UserInfo.UserID);
            u.UserName = txtUserName.Text;
            u.Password = txtPassword.Text;
            u.FirstName = txtFirstName.Text;
            u.LastName = txtLastName.Text;
            u.EmailAddress = txtEmail.Text;
            dbContext.SaveChanges();

            frmProfilePage frmProfilePage = new frmProfilePage();
            frmProfilePage.StartPosition = FormStartPosition.CenterScreen;
            frmProfilePage.Show();
            this.Close();
        }
    }
}
