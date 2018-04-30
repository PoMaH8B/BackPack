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
    public partial class MainForm : Form
    {
        private List<Item> items;

        public MainForm()
        {
            InitializeComponent();
            items = new List<Item>();
            AddItems();
            ShowItems(items);
        }

        private void AddItems()
        {
            items.Add(new Item("Книга", 1, 600));
            items.Add(new Item("Бинокль", 2, 5000));
            items.Add(new Item("Аптечка", 4, 1500));
            items.Add(new Item("Ноутбук", 2, 40000));
            items.Add(new Item("Котелок", 1, 500));
        }

        private void ShowItems(List<Item> _items)
        {
            itemsListView.Items.Clear();

            foreach (Item i in _items)
            {
                itemsListView.Items.Add(new ListViewItem(new string[] { i.name, i.weigth.ToString(), 
                    i.price.ToString() }));
            }
        }

        //сбросить решение
        private void btnReset_Click(object sender, EventArgs e)
        {
            ShowItems(items);
        }

        //решить задачу
        private void btnSolve_Click(object sender, EventArgs e)
        {
            Backpack bp = new Backpack(Convert.ToDouble(weightTextBox.Text));

            bp.MakeAllSets(items);

            List<Item> solve = bp.GetBestSet();

            if(solve == null)
            {
                MessageBox.Show("Нет решения!");
            }
            else
            {
                itemsListView.Items.Clear();

                ShowItems(solve);

                MessageBox.Show("Решение приведено в таблице");
            }
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            AddItemForm iForm = new AddItemForm();
            if(iForm.ShowDialog() == DialogResult.OK)
            {
                items.Add(iForm.newItem);
                ShowItems(items);
            }
        }

        private void itemsListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Item item = items[itemsListView.SelectedItems[0].Index];

            AddItemForm iForm = new AddItemForm(item);
            if(iForm.ShowDialog() == DialogResult.OK)
            {
                items[itemsListView.SelectedItems[0].Index] = iForm.newItem;
                ShowItems(items);
            }
        }

        private void btnRemoveItem_Click(object sender, EventArgs e)
        {
            RemoveItemForm iForm = new RemoveItemForm();
            if(iForm.ShowDialog() == DialogResult.OK)
            {
                if(items.Exists(item => item.name == iForm.name))
                {
                    items.RemoveAll(item => item.name == iForm.name);
                    ShowItems(items);
                }
                else
                {
                    MessageBox.Show("Такого предмета не существует");
                }
            }
        }
    }
}