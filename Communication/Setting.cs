using BLL;
using CCWin;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Communication
{
    public partial class Setting : CCSkinMain
    {
        User user=new User();
        UserManager userManager = new UserManager();
        public Setting()
        {
            InitializeComponent();
        }
        public Setting(string ip)
        {
            InitializeComponent();
            user.IP = ip;
        }

        private void Setting_Load(object sender, EventArgs e)
        {
            user = userManager.GetUserByIP(user.IP);
            pictureIcon.Image = Base.ChageToImage(user.Picture);
            txtName.Text = user.Name;
            txtSignature.Text = user.Signature;
        }

        private void btnCannel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPicture_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "PNG文件|*.png|GIF文件|*.gif|BMP文件|*.bmp|JPG文件|*.jpg|所有文件(*.*)|*.*";
            fileDialog.InitialDirectory = Directory.GetCurrentDirectory() + "\\Head\\";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = fileDialog.FileName;
                pictureIcon.Image = Image.FromFile(fileName);
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if(txtName.Text==null||txtName.Text=="")
            {
                txtName.Focus();
                MessageBox.Show("请输入昵称");
                return;
            }
            user.Name = txtName.Text;
            user.Signature = txtSignature.Text;
            user.Picture = Base.ChangeToBytes(pictureIcon.Image);
            userManager.UpdateUser(user);
            this.Close();
        }

        private void Setting_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

    }
}
