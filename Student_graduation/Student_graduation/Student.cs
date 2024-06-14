using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_graduation
{
    class Student
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string StudentNumber { get; set; }
        public double GPA { get; set; }

        public Student(string Name, string Surname, string StudentNumber, double GPA)
        {
            this.Name = Name;
            this.Surname = Surname;
            this.StudentNumber = StudentNumber;
            this.GPA = GPA;
        }

            }
}
