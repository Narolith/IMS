using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using IMS.BL;

namespace IMS.UI
{
    public partial class MainForm : Form
    {

        public MainForm()
        {
            InitializeComponent();
            MainForm_Load();

        }

        public void MainForm_Load()
        {
            var bsParts = new BindingSource
            {
                DataSource = Inventory.AllParts
            };
            dgvParts.DataSource = bsParts;

            dgvParts.Columns["PartID"].HeaderText = "Part ID";
            dgvParts.Columns["Name"].HeaderText = "Part Name";
            dgvParts.Columns["InStock"].HeaderText = "Inventory";
            dgvParts.Columns["Price"].HeaderText = "Price per Unit";
            dgvParts.Columns["Min"].HeaderText = "Min";
            dgvParts.Columns["Min"].Width = 76;
            dgvParts.Columns["Max"].HeaderText = "Max";
            dgvParts.Columns["Max"].Width = 76;

            var bsProducts = new BindingSource
            {
                DataSource = Inventory.Products
            };
            dgvProducts.DataSource = bsProducts;

            dgvProducts.Columns["ProductID"].HeaderText = "Product ID";
            dgvProducts.Columns["Name"].HeaderText = "Product Name";
            dgvProducts.Columns["InStock"].HeaderText = "Inventory";
            dgvProducts.Columns["Price"].HeaderText = "Price per Unit";
            dgvProducts.Columns["Min"].HeaderText = "Min";
            dgvProducts.Columns["Min"].Width = 76;
            dgvProducts.Columns["Max"].HeaderText = "Max";
            dgvProducts.Columns["Max"].Width = 76;

        }
        #region Parts
        private void BtnPartAdd_Click(object sender, EventArgs e)
        {
            new PartForm().ShowDialog();
        }

        private void BtnPartModify_Click(object sender, EventArgs e)
        {
            if (dgvParts.CurrentRow == null)
            {
                MessageBox.Show("Please select a part to modify.", "Error");
                return;
            }
            if (dgvParts.CurrentRow.DataBoundItem.GetType() == typeof(InhousePart))
            {
                InhousePart inhousePart = (InhousePart)dgvParts.CurrentRow.DataBoundItem;
                new PartForm(inhousePart).ShowDialog();
                return;
            }
            if (dgvParts.CurrentRow.DataBoundItem.GetType() == typeof(OutsourcedPart))
            {
                OutsourcedPart outsourcedPart = (OutsourcedPart)dgvParts.CurrentRow.DataBoundItem;
                new PartForm(outsourcedPart).ShowDialog();
                return;
            }
        }

        private void BtnDeletePart_Click(object sender, EventArgs e)
        {
            if (dgvParts.CurrentRow == null)
            {
                MessageBox.Show("Please select a part to delete.", "Error");
                return;
            }
            if (dgvParts.CurrentRow.DataBoundItem.GetType() == typeof(InhousePart))
            {
                InhousePart part = (InhousePart)dgvParts.CurrentRow.DataBoundItem;
                var result = MessageBox.Show($"Delete {part.Name}?", "Delete Confirmation", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    Inventory.AllParts.Remove(part);
                    return;
                }
                else
                {
                    return;
                }
            }
            if (dgvParts.CurrentRow.DataBoundItem.GetType() == typeof(OutsourcedPart))
            {
                OutsourcedPart part = (OutsourcedPart)dgvParts.CurrentRow.DataBoundItem;
                var result = MessageBox.Show($"Delete {part.Name}?", "Delete Confirmation", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    Inventory.AllParts.Remove(part);
                    return;
                }
                else
                {
                    return;
                }
            }

        }

        private void BtnSearchParts_Click(object sender, EventArgs e)
        {
            SearchParts();
        }

        private void TbSearchParts_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchParts();
            }
        }

        private void SearchParts()
        {
            var searchValue = tbSearchParts.Text.ToLower();
            foreach (DataGridViewRow row in dgvParts.Rows)
            {
                row.DefaultCellStyle.BackColor = Color.White;
                if (row.Cells[0].Value.ToString().ToLower().Equals(searchValue))
                {
                    row.DefaultCellStyle.BackColor = Color.Yellow;
                }
                if (row.Cells[1].Value.ToString().ToLower().Equals(searchValue))
                {
                    row.DefaultCellStyle.BackColor = Color.Yellow;
                }
            }
        }
        #endregion

        #region Product
        private void BtnProductAdd_Click(object sender, EventArgs e)
        {
            ProductForm productForm = new ProductForm();
            productForm.Show(this);

        }

        private void BtnProductModify_Click(object sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow == null)
            {
                MessageBox.Show("Please select a product to modify.", "Error");
                return;
            }
            Product product = (Product)dgvProducts.CurrentRow.DataBoundItem;
                new ProductForm(product).ShowDialog();
                return;
        }

        private void BtnDeleteProduct_Click(object sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow == null)
            {
                MessageBox.Show("Please select a product to delete.", "Error");
                return;
            }
            Product product = (Product)dgvProducts.CurrentRow.DataBoundItem;
            var result = MessageBox.Show($"Delete {product.Name}?", "Delete Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                if (product.AssociatedParts.Count != 0)
                {
                    MessageBox.Show($"Can't delete {product.Name} because parts are still associated to the product.", "Error");
                    return;
                }
                else
                {
                    Inventory.Products.Remove(product);
                    return;
                }
            }
            else
            {
                return;
            }
        }

        private void SearchProducts()
        {
            var searchValue = tbSearchProducts.Text.ToLower();
            foreach (DataGridViewRow row in dgvProducts.Rows)
            {
                row.DefaultCellStyle.BackColor = Color.White;
                if (row.Cells[0].Value.ToString().ToLower().Equals(searchValue))
                {
                    row.DefaultCellStyle.BackColor = Color.Yellow;
                }
                if (row.Cells[1].Value.ToString().ToLower().Equals(searchValue))
                {
                    row.DefaultCellStyle.BackColor = Color.Yellow;
                }
            }
        }

        private void BtnSearchProducts_Click(object sender, EventArgs e)
        {
            SearchProducts();
        }

        private void TbSearchProducts_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchProducts();
            }
        }
        #endregion

        private void BtnExit_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show($"Are you sure you want to exit?", "Exit Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
                return;
            }
            else
            {
                return;
            }

        }
    }
}

