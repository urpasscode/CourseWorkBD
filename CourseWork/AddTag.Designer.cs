namespace CourseWork
{
    partial class AddTag
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
            this.tagName = new System.Windows.Forms.Label();
            this.listNotes = new System.Windows.Forms.Label();
            this.tagNameBox = new System.Windows.Forms.TextBox();
            this.selectNotesToTag = new System.Windows.Forms.CheckedListBox();
            this.saveTag = new System.Windows.Forms.Button();
            this.cancelInTagForm = new System.Windows.Forms.Button();
            this.changeTagButton = new System.Windows.Forms.Button();
            this.notesInTag = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.deleteTag = new System.Windows.Forms.Button();
            this.tagErrorLabel = new System.Windows.Forms.Label();
            this.safeTagAfterChange = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tagName
            // 
            this.tagName.AutoSize = true;
            this.tagName.Location = new System.Drawing.Point(21, 9);
            this.tagName.Name = "tagName";
            this.tagName.Size = new System.Drawing.Size(105, 16);
            this.tagName.TabIndex = 0;
            this.tagName.Text = "Название тега";
            // 
            // listNotes
            // 
            this.listNotes.AutoSize = true;
            this.listNotes.Location = new System.Drawing.Point(21, 70);
            this.listNotes.Name = "listNotes";
            this.listNotes.Size = new System.Drawing.Size(121, 16);
            this.listNotes.TabIndex = 1;
            this.listNotes.Text = "Содержание тега";
            // 
            // tagNameBox
            // 
            this.tagNameBox.Location = new System.Drawing.Point(24, 28);
            this.tagNameBox.Name = "tagNameBox";
            this.tagNameBox.Size = new System.Drawing.Size(375, 22);
            this.tagNameBox.TabIndex = 2;
            // 
            // selectNotesToTag
            // 
            this.selectNotesToTag.FormattingEnabled = true;
            this.selectNotesToTag.Location = new System.Drawing.Point(24, 101);
            this.selectNotesToTag.Name = "selectNotesToTag";
            this.selectNotesToTag.Size = new System.Drawing.Size(322, 276);
            this.selectNotesToTag.TabIndex = 3;
            // 
            // saveTag
            // 
            this.saveTag.Location = new System.Drawing.Point(24, 415);
            this.saveTag.Name = "saveTag";
            this.saveTag.Size = new System.Drawing.Size(107, 23);
            this.saveTag.TabIndex = 4;
            this.saveTag.Text = "Сохранить";
            this.saveTag.UseVisualStyleBackColor = true;
            this.saveTag.Click += new System.EventHandler(this.saveTag_Click);
            // 
            // cancelInTagForm
            // 
            this.cancelInTagForm.Location = new System.Drawing.Point(292, 415);
            this.cancelInTagForm.Name = "cancelInTagForm";
            this.cancelInTagForm.Size = new System.Drawing.Size(107, 23);
            this.cancelInTagForm.TabIndex = 5;
            this.cancelInTagForm.Text = "Отмена";
            this.cancelInTagForm.UseVisualStyleBackColor = true;
            this.cancelInTagForm.Click += new System.EventHandler(this.cancelInTagForm_Click);
            // 
            // changeTagButton
            // 
            this.changeTagButton.Location = new System.Drawing.Point(24, 415);
            this.changeTagButton.Name = "changeTagButton";
            this.changeTagButton.Size = new System.Drawing.Size(107, 23);
            this.changeTagButton.TabIndex = 6;
            this.changeTagButton.Text = "Изменить";
            this.changeTagButton.UseVisualStyleBackColor = true;
            this.changeTagButton.Click += new System.EventHandler(this.changeTagButton_Click);
            // 
            // notesInTag
            // 
            this.notesInTag.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.notesInTag.HideSelection = false;
            this.notesInTag.Location = new System.Drawing.Point(24, 101);
            this.notesInTag.Name = "notesInTag";
            this.notesInTag.Size = new System.Drawing.Size(375, 268);
            this.notesInTag.TabIndex = 7;
            this.notesInTag.UseCompatibleStateImageBehavior = false;
            this.notesInTag.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Название заметки";
            this.columnHeader1.Width = 312;
            // 
            // deleteTag
            // 
            this.deleteTag.Location = new System.Drawing.Point(159, 415);
            this.deleteTag.Name = "deleteTag";
            this.deleteTag.Size = new System.Drawing.Size(107, 23);
            this.deleteTag.TabIndex = 8;
            this.deleteTag.Text = "Удалить";
            this.deleteTag.UseVisualStyleBackColor = true;
            this.deleteTag.Click += new System.EventHandler(this.deleteTag_Click);
            // 
            // tagErrorLabel
            // 
            this.tagErrorLabel.AutoSize = true;
            this.tagErrorLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.tagErrorLabel.Location = new System.Drawing.Point(21, 386);
            this.tagErrorLabel.Name = "tagErrorLabel";
            this.tagErrorLabel.Size = new System.Drawing.Size(44, 16);
            this.tagErrorLabel.TabIndex = 9;
            this.tagErrorLabel.Text = "label1";
            // 
            // safeTagAfterChange
            // 
            this.safeTagAfterChange.Location = new System.Drawing.Point(24, 415);
            this.safeTagAfterChange.Name = "safeTagAfterChange";
            this.safeTagAfterChange.Size = new System.Drawing.Size(118, 23);
            this.safeTagAfterChange.TabIndex = 10;
            this.safeTagAfterChange.Text = "Сохранить";
            this.safeTagAfterChange.UseVisualStyleBackColor = true;
            this.safeTagAfterChange.Click += new System.EventHandler(this.safeTagAfterChange_Click);
            // 
            // AddTag
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 450);
            this.Controls.Add(this.safeTagAfterChange);
            this.Controls.Add(this.tagErrorLabel);
            this.Controls.Add(this.deleteTag);
            this.Controls.Add(this.notesInTag);
            this.Controls.Add(this.changeTagButton);
            this.Controls.Add(this.cancelInTagForm);
            this.Controls.Add(this.saveTag);
            this.Controls.Add(this.selectNotesToTag);
            this.Controls.Add(this.tagNameBox);
            this.Controls.Add(this.listNotes);
            this.Controls.Add(this.tagName);
            this.Name = "AddTag";
            this.Text = "addTag";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label tagName;
        private System.Windows.Forms.Label listNotes;
        private System.Windows.Forms.TextBox tagNameBox;
        private System.Windows.Forms.CheckedListBox selectNotesToTag;
        private System.Windows.Forms.Button saveTag;
        private System.Windows.Forms.Button cancelInTagForm;
        private System.Windows.Forms.Button changeTagButton;
        private System.Windows.Forms.ListView notesInTag;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Button deleteTag;
        private System.Windows.Forms.Label tagErrorLabel;
        private System.Windows.Forms.Button safeTagAfterChange;
    }
}