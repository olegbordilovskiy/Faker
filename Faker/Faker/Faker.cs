using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Faker.Faker
{
	public class Faker : IFaker
	{
		public T Create<T>()
		{
			return (T)Create(typeof(T));
		}
		private object Create(Type type)
		{
			if (type.GetCustomAttributes(typeof(DtoAttribute), true).Length > 0)
			{
				var instance = Activator.CreateInstance(type);

				var propertiesAndFields = type.GetMembers(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public)
											   .Where(member => member.MemberType == MemberTypes.Field || member.MemberType == MemberTypes.Property)
											   .ToList();

				foreach (var member in propertiesAndFields)
				{
					var memberType = member is PropertyInfo ? ((PropertyInfo)member).PropertyType : ((FieldInfo)member).FieldType;

					if (memberType.GetCustomAttributes(typeof(DtoAttribute), true).Length > 0)
					{
						var memberValue = Create(memberType);
						if (member is PropertyInfo property)
						{
							property.SetValue(instance, memberValue);
						}
						else if (member is FieldInfo field)
						{
							field.SetValue(instance, memberValue);
						}
					}
					else
					{
						var randomValue = Generator.GenerateRandom(memberType);
						if (member is PropertyInfo property)
						{
							property.SetValue(instance, randomValue);
						}
						else if (member is FieldInfo field)
						{
							field.SetValue(instance, randomValue);
						}
					}
				}

				return instance;
			}
			else
			{
				return Generator.GenerateRandom(type);
			}
		}

	}

}
