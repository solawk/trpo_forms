namespace TRPO_FORMS.Prompts
{
    partial class ElCreate_Form
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
            this.NameLabel = new System.Windows.Forms.Label();
            this.CategoryList = new System.Windows.Forms.ComboBox();
            this.CategoryLabel = new System.Windows.Forms.Label();
            this.NameInput = new System.Windows.Forms.TextBox();
            this.TableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.DataInput = new System.Windows.Forms.TextBox();
            this.DescriptionLabel = new System.Windows.Forms.Label();
            this.ConfirmButton = new System.Windows.Forms.Button();
            this.TableLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(3, 0);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(114, 15);
            this.NameLabel.TabIndex = 3;
            this.NameLabel.Text = "Название элемента";
            // 
            // CategoryList
            // 
            this.CategoryList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CategoryList.FormattingEnabled = true;
            this.CategoryList.Location = new System.Drawing.Point(162, 176);
            this.CategoryList.Name = "CategoryList";
            this.CategoryList.Size = new System.Drawing.Size(313, 23);
            this.CategoryList.TabIndex = 2;
            this.CategoryList.SelectedIndexChanged += new System.EventHandler(this.ParentList_SelectedIndexChanged);
            // 
            // CategoryLabel
            // 
            this.CategoryLabel.AutoSize = true;
            this.CategoryLabel.Location = new System.Drawing.Point(3, 173);
            this.CategoryLabel.Name = "CategoryLabel";
            this.CategoryLabel.Size = new System.Drawing.Size(63, 15);
            this.CategoryLabel.TabIndex = 4;
            this.CategoryLabel.Text = "Категория";
            // 
            // NameInput
            // 
            this.NameInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NameInput.Location = new System.Drawing.Point(162, 3);
            this.NameInput.Name = "NameInput";
            this.NameInput.Size = new System.Drawing.Size(313, 23);
            this.NameInput.TabIndex = 1;
            // 
            // TableLayout
            // 
            this.TableLayout.ColumnCount = 2;
            this.TableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.2636F));
            this.TableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.7364F));
            this.TableLayout.Controls.Add(this.NameInput, 1, 0);
            this.TableLayout.Controls.Add(this.NameLabel, 0, 0);
            this.TableLayout.Controls.Add(this.DataInput, 1, 1);
            this.TableLayout.Controls.Add(this.DescriptionLabel, 0, 1);
            this.TableLayout.Controls.Add(this.CategoryLabel, 0, 2);
            this.TableLayout.Controls.Add(this.CategoryList, 1, 2);
            this.TableLayout.Controls.Add(this.ConfirmButton, 1, 3);
            this.TableLayout.Location = new System.Drawing.Point(12, 25);
            this.TableLayout.Name = "TableLayout";
            this.TableLayout.RowCount = 4;
            this.TableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.86441F));
            this.TableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 56.07843F));
            this.TableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.37255F));
            this.TableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.39216F));
            this.TableLayout.Size = new System.Drawing.Size(478, 255);
            this.TableLayout.TabIndex = 6;
            // 
            // DataInput
            // 
            this.DataInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataInput.Location = new System.Drawing.Point(162, 33);
            this.DataInput.Multiline = true;
            this.DataInput.Name = "DataInput";
            this.DataInput.Size = new System.Drawing.Size(313, 137);
            this.DataInput.TabIndex = 5;
            // 
            // DescriptionLabel
            // 
            this.DescriptionLabel.AutoSize = true;
            this.DescriptionLabel.Location = new System.Drawing.Point(3, 30);
            this.DescriptionLabel.Name = "DescriptionLabel";
            this.DescriptionLabel.Size = new System.Drawing.Size(150, 15);
            this.DescriptionLabel.TabIndex = 7;
            this.DescriptionLabel.Text = "Характеристики элемента";
            // 
            // ConfirmButton
            // 
            this.ConfirmButton.Location = new System.Drawing.Point(162, 205);
            this.ConfirmButton.Name = "ConfirmButton";
            this.ConfirmButton.Size = new System.Drawing.Size(108, 39);
            this.ConfirmButton.TabIndex = 0;
            this.ConfirmButton.Text = "Создать";
            this.ConfirmButton.UseVisualStyleBackColor = true;
            this.ConfirmButton.Click += new System.EventHandler(this.ConfirmButton_Click);
            // 
            // ElCreate_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 291);
            this.Controls.Add(this.TableLayout);
            this.Name = "ElCreate_Form";
            this.Text = "ElCreate_Form";
            this.TableLayout.ResumeLayout(false);
            this.TableLayout.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Label NameLabel;
        private ComboBox CategoryList;
        private Label CategoryLabel;
        private TextBox NameInput;
        private TableLayoutPanel TableLayout;
        private TextBox DataInput;
        private Label DescriptionLabel;
        private Button ConfirmButton;
    }
}