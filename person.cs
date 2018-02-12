using System;
using System.Collections.Generic;
using System.Text;

namespace Person
{
	public class Person
	{

		// member properties
		public int Age;
		public string FirstName;
		public string LastName;
		public Person Spouse;

		// class static properties
		private static double averageAge = 0.0;
		private static Person youngestSingle;
		private static Person youngestMarried;
		private static Person oldestSingle;
		private static Person oldestMarried;
		private static int Count = 0;		// keeps track of number of Persons instantiated
		private static int TotalAge = 0;	// a running total of age of all persons


		public Person() : this (null, null, 0) { }      // no arg ctor


		public Person(string firstname, string lastname, int age)	// ctor for a spouse person
		{
			Age = age;
			FirstName = firstname;
			LastName = lastname;
			Spouse = null;
			Count++;
			TotalAge += Age;
			AverageAge = calculateAvgAge(TotalAge, Count);
		}

		public Person(string firstname, string lastname, int age, string spouseFirstname, int spouseAge)
		{
			Age = age;
			FirstName = firstname;
			LastName = lastname;
			Count++;
			TotalAge += Age;
			AverageAge = calculateAvgAge(TotalAge, Count);

			if (!(String.IsNullOrEmpty(spouseFirstname)))
			{
				Spouse = new Person(spouseFirstname, lastname, spouseAge);
				Spouse.Spouse = this;   // link Spouse back to original person

				// identify the oldest/youngest married Person
				if ((oldestMarried == null) || (spouseAge > oldestMarried.Age))
				{
					oldestMarried = Spouse;
				}
				if ((youngestMarried == null) || (spouseAge < youngestMarried.Age))
				{
					youngestMarried = Spouse;
				}
				if ((oldestMarried == null) || (Age > oldestMarried.Age))
				{
					oldestMarried = this;
				}
				if ((youngestMarried == null) || (Age < youngestMarried.Age))
				{
					youngestMarried = this;
				}
			}
			else  // not married, identify oldest/youngest
			{
				if ((oldestSingle == null) || (Age > oldestSingle.Age))
				{
					oldestSingle = this;
				}
				if (( YoungestSingle == null) || (Age < youngestSingle.Age))
				{
					youngestSingle = this;
				}
			}
		}

		private double calculateAvgAge(int ages, int numberOfPeople)
		{
			double calculatedAverageAge = 0.0;
			double myAges = System.Convert.ToDouble(ages);     // convert before division to preserve decimal precision
			double myCount = System.Convert.ToDouble(numberOfPeople);

			if (numberOfPeople != 0)	// avoid dividing by 0
			{
				calculatedAverageAge = (myAges / numberOfPeople);
			}

			return calculatedAverageAge;
		}

		public static Person YoungestSingle
		{
			get
			{
				return youngestSingle;
			}
			private set
			{
				youngestSingle = value;
			}
		}

		public static Person YoungestMarried
		{
			get
			{
				return youngestMarried;
			}
			private set
			{
				youngestMarried = value;
			}
		}

		public static Person OldestSingle
		{
			get
			{
				return oldestSingle;
			}
			private set
			{
				oldestSingle = value;
			}
		}

		public static Person OldestMarried
		{
			get
			{
				return oldestMarried;
			}
			private set
			{
				oldestMarried = value;
			}
		}

		public static double AverageAge
		{
			get
			{
				return averageAge;
			}
			private set
			{
				if (value >= 0)
				{
					averageAge = value;
				}
				else
				{
					Console.WriteLine(" Invalid AverageAge ({0}) set to 1.", value);
					averageAge = 1.0;
				}
			}
		}


		public void DisplayPersonInfo(int personId)		// the requirements have an id number shown for each person, hence the parameter
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
				Console.WriteLine("Person #" + personId + " Married?   \t\t:  no");
			}
			Console.WriteLine();
		}

		public static void DisplayStaticVars()
		{
			Console.WriteLine();
			if (OldestSingle != null)
			{
				Console.WriteLine("OLDEST SINGLE\t\t:  " + oldestSingle.FirstName + " " + oldestSingle.LastName);
			}
			if (youngestSingle != null)
			{
				Console.WriteLine("YOUNGEST SINGLE\t\t:  " + youngestSingle.FirstName + " " + YoungestSingle.LastName);
			}
			if (oldestMarried != null)
			{
				Console.WriteLine("OLDEST MARRIED\t\t:  " + oldestMarried.FirstName + " " + oldestMarried.LastName);
			}
			if (youngestMarried != null)
			{
				Console.WriteLine("YOUNGEST MARRIED\t:  " + youngestMarried.FirstName + " " + youngestMarried.LastName);
			}
			Console.WriteLine("AVERAGE AGE\t\t:  {0:F1}", averageAge);
		}

		public static Person getPersonInformation()
		{
			Console.WriteLine("Enter The Person's First Name:");
			string firstName = Console.ReadLine();
			Console.WriteLine("Enter The Person's Last Name:");
			string lastName = Console.ReadLine();
			Console.WriteLine("Enter The Person's Age:");
			int age = 0;
			try
			{
				age = Convert.ToInt32(Console.ReadLine());
			}
			catch
			{
				Console.WriteLine("Age should be an Integer");
			}

			Console.WriteLine("Does person have a spouse? Enter y or n");
			string hasSpouse = Console.ReadLine();
			string spouseName = null;
			int spouseAge = 0;

			if (hasSpouse == "Y" || hasSpouse == "y")
			{

				Console.WriteLine("Enter Spouse'e First Name:");
				spouseName = Console.ReadLine();
				Console.WriteLine("Enter Spouse'e Age:");
				try
				{
					spouseAge = Convert.ToInt32(Console.ReadLine());
				}
				catch
				{
					Console.WriteLine("Age should be an Integer");
				}
			}


			Person myPerson = new Person(firstName, lastName, age, spouseName, spouseAge);

			Console.WriteLine();

			return myPerson;
		}

	}
}
