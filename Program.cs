using System;

namespace StudentManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            var physics = new Course("P01");
            physics.CourseName = "physics";

            var kostas = new Student();
            kostas.Name = "name";
            kostas.Level = LevelId.FirstGrade;
            kostas.Age = 25;
            kostas.EnrollToCourse(physics);
            kostas.Grade = Student.CalculateMark(78);

            // few months later
            kostas.WithdrawFromCourse();

            //Console.WriteLine($"the mark is: {kostas.Grade}\nAge is : {kostas.Age} ");
            Console.WriteLine(kostas);
        }

        class Course
        {
            public string CourseName { get; set; }
            public string Code { get; private set; }
            public string InstructorName { get; set; }

            public Course(string code)
            {
                Code = code;
            }
        }
        class Student
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public LevelId Level { get; set; }

            private Course EnrolledCourse { get; set; }

            public string Grade { get; set; }

            public void EnrollToCourse(Course course)
            {
                if (Age >= 18)
                {
                    EnrolledCourse = course;
                }
                else
                {
                    Console.WriteLine("You cannot yet enroll to any courses");
                }
            }

            public void WithdrawFromCourse()
            {
                EnrolledCourse = null;
            }

            public override string ToString()
            {
                return $"Name:{Name}, Course name {EnrolledCourse?.CourseName}";
            }

            public static string CalculateMark(int mark)
            {
                if (mark > 100 || mark < 0)
                {
                    return "Wrong Mark";
                }
                else if (mark >= 90)
                {
                    return "A";
                }
                else if (mark >= 70)
                {
                    return "B";
                }
                else if (mark >= 50)
                {
                    return "C";
                }
                else
                {
                    return "F";
                }
            }
        }


    }

}

