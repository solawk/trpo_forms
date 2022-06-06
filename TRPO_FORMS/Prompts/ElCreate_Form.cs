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
    public partial class ElCreate_Form : Form
    {
        public TRPO_Form MainForm;
        public List<int> categoryIDs = new List<int>();

        public ElCreate_Form()
        {
            InitializeComponent();
        }

        private void ParentList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            if (NameInput.Text.Trim(' ').Equals(""))
            {
                MessageBox.Show("Пустое название элемента!");
                return;
            }

            string name = NameInput.Text;

            try
            {
                Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, object>>(DataInput.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Некорректно введены характеристики!");
                return;
            }

            if (DataInput.Text.Trim(' ').Equals(""))
            {
                MessageBox.Show("Пустой список характеристик!");
                return;
            }

            string data = DataInput.Text;

            int categoryIndex = CategoryList.SelectedIndex;
            int categoryID = categoryIDs[categoryIndex];

            MainForm.CreateElement(name, data, categoryID);
            Close();
        }
    }
}
