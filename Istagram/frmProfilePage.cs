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
    public partial class frmProfilePage : Form
    {
        public frmProfilePage()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            frmMainPage frmMainPage = new frmMainPage();
            frmMainPage.StartPosition = FormStartPosition.CenterScreen;
            frmMainPage.Show();
            this.Close();
        }

        private void frmProfilePage_Load(object sender, EventArgs e)
        {
            cmbMenu.Items.Add("Edit Profile");
            cmbMenu.Items.Add("Log out");

            IstagramDbContext dbContext = new IstagramDbContext();
            var imageList = dbContext.Images.OrderByDescending(x => x.ImageID).ToList();

            dbContext.Users.FirstOrDefault(x => x.UserID == LoginInfo.UserInfo.UserID);

            foreach (var item in imageList)
            {
                if (item.UserID == LoginInfo.UserInfo.UserID)
                {
                    PictureBox p = new PictureBox();
                    Label l = new Label();
                    Label l2 = new Label();

                    Label line = new Label();
                    line.AutoSize = false;
                    line.BorderStyle = BorderStyle.FixedSingle;
                    line.Height = 1;
                    line.Width = flwProfilePageImages.Width - 30;



                    User u = dbContext.Users.FirstOrDefault(x => x.UserID == item.UserID);
                    l.Text = u.UserName;
                    l.Font = new Font(l.Font.Name, 9, FontStyle.Bold);

                    p.ImageLocation = item.Picture;
                    p.Size = new System.Drawing.Size(320, 250);
                    p.SizeMode = PictureBoxSizeMode.StretchImage;

                    l2.Text = item.Description;

                    flwProfilePageImages.Controls.Add(l);
                    flwProfilePageImages.Controls.Add(p);
                    flwProfilePageImages.Controls.Add(l2);
                    flwProfilePageImages.Controls.Add(line);
                }
            }
        }

        private void cmbMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMenu.SelectedItem.ToString() == "Edit Profile")
            {
                frmEditProfile frmEditProfile = new frmEditProfile();
                frmEditProfile.StartPosition = FormStartPosition.CenterScreen;
                frmEditProfile.Show();
                this.Close();
            }
            else if (cmbMenu.SelectedItem.ToString() == "Log out")
            {
                IstagramDbContext dbContext = new IstagramDbContext();
                Log l = dbContext.Logs.FirstOrDefault(x => x.LogID == LoginInfo.LogID);
                l.LogOutTime = DateTime.Now;
                dbContext.SaveChanges();
                this.Close();
            }
        }
    }
}
