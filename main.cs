using System.Diagnostics;
using ProjectEuler;

var running = true;
while (running)
{
    Console.WriteLine("Choose Option");
    Console.WriteLine("[0] Exit the program");
    Console.WriteLine("[N > 0] Solve Problem N");

    var input = Console.ReadLine();
    Console.WriteLine();
    switch (input)
    {
        case "0":
            running = false;
            break;
        default:
            int problemNumber = Convert.ToInt32(input);
            var problem = Helper.GetProblem(problemNumber);
            Stopwatch stopwatch = Stopwatch.StartNew();
            Console.WriteLine("Solving Problem...");
            Console.WriteLine($"Answer = {problem.Solve()}");
            stopwatch.Stop();
            Console.WriteLine($"Time passed = {stopwatch.Elapsed}");
            break;
    }
    Console.WriteLine();

}


