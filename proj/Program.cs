using System;

class Student
{
    private int studentID;
    private string name;
    private int[] grades = new int[5];

    public Student(int studentID, string name, int[] grades)
    {
        this.studentID = studentID;
        this.name = name;
        this.grades = grades;
    }

    public int getStudentID()
    {
        return studentID;
    }

    public void setStudentID(int studentID)
    {
        this.studentID = studentID;
    }

    public string getName()
    {
        return name;
    }

    public void setName(string name)
    {
        this.name = name;
    }

    public int[] getGrades()
    {
        return grades;
    }

    public void setGrades(int[] grades)
    {
        this.grades = grades;
    }

    public double calculateAverageGrade()
    {
        double sum = 0;
        for (int i = 0; i < grades.Length; i++)
        {
            sum += grades[i];
        }
        return sum / grades.Length;
    }

    public int getMaxGrade()
    {
        int max = grades[0];
        for (int i = 1; i < grades.Length; i++)
        {
            if (grades[i] > max)
            {
                max = grades[i];
            }
        }
        return max;
    }

    public int getMinGrade()
    {
        int min = grades[0];
        for (int i = 1; i < grades.Length; i++)
        {
            if (grades[i] < min)
            {
                min = grades[i];
            }
        }
        return min;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Student[] students = new Student[3];
        int studentID;
        string name;
        int[] grades = new int[5];

        for (int i = 0; i < students.Length; i++)
        {
            Console.WriteLine("Enter details for student " + (i + 1));
            Console.Write("Student ID: ");
            studentID = Convert.ToInt32(Console.ReadLine());
            Console.Write("Name: ");
            name = Console.ReadLine();
            Console.WriteLine("Grades:");
            for (int j = 0; j < grades.Length; j++)
            {
                Console.Write("Grade " + (j + 1) + ": ");
                grades[j] = Convert.ToInt32(Console.ReadLine());
            }
            students[i] = new Student(studentID, name, grades);
        }

        bool quit = false;
        while (!quit)
        {
            Console.WriteLine("\nSelect an operation to perform:");
            Console.WriteLine("1. Calculate average grade for a student");
            Console.WriteLine("2. Get max and min grade for a student");
            Console.WriteLine("3. Get max and min grade for all students");
            Console.WriteLine("4. Sort students by name");
            Console.WriteLine("5. Search for a student by ID");
            Console.WriteLine("6. Quit");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Enter student ID: ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    for (int i = 0; i < students.Length; i++)
                    {
                        if (students[i].getStudentID() == id)
                        {
                            Console.WriteLine("Average grade: " + students[i].calculateAverageGrade());
                            break;
                        }
                    }
                    break;

                case 2:
                    Console.Write("Enter student ID: ");
                    int id2 = Convert.ToInt32(Console.ReadLine());
                    for (int i = 0; i < students.Length; i++)
                    {
                        if (students[i].getStudentID() == id2)
                        {
                            Console.WriteLine("Max grade: " + students[i].getMaxGrade());
                            Console.WriteLine("Min grade: " + students[i].getMinGrade());
                            break;
                        }
                    }
                    break;

                case 3:
                    int maxGrade = students[0].getMaxGrade();
                    int minGrade = students[0].getMinGrade();
                    for (int i = 1; i < students.Length; i++)
                    {
                        if (students[i].getMaxGrade() > maxGrade)
                        {
                            maxGrade = students[i].getMaxGrade();
                        }
                        if (students[i].getMinGrade() < minGrade)
                        {
                            minGrade = students[i].getMinGrade();
                             
                        }
                    }
                    Console.WriteLine("Max grade for all students: " + maxGrade);
                    Console.WriteLine("Min grade for all students: " + minGrade);
                    break;

                case 4:
                    Array.Sort(students, delegate (Student s1, Student s2) {
                        return s1.getName().CompareTo(s2.getName());
                    });
                    Console.WriteLine("Students sorted by name:");
                    foreach (Student s in students)
                    {
                        Console.WriteLine(s.getStudentID() + " " + s.getName());
                    }
                    break;

                case 5:
                    Console.Write("Enter student ID: ");
                    int id3 = Convert.ToInt32(Console.ReadLine());
                    bool found = false;
                    for (int i = 0; i < students.Length; i++)
                    {
                        if (students[i].getStudentID() == id3)
                        {
                            Console.WriteLine(students[i].getStudentID() + " " + students[i].getName());
                            found = true;
                            break;
                        }
                    }
                    if (!found)
                    {
                        Console.WriteLine("Student not found.");
                    }
                    break;

                case 6:
                    quit = true;
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}