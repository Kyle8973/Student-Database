using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITPAssignment1
{
    internal class ViewStudentDataRecord
    {
        private Dictionary<string, StudentRecordData> studentRecords;
        private string dataDirectory = "UserData";

        public ViewStudentDataRecord(Dictionary<string, StudentRecordData> studentRecords)
        {
            this.studentRecords = studentRecords;
        }
        public void ViewStudentData()
        {
            Console.WriteLine("");
            Console.Write("Please Enter The Student's ID Number: ");
            string studentID = Console.ReadLine();

            if (studentRecords.ContainsKey(studentID))
            {
                string jsonPath = Path.Combine(dataDirectory, $"{studentID}.json");
                string textPath = Path.Combine(dataDirectory, $"{studentID}.txt");

                if (File.Exists(jsonPath))
                {
                    string json = File.ReadAllText(jsonPath);
                    StudentRecordData studentData = JsonConvert.DeserializeObject<StudentRecordData>(json);

                    Console.WriteLine("");
                    Console.WriteLine("Reading Student Data From JSON Database"); // Read JSON Data
                    Console.WriteLine("");
                    Console.WriteLine($"Student ID: {studentData.StudentID}");
                    Console.WriteLine($"Student Name: {studentData.StudentName}");
                    Console.WriteLine($"Marks: {string.Join(", ", studentData.Marks)}");
                    Console.WriteLine($"Notes: {string.Join(", ", studentData.Notes)}");
                    Console.WriteLine("");

                    if (studentData.NewMarks.Any()) // Check If Marks Have Been Updated Or Not
                    {
                        Console.WriteLine($"Updated Marks: {string.Join(", ", studentData.NewMarks)}");
                        Console.WriteLine($"Updated Notes: {studentData.NewNotes}");
                        Console.WriteLine("");
                    }
                }
                else if (File.Exists(textPath))
                {
                    using (StreamReader reader = new StreamReader(textPath))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            Console.WriteLine("");
                            Console.WriteLine(line);
                            Console.WriteLine("");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("");
                    Console.WriteLine("Student Data Record Not Found, Please Try Again With A Valid ID"); // Error Handling
                    Console.WriteLine("");
                }
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine("Student Data Record Not Found, Please Try Again With A Valid ID"); // Error Handling
                Console.WriteLine("");
            }
        }
    }
}
