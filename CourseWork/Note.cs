using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace CourseWork
{
    public class Note
    {
        string noteName;
        DateTime noteCreate;
        string noteDesc;

        public string NoteName { get { return noteName; } set { noteName= value; } }
        public DateTime NoteCreate { get { return noteCreate; } set { noteCreate= value; } }
        public string NoteDesc { get { return noteDesc; } set { noteDesc= value; } }

        public Note() { }

        public Note(string noteName, string noteDesc)
        {
            this.noteName = noteName;
            this.noteCreate=DateTime.Now;
            this.noteDesc = noteDesc;

        }

        public Note(string noteName, DateTime date, string noteDesc)
        {
            this.noteName = noteName;
            this.noteCreate = date;
            this.noteDesc = noteDesc;

        }


        public void addNewNote(Note note)
        {
            int noteId = 0;
            NpgsqlConnection nc = connectToDB.connect();
            using (var command = new NpgsqlCommand("INSERT INTO elem (elem_type, user_id) VALUES (false, @userId) returning elem_id", nc))
            {
                command.Parameters.AddWithValue("@userId", AutentificationClass.UserID);
                try
                {
                    noteId = Convert.ToInt32(command.ExecuteScalar());
                    nc.Close();
                }
                catch (Exception ex) {
                    MessageBox.Show("Ошибка с индексом элемента" + ex.Message);
                }
            }
            try
            {
                using (nc)
                {
                    nc.Open();
                    using (var com = new NpgsqlCommand("INSERT INTO note (elem_id, note_name, note_create, description) VALUES (@elem_id, @noteName, @noteCreate, @desc)", nc))
                    {
                        com.Parameters.AddWithValue("@elem_id", noteId);
                        mainForm.noteIndexes.Add(mainForm.noteIndexes.Count, noteId);
                        com.Parameters.AddWithValue("@noteName", note.NoteName);
                        com.Parameters.AddWithValue("@noteCreate", note.NoteCreate);
                        if (note.NoteDesc == null)
                        {
                            com.Parameters.AddWithValue("@desc", DBNull.Value);
                        }
                        else
                        {
                            com.Parameters.AddWithValue("@desc", note.NoteDesc);
                        }
                        com.ExecuteNonQuery();
                        nc.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Заметка не добавилась" + ex.Message);
            }

        }

    }
}
