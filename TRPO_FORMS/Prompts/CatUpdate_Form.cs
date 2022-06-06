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
    public partial class CatUpdate_Form : Form
    {
        public TRPO_Form MainForm;
        public int idOfCategory;
        public List<int> categoryIDs = new List<int>();

        public CatUpdate_Form()
        {
            InitializeComponent();
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

            MainForm.UpdateCategory(idOfCategory, name, parentID);
            Close();
        }
    }
}
