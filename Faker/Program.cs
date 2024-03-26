namespace Faker
{
	internal class Program
	{
		static void Main(string[] args)
		{
			var faker = new Faker.Faker();
			TestClass testClass = faker.Create<TestClass>();
			Console.WriteLine("df");

			
		}
	}
}
