using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace ITPAssignment1
{
    internal class JSON
    {
        private Dictionary<string, StudentRecordData> studentRecords;
        private string dataDirectory = "UserData";

        public JSON(Dictionary<string, StudentRecordData> studentRecords)
        {
            this.studentRecords = studentRecords;
        }

        public void SaveStudentDataPerma()
        {
            foreach (var studentID in studentRecords.Keys)
            {
                try
                {
                    if (studentRecords.TryGetValue(studentID, out var studentData))
                    {
                        // Save JSON data
                        string json = JsonConvert.SerializeObject(studentData);
                        string jsonFilePath = Path.Combine(dataDirectory, $"{studentID}.json");
                        File.WriteAllText(jsonFilePath, json);

                        // Save text data
                        string textFilePath = Path.Combine(dataDirectory, $"{studentID}.txt");
                        using (StreamWriter writer = new StreamWriter(textFilePath, false))
                        {
                            writer.WriteLine($"Student ID: {studentData.StudentID}");
                            writer.WriteLine($"Student Name: {studentData.StudentName}");
                            writer.WriteLine($"Marks: {string.Join(", ", studentData.Marks)}");
                            writer.WriteLine($"Notes: {string.Join(", ", studentData.Notes)}");

                            if (studentData.NewMarks.Count > 0) // Check If Marks Have Been Updated Or Not
                            {
                                writer.WriteLine($"Updated Marks: {string.Join(", ", studentData.NewMarks)}");
                                writer.WriteLine($"Updated Notes: {studentData.NewNotes}");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Student ID {studentID} Not Found In The Dictionary");
                    }
                }
                catch (Exception Error)
                {
                    Console.WriteLine($"Error Saving Data To File: {Error.Message}");
                }
            }
        }

        public void LoadPermaStudentData()
        {
            foreach (var filePath in Directory.EnumerateFiles(dataDirectory, "*.json"))
            {
                try
                {
                    string json = File.ReadAllText(filePath);
                    StudentRecordData studentData = JsonConvert.DeserializeObject<StudentRecordData>(json);

                    string studentID = Path.GetFileNameWithoutExtension(filePath);

                    if (!studentRecords.ContainsKey(studentID))
                    {
                        studentRecords[studentID] = studentData;
                    }
                    else
                    {
                    }
                }
                catch (Exception Error)
                {
                    Console.WriteLine($"Error Loading Data From File: {Error.Message}");
                }
            }
        }
    }
}
