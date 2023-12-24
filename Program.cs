using System;
using System.Collections.Generic;
using System.IO;

namespace ITPAssignment1
{
    public class Program
    {
        private Dictionary<string, StudentRecordData> studentRecords = new Dictionary<string, StudentRecordData>();
        private string dataDirectory = "UserData";

        public static void Main()
        {
            Program program = new Program();
            program.Initiate();
        }

        public void Initiate()
        {
            Directory.CreateDirectory(dataDirectory);

            // Create JSON Class
            JSON json = new JSON(studentRecords);

            // Load Student Data From JSON
            json.LoadPermaStudentData();

            CreateNewStudentRecord studentRecordCreator = new CreateNewStudentRecord(studentRecords); // CreateStudentRecord.cs
            EnterStudentMarks studentMarks = new EnterStudentMarks(studentRecords); // EnterStudentMarks.cs
            UpdateStudentMarks updateStudentMarks = new UpdateStudentMarks(studentRecords); // UpdateStudentMarks.cs
            ViewStudentDataRecord viewStudentDataRecord = new ViewStudentDataRecord(studentRecords); // ViewStudentRecord.cs


            // Menu Options
            string[] menuOptions = {
                "Create A New Student Data Record",
                "Input Marks For A Student",
                "Update A Student's Existing Marks",
                "Display An Existing Student Record",
                "Exit The Program"
            };

            while (true)
            {
                DisplayMenu(menuOptions);

                Console.Write("Make Your Selection From the Menu (1-5) ");
                string choice = Console.ReadLine();

                if (int.TryParse(choice, out int selectedOption) && selectedOption >= 1 && selectedOption <= menuOptions.Length)
                {
                    switch (selectedOption)
                    {
                        case 1:
                            studentRecordCreator.CreateStudentRecord();
                            break;
                        case 2:
                            studentMarks.EnterStudentMarksData();
                            break;
                        case 3:
                            updateStudentMarks.UpdateStudentMarksData();
                            break;
                        case 4:
                            viewStudentDataRecord.ViewStudentData();
                            break;
                        case 5:
                            json.SaveStudentDataPerma();
                            json.LoadPermaStudentData();

                            Console.WriteLine("");
                            Console.WriteLine("Please Press Any Key To Confirm Exiting The Program");
                            Console.ReadKey();
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Invalid Selection, Please Choose An Option 1 - 5");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Selection, Please Choose An Option 1 - 5");
                }
            }
        }

        private void DisplayMenu(string[] menuOptions)
        {
            Console.WriteLine("Menu Choices:");
            for (int i = 0; i < menuOptions.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {menuOptions[i]}");
            }
            Console.WriteLine("");
        }
    }
}