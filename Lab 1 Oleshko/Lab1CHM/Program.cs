using System;

class Program
{
    static double Function(double x)
    {
        return 3 * x * Math.Log(x) - Math.Pow(x - 2, 2) + 2;
    }

    static double FunctionDerivative(double x)
    {
        return 3 * (Math.Log(x) + 1) - 2 * (x - 2);
    }

    static void SimpleIterationMethod(double initialApproximation, double epsilon)
    {
        double x = initialApproximation;
        double previousX;

        int iteration = 0;
        Console.WriteLine("Simple Iteration Method:");
        Console.WriteLine("e = {0}, Initial Approximation = {1}", epsilon, initialApproximation);
        Console.WriteLine("k\t xk\t\t xk - x(k-1)\t\t f(xk)");

        do
        {
            previousX = x;
            x = Math.Pow(Math.Exp(1), (Math.Pow(previousX - 2, 2) - 2) / previousX / 3);


            double error = Math.Abs(x - previousX);
            double functionValue = Function(x);

            Console.WriteLine("{0}\t {1:F10}\t {2:F10}\t {3:F10}", iteration, x, x - previousX, functionValue);

            iteration++;
        } while (Math.Abs(x - previousX) > epsilon);

        Console.WriteLine();
    }

    static void NewtonMethod(double initialApproximation, double epsilon)
    {
        double x = initialApproximation;

        int iteration = 0;
        Console.WriteLine("Newton's Method:");
        Console.WriteLine("e = {0}, Initial Approximation = {1}", epsilon, initialApproximation);
        Console.WriteLine("k\t xk\t\t xk - x(k-1)\t\t f(xk)");

        do
        {
            double previousX = x;
            x = previousX - Function(previousX) / FunctionDerivative(previousX);

            double error = Math.Abs(x - previousX);
            double functionValue = Function(x);

            Console.WriteLine("{0}\t {1:F10}\t {2:F10}\t {3:F10}", iteration, x, x - previousX, functionValue);

            iteration++;
        } while (Math.Abs(Function(x)) > epsilon);

        Console.WriteLine();
    }

    static void ModifiedNewtonMethod(double initialApproximation, double epsilon)
    {
        double x = initialApproximation;

        int iteration = 0;
        Console.WriteLine("Modified Newton's Method:");
        Console.WriteLine("e = {0}, Initial Approximation = {1}", epsilon, initialApproximation);
        Console.WriteLine("k\t xk\t\t xk - x(k-1)\t\t f(xk)");

        do
        {
            double previousX = x;
            double derivative = FunctionDerivative(previousX);

            if (Math.Abs(derivative) < 1e-10)
            {
                Console.WriteLine("Derivative is close to zero. Modified Newton's method cannot be applied.");
                return;
            }

            x = previousX - Function(previousX) / derivative;

            double error = Math.Abs(x - previousX);
            double functionValue = Function(x);

            Console.WriteLine("{0}\t {1:F10}\t {2:F10}\t {3:F10}", iteration, x, x - previousX, functionValue);

            iteration++;
        } while (Math.Abs(Function(x)) > epsilon);

        Console.WriteLine();
    }

    static void Main()
    {
        double epsilon = 1e-5;
        double initialApproximation = 2.5;

        SimpleIterationMethod(initialApproximation, epsilon);
        NewtonMethod(initialApproximation, epsilon);
        ModifiedNewtonMethod(initialApproximation, epsilon);

        Console.ReadLine();
    }
}
