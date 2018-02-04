using System;
using System.Collections.Generic;
using System.Text;

namespace Person
{
	public class Person
	{

		// member properties
		public int Age = 0;
		public string FirstName = "";
		public string LastName = "";
		public Person Spouse;

		// class static properties
		static double AverageAge = 0.0;
		static Person YoungestSingle;
		static Person YoungestMarried;
		static Person OldestSingle;
		static Person OlsestMarried;


		//public Person(Person Spouse)
		//{
		//	this.Spouse = Spouse;
		//}


		public void DisplayPersonInfo(int personId)
		{
			Console.WriteLine("Person #" + personId + " First Name \t\t:  " + this.FirstName);
			Console.WriteLine("Person #" + personId + " Last Name \t\t:  " + this.LastName);
			Console.WriteLine("Person #" + personId + " Age \t\t\t:  " + this.Age);
			if (this.Spouse != null)
			{
				Console.WriteLine("Person #" + personId + " Married?   \t\t:  yes");
				Console.WriteLine("Person #" + personId + " Spouse First Name   \t:  " + this.Spouse.FirstName);
				Console.WriteLine("Person #" + personId + " Spouse Age   \t\t:  " + this.Spouse.Age);
			}
			else
			{
				Console.WriteLine("Person #" + personId + "Married?   \t\t:  no");
			}

		}

		public void GetPersionInfo()
		{
			Console.WriteLine("Enter The Person's First Name:");
			this.FirstName = Console.ReadLine();
			Console.WriteLine("Enter The Person's Last Name:");
			this.LastName = Console.ReadLine();
			Console.WriteLine("Enter The Person's Age:");
			try
			{
				this.Age = Convert.ToInt32(Console.ReadLine());
			}
			catch
			{
				Console.WriteLine("Age should be an Integer");
			}
			Console.WriteLine();
		}
	}
}
