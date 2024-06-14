// See https://aka.ms/new-console-template for more information

using Student_graduation;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

class Program
{
    public delegate void gpaHandle(double GPA);

    static void NotifyUser(double GPA)
    {
        if (GPA >= 3.5 && GPA < 3.7)
        {
            Console.WriteLine("Student eligible for Cum laude");
        }
        else if (GPA >= 3.8 && GPA <3.9)
        {
            Console.WriteLine("Student eligible for Magna cum laude");
        }
        else if (GPA >= 4.0)
        {
            Console.WriteLine("Student is eligible for Summa cum laude");
        }
    }

    static void Main(string[] args)
    {
       
        List<Student> students = new List<Student>();

        bool Student = true;

        while (Student)
        {
            Console.WriteLine("Enter student name:");
            string Name = Console.ReadLine();

            Console.WriteLine("Enter student surname:");
            string Surname = Console.ReadLine();

            Console.WriteLine("Enter Student number:");
            string StudentNumber = (Console.ReadLine());

            Console.WriteLine("Enter GPA score:");
            double GPA = Convert.ToDouble(Console.ReadLine());
            

            if (string.IsNullOrWhiteSpace(Name) || string.IsNullOrWhiteSpace(Surname) || string.IsNullOrWhiteSpace(StudentNumber))
            {
                Console.WriteLine("Invalid input. Please provide all details.");
                continue;
            }

            // Check for duplicate names
            if (students.Any(s => string.Equals(s.Name, Name, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("Student with this name already exists. Please enter a unique name.");
                continue;
            }

            Student newStudent = new Student(Name, Surname, StudentNumber, GPA);
            students.Add(newStudent);

            Console.WriteLine("Add student? (yes/no)");
            string userinput = Console.ReadLine();
            
            if (userinput.ToLower() != "yes")
            {
                (Student) = false;
            }
            
            
        }
        var alphaOrder = students.OrderBy(x => x.Name).ToList();

        Console.WriteLine("Student list:");

        foreach (Student student in alphaOrder)
        {
            Console.WriteLine($"Student: {student.Name} {student.Surname} \n Student Number: {student.StudentNumber}");
        }

        Console.WriteLine("Enter 'quit' to leave or any key to display student");
        string input = Console.ReadLine();

        while (input.ToLower() !="quit")
        {
            Console.WriteLine("Which student do you want to diaplay");
            string User = Console.ReadLine();

            var findStudent = alphaOrder.FirstOrDefault(x => string.Equals(x.Name, User, StringComparison.OrdinalIgnoreCase));

            if (findStudent != null)
            {
                Console.WriteLine($"Name: {findStudent.Name}\n Surname: {findStudent.Surname}\n Student Number: {findStudent.StudentNumber}\n GPA score: {findStudent.GPA}");
                NotifyUser(findStudent.GPA);
            }
            else
            {
                Console.WriteLine("Student does not exist.");
            }
            Console.WriteLine("Enter 'quit' to leave or any key to display student");
            input = Console.ReadLine();
        }
        Console.WriteLine("Thank You");
    }
}
