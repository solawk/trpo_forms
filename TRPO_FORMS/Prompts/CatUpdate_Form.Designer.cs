namespace TRPO_FORMS.Prompts
{
    partial class CatUpdate_Form
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
            this.ParentList = new System.Windows.Forms.ComboBox();
            this.ParentLabel = new System.Windows.Forms.Label();
            this.NameInput = new System.Windows.Forms.TextBox();
            this.ConfirmButton = new System.Windows.Forms.Button();
            this.TableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.TableLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(3, 0);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(118, 15);
            this.NameLabel.TabIndex = 3;
            this.NameLabel.Text = "Название категории";
            // 
            // ParentList
            // 
            this.ParentList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ParentList.FormattingEnabled = true;
            this.ParentList.Location = new System.Drawing.Point(170, 34);
            this.ParentList.Name = "ParentList";
            this.ParentList.Size = new System.Drawing.Size(271, 23);
            this.ParentList.TabIndex = 2;
            // 
            // ParentLabel
            // 
            this.ParentLabel.AutoSize = true;
            this.ParentLabel.Location = new System.Drawing.Point(3, 31);
            this.ParentLabel.Name = "ParentLabel";
            this.ParentLabel.Size = new System.Drawing.Size(140, 15);
            this.ParentLabel.TabIndex = 4;
            this.ParentLabel.Text = "Родительская категория";
            // 
            // NameInput
            // 
            this.NameInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NameInput.Location = new System.Drawing.Point(170, 3);
            this.NameInput.Name = "NameInput";
            this.NameInput.Size = new System.Drawing.Size(271, 23);
            this.NameInput.TabIndex = 1;
            // 
            // ConfirmButton
            // 
            this.ConfirmButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ConfirmButton.Location = new System.Drawing.Point(170, 65);
            this.ConfirmButton.Name = "ConfirmButton";
            this.ConfirmButton.Size = new System.Drawing.Size(108, 39);
            this.ConfirmButton.TabIndex = 0;
            this.ConfirmButton.Text = "Сохранить";
            this.ConfirmButton.UseVisualStyleBackColor = true;
            this.ConfirmButton.Click += new System.EventHandler(this.ConfirmButton_Click);
            // 
            // TableLayout
            // 
            this.TableLayout.ColumnCount = 2;
            this.TableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37.62576F));
            this.TableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 62.37424F));
            this.TableLayout.Controls.Add(this.NameLabel, 0, 0);
            this.TableLayout.Controls.Add(this.ParentList, 1, 1);
            this.TableLayout.Controls.Add(this.ParentLabel, 0, 1);
            this.TableLayout.Controls.Add(this.NameInput, 1, 0);
            this.TableLayout.Controls.Add(this.ConfirmButton, 1, 2);
            this.TableLayout.Location = new System.Drawing.Point(12, 12);
            this.TableLayout.Name = "TableLayout";
            this.TableLayout.RowCount = 3;
            this.TableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 51F));
            this.TableLayout.Size = new System.Drawing.Size(444, 113);
            this.TableLayout.TabIndex = 6;
            // 
            // CatUpdate_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 135);
            this.Controls.Add(this.TableLayout);
            this.Name = "CatUpdate_Form";
            this.Text = "Редактирование";
            this.TableLayout.ResumeLayout(false);
            this.TableLayout.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Label NameLabel;
        private ComboBox ParentList;
        private Label ParentLabel;
        private TextBox NameInput;
        private Button ConfirmButton;
        private TableLayoutPanel TableLayout;
    }
}