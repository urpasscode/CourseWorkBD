using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace CourseWork
{
    public partial class AddNote : Form
    {
        public AddNote()
        {
            InitializeComponent();
        }


        int toFindInDB = 0;
        int currentIndexInList=0;


        public bool checkNoteDesc()
        {
            Regex checkDesc = new Regex(@"^[а-яА-ЯёЁa-zA-Z0-9\.\-\,\s ]+$");
            Match note = checkDesc.Match(noteDiscription.Text);
            if (!note.Success)
            {
                noteErrorLabel.Visible = true;
                noteErrorLabel.Text = "Неверный формат ввода описания заметки";
                return false;
            }
            return true;
        }

        public bool checkNoteName()
        {
            Regex checkNote = new Regex(@"^[а-яА-ЯёЁa-zA-Z0-9\.\-\,\s ]+$");
            Match note = checkNote.Match(noteName.Text);
            if (!note.Success)
            {
                noteErrorLabel.Visible = true;
                noteErrorLabel.Text = "Неверный формат ввода названия заметки";
                return false;
            }
            return true;
        }

        public bool addNewNote()
        {
            if (String.IsNullOrEmpty(noteName.Text))
            {
                noteErrorLabel.Text = "Введите название заметки";
                return false;
            }
            else
            {
                bool b=checkNoteName();
                if (b)
                {
                    string name = noteName.Text;
                    string desc = null;
                    if (!String.IsNullOrEmpty(noteDiscription.Text))
                    {
                        bool b2 = checkNoteDesc();
                        if (b2)
                        {
                            desc = noteDiscription.Text;
                            Note newNote = new Note(name, desc);
                            newNote.addNewNote(newNote);
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        Note newNote = new Note(name, desc);
                        newNote.addNewNote(newNote);
                    }
                }
                else
                {
                    return false;
                }
            }
            return true;
            
        }

        public void openAddForm()
        {
            noteErrorLabel.Visible = false;
            changeNoteButton.Visible = false;
            saveNote.Visible = true;
            saveChangesButton.Visible = false;
            noteDiscription.ReadOnly = false;
            noteName.ReadOnly=false;
            deleteNote.Visible= false;
            cancelChangesButton.Visible = false;
        }



        public int openEditForm(int ind)
        {
            noteErrorLabel.Visible = false;
            saveChangesButton.Visible= false;
            saveNote.Visible = false;
            noteName.ReadOnly = true;
            noteDiscription.ReadOnly = true;
            changeNoteButton.Visible = true;
            cancelChangesButton.Visible = false;
            deleteNote.Visible = true;
            cancelNote.Visible = true;
            currentIndexInList = ind;
            mainForm.noteIndexes.TryGetValue(currentIndexInList, out toFindInDB);
            NpgsqlConnection nc = connectToDB.connect();
            if (toFindInDB != 0)
            {
                try
                {
                    string sql = "select note_name, description from note where elem_id=@toFindInDB;";
                    NpgsqlCommand currentNote = new NpgsqlCommand(sql, nc);
                    currentNote.Parameters.AddWithValue("@toFindInDB", toFindInDB);
                    NpgsqlDataReader reader = currentNote.ExecuteReader();
                    while (reader.Read())
                    {
                        noteName.Text = reader[0].ToString();
                        noteDiscription.Text = reader[1].ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("неудачно показалась заметка" + ex.Message);
                }

            }
            else
            {
                MessageBox.Show("не удалось считать индекс заметки из дикшнари");
            }

            return toFindInDB;
        }

        private void addNote_Load(object sender, EventArgs e)
        {
        }

        private void saveNote_Click(object sender, EventArgs e)
        {
            bool b=addNewNote();
            if (b)
            {
                this.Close();
            }
            
        }

        private void changeNoteButton_Click(object sender, EventArgs e)
        {
            noteName.ReadOnly = false;
            noteDiscription.ReadOnly = false;
            changeNoteButton.Visible = false;
            deleteNote.Visible = false;
            saveChangesButton.Visible = true;
            cancelChangesButton.Visible = true;
            cancelNote.Visible = false;
        }

        //почему-то бд обновляется не сразу, поэтому после удаления заметки бд считает, что она еще есть в теге...

        public void checkIfTagIsEmpty()
        {
            foreach (Tags tag in Tags.allTags)
            {
                if (tag.NotesId.Count == 0)
                {
                    NpgsqlConnection nc1 = connectToDB.connect();
                    try
                    {
                        string sql = "delete from tag where tag_id=@tagId;";
                        NpgsqlCommand deleteNote = new NpgsqlCommand(sql, nc1);
                        deleteNote.Parameters.AddWithValue("@tagId", tag.TagId);
                        deleteNote.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка при удалении  пустого тега" + ex.Message);
                    }
                    nc1.Close();
                }
                else
                {
                    MessageBox.Show("тег почему то не пустой...");
                }
            }
        }


        //функция для удаления открывшейся заметки
        public void deleteCurrentNote(int index)
        {
            NpgsqlConnection nc = connectToDB.connect();
            try
            {
                string sql = "delete from note where elem_id=@ind;";
                NpgsqlCommand deleteNote = new NpgsqlCommand(sql, nc);
                deleteNote.Parameters.AddWithValue("@ind", index);
                deleteNote.ExecuteNonQuery();
                mainForm.noteIndexes.Remove(index);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при удалении заметки" + ex.Message);
            }
            nc.Close();
            foreach(Tags tag in Tags.allTags)
            {
                if (tag.NotesId.Contains(index))
                {
                    tag.NotesId.Remove(index);
                }
            }
        }

        //кнопка для удаления заметки
        private void deleteNote_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Подтвердите удаление элемента",
                                     "Удаление заметки",
                                     MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                deleteCurrentNote(toFindInDB);
                checkIfTagIsEmpty();
                this.Close();
            }

        }

        private void cancelNote_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void changeNote(string newNoteName, string newNoteDescription)
        {
            NpgsqlConnection nc = connectToDB.connect();
            try
            {
                string sql = "update note set note_name=@newNoteName, note_create=@newNoteCreate, description=@newNoteDescription " +
                    "where elem_id=@noteId;";
                NpgsqlCommand deleteNote = new NpgsqlCommand(sql, nc);
                deleteNote.Parameters.AddWithValue("@newNoteName", newNoteName);
                deleteNote.Parameters.AddWithValue("@newNoteCreate", DateTime.Now);
                if (newNoteDescription!= null) {
                    deleteNote.Parameters.AddWithValue("@newNoteDescription", newNoteDescription);
                }
                else
                {
                    deleteNote.Parameters.AddWithValue("@newNoteDescription", DBNull.Value);
                }
                
                deleteNote.Parameters.AddWithValue("@noteId", toFindInDB);
                deleteNote.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при изменении заметки" + ex.Message);
            }
            nc.Close();

        }

        public bool saveCurrentNote()
        {
            string newNoteName;
            string newNoteDescription = null;
            bool b = checkNoteName();
            bool b1 = checkNoteDesc();
            if (String.IsNullOrEmpty(noteName.Text))
            {
                noteErrorLabel.Visible = true;
                noteErrorLabel.Text = "Введите название заметки";
                return false;
            }
            else
            {
                if (b)
                {
                    newNoteName = noteName.Text;
                    if (!String.IsNullOrEmpty(noteDiscription.Text))
                    {
                        if (b1)
                        {
                            newNoteDescription = noteDiscription.Text;
                            changeNote(newNoteName, newNoteDescription);
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        changeNote(newNoteName, newNoteDescription);
                    }
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        private void saveChangesButton_Click(object sender, EventArgs e)
        {
            bool b=saveCurrentNote();
            if (b)
            {
                this.Close();
            }
        }

        private void cancelChangesButton_Click(object sender, EventArgs e)
        {
            openEditForm(currentIndexInList);
        }
    }
}
