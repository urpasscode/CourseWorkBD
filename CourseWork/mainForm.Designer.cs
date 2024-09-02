namespace CourseWork
{
    partial class mainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.monthForFilter = new System.Windows.Forms.ComboBox();
            this.cancelFilter = new System.Windows.Forms.Button();
            this.cancelSearch = new System.Windows.Forms.Button();
            this.filterByDate = new System.Windows.Forms.Button();
            this.searchByNane = new System.Windows.Forms.Button();
            this.nameForSearch = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.addNewNote = new System.Windows.Forms.Button();
            this.allNotes = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.addTag = new System.Windows.Forms.Button();
            this.allTagsTree = new System.Windows.Forms.TreeView();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(0, 68);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1351, 658);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.monthForFilter);
            this.tabPage1.Controls.Add(this.cancelFilter);
            this.tabPage1.Controls.Add(this.cancelSearch);
            this.tabPage1.Controls.Add(this.filterByDate);
            this.tabPage1.Controls.Add(this.searchByNane);
            this.tabPage1.Controls.Add(this.nameForSearch);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.addNewNote);
            this.tabPage1.Controls.Add(this.allNotes);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1343, 629);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Контакты";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // monthForFilter
            // 
            this.monthForFilter.FormattingEnabled = true;
            this.monthForFilter.Items.AddRange(new object[] {
            "Не выбрано",
            "Январь",
            "Февраль",
            "Март",
            "Апрель",
            "Май",
            "Июнь",
            "Июль",
            "Август",
            "Сентябрь",
            "Октябрь",
            "Ноябрь",
            "Декабрь"});
            this.monthForFilter.Location = new System.Drawing.Point(260, 35);
            this.monthForFilter.Name = "monthForFilter";
            this.monthForFilter.Size = new System.Drawing.Size(130, 24);
            this.monthForFilter.TabIndex = 10;
            // 
            // cancelFilter
            // 
            this.cancelFilter.Location = new System.Drawing.Point(260, 92);
            this.cancelFilter.Name = "cancelFilter";
            this.cancelFilter.Size = new System.Drawing.Size(130, 23);
            this.cancelFilter.TabIndex = 9;
            this.cancelFilter.Text = "Отменить";
            this.cancelFilter.UseVisualStyleBackColor = true;
            this.cancelFilter.Click += new System.EventHandler(this.cancelFilter_Click);
            // 
            // cancelSearch
            // 
            this.cancelSearch.Location = new System.Drawing.Point(11, 92);
            this.cancelSearch.Name = "cancelSearch";
            this.cancelSearch.Size = new System.Drawing.Size(132, 23);
            this.cancelSearch.TabIndex = 8;
            this.cancelSearch.Text = "Отменить";
            this.cancelSearch.UseVisualStyleBackColor = true;
            this.cancelSearch.Click += new System.EventHandler(this.cancelSearch_Click);
            // 
            // filterByDate
            // 
            this.filterByDate.Location = new System.Drawing.Point(260, 63);
            this.filterByDate.Name = "filterByDate";
            this.filterByDate.Size = new System.Drawing.Size(130, 23);
            this.filterByDate.TabIndex = 7;
            this.filterByDate.Text = "Фильтровать";
            this.filterByDate.UseVisualStyleBackColor = true;
            this.filterByDate.Click += new System.EventHandler(this.filterByDate_Click);
            // 
            // searchByNane
            // 
            this.searchByNane.Location = new System.Drawing.Point(11, 63);
            this.searchByNane.Name = "searchByNane";
            this.searchByNane.Size = new System.Drawing.Size(132, 23);
            this.searchByNane.TabIndex = 6;
            this.searchByNane.Text = "Поиск ";
            this.searchByNane.UseVisualStyleBackColor = true;
            this.searchByNane.Click += new System.EventHandler(this.searchByNane_Click);
            // 
            // nameForSearch
            // 
            this.nameForSearch.Location = new System.Drawing.Point(11, 35);
            this.nameForSearch.Name = "nameForSearch";
            this.nameForSearch.Size = new System.Drawing.Size(130, 22);
            this.nameForSearch.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(257, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Фильтр по дате";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Поиск по названию";
            // 
            // addNewNote
            // 
            this.addNewNote.Location = new System.Drawing.Point(1177, 16);
            this.addNewNote.Name = "addNewNote";
            this.addNewNote.Size = new System.Drawing.Size(144, 23);
            this.addNewNote.TabIndex = 1;
            this.addNewNote.Text = "Добавить заметку";
            this.addNewNote.UseVisualStyleBackColor = true;
            this.addNewNote.Click += new System.EventHandler(this.addNewNote_Click);
            // 
            // allNotes
            // 
            this.allNotes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.allNotes.FullRowSelect = true;
            this.allNotes.HideSelection = false;
            this.allNotes.Location = new System.Drawing.Point(0, 121);
            this.allNotes.MultiSelect = false;
            this.allNotes.Name = "allNotes";
            this.allNotes.Size = new System.Drawing.Size(1321, 508);
            this.allNotes.TabIndex = 0;
            this.allNotes.UseCompatibleStateImageBehavior = false;
            this.allNotes.View = System.Windows.Forms.View.Details;
            this.allNotes.SelectedIndexChanged += new System.EventHandler(this.allNotes_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "№";
            this.columnHeader1.Width = 37;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Название";
            this.columnHeader2.Width = 183;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Дата создания";
            this.columnHeader3.Width = 192;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Содержание";
            this.columnHeader4.Width = 1253;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.addTag);
            this.tabPage2.Controls.Add(this.allTagsTree);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1343, 629);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Категории";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // addTag
            // 
            this.addTag.Location = new System.Drawing.Point(1204, 9);
            this.addTag.Name = "addTag";
            this.addTag.Size = new System.Drawing.Size(117, 23);
            this.addTag.TabIndex = 1;
            this.addTag.Text = "Добавить тег";
            this.addTag.UseVisualStyleBackColor = true;
            this.addTag.Click += new System.EventHandler(this.addTag_Click);
            // 
            // allTagsTree
            // 
            this.allTagsTree.Location = new System.Drawing.Point(0, 38);
            this.allTagsTree.Name = "allTagsTree";
            this.allTagsTree.Size = new System.Drawing.Size(1321, 591);
            this.allTagsTree.TabIndex = 0;
            this.allTagsTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.allTags_AfterSelect);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1181, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(144, 25);
            this.button1.TabIndex = 1;
            this.button1.Text = "Личный кабинет";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1353, 730);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tabControl1);
            this.Name = "mainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ListView allNotes;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Button addNewNote;
        private System.Windows.Forms.TextBox nameForSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TreeView allTagsTree;
        private System.Windows.Forms.Button addTag;
        private System.Windows.Forms.Button cancelFilter;
        private System.Windows.Forms.Button cancelSearch;
        private System.Windows.Forms.Button filterByDate;
        private System.Windows.Forms.Button searchByNane;
        private System.Windows.Forms.ComboBox monthForFilter;
    }
}

