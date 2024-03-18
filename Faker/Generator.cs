using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faker
{
	public static class Generator
	{
		private static Random _random = new Random();
		private static Dictionary<Type, Func<object>> _dictionary = new Dictionary<Type, Func<object>>()
		{
			{ typeof(int), () => GetRandomInt()},
			{ typeof(long), () => GetRandomLong() },
			{ typeof(double), () => GetRandomDouble() },
			{ typeof(float), () => GetRandomFloat() },
			{ typeof(bool), () => GetRandomBool() },
			{ typeof(char), () => GetRandomChar() },
			{ typeof(string), () => GetRandomString() },
		};

		public static object GenerateRandom(Type type)
		{
			if (_dictionary.ContainsKey(type))
			{
				return _dictionary[type].Invoke();
			}
			else
			{
				throw new Exception("Type is not supported");
			}
		}
		private static int GetRandomInt()
		{
			return _random.Next();
		}
		private static long GetRandomLong()
		{
			return _random.NextInt64();
		}
		private static float GetRandomFloat()
		{
			return (float)_random.NextDouble();
		}
		private static double GetRandomDouble()
		{
			return _random.NextDouble();
		}
		private static bool GetRandomBool()
		{
			int flag = _random.Next(0, 1);
			if (flag == 1) return true;
			return false;
		}
		private static char GetRandomChar()
		{
			const int PRINTABLE_START = 32;
			const int PRINTABLE_END = 126;
			return (char)_random.Next(PRINTABLE_START, PRINTABLE_END);
		}
		public static string GetRandomString()
		{
			const int PRINTABLE_START = 32;
			const int PRINTABLE_END = 126;

			StringBuilder stringBuilder = new StringBuilder();
			int stringSize = _random.Next(1, 100);
			for (int i = 0; i < stringSize; i++)
			{
				stringBuilder.Append((char)_random.Next(PRINTABLE_START, PRINTABLE_END));
			}
			return stringBuilder.ToString();
		}
		public static DateTime GetRandomDateTime()
		{
			const int DAY_SECONDS = 86400;
			var dateTime = new DateTime(1, 1, 1);
			int days = _random.Next(2000000);
			int time = _random.Next(DAY_SECONDS);
			dateTime = dateTime.AddDays(days);
			dateTime = dateTime.AddSeconds(time);
			return dateTime;	
		}
	}
}
