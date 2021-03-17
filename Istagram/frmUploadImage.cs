using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Istagram
{
    public partial class frmUploadImage : Form
    {
        public frmUploadImage()
        {
            InitializeComponent();
        }

        void Guid()
        {
            int n;
            char[] lowerCase = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            char[] upperCase = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            char[] number = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

            Random rnd = new Random();
            string[] guid = new string[8];
            n = rnd.Next(0, 26);
            guid[0] = lowerCase[n].ToString();
            n = rnd.Next(0, 26);
            guid[1] = lowerCase[n].ToString();
            n = rnd.Next(0, 26);
            guid[2] = lowerCase[n].ToString();
            n = rnd.Next(0, 26);
            guid[3] = upperCase[n].ToString();
            n = rnd.Next(0, 26);
            guid[4] = upperCase[n].ToString();
            n = rnd.Next(0, 10);
            guid[5] = number[n].ToString();
            n = rnd.Next(0, 10);
            guid[6] = number[n].ToString();
            n = rnd.Next(0, 10);
            guid[7] = number[n].ToString();

            string[] randomGuid = guid.OrderBy(x => rnd.Next()).ToArray();

            guidName = randomGuid[0] + randomGuid[1] + randomGuid[2] + randomGuid[3] + randomGuid[4] + randomGuid[5] + randomGuid[6] + randomGuid[7];
        }

        private void frmUploadImage_Load(object sender, EventArgs e)
        {
            lblUser.Text = LoginInfo.UserInfo.UserName;
            Guid();
        }


        private void btnUpload_Click(object sender, EventArgs e)
        {
            string url = txtImageUrl.Text;
            string fileName = guidName;
            SaveImage(fileName, url, ImageFormat.Png);
        }

        public void SaveImage(string filename, string imageUrl, ImageFormat format)
        {
            WebClient client = new WebClient();
            Stream stream = client.OpenRead(imageUrl);
            Bitmap bitmap; bitmap = new Bitmap(stream);

            if (bitmap != null)
            {
                string filePath = Application.StartupPath + "\\Images" + "\\";
                string fileNameWithExt = filename + "." + format.ToString().ToLower();
                string fileUrl = filePath + fileNameWithExt;
                bitmap.Save(fileUrl, format);

                pictureBox1.ImageLocation = fileUrl;
            }
            stream.Flush();
            stream.Close();
            client.Dispose();
        }

        string guidName;
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            IstagramDbContext dbContext = new IstagramDbContext();
            string filePath = Application.StartupPath + "\\Images" + "\\";
            string fileNameWithExt = guidName + ".png";
            string fileUrl = filePath + fileNameWithExt;
            Entities.Image i = new Entities.Image()
            {
                UserID = LoginInfo.UserInfo.UserID,
                Picture = fileUrl,
                Description = txtDescription.Text,
            };
            dbContext.Images.Add(i);
            dbContext.SaveChanges();

            frmMainPage frmMainPage = new frmMainPage();
            frmMainPage.StartPosition = FormStartPosition.CenterScreen;
            frmMainPage.Show();
            this.Close();
        }
    }
}
