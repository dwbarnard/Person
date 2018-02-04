using System;

namespace Person
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Assignment #1  Person");

			Person myPerson1 = new Person();

			Console.WriteLine("Enter The Person's First Name:");
			myPerson1.FirstName = Console.ReadLine();
			Console.WriteLine("Enter The Person's Last Name:");
			myPerson1.LastName = Console.ReadLine();
			Console.WriteLine("Enter The Person's Age:");
			try
			{
				myPerson1.Age = Convert.ToInt32(Console.ReadLine());
			}
			catch
			{
				Console.WriteLine("Age should be an Integer");
			}
			Console.WriteLine("Does person have a spouse? Enter y or n");
			string hasSpouse = Console.ReadLine();
			if (hasSpouse == "Y" || hasSpouse == "y")
			{
				Person mySpouse = new Person();
				mySpouse.LastName = myPerson1.LastName;
				mySpouse.Spouse = myPerson1;
				myPerson1.Spouse = mySpouse;
				Console.WriteLine("Enter Spouse'e First Name:");
				mySpouse.FirstName = Console.ReadLine();
				Console.WriteLine("Enter Spouse'e Age:");
				try
				{
					mySpouse.Age = Convert.ToInt32(Console.ReadLine());
				}
				catch
				{
					Console.WriteLine("Age should be an Integer");
				}

			}

			Console.WriteLine();


			myPerson1.DisplayPersonInfo(1);

			Console.WriteLine("\n\n\nPress Enter key to end program");
			Console.ReadLine();
		}


	}
}
