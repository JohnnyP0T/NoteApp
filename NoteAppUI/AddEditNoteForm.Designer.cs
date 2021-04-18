
namespace NoteAppUI
{
    partial class AddEditNoteForm
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
            this.TitleLabel = new System.Windows.Forms.Label();
            this.TitleTextBox = new System.Windows.Forms.TextBox();
            this.CategoryLabel = new System.Windows.Forms.Label();
            this.CategoryComboBox = new System.Windows.Forms.ComboBox();
            this.ModifiedMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.ModifiedLabel = new System.Windows.Forms.Label();
            this.CreatedTimeMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.CreatedLabel = new System.Windows.Forms.Label();
            this.TextNoteRichTextBox = new System.Windows.Forms.RichTextBox();
            this.OkButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TitleLabel
            // 
            this.TitleLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Location = new System.Drawing.Point(7, 13);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(58, 13);
            this.TitleLabel.TabIndex = 0;
            this.TitleLabel.Text = "Заглавие:";
            // 
            // TitleTextBox
            // 
            this.TitleTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TitleTextBox.Location = new System.Drawing.Point(71, 10);
            this.TitleTextBox.MaximumSize = new System.Drawing.Size(717, 20);
            this.TitleTextBox.MinimumSize = new System.Drawing.Size(121, 20);
            this.TitleTextBox.Name = "TitleTextBox";
            this.TitleTextBox.Size = new System.Drawing.Size(701, 20);
            this.TitleTextBox.TabIndex = 1;
            this.TitleTextBox.TextChanged += new System.EventHandler(this.TitleTextBox_TextChanged);
            this.TitleTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.TitleTextBox_Validating);
            // 
            // CategoryLabel
            // 
            this.CategoryLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CategoryLabel.AutoSize = true;
            this.CategoryLabel.Location = new System.Drawing.Point(7, 60);
            this.CategoryLabel.Name = "CategoryLabel";
            this.CategoryLabel.Size = new System.Drawing.Size(63, 13);
            this.CategoryLabel.TabIndex = 2;
            this.CategoryLabel.Text = "Категория:";
            // 
            // CategoryComboBox
            // 
            this.CategoryComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CategoryComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CategoryComboBox.FormattingEnabled = true;
            this.CategoryComboBox.Location = new System.Drawing.Point(71, 57);
            this.CategoryComboBox.MaximumSize = new System.Drawing.Size(121, 0);
            this.CategoryComboBox.MaxLength = 21;
            this.CategoryComboBox.MinimumSize = new System.Drawing.Size(121, 0);
            this.CategoryComboBox.Name = "CategoryComboBox";
            this.CategoryComboBox.Size = new System.Drawing.Size(121, 21);
            this.CategoryComboBox.TabIndex = 3;
            // 
            // ModifiedMaskedTextBox
            // 
            this.ModifiedMaskedTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ModifiedMaskedTextBox.Location = new System.Drawing.Point(280, 99);
            this.ModifiedMaskedTextBox.Mask = "00/00/0000";
            this.ModifiedMaskedTextBox.MaximumSize = new System.Drawing.Size(100, 20);
            this.ModifiedMaskedTextBox.MinimumSize = new System.Drawing.Size(100, 20);
            this.ModifiedMaskedTextBox.Name = "ModifiedMaskedTextBox";
            this.ModifiedMaskedTextBox.ReadOnly = true;
            this.ModifiedMaskedTextBox.Size = new System.Drawing.Size(100, 20);
            this.ModifiedMaskedTextBox.TabIndex = 10;
            this.ModifiedMaskedTextBox.ValidatingType = typeof(System.DateTime);
            // 
            // ModifiedLabel
            // 
            this.ModifiedLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ModifiedLabel.AutoSize = true;
            this.ModifiedLabel.Location = new System.Drawing.Point(212, 102);
            this.ModifiedLabel.Name = "ModifiedLabel";
            this.ModifiedLabel.Size = new System.Drawing.Size(62, 13);
            this.ModifiedLabel.TabIndex = 9;
            this.ModifiedLabel.Text = "Изменено:";
            // 
            // CreatedTimeMaskedTextBox
            // 
            this.CreatedTimeMaskedTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CreatedTimeMaskedTextBox.Location = new System.Drawing.Point(71, 99);
            this.CreatedTimeMaskedTextBox.Mask = "00/00/0000";
            this.CreatedTimeMaskedTextBox.MaximumSize = new System.Drawing.Size(100, 20);
            this.CreatedTimeMaskedTextBox.MinimumSize = new System.Drawing.Size(100, 20);
            this.CreatedTimeMaskedTextBox.Name = "CreatedTimeMaskedTextBox";
            this.CreatedTimeMaskedTextBox.ReadOnly = true;
            this.CreatedTimeMaskedTextBox.Size = new System.Drawing.Size(100, 20);
            this.CreatedTimeMaskedTextBox.TabIndex = 8;
            this.CreatedTimeMaskedTextBox.ValidatingType = typeof(System.DateTime);
            // 
            // CreatedLabel
            // 
            this.CreatedLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CreatedLabel.AutoSize = true;
            this.CreatedLabel.Location = new System.Drawing.Point(7, 102);
            this.CreatedLabel.Name = "CreatedLabel";
            this.CreatedLabel.Size = new System.Drawing.Size(53, 13);
            this.CreatedLabel.TabIndex = 7;
            this.CreatedLabel.Text = "Создано:";
            // 
            // TextNoteRichTextBox
            // 
            this.TextNoteRichTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextNoteRichTextBox.Location = new System.Drawing.Point(16, 140);
            this.TextNoteRichTextBox.Name = "TextNoteRichTextBox";
            this.TextNoteRichTextBox.Size = new System.Drawing.Size(756, 389);
            this.TextNoteRichTextBox.TabIndex = 11;
            this.TextNoteRichTextBox.Text = "";
            // 
            // OkButton
            // 
            this.OkButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OkButton.Location = new System.Drawing.Point(616, 536);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(75, 23);
            this.OkButton.TabIndex = 12;
            this.OkButton.Text = "Ок";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelButton.Location = new System.Drawing.Point(697, 536);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 13;
            this.CancelButton.Text = "Отмена";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // AddEditNoteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.TextNoteRichTextBox);
            this.Controls.Add(this.ModifiedMaskedTextBox);
            this.Controls.Add(this.ModifiedLabel);
            this.Controls.Add(this.CreatedTimeMaskedTextBox);
            this.Controls.Add(this.CreatedLabel);
            this.Controls.Add(this.CategoryComboBox);
            this.Controls.Add(this.CategoryLabel);
            this.Controls.Add(this.TitleTextBox);
            this.Controls.Add(this.TitleLabel);
            this.MinimumSize = new System.Drawing.Size(364, 257);
            this.Name = "AddEditNoteForm";
            this.Text = "Добавление или редактирование заметки";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddEditNoteForm_FormClosing);
            this.Load += new System.EventHandler(this.AddEditNoteForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.TextBox TitleTextBox;
        private System.Windows.Forms.Label CategoryLabel;
        private System.Windows.Forms.ComboBox CategoryComboBox;
        private System.Windows.Forms.MaskedTextBox ModifiedMaskedTextBox;
        private System.Windows.Forms.Label ModifiedLabel;
        private System.Windows.Forms.MaskedTextBox CreatedTimeMaskedTextBox;
        private System.Windows.Forms.Label CreatedLabel;
        private System.Windows.Forms.RichTextBox TextNoteRichTextBox;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Button CancelButton;
    }
}