using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CourseWork
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }
        /*список для хранения индексов, гле первый индекс-индект элемента в списке в листвью
         * а второй-его айдишник в бд
         * 
         */
        public static Dictionary<int, int> noteIndexes = new Dictionary<int, int>();

        public void insertIntoDictionary(int index, int id)
        {
            mainForm.noteIndexes.Add(index, id);
        }


        //открывается форма для добавления новой заметки
        private void addNewNote_Click(object sender, EventArgs e)
        {
            AddNote newAddForm = new AddNote();
            newAddForm.openAddForm();
            newAddForm.Show();
            newAddForm.Activate();
            newAddForm.FormClosed += (obj, args) => showAll();

        }

        private void allNotes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (allNotes.SelectedIndices.Count > 0)
            {
                int ind = allNotes.SelectedIndices[0];
                AddNote editNote = new AddNote();
                editNote.openEditForm(ind);
                editNote.Show();
                editNote.Activate();
                editNote.FormClosed += (obj, args) => allNotes.SelectedIndices.Clear();
                editNote.FormClosed += (obj, args) => showAll();
            }
        }


        //подключение к бд


        //добавление тегов во вкладку категории
        public void showTags()
        {
            allTagsTree.Nodes.Clear();
            Tags.allTags.Clear();

            NpgsqlConnection nc = connectToDB.connect();
            try
            {
                string sql = "select distinct tag.tag_id, tag.tag_name from tag, element_tag, fulluser, " +
                    "elem where tag.tag_id = element_tag.tag_id and fulluser.user_id = elem.user_id " +
                    "and fulluser.user_id = @userId and elem.elem_id = element_tag.elem_id;";
                NpgsqlCommand showTagsNames = new NpgsqlCommand(sql, nc);
                showTagsNames.Parameters.AddWithValue("@userId", AutentificationClass.UserID);
                NpgsqlDataReader reader = showTagsNames.ExecuteReader();
                while (reader.Read())
                {
                    int tagId = Convert.ToInt32(reader[0]);
                    string thisNode = reader.GetString(1);
                    Tags tag = new Tags(tagId);
                    TreeNode newTag = new TreeNode(thisNode);
                    NpgsqlConnection nc1 = connectToDB.connect();
                    try
                    {
                        string getNotes = "SELECT note.elem_id, note.note_name " +
                            "FROM tag, note, element_tag, elem, fulluser  WHERE note.elem_id = elem.elem_id " +
                            "AND elem.elem_id = element_tag.elem_id AND tag.tag_id = element_tag.tag_id AND elem.user_id=fulluser.user_id AND fulluser.user_id=@userId " +
                            "AND tag.tag_id=@tagId;";
                        NpgsqlCommand showNotes = new NpgsqlCommand(getNotes, nc1);
                        showNotes.Parameters.AddWithValue("@userId", AutentificationClass.UserID);
                        showNotes.Parameters.AddWithValue("@tagId", tagId);
                        NpgsqlDataReader readNotes = showNotes.ExecuteReader();
                        while (readNotes.Read())
                        {
                            int noteId = Convert.ToInt32(readNotes[0]);
                            TreeNode newNote = new TreeNode(readNotes.GetString(1));
                            tag.addNotesToTag(noteId);
                            newTag.Nodes.Add(newNote);
                        }
                        newTag.Text += " ";
                        newTag.Text += newTag.Nodes.Count.ToString();
                        allTagsTree.Nodes.Add(newTag);
                        Tags.addNewTag(tag);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("ошибка с добавлением заметки в тег" + ex.Message);
                    }
                    nc1.Close();

                }
            }
            catch
            {
                MessageBox.Show("Ошибка при загрузке тегов");
            }
            nc.Close();
            allTagsTree.ExpandAll();
        }

        //добавление заметок во вкладку заметки
        public void showNotes()
        {
            noteIndexes.Clear();
            allNotes.Items.Clear();
            NpgsqlConnection nc = connectToDB.connect();
            try
            {

                string sql = "select note.elem_id, note_name, note_create, description from note join elem on elem.elem_id=note.elem_id and elem.user_id=@userId";
                string[] info = new string[4];
                NpgsqlCommand showNotes = new NpgsqlCommand(sql, nc);
                showNotes.Parameters.AddWithValue("@userId", AutentificationClass.UserID);
                NpgsqlDataReader reader = showNotes.ExecuteReader();
                int num = 1;
                while (reader.Read())
                {
                    int noteId = Convert.ToInt32(reader[0]);
                    info[0] = num.ToString();
                    info[1] = reader[1].ToString();
                    info[2] = reader[2].ToString();
                    info[3] = reader[3].ToString();
                    ListViewItem newNote = new ListViewItem(info);
                    allNotes.Items.Add(newNote);
                    insertIntoDictionary(newNote.Index, noteId);
                    num++;

                }
            }
            catch
            {
                MessageBox.Show("Ошибка при загрузке БД из шоу нотс");
            }
            nc.Close();
        }

        public void showAll()
        {

            showNotes();
            showTags();
        }

        //при загрузке главной формы
        private void mainForm_Load(object sender, EventArgs e)
        {
            autentificationForm newAutForm = new autentificationForm();
            newAutForm.ShowDialog();
            if (AutentificationClass.UserID != 0)
            {
                newAutForm.Close();
                showAll();
                monthForFilter.SelectedIndex= 0;
            }
            else
            {
                this.Close();
            }

        }

        //кнопка открыть личный кабинет
        private void button1_Click(object sender, EventArgs e)
        {
            userAccount currentAccount = new userAccount();
            currentAccount.openAccount();
            currentAccount.Show();

        }

        //кнопка добавить тег
        private void addTag_Click(object sender, EventArgs e)
        {
            AddTag newAddTag = new AddTag(); //создаем новую форму для добавления тега
            newAddTag.openAddForm();
            newAddTag.Show();
            newAddTag.Activate();
            newAddTag.FormClosed += (obj, args) => showAll();

        }

        //если кликаем на какой-то тег, то открывается форма его редактирования
        private void allTags_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode tn = allTagsTree.SelectedNode;
            if (tn!=null)
            {
                AddTag newEditTag = new AddTag(); //создаем новую форму для изменения тега
                int tagIndex = allTagsTree.SelectedNode.Index;
                newEditTag.openEditForm(tagIndex);
                newEditTag.Show();
                newEditTag.Activate();
                newEditTag.FormClosed += (obj, args) => allTagsTree.SelectedNode=null;
                newEditTag.FormClosed += (obj, args) =>showAll();
                
            }

        }

        public List<Note> searchByName(string name)
        {
            List<Note> notes = new List<Note>();
            NpgsqlConnection nc = connectToDB.connect();
            try
            {

                string sql = "select note_name, note_create, description from note join elem on " +
                    "elem.elem_id=note.elem_id and elem.user_id=@userId and note_name=@name";
                //string[] info = new string[4];
                
                NpgsqlCommand showNotes = new NpgsqlCommand(sql, nc);
                showNotes.Parameters.AddWithValue("@userId", AutentificationClass.UserID);
                showNotes.Parameters.AddWithValue("@name", name);
                NpgsqlDataReader reader = showNotes.ExecuteReader();
                while (reader.Read())
                {
                    Note newNote = new Note();
                    // = num.ToString();
                    newNote.NoteName = reader[0].ToString();
                    try
                    {
                        newNote.NoteCreate = Convert.ToDateTime(reader[1]);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Не удалось сконвертировать дату при поиске заметки" + ex.Message);
                    }
                    newNote.NoteDesc = reader[2].ToString();
                    notes.Add(newNote);
                }
            }
            catch
            {
                MessageBox.Show("Ошибка при поиске заметок");
            }
            nc.Close();
            return notes;
        }

        public void printNotesFromSearchOrFilter(List<Note> notes)
        {
            allNotes.Items.Clear();
            int num = 1;
            foreach (Note currentNote in notes)
            {
                
                string[] info = new string[4];
                try
                {
                    info[0] = num.ToString();
                    info[1] = currentNote.NoteName.ToString();
                    info[2] = currentNote.NoteCreate.ToString();
                    info[3] = currentNote.NoteDesc.ToString();
                }
                catch
                {
                    MessageBox.Show("Ошибка при конвертации индекса");
                }
                ListViewItem newNote = new ListViewItem(info);
                allNotes.Items.Add(newNote);
                num++;
            }
        }

        private void searchByNane_Click(object sender, EventArgs e)
        {
            List<Note> searchResult = new List<Note>();
            if (String.IsNullOrEmpty(nameForSearch.Text))
            {
                MessageBox.Show("Введите название заметки для поиска");
            }
            else
            {
                searchResult = searchByName(nameForSearch.Text);
                if (searchResult.Count > 0)
                {
                    printNotesFromSearchOrFilter(searchResult);
                }
                else
                {
                    MessageBox.Show("Нет заметок, удовлетворяющих условиям поиска");
                }
                
            }
        }

        private void cancelSearch_Click(object sender, EventArgs e)
        {
            nameForSearch.Text= null;
            showAll();
        }

        public List<Note> getByMonth(int month)
        {
            List<Note> notes = new List<Note>();
            NpgsqlConnection nc = connectToDB.connect();
            try
            {

                string sql = "select note_name, note_create, description from note join elem on " +
                    "elem.elem_id=note.elem_id and elem.user_id=@userId";

                NpgsqlCommand showNotes = new NpgsqlCommand(sql, nc);
                showNotes.Parameters.AddWithValue("@userId", AutentificationClass.UserID);
                NpgsqlDataReader reader = showNotes.ExecuteReader();
                while (reader.Read())
                {
                    Note newNote = new Note();
                    DateTime date;
                    //newNote.NoteName = reader[0].ToString();
                    try
                    {
                        date = Convert.ToDateTime(reader[1]);
                        if (date.Month == month)
                        {
                            newNote.NoteName = reader[0].ToString();
                            newNote.NoteCreate = date;
                            newNote.NoteDesc= reader[2].ToString();
                            notes.Add(newNote);
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Не удалось сконвертировать дату при поиске заметки" + ex.Message);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Ошибка при поиске заметок");
            }
            nc.Close();
            return notes;

        }

        private void filterByDate_Click(object sender, EventArgs e)
        {
            DateTime date;
            List<Note> notes = new List<Note>();
            if (monthForFilter.SelectedIndex==0) {
                MessageBox.Show("Введите дату");
            }
            else
            {
                notes=getByMonth(monthForFilter.SelectedIndex);
                if (notes.Count == 0) {
                    MessageBox.Show("Нет заметок, удовлетворяющих критериям поиска");
                }
                else
                {
                    printNotesFromSearchOrFilter(notes);
                }
                
            }
        }

        private void cancelFilter_Click(object sender, EventArgs e)
        {
            monthForFilter.SelectedIndex = 0;
            showAll();
        }
    }
}
