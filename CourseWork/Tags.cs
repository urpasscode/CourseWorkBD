using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork
{
    internal class Tags
    {
        int tagId;

        public List<int> NotesId;
        public int TagId { get { return tagId; } set { tagId = value; } }
        public Tags(int tagId)
        {
            this.TagId = tagId;
            this.NotesId = new List<int>();
        }

        public Tags() { }
        public static List<Tags> allTags = new List<Tags>();

        public static void addNewTag(Tags tag)
        {
            allTags.Add(tag);
        }

        public void addNotesToTag(int noteId)
        {
            this.NotesId.Add(noteId);

        }
    }
}
