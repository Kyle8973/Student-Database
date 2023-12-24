using System.Collections.Generic;

namespace ITPAssignment1
{
    public class StudentRecordData
    {
        public string StudentID { get; set; }
        public string StudentName { get; set; }
        public List<int> Marks { get; set; }
        public List<string> Notes { get; set; }
        public List<int> NewMarks { get; set; }
        public string NewNotes { get; set; }

        public StudentRecordData()
        {
            Marks = new List<int>();
            Notes = new List<string>();
            NewMarks = new List<int>();
            NewNotes = string.Empty;
        }
    }
}
