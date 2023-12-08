using System;

class Calculator
{
    static int whichNumber = 1;

    static void Main()
    {
        double num1 = 0; // Initialize num1 to store the result

        while (true)
        {
            Console.Clear();
            MakeCalculator();

            Console.SetCursorPosition(1, 14);  // Set cursor position for the welcome message
            Console.Write("Welcome to The Calculator(tm)");

            if (whichNumber == 1)
            {
                Console.SetCursorPosition(2, 4);  // Set cursor position for the first number
                num1 = GetNumber();
            }

            char op = GetOperator();

            while (true)
            {
                Console.SetCursorPosition(1, 1);  // Set cursor position for the result/first number
                Console.Write(num1);

                Console.SetCursorPosition(1, 2);  // Set cursor position for the operator
                Console.Write(op);

                Console.SetCursorPosition(1, 3);  // Set cursor position for the new number
                double num2 = GetNumber();

                num1 = PerformCalculation(num1, op, num2);

                Console.SetCursorPosition(2, 4);  // Set cursor position for the result line
                Console.Write($"{num1,22}");

                Console.SetCursorPosition(2, 15);  // Set cursor position for the prompt
                Console.Write("Press Enter to continue or an operator to start a new calculation...");

                var keyInfo = Console.ReadKey(true);

                if (keyInfo.Key == ConsoleKey.Enter)
                {
                    ClearLines(3, 3); // Clear lines 3 to 3 (user input)
                    break;
                }
                else if (keyInfo.KeyChar == '+' || keyInfo.KeyChar == '-' || keyInfo.KeyChar == '*' || keyInfo.KeyChar == '/')
                {
                    ClearLines(3, 3); // Clear lines 3 to 3 (user input)
                    op = keyInfo.KeyChar;
                }
            }

            whichNumber++; // Increment whichNumber after the first iteration

            if (!MoreCalculations())
            {
                break;
            }
        }
    }

    private static void MakeCalculator()
    {
        Console.WriteLine("|-----------------------|");
        Console.WriteLine("|                       |");
        Console.WriteLine("|                       |");
        Console.WriteLine("|                       |");
        Console.WriteLine("|                       |");
        Console.WriteLine("|-----------------------|");
        Console.WriteLine("|  1  |  2  |  3  |  +  |");
        Console.WriteLine("|-----------------------|");
        Console.WriteLine("|  4  |  5  |  6  |  -  |");
        Console.WriteLine("|-----------------------|");
        Console.WriteLine("|  7  |  8  |  9  |  *  |");
        Console.WriteLine("|-----------------------|");
        Console.WriteLine("|        0        |  /  |");
        Console.WriteLine("|-----------------------|");
    }

    static double GetNumber()
    {
        if (whichNumber == 1)
        {
            Console.SetCursorPosition(1, 1);  // Set cursor position for the first number
        }
        else if (whichNumber == 2)
        {
            Console.SetCursorPosition(1, 3);  // Set cursor position for the second number
        }

        whichNumber++;

        while (true)
        {
            if (double.TryParse(Console.ReadLine(), out double number))
            {
                return number;
            }
            else
            {
                //Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }
    }

    static char GetOperator()
    {
        while (true)
        {
            Console.SetCursorPosition(1, 2);  // Set cursor position for the operator
            char op = Console.ReadKey().KeyChar;
            Console.WriteLine();

            if (op == '+' || op == '-' || op == '*' || op == '/')
            {
                return op;
            }
            else
            {
                Console.SetCursorPosition(1, 3);  // Set cursor position for the error message
                //Console.WriteLine("Invalid operator. Please enter a valid operator (+, -, *, /).");
            }
        }
    }
    //Performing the calculations based on input
    static double PerformCalculation(double num1, char op, double num2)
    {
        switch (op)
        {
            case '+':
                return num1 + num2;
            case '-':
                return num1 - num2;
            case '*':
                return num1 * num2;
            case '/':
                if (num2 != 0)
                {
                    return num1 / num2;
                }
                else
                {
                    Console.WriteLine("Cannot divide by zero. Please enter a non-zero second number.");
                    return 0;
                }
            default:
                Console.WriteLine("Invalid operator. Please enter a valid operator (+, -, *, /).");
                return 0;
        }
    }

    static bool MoreCalculations()
    {
        char key;

        do
        {
            Console.SetCursorPosition(2, 15);  // Set cursor position for the result line
            Console.Write("Do you want to perform another calculation? (y/n): ");
            key = Console.ReadKey().KeyChar;
            Console.WriteLine();

            if (key != 'y' && key != 'n')
            {
                Console.WriteLine("Invalid input. Please enter 'y' or 'n'.");
            }
        } while (key != 'y' && key != 'n');

        whichNumber = 1; // Reset whichNumber for the next iteration
        return key == 'y';
    }
    // Method to clear specific lines on the console
    static void ClearLines(int startLine, int endLine)
    {
        for (int i = startLine; i <= endLine; i++)
        {
            Console.SetCursorPosition(1, i);
            Console.Write(new string(' ', Console.WindowWidth));
        }
    }
}