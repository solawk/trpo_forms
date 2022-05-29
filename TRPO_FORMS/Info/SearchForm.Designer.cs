namespace TRPO_FORMS.Info
{
    partial class SearchForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SearchInput = new System.Windows.Forms.TextBox();
            this.ElementsGrid = new System.Windows.Forms.DataGridView();
            this.ElementNames = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ElementData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SearchButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ElementsGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // SearchInput
            // 
            this.SearchInput.Location = new System.Drawing.Point(8, 8);
            this.SearchInput.Multiline = true;
            this.SearchInput.Name = "SearchInput";
            this.SearchInput.Size = new System.Drawing.Size(808, 137);
            this.SearchInput.TabIndex = 6;
            this.SearchInput.Text = "[]";
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
            this.ElementsGrid.Location = new System.Drawing.Point(8, 203);
            this.ElementsGrid.Name = "ElementsGrid";
            this.ElementsGrid.ReadOnly = true;
            this.ElementsGrid.RowHeadersVisible = false;
            this.ElementsGrid.RowTemplate.Height = 25;
            this.ElementsGrid.ShowEditingIcon = false;
            this.ElementsGrid.Size = new System.Drawing.Size(808, 407);
            this.ElementsGrid.TabIndex = 7;
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
            // SearchButton
            // 
            this.SearchButton.Location = new System.Drawing.Point(61, 151);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(172, 46);
            this.SearchButton.TabIndex = 8;
            this.SearchButton.Text = "Поиск";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // SearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 622);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.ElementsGrid);
            this.Controls.Add(this.SearchInput);
            this.Name = "SearchForm";
            this.Text = "Поиск";
            ((System.ComponentModel.ISupportInitialize)(this.ElementsGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox SearchInput;
        private DataGridView ElementsGrid;
        private DataGridViewTextBoxColumn ElementNames;
        private DataGridViewTextBoxColumn ElementData;
        private Button SearchButton;
    }
}