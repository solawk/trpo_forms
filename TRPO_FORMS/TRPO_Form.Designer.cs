namespace TRPO_FORMS
{
    partial class TRPO_Form
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.CategoriesView = new System.Windows.Forms.TreeView();
            this.ElementsGrid = new System.Windows.Forms.DataGridView();
            this.ElementNames = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ElementData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CatCreateButton = new System.Windows.Forms.Button();
            this.CatDeleteButton = new System.Windows.Forms.Button();
            this.ElCreateButton = new System.Windows.Forms.Button();
            this.ElDeleteButton = new System.Windows.Forms.Button();
            this.ElUpdateButton = new System.Windows.Forms.Button();
            this.CatUpdateButton = new System.Windows.Forms.Button();
            this.ElSearchButton = new System.Windows.Forms.Button();
            this.CategoriesLabel = new System.Windows.Forms.Label();
            this.ElementsLabel = new System.Windows.Forms.Label();
            this.ExportButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ElementsGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // CategoriesView
            // 
            this.CategoriesView.Location = new System.Drawing.Point(12, 93);
            this.CategoriesView.Name = "CategoriesView";
            this.CategoriesView.Size = new System.Drawing.Size(230, 456);
            this.CategoriesView.TabIndex = 0;
            this.CategoriesView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.CategoriesView_AfterSelect);
            // 
            // ElementsGrid
            // 
            this.ElementsGrid.AllowUserToAddRows = false;
            this.ElementsGrid.AllowUserToDeleteRows = false;
            this.ElementsGrid.AllowUserToResizeRows = false;
            this.ElementsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ElementsGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ElementNames,
            this.ElementData});
            this.ElementsGrid.Location = new System.Drawing.Point(248, 93);
            this.ElementsGrid.Name = "ElementsGrid";
            this.ElementsGrid.ReadOnly = true;
            this.ElementsGrid.RowHeadersVisible = false;
            this.ElementsGrid.RowTemplate.Height = 25;
            this.ElementsGrid.ShowEditingIcon = false;
            this.ElementsGrid.Size = new System.Drawing.Size(724, 456);
            this.ElementsGrid.TabIndex = 2;
            // 
            // ElementNames
            // 
            this.ElementNames.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ElementNames.HeaderText = "Название";
            this.ElementNames.Name = "ElementNames";
            this.ElementNames.ReadOnly = true;
            this.ElementNames.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ElementNames.Width = 65;
            // 
            // ElementData
            // 
            this.ElementData.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ElementData.HeaderText = "Характеристики";
            this.ElementData.Name = "ElementData";
            this.ElementData.ReadOnly = true;
            this.ElementData.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // CatCreateButton
            // 
            this.CatCreateButton.Location = new System.Drawing.Point(12, 33);
            this.CatCreateButton.Name = "CatCreateButton";
            this.CatCreateButton.Size = new System.Drawing.Size(84, 54);
            this.CatCreateButton.TabIndex = 3;
            this.CatCreateButton.Text = "Создать";
            this.CatCreateButton.UseVisualStyleBackColor = true;
            this.CatCreateButton.Click += new System.EventHandler(this.CatCreateButton_Click);
            // 
            // CatDeleteButton
            // 
            this.CatDeleteButton.Location = new System.Drawing.Point(183, 33);
            this.CatDeleteButton.Name = "CatDeleteButton";
            this.CatDeleteButton.Size = new System.Drawing.Size(59, 54);
            this.CatDeleteButton.TabIndex = 4;
            this.CatDeleteButton.Text = "Удалить";
            this.CatDeleteButton.UseVisualStyleBackColor = true;
            this.CatDeleteButton.Click += new System.EventHandler(this.CatDeleteButton_Click);
            // 
            // ElCreateButton
            // 
            this.ElCreateButton.Location = new System.Drawing.Point(467, 33);
            this.ElCreateButton.Name = "ElCreateButton";
            this.ElCreateButton.Size = new System.Drawing.Size(109, 54);
            this.ElCreateButton.TabIndex = 5;
            this.ElCreateButton.Text = "Добавить";
            this.ElCreateButton.UseVisualStyleBackColor = true;
            this.ElCreateButton.Click += new System.EventHandler(this.ElCreateButton_Click);
            // 
            // ElDeleteButton
            // 
            this.ElDeleteButton.Location = new System.Drawing.Point(696, 33);
            this.ElDeleteButton.Name = "ElDeleteButton";
            this.ElDeleteButton.Size = new System.Drawing.Size(66, 54);
            this.ElDeleteButton.TabIndex = 6;
            this.ElDeleteButton.Text = "Удалить";
            this.ElDeleteButton.UseVisualStyleBackColor = true;
            this.ElDeleteButton.Click += new System.EventHandler(this.ElDeleteButton_Click);
            // 
            // ElUpdateButton
            // 
            this.ElUpdateButton.Location = new System.Drawing.Point(582, 33);
            this.ElUpdateButton.Name = "ElUpdateButton";
            this.ElUpdateButton.Size = new System.Drawing.Size(108, 54);
            this.ElUpdateButton.TabIndex = 7;
            this.ElUpdateButton.Text = "Изменить";
            this.ElUpdateButton.UseVisualStyleBackColor = true;
            this.ElUpdateButton.Click += new System.EventHandler(this.ElUpdateButton_Click);
            // 
            // CatUpdateButton
            // 
            this.CatUpdateButton.Location = new System.Drawing.Point(102, 33);
            this.CatUpdateButton.Name = "CatUpdateButton";
            this.CatUpdateButton.Size = new System.Drawing.Size(75, 54);
            this.CatUpdateButton.TabIndex = 8;
            this.CatUpdateButton.Text = "Изменить";
            this.CatUpdateButton.UseVisualStyleBackColor = true;
            this.CatUpdateButton.Click += new System.EventHandler(this.CatUpdateButton_Click);
            // 
            // ElSearchButton
            // 
            this.ElSearchButton.Location = new System.Drawing.Point(271, 33);
            this.ElSearchButton.Name = "ElSearchButton";
            this.ElSearchButton.Size = new System.Drawing.Size(163, 54);
            this.ElSearchButton.TabIndex = 9;
            this.ElSearchButton.Text = "Поиск";
            this.ElSearchButton.UseVisualStyleBackColor = true;
            this.ElSearchButton.Click += new System.EventHandler(this.ElSearchButton_Click);
            // 
            // CategoriesLabel
            // 
            this.CategoriesLabel.AutoSize = true;
            this.CategoriesLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CategoriesLabel.Location = new System.Drawing.Point(77, 9);
            this.CategoriesLabel.Name = "CategoriesLabel";
            this.CategoriesLabel.Size = new System.Drawing.Size(84, 21);
            this.CategoriesLabel.TabIndex = 10;
            this.CategoriesLabel.Text = "Категории";
            // 
            // ElementsLabel
            // 
            this.ElementsLabel.AutoSize = true;
            this.ElementsLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ElementsLabel.Location = new System.Drawing.Point(437, 9);
            this.ElementsLabel.Name = "ElementsLabel";
            this.ElementsLabel.Size = new System.Drawing.Size(82, 21);
            this.ElementsLabel.TabIndex = 11;
            this.ElementsLabel.Text = "Элементы";
            // 
            // ExportButton
            // 
            this.ExportButton.Location = new System.Drawing.Point(845, 33);
            this.ExportButton.Name = "ExportButton";
            this.ExportButton.Size = new System.Drawing.Size(127, 54);
            this.ExportButton.TabIndex = 12;
            this.ExportButton.Text = "Экспорт базы данных";
            this.ExportButton.UseVisualStyleBackColor = true;
            this.ExportButton.Click += new System.EventHandler(this.ExportButton_Click);
            // 
            // TRPO_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.ExportButton);
            this.Controls.Add(this.ElementsLabel);
            this.Controls.Add(this.CategoriesLabel);
            this.Controls.Add(this.ElSearchButton);
            this.Controls.Add(this.CatUpdateButton);
            this.Controls.Add(this.ElUpdateButton);
            this.Controls.Add(this.ElDeleteButton);
            this.Controls.Add(this.ElCreateButton);
            this.Controls.Add(this.CatDeleteButton);
            this.Controls.Add(this.CatCreateButton);
            this.Controls.Add(this.ElementsGrid);
            this.Controls.Add(this.CategoriesView);
            this.Name = "TRPO_Form";
            this.Text = "ИПСПЭС";
            this.Load += new System.EventHandler(this.TRPO_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ElementsGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TreeView CategoriesView;
        private DataGridView ElementsGrid;
        private Button CatCreateButton;
        private Button CatDeleteButton;
        private Button ElCreateButton;
        private Button ElDeleteButton;
        private Button ElUpdateButton;
        private DataGridViewTextBoxColumn ElementNames;
        private DataGridViewTextBoxColumn ElementData;
        private Button CatUpdateButton;
        private Button ElSearchButton;
        private Label CategoriesLabel;
        private Label ElementsLabel;
        private Button ExportButton;
    }
}