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
                NameInput.BackColor = Color.Red;
                return;
            }

            string name = NameInput.Text;

            try
            {
                Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, object>>(DataInput.Text);
            }
            catch (Exception)
            {
                DataInput.BackColor = Color.Red;
                return;
            }

            if (DataInput.Text.Trim(' ').Equals(""))
            {
                DataInput.BackColor = Color.Red;
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
