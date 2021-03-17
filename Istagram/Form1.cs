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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void lblSignUp_Click(object sender, EventArgs e)
        {
            frmRegister frmRegister = new frmRegister();
            frmRegister.StartPosition = FormStartPosition.CenterScreen;

            DialogResult result = frmRegister.ShowDialog();
            if (result == DialogResult.OK)
            {
                MessageBox.Show("Successful");
            }
            else
            {
                MessageBox.Show("Warning");
            }
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text;
            string password = txtPassword.Text;
            IstagramDbContext dbContext = new IstagramDbContext();
            User u = dbContext.Users.FirstOrDefault(x => x.UserName == userName);
            if (u != null && u.Password == password)
            {
                frmMainPage frmMainPage = new frmMainPage();
                frmMainPage.StartPosition = FormStartPosition.CenterScreen;
                LoginInfo.UserInfo = new UserInfo()
                {
                    UserName = u.UserName,
                    UserID = u.UserID                    
                };

                Log l = new Log();
                l.UserID = u.UserID;
                l.LogInTime = DateTime.Now;
                dbContext.Logs.Add(l);
                dbContext.SaveChanges();

                LoginInfo.LogID = l.LogID;

                txtUserName.Clear();
                txtPassword.Clear();

                frmMainPage.Show();
                
            }
            else
            {
                MessageBox.Show("Error");
            }
        }
    }
}
