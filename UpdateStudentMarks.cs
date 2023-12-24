using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ITPAssignment1
{
    internal class UpdateStudentMarks
    {
        private Dictionary<string, StudentRecordData> studentRecords;
        private string dataDirectory = "UserData";

        public UpdateStudentMarks(Dictionary<string, StudentRecordData> studentRecords)
        {
            this.studentRecords = studentRecords;
        }

        public void UpdateStudentMarksData()
        {
            Console.WriteLine("");
            Console.Write("Please Enter The Student's ID Number: ");
            string studentID = Console.ReadLine();

            if (studentRecords.ContainsKey(studentID))
            {
                Console.WriteLine("Enter 6 New Marks (0 - 100):");
                var marks = new List<int>();
                for (int i = 0; i < 6; i++)
                {
                    Console.Write($"Enter New Mark {i + 1}: ");
                    if (int.TryParse(Console.ReadLine(), out int mark) && mark >= 0 && mark <= 100)
                    {
                        marks.Add(mark);
                    }
                    else
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Invalid Input, Marks Must Be 0 - 100");
                        Console.WriteLine("");
                        i--;
                    }
                }

                int average = (int)marks.Average();

                // If Marks Have Already Been Updated And Are Being Updated Again, This Clears The Old Updated Marks
                if (studentRecords[studentID].NewMarks == null)
                {
                    studentRecords[studentID].NewMarks = new List<int>();
                }
                else
                {
                    studentRecords[studentID].NewMarks.Clear();
                }

                studentRecords[studentID].NewMarks.AddRange(marks);
                studentRecords[studentID].NewNotes = average >= 40 ? "Passed" : "Failed";

                string jsonFilePath = Path.Combine(dataDirectory, $"{studentID}.json");
                string json = JsonConvert.SerializeObject(studentRecords[studentID]);
                File.WriteAllText(jsonFilePath, json); // Write Data To JSON

                string filePath = Path.Combine(dataDirectory, $"{studentID}.txt"); // Write Data To Text File
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine($"New Marks: {string.Join(", ", marks)}");
                    writer.WriteLine($"New Notes: {(average >= 40 ? "Passed" : "Failed")}");
                }
                Console.WriteLine($"The Marks Have Been Updated For This Student. Average: {average}");
                Console.WriteLine("");
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