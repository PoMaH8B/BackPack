using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BackpackTask
{
    public partial class AddItemForm : Form
    {
        public Item newItem;

        public AddItemForm(Item oldItem = null)
        {
            InitializeComponent();
            btnOk.NotifyDefault(true);
            if(oldItem != null)
            {
                tbName.Text = oldItem.name;
                tbWeight.Text = oldItem.weigth.ToString();
                tbPrice.Text = oldItem.price.ToString();
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            double weight, price;

            if(tbName.Text == "")
            {
                MessageBox.Show("Неправильное задано название");
                return;
            }

            if(!Double.TryParse(tbWeight.Text, out weight))
            {
                MessageBox.Show("Неправильно задан вес");
                return;
            }

            if (!Double.TryParse(tbPrice.Text, out price))
            {
                MessageBox.Show("Неправильно задана цена");
                return;
            }

            newItem = new Item(tbName.Text, weight, price);
            DialogResult = DialogResult.OK;
        }
    }
}
