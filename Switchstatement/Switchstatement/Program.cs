// See https://aka.ms/new-console-template for more information
using System;

Console.WriteLine("Enter student mark");
int mark = Convert.ToInt32(Console.ReadLine());

switch (mark)
{
    case int k when (k >= 80 && k <= 100):
        Console.WriteLine("Outstanding");
        break;
    case int k when (k >= 70 && k <= 79):
        Console.WriteLine("Meritorious");
        break;
    case int k when (k >= 60 && k <= 69):
        Console.WriteLine("Substantial");
        break;
    case int k when (k >= 50 && k <= 59):
        Console.WriteLine("Moderate");
        break;
    case int k when (k >= 40 && k <= 49):
        Console.WriteLine("Adequate");
        break;
    case int k when (k >= 30 && k <= 39):
        Console.WriteLine("Elementary");
        break;
    case int k when (k >= 0 && k <= 29):
        Console.WriteLine("Not achieved");
        break;
        default:
        Console.WriteLine("Invalid input. Enter between 1 to 100");
            break;
}