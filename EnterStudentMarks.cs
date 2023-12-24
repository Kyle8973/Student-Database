using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ITPAssignment1
{
    internal class EnterStudentMarks
    {
        private Dictionary<string, StudentRecordData> studentRecords;
        private string dataDirectory = "UserData";

        public EnterStudentMarks(Dictionary<string, StudentRecordData> studentRecords)
        {
            this.studentRecords = studentRecords;
        }

        public void EnterStudentMarksData()
        {
            Console.WriteLine("");
            Console.Write("Please Enter The Student's ID Number: ");
            string studentID = Console.ReadLine();

            if (studentRecords.ContainsKey(studentID))
            {
                Console.WriteLine("");
                Console.WriteLine("Enter 6 Marks (0 - 100):");
                var marks = new List<int>();
                for (int i = 0; i < 6; i++)
                {
                    Console.Write($"Enter Mark {i + 1}: ");
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
                studentRecords[studentID].Marks.AddRange(marks);
                studentRecords[studentID].Notes.Add(average >= 40 ? "Passed" : "Failed");

                string jsonFilePath = Path.Combine(dataDirectory, $"{studentID}.json");
                string json = JsonConvert.SerializeObject(studentRecords[studentID]);
                File.WriteAllText(jsonFilePath, json);

                string filePath = Path.Combine(dataDirectory, $"{studentID}.txt");
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine($"Marks: {string.Join(", ", marks)}");
                    writer.WriteLine($"Notes: {(average >= 40 ? "Passed" : "Failed")}");
                }
                Console.WriteLine("");
                Console.WriteLine($"The Marks Have Been Added For This Student. Average Mark: {average}");
                Console.WriteLine("");
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine("Student Data Record Not Found, Please Try Again With A Valid ID");
                Console.WriteLine("");
            }
        }
    }
}