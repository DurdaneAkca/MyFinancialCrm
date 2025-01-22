using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyFinancialCrm.Models;

namespace MyFinancialCrm
{
    public partial class FrmCategories : Form
    {
        public FrmCategories()
        {
            InitializeComponent();
        }

        FinancialCrmDbEntities db = new FinancialCrmDbEntities();
        private void FrmCategories_Load(object sender, EventArgs e)
        {
            var values = db.Categories.ToList();
            dataGridView1.DataSource = values;
        }

        private void btnCategoriList_Click(object sender, EventArgs e)
        {
            var values = db.Categories.ToList();
            dataGridView1.DataSource = values;
        }

        private void btnCategoriCreate_Click(object sender, EventArgs e)
        {
            string name = txtCategoryName.Text;

            Categories categories = new Categories();
            categories.CategoryName = name;
            db.Categories.Add(categories);
            db.SaveChanges();
            MessageBox.Show("Kategori Ekleme Başarılı", "Kategoriler", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCategoriDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtCategoryId.Text);
            var deleteValue = db.Categories.Find(id);
            db.Categories.Remove(deleteValue);
            db.SaveChanges();
            MessageBox.Show("Kategori Silme İşlemi Başarılı", "Kategoriler", MessageBoxButtons.OK, MessageBoxIcon.Information);

            var values=db.Categories.ToList();
            dataGridView1.DataSource = values;
        }

        private void btnCategoriUpdate_Click(object sender, EventArgs e)
        {
            string name = txtCategoryName.Text;
            int id = int.Parse(txtCategoryId.Text);

            var updateValue = db.Categories.Find(id);
            updateValue.CategoryName = name;
            db.SaveChanges();
            MessageBox.Show("Kategori Güncelleme İşlemi Başarılı", "Kategoriler", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            var values2 = db.Categories.ToList();
            dataGridView1.DataSource = values2;
        }

        private void btnCategoriesForm_Click(object sender, EventArgs e)
        {
            FrmCategories frm = new FrmCategories();
            frm.Show();
            this.Hide();
        }

        private void btnBanksForm_Click(object sender, EventArgs e)
        {
            FrmBanks frm = new FrmBanks();
            frm.Show();
            this.Hide();
        }

        private void btnSpendingForm_Click(object sender, EventArgs e)
        {
            FrmSpendings frm = new FrmSpendings();
            frm.Show();
            this.Hide();
        }

        private void btnDashboardForm_Click(object sender, EventArgs e)
        {
            FrmDashboard frm = new FrmDashboard();
            frm.Show();
            this.Hide();
        }

        private void btnExitForm_Click(object sender, EventArgs e)
        {
            FrmUsers frm = new FrmUsers();
            frm.Show();
            this.Hide();
        }

        private void btnSettingsForm_Click(object sender, EventArgs e)
        {
            FrmSettings frm = new FrmSettings();
            frm.Show();
            this.Hide();
        }

        private void btnBankTransactionsForm_Click(object sender, EventArgs e)
        {
            FrmBankTransactions frm = new FrmBankTransactions();
            frm.Show();
            this.Hide();
        }
    }
}
