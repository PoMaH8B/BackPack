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
    public partial class RemoveItemForm : Form
    {
        public string name;

        public RemoveItemForm()
        {
            InitializeComponent();
            btnOk.NotifyDefault(true);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if(tbName.Text == "")
            {
                MessageBox.Show("Неправильное задано название");
                return;
            }

            name = tbName.Text;
            DialogResult = DialogResult.OK;
        }
    }
}
