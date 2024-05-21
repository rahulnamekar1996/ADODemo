using ADODemo.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ADODemo
{
    public partial class Form1 : Form

    {
        ProductCrud crud;
        public Form1()
        {
            InitializeComponent();
            crud= new ProductCrud();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            {
                try
                {
                    List<Category> list = crud.GetCategories();
                    txtcategory.DataSource = list;
                    txtcategory.DisplayMember = "Cname";
                    txtcategory.ValueMember = "Cid";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Product p = new Product();
                p.Name = txtproductname.Text;
                p.Price = Convert.ToInt32(txtproductprice.Text);
                p.Cid = Convert.ToInt32(txtcategory.SelectedValue);
                int res = crud.AddProduct(p);
                if (res > 0)
                {
                    MessageBox.Show("Record inserted..");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

       
    }
}    
