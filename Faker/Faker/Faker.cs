using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faker.Faker
{
	internal class Faker : IFaker
	{
		public T Create<T>()
		{
			return (T)Create(typeof(T));
		}
		private object Create(Type type) 
		{
			return new object();
		}
	}

}
