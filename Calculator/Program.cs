using System;

class Calculator
{
    static int whichNumber = 1;

    static void Main()
    {
        while (true)
        {
            Console.Clear();
            MakeCalculator();

            Console.SetCursorPosition(1, 14);  // Set cursor position for the welcome message
            Console.Write("Welcome to The Calculator(tm)");

            Console.SetCursorPosition(2, 4);  // Set cursor position for the first number
            double num1 = GetNumber();

            Console.SetCursorPosition(2, 6);  // Set cursor position for the operator
            char op = GetOperator();

            Console.SetCursorPosition(2, 8);  // Set cursor position for the second number
            double num2 = GetNumber();

            double result = PerformCalculation(num1, op, num2);

            Console.SetCursorPosition(2, 4);  // Set cursor position for the result line
            Console.Write($"{result,22}");

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
}