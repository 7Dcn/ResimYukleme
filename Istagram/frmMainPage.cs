using Istagram.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Istagram
{
    public partial class frmMainPage : Form
    {
        public frmMainPage()
        {
            InitializeComponent();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            IstagramDbContext dbContext = new IstagramDbContext();
            Log l = dbContext.Logs.FirstOrDefault(x => x.LogID == LoginInfo.LogID);
            l.LogOutTime = DateTime.Now;
            dbContext.SaveChanges();
            this.Close();
        }

        private void frmMainPage_Load(object sender, EventArgs e)
        {
            lblUser.Text = "Welcome " + LoginInfo.UserInfo.UserName;
            btnLogs.Visible = false;
            if (LoginInfo.UserInfo.UserName == "Admin")
            {
                btnLogs.Visible = true;
            }
            IstagramDbContext dbContext = new IstagramDbContext();
            var imageList = dbContext.Images.OrderByDescending(x=>x.ImageID).ToList();

            foreach (var item in imageList)
            {
                PictureBox p = new PictureBox();
                Label l = new Label();
                Label l2 = new Label();

                Label line = new Label();
                line.AutoSize = false;
                line.BorderStyle = BorderStyle.FixedSingle;
                line.Height = 1;
                line.Width = flwImages.Width-30;
                


                User u = dbContext.Users.FirstOrDefault(x => x.UserID == item.UserID);
                l.Text = u.UserName;
                l.Font = new Font(l.Font.Name, 9, FontStyle.Bold);

                p.ImageLocation = item.Picture;
                p.Size = new System.Drawing.Size(320, 250);
                p.SizeMode = PictureBoxSizeMode.StretchImage;

                l2.Text = item.Description;

                flwImages.Controls.Add(l);
                flwImages.Controls.Add(p);
                flwImages.Controls.Add(l2);
                flwImages.Controls.Add(line);

            }
        }

        private void btnUploadPic_Click(object sender, EventArgs e)
        {
            frmUploadImage frmUploadImage = new frmUploadImage();
            frmUploadImage.StartPosition = FormStartPosition.CenterScreen;
            frmUploadImage.Show();
            this.Close();
        }

        private void btnLogs_Click(object sender, EventArgs e)
        {
            frmAdminPage frmAdminPage = new frmAdminPage();
            frmAdminPage.StartPosition = FormStartPosition.CenterScreen;
            frmAdminPage.Show();
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            frmProfilePage frmProfilePage = new frmProfilePage();
            frmProfilePage.StartPosition = FormStartPosition.CenterScreen;
            frmProfilePage.Show();
            this.Close();
        }
    }
}
