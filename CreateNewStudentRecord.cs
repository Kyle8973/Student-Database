using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace ITPAssignment1
{
    public class CreateNewStudentRecord
    {
        private Dictionary<string, StudentRecordData> studentRecords;
        private string dataDirectory = "UserData";

        public CreateNewStudentRecord(Dictionary<string, StudentRecordData> studentRecords)
        {
            this.studentRecords = studentRecords;
        }

        public void CreateStudentRecord()
        {
            Console.WriteLine("");
            Console.Write("Please Enter The Student's Full Name: ");
            string name = Console.ReadLine();

            string studentID = StudentIDGenerator.GenerateStudentID();
            var newStudent = new StudentRecordData
            {
                StudentID = studentID,
                StudentName = name
            };

            studentRecords[studentID] = newStudent;

            string jsonFilePath = Path.Combine(dataDirectory, $"{studentID}.json");
            string json = JsonConvert.SerializeObject(newStudent);
            File.WriteAllText(jsonFilePath, json);

            string filePath = Path.Combine(dataDirectory, $"{studentID}.txt");
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine($"Student Number: {studentID}");
                writer.WriteLine($"Student Name: {name}");
            }
            Console.WriteLine("");
            Console.WriteLine($"Successfully Created A New Student Record For {name} With The ID: {studentID}");
            Console.WriteLine("");
        }
    }
}