using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITPAssignment1
{
    internal class StudentIDGenerator
    {
        // Generate Random Student ID Number
        public static string GenerateStudentID()
        {
            Random rand = new Random();
            int number = rand.Next(10000000, 99999999);
            return number.ToString();
        }
    }
}
