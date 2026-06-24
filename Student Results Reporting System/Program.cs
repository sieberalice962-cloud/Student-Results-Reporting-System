using System;

class Program
{
    static void Main()
    {
        const int numberOfCourses = 5;

        Console.Write("Enter number of students: ");
        int numberOfStudents = int.Parse(Console.ReadLine() ?? "0");

        string[] studentNames = new string[numberOfStudents];
        string[] studentIDs = new string[numberOfStudents];
        string[] programmes = new string[numberOfStudents];
        string[] levels = new string[numberOfStudents];

        int[,] scores = new int[numberOfStudents, numberOfCourses];

        double[] averages = new double[numberOfStudents];

        bool dataEntered = false;

        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("==============================================");
            Console.WriteLine("   STUDENT RESULTS PROCESSING SYSTEM");
            Console.WriteLine("==============================================");
            Console.WriteLine();

            Console.WriteLine("1. Enter Student Results");
            Console.WriteLine("2. View Student Report");
            Console.WriteLine("3. Exit");

            Console.WriteLine();
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine() ?? "";

            switch (choice)
            {
                case "1":

                    string[] courses =
                    {
                        "Programming with C#",
                        "Database Systems",
                        "Computer Networks",
                        "Web Development",
                        "Mathematics for Computing"
                    };

                    for (int i = 0; i < numberOfStudents; i++)
                    {
                        Console.WriteLine();
                        Console.WriteLine($"Enter details for Student {i + 1}");
                        Console.WriteLine();

                        Console.Write("Enter Full Name : ");
                        studentNames[i] = Console.ReadLine() ?? "";

                        Console.Write("Enter Student ID: ");
                        studentIDs[i] = Console.ReadLine() ?? "";

                        Console.Write("Enter Programme : ");
                        programmes[i] = Console.ReadLine() ?? "";

                        Console.Write("Enter Level     : ");
                        levels[i] = Console.ReadLine() ?? "";

                        Console.WriteLine();

                        for (int j = 0; j < numberOfCourses; j++)
                        {
                            while (true)
                            {
                                Console.Write($"Enter score for {courses[j]}: ");

                                if (int.TryParse(Console.ReadLine(), out int score)
                                    && score >= 0 && score <= 100)
                                {
                                    scores[i, j] = score;
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Invalid score. Score must be between 0 and 100.");
                                }
                            }
                        }

                        Console.WriteLine();
                    }

                    dataEntered = true;
                    Console.WriteLine("Student results saved successfully.");
                    break;

                case "2":

                    if (!dataEntered)
                    {
                        Console.WriteLine("\nPlease enter student results first.");
                        break;
                    }

                    int bestStudentIndex = 0;
                    double highestAverage = 0;

                    int lowestStudentIndex = 0;
                    double lowestAverage = 100;

                    double classTotal = 0;

                    string[] courseNames =
                    {
                        "Programming with C#",
                        "Database Systems",
                        "Computer Networks",
                        "Web Development",
                        "Mathematics for Computing"
                    };

                    for (int i = 0; i < numberOfStudents; i++)
                    {
                        int total = 0;

                        Console.WriteLine();
                        Console.WriteLine("========================================");
                        Console.WriteLine("      STUDENT RESULTS REPORT");
                        Console.WriteLine("========================================");
                        Console.WriteLine();

                        Console.WriteLine($"Student Name : {studentNames[i]}");
                        Console.WriteLine($"Student ID   : {studentIDs[i]}");
                        Console.WriteLine($"Programme    : {programmes[i]}");
                        Console.WriteLine($"Level        : {levels[i]}");

                        Console.WriteLine();

                        for (int j = 0; j < numberOfCourses; j++)
                        {
                            Console.WriteLine($"{courseNames[j],-28}: {scores[i, j]}");
                            total += scores[i, j];
                        }

                        double average = total / 5.0;
                        averages[i] = average;

                        classTotal += average;

                        if (average > highestAverage)
                        {
                            highestAverage = average;
                            bestStudentIndex = i;
                        }

                        if (average < lowestAverage)
                        {
                            lowestAverage = average;
                            lowestStudentIndex = i;
                        }

                        string grade;

                        if (average >= 80)
                            grade = "A";
                        else if (average >= 70)
                            grade = "B";
                        else if (average >= 60)
                            grade = "C";
                        else if (average >= 50)
                            grade = "D";
                        else
                            grade = "F";

                        string status = average >= 50 ? "Passed" : "Failed";

                        Console.WriteLine();

                        Console.WriteLine($"Total Score   : {total}");
                        Console.WriteLine($"Average Score : {average:F1}");
                        Console.WriteLine($"Grade         : {grade}");
                        Console.WriteLine($"Status        : {status}");

                        Console.WriteLine();
                    }

                    double classAverage = classTotal / numberOfStudents;

                    Console.WriteLine("========================================");
                    Console.WriteLine("          CLASS SUMMARY");
                    Console.WriteLine("========================================");
                    Console.WriteLine();

                    Console.WriteLine($"Class Average : {classAverage:F1}");

                    Console.WriteLine();
                    Console.WriteLine("BEST STUDENT");
                    Console.WriteLine("----------------------------------------");
                    Console.WriteLine($"Name    : {studentNames[bestStudentIndex]}");
                    Console.WriteLine($"ID      : {studentIDs[bestStudentIndex]}");
                    Console.WriteLine($"Average : {highestAverage:F1}");

                    Console.WriteLine();
                    Console.WriteLine("LOWEST AVERAGE STUDENT");
                    Console.WriteLine("----------------------------------------");
                    Console.WriteLine($"Name    : {studentNames[lowestStudentIndex]}");
                    Console.WriteLine($"ID      : {studentIDs[lowestStudentIndex]}");
                    Console.WriteLine($"Average : {lowestAverage:F1}");

                    Console.WriteLine();
                    Console.WriteLine("========================================");

                    break;

                case "3":

                    Console.WriteLine();
                    Console.WriteLine("Thank you for using the Student Results Processing System.");
                    return;

                default:

                    Console.WriteLine();
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
}