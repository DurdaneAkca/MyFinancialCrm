using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyFinancialCrm.Models;

namespace MyFinancialCrm
{
    public partial class FrmUsers : Form
    {
        public FrmUsers()
        {
            InitializeComponent();
        }
        FinancialCrmDbEntities db = new FinancialCrmDbEntities();
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = new Icon("foto.jpg").ToBitmap();
            pictureBox1.Image = Properties.Resources.foto;
        }
        

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            // Veritabanında kullanıcı adı ve şifreyi kontrol et
            var user = db.Users.FirstOrDefault(x => x.Username == username && x.Password == password);

            if (user != null)
            {
                // Kullanıcı doğrulandı, yeni formu aç
                FrmDashboard frm = new FrmDashboard();
                frm.Show();
                this.Hide();
            }
            else
            {
                // Hatalı giriş mesajı göster
                lblErrorMessage.Text = "Hatalı kullanıcı adı veya şifre!";
                lblErrorMessage.ForeColor = Color.Red; // Mesajın kırmızı görünmesini sağla
                lblErrorMessage.Visible = true; // Label'ı görünür yap

                // Kullanıcı adı ve şifre alanlarını temizle
                txtUsername.Text = string.Empty;
                txtPassword.Text = string.Empty;

                // Kullanıcı adını girmek için tekrar odağı username alanına getir
                txtUsername.Focus();
            }
        }


        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            // CheckBox işaretliyse şifreyi göster, değilse gizle
            if (chkShowPassword.Checked)
            {
                txtPassword.PasswordChar = '\0'; // Şifreyi göster
            }
            else
            {
                txtPassword.PasswordChar = '*'; // Şifreyi gizle
        }
    }
    }
}
