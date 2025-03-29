//program will run from program.cs

using System;

class Calculator  // Base Class
{
    protected double num1, num2;

    public Calculator(double num1, double num2)  // Constructor
    {
        this.num1 = num1;
        this.num2 = num2;
    }

    public virtual double Calculate()  // Virtual method for polymorphism
    {
        return 0;
    }

    public void DisplayResult()
    {
        Console.WriteLine($"Result: {Calculate()}");
    }

    ~Calculator()  // Destructor
    {
        Console.WriteLine("Calculator object destroyed.");
    }
}

// Derived classes for different operations
class Addition : Calculator
{
    public Addition(double num1, double num2) : base(num1, num2) { }
    public override double Calculate() => num1 + num2;
}

class Subtraction : Calculator
{
    public Subtraction(double num1, double num2) : base(num1, num2) { }
    public override double Calculate() => num1 - num2;
}

class Multiplication : Calculator
{
    public Multiplication(double num1, double num2) : base(num1, num2) { }
    public override double Calculate() => num1 * num2;
}

class Division : Calculator
{
    public Division(double num1, double num2) : base(num1, num2) { }

    public override double Calculate()
    {
        if (num2 == 0)
            throw new DivideByZeroException("Error: Cannot divide by zero!");
        return num1 / num2;
    }
}

// Function Overloading Example
class MathOperations
{
    public static double Square(double num) => num * num;
    public static double Square(int num) => num * num;
}

// Calculator Application Logic
class CalculatorApp
{
    public static void RunCalculator()
    {
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("\n===== Calculator Application (OOP) =====");
            Console.WriteLine("1. Addition");
            Console.WriteLine("2. Subtraction");
            Console.WriteLine("3. Multiplication");
            Console.WriteLine("4. Division");
            Console.WriteLine("5. Square (Function Overloading)");
            Console.WriteLine("6. Exit");
            Console.Write("Enter your choice: ");

            string choice = Console.ReadLine();
            double num1 = 0, num2 = 0;

            if (choice != "5" && choice != "6")
            {
                try
                {
                    Console.Write("Enter first number: ");
                    num1 = Convert.ToDouble(Console.ReadLine());

                    Console.Write("Enter second number: ");
                    num2 = Convert.ToDouble(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Invalid input! {ex.Message}");
                    continue;
                }
            }

            try
            {
                Calculator calc;
                switch (choice)
                {
                    case "1":
                        calc = new Addition(num1, num2);
                        calc.DisplayResult();
                        break;
                    case "2":
                        calc = new Subtraction(num1, num2);
                        calc.DisplayResult();
                        break;
                    case "3":
                        calc = new Multiplication(num1, num2);
                        calc.DisplayResult();
                        break;
                    case "4":
                        calc = new Division(num1, num2);
                        calc.DisplayResult();
                        break;
                    case "5":
                        Console.Write("Enter a number to square: ");
                        double sqNum = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine($"Square (double overload): {MathOperations.Square(sqNum)}");
                        Console.WriteLine($"Square (int overload): {MathOperations.Square((int)sqNum)}");
                        break;
                    case "6":
                        exit = true;
                        Console.WriteLine("Exiting calculator...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }
        }
    }
}
