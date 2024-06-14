// See https://aka.ms/new-console-template for more information
int num1, num2;

do
{
    Console.WriteLine("Enter first positive integer");
} while (!int.TryParse(Console.ReadLine(), out num1) || num1 <= 0);

do
{
    Console.WriteLine("Enter second integer");
} while (!int.TryParse(Console.ReadLine(),out num2) || num2 <=0);

int sum = num1 + num2;
Console.WriteLine($"Sum of {num1} and {num2} is: {sum}");