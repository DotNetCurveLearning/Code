using static System.Console;

namespace Packt.Shared;

public class Person
{

	public string? FirstName { get; set; }
	public string? LastName { get; set; }
	public DateTime DateOfBirth { get; set; }
	public HashSet<Person> Children { get; set; }
	public decimal Salary { get; set; }

	public Person(decimal initialSalary)
	{
		initialSalary = initialSalary;
	}
}