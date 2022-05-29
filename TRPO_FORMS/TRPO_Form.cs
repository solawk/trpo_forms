using TRPO_BL;
using TRPO_DM.ViewModels;
using TRPO_DM.InputModels;
using TRPO_FORMS.Prompts;
using TRPO_FORMS.Info;

namespace TRPO_FORMS
{
    public partial class TRPO_Form : Form
    {
        public DataManager manager;

        public TRPO_Form()
        {
            InitializeComponent();

            manager = new DataManager();

            CategoriesView.NodeMouseClick += new TreeNodeMouseClickEventHandler(CategoriesView_NodeMouseClick);
            ElementsGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ElementsGrid.CellDoubleClick += new DataGridViewCellEventHandler(ElementsView_CellDoubleClick);
            RefreshForm();
        }

        private void CategoriesView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            ElementsDisplay((int)e.Node.Tag);
        }

        private void ElementsView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;

            var row = ElementsGrid.Rows[e.RowIndex];
            int id = (int)row.Tag;

            ReadElement(id);
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

        public Dictionary<string, object> ParseData(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, object>>(data);
        }

        // Заполнение таблицы элементов в категории
        private void ElementsDisplay(int categoryID)
        {
            ElementsGrid.Rows.Clear();

            var elements = manager.elements.ReadCategory(categoryID);

            foreach (var e in elements)
            {
                Dictionary<string, object> dataDictionary = ParseData(e.Data);
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

            ElementsGrid.Tag = categoryID;
        }

        private CategoryVM findCategoryInListByID(List<CategoryVM> categories, int id)
        {
            return categories.FindLast(c => c.ID == id);
        }

        private bool isCategoryIndependentOf(List<CategoryVM> categories, int categoryID, int possibleDependencyID)
        {
            CategoryVM category = findCategoryInListByID(categories, categoryID);
            int? parentID = category.ParentID;

            while (parentID != null)
            {
                if (parentID == possibleDependencyID) return false;

                category = findCategoryInListByID(categories, (int)parentID);
                parentID = category.ParentID;
            }

            return true;
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

        private void CatUpdateButton_Click(object sender, EventArgs e)
        {
            if (CategoriesView.SelectedNode == null) return;

            var categories = manager.categories.Read();
            int id = (int)CategoriesView.SelectedNode.Tag;
            var category = manager.categories.Read(id);

            var prompt = new CatUpdate_Form();

            prompt.MainForm = this;
            prompt.idOfCategory = id;

            TextBox nameInput = (TextBox)prompt.Controls.Find("NameInput", true)[0];
            nameInput.Text = category.Name;

            ComboBox parentList = (ComboBox)prompt.Controls.Find("ParentList", true)[0];
            parentList.Items.Add("- Без родительской категории -");
            parentList.SelectedIndex = 0;
            foreach (var c in categories)
            {
                if (c.ID == category.ID || !isCategoryIndependentOf(categories, c.ID, category.ID))
                {
                    continue;
                }

                parentList.Items.Add(c.Name);
                prompt.categoryIDs.Add(c.ID);

                if (c.ID == category.ParentID)
                {
                    parentList.SelectedIndex = parentList.Items.Count - 1;
                }
            }

            prompt.Text = category.Name + " - Редактирование";
            prompt.Show();
        }

        private void CatDeleteButton_Click(object sender, EventArgs e)
        {
            if (CategoriesView.SelectedNode == null) return;

            int id = (int)CategoriesView.SelectedNode.Tag;
            DeleteCategory(id);
        }

        private void ElCreateButton_Click(object sender, EventArgs e)
        {
            if (ElementsGrid.Tag == null) return;

            var categories = manager.categories.Read();

            if (categories.Count == 0)
            {
                return;
            }

            var prompt = new ElCreate_Form();

            prompt.MainForm = this;

            ComboBox categoryList = (ComboBox)prompt.Controls.Find("CategoryList", true)[0];
            foreach (var c in categories)
            {
                categoryList.Items.Add(c.Name);
                prompt.categoryIDs.Add(c.ID);

                if (c.ID == (int)ElementsGrid.Tag)
                {
                    categoryList.SelectedIndex = categoryList.Items.Count - 1;
                }
            }

            if (ElementsGrid.Tag == null)
            {
                categoryList.SelectedIndex = 0;
            }           

            prompt.Show();
        }

        private void ElUpdateButton_Click(object sender, EventArgs e)
        {
            if (ElementsGrid.SelectedRows.Count == 0) return;

            var categories = manager.categories.Read();
            int id = (int)ElementsGrid.SelectedRows[0].Tag;
            var element = manager.elements.Read(id);

            if (categories.Count == 0)
            {
                return;
            }

            var prompt = new ElUpdate_Form();

            prompt.MainForm = this;
            prompt.idOfElement = id;

            TextBox nameInput = (TextBox)prompt.Controls.Find("NameInput", true)[0];
            nameInput.Text = element.Name;

            TextBox dataInput = (TextBox)prompt.Controls.Find("DataInput", true)[0];
            dataInput.Text = element.Data;

            ComboBox categoryList = (ComboBox)prompt.Controls.Find("CategoryList", true)[0];
            foreach (var c in categories)
            {
                categoryList.Items.Add(c.Name);
                prompt.categoryIDs.Add(c.ID);

                if (c.ID == element.CategoryID)
                {
                    categoryList.SelectedIndex = categoryList.Items.Count - 1;
                }
            }

            if (ElementsGrid.Tag == null)
            {
                categoryList.SelectedIndex = 0;
            }           

            prompt.Text = element.Name + " - Редактирование";
            prompt.Show();
        }

        private void ElDeleteButton_Click(object sender, EventArgs e)
        {
            if (ElementsGrid.SelectedRows.Count == 0) return;

            int id = (int)ElementsGrid.SelectedRows[0].Tag;
            DeleteElement(id);
        }

        private void ElSearchButton_Click(object sender, EventArgs e)
        {
            SearchForm form = new SearchForm();

            form.MainForm = this;

            form.Show();
        }

        // CRUD для категорий

        public void CreateCategory(string name, int? parentID)
        {
            manager.categories.Create(new CategoryIM(0, parentID, name));
            RefreshForm();
        }

        public void UpdateCategory(int id, string name, int? parentID)
        {
            manager.categories.Update(new CategoryIM(id, parentID, name));
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

        public void ReadElement(int id)
        {
            var element = manager.elements.Read(id);

            ElInfo_Form infoForm = new ElInfo_Form();

            Label nameLabel = (Label)infoForm.Controls.Find("NameLabel", true)[0];
            nameLabel.Text = element.Name;

            Label categoryLabel = (Label)infoForm.Controls.Find("CategoryLabel", true)[0];
            categoryLabel.Text = element.Category.Name;

            TextBox dataBox = (TextBox)infoForm.Controls.Find("DataBox", true)[0];
            var dataDictionary = ParseData(element.Data);

            string dataString = "";
            foreach (var d in dataDictionary)
            {
                dataString += d.Key + ": " + d.Value.ToString() + "\n";
            }

            dataBox.Text = dataString;

            infoForm.Text = element.Name + " - Информация";
            infoForm.Show();
        }

        public void UpdateElement(int id, string name, string data, int categoryID)
        {
            manager.elements.Update(new ElementIM(id, name, data, categoryID));
            RefreshForm();
        }

        public void DeleteElement(int id)
        {
            manager.elements.Delete(id);
            RefreshForm();
        }

        // Резервное копирование

        private void ExportDatabase()
        {
            var file = File.Create("DATABASE.txt");

            var categories = manager.categories.Read();

            foreach (var c in categories)
            {
                FileAppend(file, c.ID.ToString() + " - " + c.Name + (c.ParentID != null ? " < " + (int)c.ParentID : "") + "\n");

                var elementsOfCategory = manager.elements.ReadCategory(c.ID);

                foreach (var e in elementsOfCategory)
                {
                    FileAppend(file, "-- " + e.ID.ToString() + " - " + e.Name + " - " + e.Data + "\n");
                }
            }

            file.Close();
        }

        private static void FileAppend(FileStream fs, string value)
        {
            byte[] info = new System.Text.UTF8Encoding(true).GetBytes(value);
            fs.Write(info, 0, info.Length);
        }

        private void ExportButton_Click(object sender, EventArgs e)
        {
            ExportDatabase();
            MessageBox.Show("База данных успешно экспортирована в файл DATABASE.txt!");
        }
    }
}