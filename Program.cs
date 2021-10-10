using System;
using System.Collections.Generic;

namespace Homework_10102564__ข้อ1
{
    enum Menu
    {
        RegisterNewStudent = 1,
        RegisterNewTeacher,
        GetListPersons
    }
    class PersonList
    {
        private List<Person> personList;

        public PersonList()
        {
            this.personList = new List<Person>();
        }

        public void AddNewPerson(Person person)
        {
            this.personList.Add(person);
        }

        public void FetchPersonsList()
        {
            Console.WriteLine("List Persons");
            Console.WriteLine("---------------------");
            foreach (Person person in this.personList)
            {
                if (person is StudentInfo)
                {
                    Console.WriteLine("Name: {0} \nType: Student \n", person.GetName());

                }
                else if (person is TeacherInfo)
                {
                    Console.WriteLine("Name: {0} \nType: Teacher \n", person.GetName());

                }
            }
        }
    }
    class Inputinformation
    {
        static public string InputName()
        {
            Console.Write("Name: ");
            return Console.ReadLine();
        }
        static public string InputStudentID()
        {
            Console.Write("Student ID: ");
            return Console.ReadLine();
        }
        static public string InputAddress()
        {
            Console.Write("Address: ");
            return Console.ReadLine();
        }
        static public string InputCitizenID()
        {
            Console.Write("Citizen ID: ");
            return Console.ReadLine();
        }
        static public string InputEmployeeID()
        {
            Console.Write("Employee ID: ");
            return Console.ReadLine();
        }
    }
    class Person
    {
        protected string name;
        protected string address;
        protected string citizenID;
        public Person(string name, string address, string citizenID)
        {
            this.name = name;
            this.address = address;
            this.citizenID = citizenID;
        }
        public string GetName()
        {
            return this.name;
        }
    }
    class StudentInfo : Person
    {
        private string studentID;
        public StudentInfo(string name, string address, string citizenID, string studentID)
        : base(name, address, citizenID)
        {
            this.studentID = studentID;
        }
        static public void ShowInputRegisterNewStudentScreen()
        {
            Console.Clear();
            PrintHeaderRegisterStudent();
            int totalStudent = TotalNewStudents();
            InputNewStudentFromKeyboard(totalStudent);
        }
        static public void PrintHeaderRegisterStudent()
        {
            Console.WriteLine("Register new student.");
            Console.WriteLine("---------------------");
        }
        static int TotalNewStudents()
        {
            Console.Write("Input Total new Student: ");

            return int.Parse(Console.ReadLine());
        }
        static void InputNewStudentFromKeyboard(int totalStudent)
        {
            for (int i = 0; i < totalStudent; i++)
            {
                Console.Clear();
                StudentInfo.PrintHeaderRegisterStudent();
                StudentInfo student = CreateNewStudent();
                Program.personList.AddNewPerson(student);
            }
            Console.Clear();
            Program.PrintMenuScreen();
        }
        static StudentInfo CreateNewStudent()
        {
            return new StudentInfo(Inputinformation.InputName(),
            Inputinformation.InputAddress(),
            Inputinformation.InputCitizenID(),
            Inputinformation.InputStudentID());
        }

    }
    class TeacherInfo : Person
    {
        private string employeeID;

        public TeacherInfo(string name, string address, string citizenID, string employeeID)
        : base(name, address, citizenID)
        {
            this.employeeID = employeeID;
        }
        static public void ShowInputRegisterNewTeacherScreen()
        {
            Console.Clear();
            PrintHeaderRegisterTeacher();
            int totalTeacher = TotalNewTeacher();
            InputNewTeacherFromKeyboard(totalTeacher);
        }
        static void PrintHeaderRegisterTeacher()
        {
            Console.WriteLine("Register new teacher.");
            Console.WriteLine("---------------------");
        }
        static int TotalNewTeacher()
        {
            Console.Write("Input Total new Teacher: ");
            return int.Parse(Console.ReadLine());
        }
        static void InputNewTeacherFromKeyboard(int totalTeacher)
        {
            for (int i = 0; i < totalTeacher; i++)
            {
                Console.Clear();
                PrintHeaderRegisterTeacher();
                TeacherInfo teacher = CreateNewTeacher();
                Program.personList.AddNewPerson(teacher);
            }
            Console.Clear();
            Program.PrintMenuScreen();
        }
        static TeacherInfo CreateNewTeacher()
        {
            return new TeacherInfo(Inputinformation.InputName(),
                Inputinformation.InputAddress(),
                Inputinformation.InputCitizenID(),
                Inputinformation.InputEmployeeID());
        }

    }
    
    class Program
    {
        static public PersonList personList;
        static void Main(string[] args)
        {
            PreparePersonListWhenProgramIsLoad();
            PrintMenuScreen();

        }
        static public void PrintMenuScreen()
        {
            Console.Clear();
            Menupage();
            InputMenuFromKeyboard();
        }
        static void Menupage()
        {
            Console.WriteLine("Welcome to registration new user school application.");
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("1. Register new student.");
            Console.WriteLine("2. Register new Teacher.");
            Console.WriteLine("3. Get List Persons.");

        }
        static public void InputMenuFromKeyboard()
        {
            Console.Write("Please Select Menu: ");
            Menu menu = (Menu)(int.Parse(Console.ReadLine()));
            PresentMenu(menu);
        }
        static void PreparePersonListWhenProgramIsLoad()
        {
            Program.personList = new PersonList();
        }
        static void PresentMenu(Menu menu)
        {
            if (menu == Menu.RegisterNewStudent)
            {
                StudentInfo.ShowInputRegisterNewStudentScreen();
            }
            else if (menu == Menu.RegisterNewTeacher)
            {
                TeacherInfo.ShowInputRegisterNewTeacherScreen();
            }
            else if (menu == Menu.GetListPersons)
            {
                ShowGetListPersonScreen();
            }
            else
            {
                ShowMessageInputMenuIsInCorrect();
            }
        }
        static void ShowGetListPersonScreen()
        {
            Console.Clear();
            Program.personList.FetchPersonsList();
            InputExitFromKeyboard();
        }
        static void ShowMessageInputMenuIsInCorrect()
        {
            Console.Clear();
            Console.WriteLine("Menu Incorrect Please try again.");
            Program.InputMenuFromKeyboard();
        }
        
        static void InputExitFromKeyboard()
        {
            string text = "";
            while (text != "exit")
            {
                Console.WriteLine("Input: ");
                text = Console.ReadLine();
            }
            Console.Clear();
            PrintMenuScreen();
        }

    }
}
