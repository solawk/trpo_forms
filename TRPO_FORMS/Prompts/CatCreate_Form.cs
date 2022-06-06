using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TRPO_FORMS.Prompts
{
    public partial class CatCreate_Form : Form
    {
        public TRPO_Form MainForm;
        public List<int> categoryIDs = new List<int>();

        public CatCreate_Form()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void NameInput_TextChanged(object sender, EventArgs e)
        {

        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            if (NameInput.Text.Trim(' ').Equals(""))
            {
                MessageBox.Show("Пустое название категории!");
                return;
            }

            string name = NameInput.Text;
            int parentIndex = ParentList.SelectedIndex;
            int? parentID = null;

            if (parentIndex > 0)
            {
                parentID = categoryIDs[parentIndex - 1];
            }

            MainForm.CreateCategory(name, parentID);
            Close();
        }
    }
}
