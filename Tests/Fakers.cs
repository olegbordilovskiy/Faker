using Tests.DTOs;
using Xunit;


namespace Tests
{
	public class FakerTests
	{
		[Fact]
		public void Create_DTO_With_Public_Properties()
		{
			var faker = new Faker.Faker.Faker();
			var dto = faker.Create<WithPublicProperties>();

			Assert.NotNull(dto);
			Assert.NotEqual(default(int), dto.IntProperty);
			Assert.NotEqual(default(DateTime), dto.DateTimeProperty);
			Assert.NotNull(dto.StringProperty);
			Assert.NotNull(dto.IntList);
			Assert.NotNull(dto.StringList);
		}

		[Fact]
		public void Create_DTO_With_Private_Constructor()
		{
			var faker = new Faker.Faker.Faker();
			var dto = faker.Create<WithPrivateConstructor>();
			Assert.NotNull(dto);
			Assert.NotEqual(default(int), dto.IntProperty);
			Assert.NotEqual(default(string), dto.StringProperty);
			Assert.NotEqual(default(DateTime), dto.DateTimeProperty);
			Assert.NotNull(dto.IntList);
			Assert.NotNull(dto.StringList);
		}

		[Fact]
		public void Create_DTO_With_Multiple_Constructors()
		{
			var faker = new Faker.Faker.Faker();
			var dto = faker.Create<WithMultipleConstructors>();

			Assert.NotNull(dto);
			Assert.NotEqual(default(int), dto.IntProperty);
			Assert.NotEqual(default(string), dto.StringProperty);
			Assert.NotEqual(default(DateTime), dto.DateTimeProperty);
			Assert.NotNull(dto.IntList);
			Assert.NotNull(dto.StringList);
		}

		//[Fact]
		//public void Create_DTO_With_Cyclic_Dependencies()
		//{
		//	var faker = new Faker.Faker.Faker();
		//	var dto = faker.Create<DtoWithCyclicDependencies>();

		//	Assert.NotNull(dto);
		//	Assert.NotNull(dto.Child);
		//	Assert.NotNull(dto.Child.Parent);
		//	Assert.Same(dto, dto.Child.Parent);
		//}
	}
}
