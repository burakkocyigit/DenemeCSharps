using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DenemeEntityFramework
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        ProductDal _productDal = new ProductDal();

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridLoad();
        }

        private void dataGridLoad()
        {
            dgwProducts.DataSource = _productDal.getAll();
        }

        private void searchLoad(string key)
        {
            dgwProducts.DataSource = _productDal.getByName(key);    //veritabanından çekiyor
            //dgwProducts.DataSource = _productDal.getAll().Where(p => p.Name.ToLower().Contains(key.ToLower())).ToList();  //listeden çekiyor
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _productDal.add(new Product
            {
                Name = txbName.Text,
                UnitPrice = Convert.ToDecimal(txbUnitPrice.Text),
                StockAmount = Convert.ToInt32(txbStockAmount.Text)
            });
            dataGridLoad();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _productDal.update(new Product
            {
                Id = Convert.ToInt32(dgwProducts.CurrentRow.Cells[0].Value),
                Name = tbxNameUpdate.Text,
                UnitPrice = Convert.ToDecimal(tbxUnitPriceUpdate.Text),
                StockAmount = Convert.ToInt32(tbxStockAmountUpdate.Text)
            });
            dataGridLoad();
        }

        private void dgwProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbxNameUpdate.Text = dgwProducts.CurrentRow.Cells[1].Value.ToString();
            tbxUnitPriceUpdate.Text = dgwProducts.CurrentRow.Cells[2].Value.ToString();
            tbxStockAmountUpdate.Text = dgwProducts.CurrentRow.Cells[3].Value.ToString();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            _productDal.delete(new Product
            {
                Id = Convert.ToInt32(dgwProducts.CurrentRow.Cells[0].Value)
            });
            dataGridLoad();
        }

        private void tbxSearch_TextChanged(object sender, EventArgs e)
        {
            searchLoad(tbxSearch.Text);
        }
    }
}
