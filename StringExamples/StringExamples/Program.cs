// See https://aka.ms/new-console-template for more information
Console.WriteLine("Enter name:");
String name = Console.ReadLine();
Console.WriteLine(name.ToLower());
Console.WriteLine("Enter surname:");
String surname = Console.ReadLine();
Console.WriteLine(surname.ToUpper());
String fullName = name + "\t" + surname;
Console.WriteLine(fullName);
int Char = fullName.IndexOf(surname[0]);
String identity = fullName.Substring(Char);
Console.WriteLine(identity);
