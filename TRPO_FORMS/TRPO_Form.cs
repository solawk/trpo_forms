using TRPO_BL;
using TRPO_DM.ViewModels;
using TRPO_DM.InputModels;
using TRPO_FORMS.Prompts;

namespace TRPO_FORMS
{
    public partial class TRPO_Form : Form
    {
        DataManager manager;

        public TRPO_Form()
        {
            InitializeComponent();

            manager = new DataManager();

            CategoriesView.NodeMouseClick += new TreeNodeMouseClickEventHandler(CategoriesView_NodeMouseClick);
            ElementsGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            RefreshForm();
        }

        void CategoriesView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            ElementsDisplay((int)e.Node.Tag);
        }

        private void TRPO_Form_Load(object sender, EventArgs e)
        {
            
        }

        private void CategoriesView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            
        }

        // Обновление формы
        private void RefreshForm()
        {
            var categories = manager.categories.Read();
            
            CategoriesView.Nodes.Clear();
            RecursiveCategoriesDisplay(categories, null, CategoriesView, null);
            CategoriesView.ExpandAll();

            if (ElementsGrid.Tag != null) ElementsDisplay((int)ElementsGrid.Tag);
        }

        // Рекурсивное заполнение дерева категорий
        private void RecursiveCategoriesDisplay(List<CategoryVM> categories, int? parentID, TreeView? parentView, TreeNode? parentNode)
        {
            foreach (var c in categories)
            {
                if (c.ParentID != parentID) continue;

                TreeNode node = new TreeNode(c.Name);
                node.Tag = c.ID;

                if (parentID == null)
                {
                    parentView.Nodes.Add(node);                   
                }
                else
                {
                    parentNode.Nodes.Add(node);
                }

                RecursiveCategoriesDisplay(categories, c.ID, null, node);
            }
        }

        // Заполнение таблицы элементов в категории
        private void ElementsDisplay(int categoryID)
        {
            ElementsGrid.Rows.Clear();

            var elements = manager.elements.ReadCategory(categoryID);

            foreach (var e in elements)
            {
                Dictionary<string, object> dataDictionary = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, object>>(e.Data);
                string dataString = "";

                foreach (var d in dataDictionary)
                {
                    dataString += ", " + d.Key + ": " + d.Value.ToString();
                }

                if (dataDictionary.Count > 0) dataString = dataString.Remove(0, 2);

                ElementsGrid.Rows.Add(new object[]{ e.Name, dataString });
                ElementsGrid.Rows[ElementsGrid.Rows.Count - 1].Tag = e.ID;
            }

            ElementsGrid.Tag = categoryID;
        }

        private void CatCreateButton_Click(object sender, EventArgs e)
        {
            var categories = manager.categories.Read();

            var prompt = new CatCreate_Form();

            prompt.MainForm = this;

            ComboBox parentList = (ComboBox)prompt.Controls.Find("ParentList", true)[0];
            parentList.Items.Add("- Без родительской категории -");
            foreach (var c in categories)
            {
                parentList.Items.Add(c.Name);
                prompt.categoryIDs.Add(c.ID);
            }
            parentList.SelectedIndex = 0;

            prompt.Show();
        }

        private void CatDeleteButton_Click(object sender, EventArgs e)
        {
            int id = (int)CategoriesView.SelectedNode.Tag;
            DeleteCategory(id);
        }

        private void ElCreateButton_Click(object sender, EventArgs e)
        {
            var categories = manager.categories.Read();

            if (categories.Count == 0)
            {
                return;
            }

            var prompt = new ElCreate_Form();

            prompt.MainForm = this;

            ComboBox parentList = (ComboBox)prompt.Controls.Find("CategoryList", true)[0];
            foreach (var c in categories)
            {
                parentList.Items.Add(c.Name);
                prompt.categoryIDs.Add(c.ID);

                if (c.ID == (int)ElementsGrid.Tag)
                {
                    parentList.SelectedIndex = parentList.Items.Count - 1;
                }
            }

            if (ElementsGrid.Tag == null)
            {
                parentList.SelectedIndex = 0;
            }           

            prompt.Show();
        }

        private void ElDeleteButton_Click(object sender, EventArgs e)
        {
            int id = (int)ElementsGrid.SelectedRows[0].Tag;
            DeleteElement(id);
        }

        // CRUD для категорий

        public void CreateCategory(string name, int? parentID)
        {
            manager.categories.Create(new CategoryIM(0, parentID, name));
            RefreshForm();
        }

        public void DeleteCategory(int id)
        {
            manager.categories.Delete(id);
            RefreshForm();
        }

        // CRUD для элементов

        public void CreateElement(string name, string data, int categoryID)
        {
            manager.elements.Create(new ElementIM(0, name, data, categoryID));
            RefreshForm();
        }

        public void DeleteElement(int id)
        {
            manager.elements.Delete(id);
            RefreshForm();
        }
    }
}