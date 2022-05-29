using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TRPO_DM.ViewModels;

namespace TRPO_FORMS.Info
{
    public partial class SearchForm : Form
    {
        public TRPO_Form MainForm;

        public SearchForm()
        {
            InitializeComponent();

            ElementsGrid.CellDoubleClick += new DataGridViewCellEventHandler(ElementsView_CellDoubleClick);
        }

        private void ElementsView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;

            var row = ElementsGrid.Rows[e.RowIndex];
            int id = (int)row.Tag;

            MainForm.ReadElement(id);
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            string query = SearchInput.Text;

            List<ElementVM>? elements;

            try
            {
                elements = MainForm.manager.elements.Search(query);
            }
            catch (Exception)
            {
                SearchInput.BackColor = Color.Red;
                return;
            }

            if (elements == null)
            {
                return;
            }

            ElementsDisplay(elements);
        }
        
        // Заполнение таблицы элементов в категории
        private void ElementsDisplay(List<ElementVM> elements)
        {
            ElementsGrid.Rows.Clear();

            foreach (var e in elements)
            {
                Dictionary<string, object> dataDictionary = MainForm.ParseData(e.Data);
                string dataString = "";

                foreach (var d in dataDictionary)
                {
                    dataString += ", " + d.Key + ": " + d.Value.ToString();
                }

                if (dataDictionary.Count > 0) dataString = dataString.Remove(0, 2);

                ElementsGrid.Rows.Add(new object[]{ e.Name, dataString });
                var row = ElementsGrid.Rows[ElementsGrid.Rows.Count - 1];

                row.Tag = e.ID;
            }
        }
    }
}
