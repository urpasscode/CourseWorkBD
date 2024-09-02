using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseWork
{
    public partial class AddTag : Form
    {
        //первый арг - номер заметки в списке, второй-айдишник
        Dictionary<int, int> notesIndexes = new Dictionary<int, int>();

        public AddTag()
        {
            InitializeComponent();
        }

        public void openAddForm()
        {
            tagErrorLabel.Visible = false;
            changeTagButton.Visible = false;
            notesInTag.Visible = false;
            saveTag.Visible = true;
            selectNotesToTag.Visible = true;
            notesIndexes.Clear();
            selectNotesToTag.Items.Clear();
            safeTagAfterChange.Visible = false;
            NpgsqlConnection nc = connectToDB.connect();
            try
            {
                string sql = "select note.elem_id, note.note_name from note join elem on elem.elem_id=note.elem_id and elem.user_id=@userId";
                NpgsqlCommand showNotes = new NpgsqlCommand(sql, nc);
                showNotes.Parameters.AddWithValue("@userId", AutentificationClass.UserID);
                NpgsqlDataReader reader = showNotes.ExecuteReader();

                while (reader.Read())
                {
                    int noteId = Convert.ToInt32(reader[0]);
                    string thisNote = reader.GetString(1);
                    selectNotesToTag.Items.Add(thisNote);
                    notesIndexes.Add(selectNotesToTag.Items.Count - 1, noteId);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке заметок для добавления  в тег" + ex.Message);
            }
            nc.Close();
        }

        //ищем заметки, отмеченный флагом
        public List<int> searchForCheckedNotes()
        {
            List<int> notesIndexesToAdd = new List<int>();

            foreach (int ind in selectNotesToTag.CheckedIndices)
            {
                notesIndexesToAdd.Add(ind);
            }
            return notesIndexesToAdd;
        }

        public void addNotesToTag(int tagId, List<int> notes)
        {

            NpgsqlConnection nc = connectToDB.connect();

            foreach (var allNote in notesIndexes)
            {
                foreach (int checkedNote in notes)
                {
                    if (allNote.Key == checkedNote)
                    {
                        NpgsqlConnection nc1 = connectToDB.connect();
                        try
                        {
                            string sql = "insert into element_tag (elem_id, tag_id) values (@elem_id, @tag_id) ;";
                            NpgsqlCommand addNotes = new NpgsqlCommand(sql, nc1);
                            addNotes.Parameters.AddWithValue("@elem_id", allNote.Value);
                            addNotes.Parameters.AddWithValue("@tag_id", tagId);
                            addNotes.ExecuteNonQuery();
                        }
                        catch (Exception ex1)
                        {
                            MessageBox.Show("ошибка при добавлении замеьки в новый тег" + ex1.Message);
                        }

                    }
                }
            }
            nc.Close();

        }

        public int addNewTag()
        {
            NpgsqlConnection nc = connectToDB.connect();
            string tagName = tagNameBox.Text;
            int tagId = 0;
            try
            {
                string sql = "insert into tag (tag_name) values (@tag_name) returning tag_id;";
                NpgsqlCommand addNotes = new NpgsqlCommand(sql, nc);
                addNotes.Parameters.AddWithValue("@tag_name", tagName);
                tagId = Convert.ToInt32(addNotes.ExecuteScalar());
            }
            catch (Exception ex1)
            {
                MessageBox.Show("ошибка при создании нового тега" + ex1.Message);
            }
            nc.Close();
            return tagId;
        }

        private void saveTag_Click(object sender, EventArgs e)
        {
            int tagId = addNewTag();
            try
            {
                List<int> checkedNotes = searchForCheckedNotes();
                addNotesToTag(tagId, checkedNotes);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ошибка либо в поиске отмеченных заметок, либо в создании связи элем-тег " + ex.Message);
            }

            this.Close();
        }




        /* здесь нужно проверить, существует ли уже эта заметка в теге. у нас есть список всех айдишников
         * дальше нужно получить айдишники, которые есть в данным теге
         */


        /*сначала нужно получить все заметки
         * дальше нужно получить заметки из конкретного тега
         * если они совпадают, то поставить флажок
         * если нет, то просто отобразить без флага
         * 
         */

        int tagToBD = 0;
        int tagToList = 0;
        public void openEditForm(int tagIndex)
        {
            tagErrorLabel.Visible = false;
            int tagId = Tags.allTags.ElementAt(tagIndex).TagId;
            tagToBD = tagId;
            tagToList = tagIndex;
            changeTagButton.Visible = true;
            notesInTag.Visible = true;
            saveTag.Visible = false;
            selectNotesToTag.Visible = false;
            safeTagAfterChange.Visible = false;
            NpgsqlConnection nc = connectToDB.connect();
            try
            {
                string getTagName = "select tag_name from tag where tag_id=@tagId;";
                NpgsqlCommand getName = new NpgsqlCommand(getTagName, nc);
                getName.Parameters.AddWithValue("@tagId", tagId);
                NpgsqlDataReader reader1 = getName.ExecuteReader();
                while (reader1.Read())
                {
                    tagNameBox.Text = reader1.GetString(0);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ошибка при получении названия тега при открытии формы для изменения" + ex.Message);
            }
            nc.Close();

            foreach (int noteId in Tags.allTags.ElementAt(tagIndex).NotesId)
            {
                NpgsqlConnection nc1 = connectToDB.connect();
                try
                {
                    string getNote = "select note_name from note where elem_id=@elemId;";
                    NpgsqlCommand getNoteName = new NpgsqlCommand(getNote, nc1);
                    getNoteName.Parameters.AddWithValue("@elemId", noteId);
                    NpgsqlDataReader readNote = getNoteName.ExecuteReader();
                    while (readNote.Read())
                    {
                        string noteName = readNote.GetString(0);
                        ListViewItem thisName = new ListViewItem(noteName);
                        notesInTag.Items.Add(thisName);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ошибка при отображении заметок в существующем теге" + ex.Message);
                }
                nc1.Close();
            }
            tagNameBox.ReadOnly = true;

        }

        /* у нас есть некоторый выбранный тег и его айдишник
         * по айдишнику тега можно из списка вычислить индексы его заметок (готово в переменной notesInCurrentTag)
         * далее начинаем читать заметки из бд
         * если находим заметку с нужным айдишником из списка, то ставим около нее флаг
         * далее отобразить эти заметки с флагом
         * если их нет в списке для конкретного тега то отобразить без флага
         * 
         */

        //здесь вернули список заметок (индекс и айди), которые УЖЕ ЕСТЬ в теге
        public Dictionary<int, int> showNotesToEdit()
        {
            /*int tagId = Tags.allTags.ElementAt(tagToList).TagId;
            tagToBD = tagId;*/
            List<int> notesInCurrentTag = Tags.allTags.ElementAt(tagToList).NotesId;
            Dictionary<int, int> trueNotes= new Dictionary<int, int>();
            notesIndexes.Clear();
            NpgsqlConnection nc = connectToDB.connect();
            try
            {
                string sql = "select note.elem_id, note.note_name from note join elem on elem.elem_id=note.elem_id and elem.user_id=@userId";
                NpgsqlCommand showNotes = new NpgsqlCommand(sql, nc);
                showNotes.Parameters.AddWithValue("@userId", AutentificationClass.UserID);
                NpgsqlDataReader reader = showNotes.ExecuteReader();
                while (reader.Read())
                {
                    int noteId = Convert.ToInt32(reader[0]);
                    string thisNote = reader.GetString(1);
                    if (notesInCurrentTag.Contains(noteId))
                    {
                        selectNotesToTag.Items.Add(thisNote, true);
                        trueNotes.Add(selectNotesToTag.Items.Count- 1, noteId);
                    }
                    else
                    {
                        selectNotesToTag.Items.Add(thisNote,false);
                    }
                    notesIndexes.Add(selectNotesToTag.Items.Count - 1, noteId);
                }
                MessageBox.Show("Заметки для добавления загружены успешно");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке заметок для добавления  в тег" + ex.Message);
            }
            nc.Close();
            return trueNotes;
        }

        //здесь как то нужно получить заметки из всех, которые отмечены 
        public Dictionary<int, int> selectNotesToEdit()
        {
            Dictionary<int, int> selectedNotes = new Dictionary<int, int>();
            foreach(int indCurrentNote in notesIndexes.Keys)
            {
                if (selectNotesToTag.GetItemChecked(indCurrentNote))
                {
                    selectedNotes.Add(indCurrentNote, notesIndexes.ElementAt(indCurrentNote).Value);
                }
            }
            MessageBox.Show("отмеченные заметки " + selectedNotes.Count.ToString());
            return selectedNotes;
        }
        /*если заметки есть в списке выбранных, то нужно найти те, которые не были выбраны ранее и добавить их
         * тут осуществляем поиск по новому списку
         * 
         * если заметок нет в списке выбранных, но они есть в старом списке, то нужно удалить
         * тут осуществляем поиск по старому списку
         * 
         */
        public void addNewNotesToCurrentTag(Dictionary<int,int> trueNotes, Dictionary<int,int> selectedNotes)
        {
            foreach (var indexSelected in selectedNotes) {
                if (!trueNotes.ContainsKey(indexSelected.Key))
                {
                    NpgsqlConnection nc = connectToDB.connect();
                    try
                    {
                        string sql = "insert into element_tag (elem_id, tag_id) values (@elem_id, @tag_id) ;";
                        NpgsqlCommand addNotes = new NpgsqlCommand(sql, nc);
                        addNotes.Parameters.AddWithValue("@elem_id", indexSelected.Value);
                        addNotes.Parameters.AddWithValue("@tag_id", tagToBD);
                        addNotes.ExecuteNonQuery();
                        MessageBox.Show("Новая связь между заметкой и тегом успешно создана");
                    }
                    catch (Exception ex1)
                    {
                        MessageBox.Show("Ошибка при связке заметки и тега при изменении тега" + ex1.Message);
                    }
                    nc.Close();
                }
            }
        }

        public void deleteNotSelectedNotesFromTag(Dictionary<int, int> trueNotes, Dictionary<int, int> selectedNotes)
        {
            foreach (var indexTrue in trueNotes)
            {
                if (!selectedNotes.ContainsKey(indexTrue.Key))
                {
                    NpgsqlConnection nc = connectToDB.connect();
                    try
                    {
                        string sql = "delete from element_tag where elem_id=@elem_id and tag_id=@tag_id ;";
                        NpgsqlCommand addNotes = new NpgsqlCommand(sql, nc);
                        addNotes.Parameters.AddWithValue("@elem_id", indexTrue.Value);
                        addNotes.Parameters.AddWithValue("@tag_id", tagToBD);
                        addNotes.ExecuteNonQuery();
                        MessageBox.Show("Более не отмеченные заметки успешно удалены з текущего тега");
                    }
                    catch (Exception ex1)
                    {
                        MessageBox.Show("Ошибка при удалении ненужных заметок из текущего тега" + ex1.Message);
                    }
                    nc.Close();
                }
            }
        }

        public void changeNotesInTag(Dictionary<int, int> trueNotes, Dictionary<int, int> selectedNotes)
        {
            deleteNotSelectedNotesFromTag(trueNotes,selectedNotes);
            addNewNotesToCurrentTag(trueNotes, selectedNotes);
        }

        Dictionary<int, int> oldNotes=new Dictionary<int, int>();

        private void changeTagButton_Click(object sender, EventArgs e)
        {
            tagNameBox.ReadOnly = false;
            notesInTag.Visible= false;
            selectNotesToTag.Visible = true;
            selectNotesToTag.Items.Clear();
            safeTagAfterChange.Visible = true;
            changeTagButton.Visible = false;
            oldNotes=showNotesToEdit();

        }

        public bool parseTagName()
        {
            Regex checkTagName = new Regex(@"^[а-яА-ЯёЁa-zA-Z0-9\.\-\,\s ]+$");

            Match name = checkTagName.Match(tagNameBox.Text);
            if (!name.Success)
            {
                tagErrorLabel.Visible = true;
                tagErrorLabel.Text = "Неверный формат ввода названия тега";
                return false;
            }

            return true;
        }

        public void changeTagName(string tagName)
        {
            NpgsqlConnection nc = connectToDB.connect();
            try
            {
                string sql = "update tag set tag_name=@tagName where tag_id=@tagId;";
                NpgsqlCommand addNotes = new NpgsqlCommand(sql, nc);
                addNotes.Parameters.AddWithValue("@tagName", tagName);
                addNotes.Parameters.AddWithValue("@tagId", tagToBD);
                addNotes.ExecuteNonQuery();
                MessageBox.Show("успешно изменили название тега");
            }
            catch (Exception ex1)
            {
                MessageBox.Show("Ошибка при изменении названия тега" + ex1.Message);
            }
            nc.Close();
        }

        private void safeTagAfterChange_Click(object sender, EventArgs e)
        {
            string tagName;
            if (string.IsNullOrEmpty(tagNameBox.Text))
            {
                tagErrorLabel.Visible = true;
                tagErrorLabel.Text = "Введите название тега";
            }
            else
            {
                bool b=parseTagName();
                if (b)
                {
                    tagName= tagNameBox.Text;
                    changeTagName(tagName);
                    Dictionary<int, int> newNotes = selectNotesToEdit();
                    if (newNotes.Count != 0)
                    {
                        changeNotesInTag(oldNotes, newNotes);
                        this.Close();
                    }
                    else
                    {
                        tagErrorLabel.Visible = true;
                        tagErrorLabel.Text = "Выберите заметки";
                    }
                    
                }
            }
            
        }

        public void deleteCurrentTag(int index)
        {
            NpgsqlConnection nc = connectToDB.connect();
            try
            {
                string sql = "delete from tag where tag_id=@tagId;";
                NpgsqlCommand deleteNote = new NpgsqlCommand(sql, nc);
                deleteNote.Parameters.AddWithValue("@tagId", index);
                deleteNote.ExecuteNonQuery();
                MessageBox.Show("тег успешно удален");
                mainForm.noteIndexes.Remove(index);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при удалении тега" + ex.Message);
            }
            nc.Close();
        }

        private void deleteTag_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Подтвердите удаление элемента",
                                     "Удаление тега",
                                     MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                deleteCurrentTag(tagToBD);
                this.Close();
            }

        }

        private void cancelInTagForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
