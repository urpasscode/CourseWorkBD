namespace CourseWork
{
    partial class AddNote
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.noteDiscription = new System.Windows.Forms.TextBox();
            this.noteName = new System.Windows.Forms.TextBox();
            this.saveNote = new System.Windows.Forms.Button();
            this.deleteNote = new System.Windows.Forms.Button();
            this.cancelNote = new System.Windows.Forms.Button();
            this.changeNoteButton = new System.Windows.Forms.Button();
            this.saveChangesButton = new System.Windows.Forms.Button();
            this.cancelChangesButton = new System.Windows.Forms.Button();
            this.noteErrorLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Название заметки";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Содержание";
            // 
            // noteDiscription
            // 
            this.noteDiscription.Location = new System.Drawing.Point(12, 92);
            this.noteDiscription.Multiline = true;
            this.noteDiscription.Name = "noteDiscription";
            this.noteDiscription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.noteDiscription.Size = new System.Drawing.Size(413, 200);
            this.noteDiscription.TabIndex = 2;
            // 
            // noteName
            // 
            this.noteName.Location = new System.Drawing.Point(12, 28);
            this.noteName.Name = "noteName";
            this.noteName.Size = new System.Drawing.Size(413, 22);
            this.noteName.TabIndex = 3;
            // 
            // saveNote
            // 
            this.saveNote.Location = new System.Drawing.Point(12, 335);
            this.saveNote.Name = "saveNote";
            this.saveNote.Size = new System.Drawing.Size(132, 23);
            this.saveNote.TabIndex = 4;
            this.saveNote.Text = "Сохранить";
            this.saveNote.UseVisualStyleBackColor = true;
            this.saveNote.Visible = false;
            this.saveNote.Click += new System.EventHandler(this.saveNote_Click);
            // 
            // deleteNote
            // 
            this.deleteNote.Location = new System.Drawing.Point(153, 335);
            this.deleteNote.Name = "deleteNote";
            this.deleteNote.Size = new System.Drawing.Size(132, 23);
            this.deleteNote.TabIndex = 5;
            this.deleteNote.Text = "Удалить";
            this.deleteNote.UseVisualStyleBackColor = true;
            this.deleteNote.Click += new System.EventHandler(this.deleteNote_Click);
            // 
            // cancelNote
            // 
            this.cancelNote.Location = new System.Drawing.Point(293, 336);
            this.cancelNote.Name = "cancelNote";
            this.cancelNote.Size = new System.Drawing.Size(132, 23);
            this.cancelNote.TabIndex = 6;
            this.cancelNote.Text = "Отмена";
            this.cancelNote.UseVisualStyleBackColor = true;
            this.cancelNote.Click += new System.EventHandler(this.cancelNote_Click);
            // 
            // changeNoteButton
            // 
            this.changeNoteButton.Location = new System.Drawing.Point(12, 336);
            this.changeNoteButton.Name = "changeNoteButton";
            this.changeNoteButton.Size = new System.Drawing.Size(132, 23);
            this.changeNoteButton.TabIndex = 7;
            this.changeNoteButton.Text = "Изменить";
            this.changeNoteButton.UseVisualStyleBackColor = true;
            this.changeNoteButton.Visible = false;
            this.changeNoteButton.Click += new System.EventHandler(this.changeNoteButton_Click);
            // 
            // saveChangesButton
            // 
            this.saveChangesButton.Location = new System.Drawing.Point(11, 335);
            this.saveChangesButton.Name = "saveChangesButton";
            this.saveChangesButton.Size = new System.Drawing.Size(132, 23);
            this.saveChangesButton.TabIndex = 8;
            this.saveChangesButton.Text = "Сохранить изменения";
            this.saveChangesButton.UseVisualStyleBackColor = true;
            this.saveChangesButton.Click += new System.EventHandler(this.saveChangesButton_Click);
            // 
            // cancelChangesButton
            // 
            this.cancelChangesButton.Location = new System.Drawing.Point(293, 335);
            this.cancelChangesButton.Name = "cancelChangesButton";
            this.cancelChangesButton.Size = new System.Drawing.Size(132, 23);
            this.cancelChangesButton.TabIndex = 9;
            this.cancelChangesButton.Text = "Отмена";
            this.cancelChangesButton.UseVisualStyleBackColor = true;
            this.cancelChangesButton.Click += new System.EventHandler(this.cancelChangesButton_Click);
            // 
            // noteErrorLabel
            // 
            this.noteErrorLabel.AutoSize = true;
            this.noteErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.noteErrorLabel.Location = new System.Drawing.Point(12, 305);
            this.noteErrorLabel.Name = "noteErrorLabel";
            this.noteErrorLabel.Size = new System.Drawing.Size(44, 16);
            this.noteErrorLabel.TabIndex = 10;
            this.noteErrorLabel.Text = "label3";
            // 
            // AddNote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 390);
            this.Controls.Add(this.noteErrorLabel);
            this.Controls.Add(this.cancelChangesButton);
            this.Controls.Add(this.saveChangesButton);
            this.Controls.Add(this.changeNoteButton);
            this.Controls.Add(this.cancelNote);
            this.Controls.Add(this.deleteNote);
            this.Controls.Add(this.saveNote);
            this.Controls.Add(this.noteName);
            this.Controls.Add(this.noteDiscription);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AddNote";
            this.Text = "addNote";
            this.Load += new System.EventHandler(this.addNote_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox noteDiscription;
        private System.Windows.Forms.TextBox noteName;
        private System.Windows.Forms.Button saveNote;
        private System.Windows.Forms.Button deleteNote;
        private System.Windows.Forms.Button cancelNote;
        private System.Windows.Forms.Button changeNoteButton;
        private System.Windows.Forms.Button saveChangesButton;
        private System.Windows.Forms.Button cancelChangesButton;
        private System.Windows.Forms.Label noteErrorLabel;
    }
}