namespace StudentResultProcessingSystem;

class Program
{
    static string[] _names = new string[3];
    static string[] _ids = new string[3];
    static string[] _programmes = new string[3];
    static string[] _levels = new string[3];
    static double[,] _scores = new double[3, 5];
    static string[] _courseNames = { "Programming with C#", "Database Systems", "Computer Networks", "Web Development", "Mathematics for Computing" };

    static void Main()
    {
        bool running = true;
        while (running)
        {
            Console.Clear();
            Console.WriteLine("===== STUDENT RESULTS PROCESSING SYSTEM =====");
            Console.WriteLine("1. Enter Student Results");
            Console.WriteLine("2. View Student Report");
            Console.WriteLine("3. Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine() ?? "";

            switch (choice)
            {
                case "1":
                    StudentMenu();
                    break;
                case "2":
                    ReportMenu();
                    break;
                case "3":
                    Console.WriteLine("Thank you for using the Student Results Processing System.");
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid option. Press any key to try again.");
                    Console.ReadKey();
                    break;
            }
        }
    }

    static void StudentMenu()
    {
        for (int i = 0; i < 3; i++)
        {
            Console.Clear();
            Console.WriteLine($"=== Enter Details for Student {i + 1} ===");

            Console.Write("Enter full name: ");
            _names[i] = Console.ReadLine() ?? "";

            Console.Write("Enter student ID: ");
            _ids[i] = Console.ReadLine() ?? "";

            Console.Write("Enter programme: ");
            _programmes[i] = Console.ReadLine() ?? "";

            Console.Write("Enter level: ");
            _levels[i] = Console.ReadLine() ?? "";

            for (int j = 0; j < 5; j++)
            {
                double score;
                Console.Write($"Enter score for {_courseNames[j]}: ");
                while (!double.TryParse(Console.ReadLine() ?? "", out score) || score < 0 || score > 100)
                {
                    Console.WriteLine("Invalid score. Score must be between 0 and 100.");
                    Console.Write($"Re-enter score for {_courseNames[j]}: ");
                }
                _scores[i, j] = score;
            }

            Console.WriteLine($"Student {i + 1} details saved. Press any key to continue.");
            Console.ReadKey();
        }
    }

    static void ReportMenu()
    {
        Console.Clear();
        Console.WriteLine("===== STUDENT RESULTS REPORT =====\n");

        for (int i = 0; i < 3; i++)
        {
            double total = 0;
            for (int j = 0; j < 5; j++)
                total += _scores[i, j];
            double average = total / 5;

            string grade;
            if (average >= 80) grade = "A";
            else if (average >= 70) grade = "B";
            else if (average >= 60) grade = "C";
            else if (average >= 50) grade = "D";
            else grade = "F";

            string status = average >= 50 ? "Passed" : "Failed";

            Console.WriteLine($"Student Name : {_names[i]}");
            Console.WriteLine($"Student ID   : {_ids[i]}");
            Console.WriteLine($"Programme    : {_programmes[i]}");
            Console.WriteLine($"Level        : {_levels[i]}\n");

            for (int j = 0; j < 5; j++)
                Console.WriteLine($"  {_courseNames[j]}: {_scores[i, j]}");

            Console.WriteLine($"\n  Total Score  : {total}");
            Console.WriteLine($"  Average Score: {average:F2}");
            Console.WriteLine($"  Grade        : {grade}");
            Console.WriteLine($"  Status       : {status}");
            Console.WriteLine(new string('-', 45));
        }

        Console.WriteLine("\nPress any key to return to the main menu.");
        Console.ReadKey();
    }
}